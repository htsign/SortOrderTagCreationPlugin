using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicBeePlugin.Windows.Forms
{
    using System.Threading;
    using Extensions.Core;
    using Net.Yomi;
    using static Plugin;

    public partial class Translator : Form
    {
        private const int RemainingTimeUpdateInterval = 100;

        private MusicBeeApiInterface mbApiInterface;
        private string[] songs;
        private YomiGetterBase getter;
        private Stopwatch sw = new Stopwatch();
        private Timer startRemainingUpdating;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        #region public properties
        private int completed = 0;
        public int Completed
        {
            get => completed;
            set => Task.Factory.StartNew(() =>
                {
                    label_completedCount.Text = value.ToString();
                    progressBar_completed.Value = value;
                    completed = value;
                },
                CancellationToken.None, TaskCreationOptions.None, uiScheduler);
        }
        #endregion

        #region constructors
        public Translator(MusicBeeApiInterface api, string[] songs, APIEngine engine)
        {
            InitializeComponent();

            mbApiInterface = api;
            this.songs = songs;
            getter = YomiGetterBase.Create(engine);

            tokenSource.Token.Register(() =>
            {
                startRemainingUpdating.Change(Timeout.Infinite, Timeout.Infinite);
                startRemainingUpdating.Dispose();
            });

            label_entireCount.Text = songs.Length.ToString();
            progressBar_completed.Maximum = songs.Length;
        }
        #endregion

        #region public methods
        public async Task TranslateSongsAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                foreach (string path in songs)
                {
                    AddSortOrderTagToFileAsync(path)
                        .ContinueWith(_ => ++Completed)
                        .Wait(tokenSource.Token);
                }
            }, tokenSource.Token)

            .ContinueWith(_ =>
                MessageBox.Show("タグ付けが完了しました。"),
                TaskContinuationOptions.OnlyOnRanToCompletion)
            .ContinueWith(_ =>
                MessageBox.Show("ユーザーの操作により中断されました。"),
                TaskContinuationOptions.OnlyOnCanceled)
            .ContinueWith(_ => Close(), uiScheduler);
        }

        public void SetRemainingTime(TimeSpan remaining)
        {
            Task.Factory.StartNew(() =>
            {
                if (label_remainingTime.IsDisposed) return;
                label_remainingTime.Text = remaining.ToString();
            },
            CancellationToken.None, TaskCreationOptions.None, uiScheduler);
        }
        #endregion

        #region private methods
        private async Task AddSortOrderTagToFileAsync(string filepath)
        {
            var song = new SongFile(mbApiInterface, filepath);

            string query = string.Join(YomiGetterBase.Separator,
                song.Artist, song.AlbumArtist, song.TrackTitle, song.Album, song.Composer);

            // まずユーザー辞書で変換を行う
            foreach (WordKanaPair wkp in Config.Instance.WordKanaCollection)
            {
                // 最初と最後の文字を削った文字列を格納
                string pattern = wkp.Word.Substring(1, wkp.Word.Length - 2);

                query = wkp.Word.IsWrappedWith("/", "/") && pattern.IsRegexPattern()
                    ? Regex.Replace(query, pattern, wkp.Kana)
                    : query.Replace(wkp.Word, wkp.Kana);
            }

            // カタカナ、半角カナを平仮名に変換する
            query = TextTranslation.Translate(query);

            // 漢字以外を変換対象とさせないため一旦退避する
            TextTranslation.ChangeOriginToTemporary(ref query, out string[] options);

            // 漢字が含まれていればWebAPIでさらに変換する
            bool containsKanji = Regex.IsMatch(query, Config.Instance.MatchesRegExp);
            string result = containsKanji ? await getter?.GetYomiAsync(query) : query;

            if (result != null)
            {
                // 退避させておいたアルファベットと記号を戻す
                TextTranslation.ChangeTemporaryToOrigin(ref result, options);

                // タグの書き込み
                string[] resultParts = result.Split(YomiGetterBase.Separator);
                song.WriteTag(Config.Instance.SortArtist,      resultParts[0]);
                song.WriteTag(Config.Instance.SortAlbumArtist, resultParts[1]);
                song.WriteTag(Config.Instance.SortTitle,       resultParts[2]);
                song.WriteTag(Config.Instance.SortAlbum,       resultParts[3]);
                song.WriteTag(Config.Instance.SortComposer,    resultParts[4]);
                song.Commit();
            }
        }
        #endregion

        #region event handlers
        private void Remaining_Load(object sender, EventArgs e)
        {
            Location = new Point(
                Owner.Location.X + (Owner.Width  - Width)  / 2,
                Owner.Location.Y + (Owner.Height - Height) / 2);
            SetRemainingTime(TimeSpan.FromSeconds(0));
        }

        private async Task Remaining_ShownAsync(object sender, EventArgs e)
        {
            startRemainingUpdating = new Timer(_ =>
                {
                    double parTime = sw.Elapsed.TotalSeconds / Completed;
                    int remainingTime = (int)(parTime * (songs.Length - Completed));

                    SetRemainingTime(TimeSpan.FromSeconds(remainingTime));
                },
                null, 0, RemainingTimeUpdateInterval);
            
            sw.Start();

            await TranslateSongsAsync();
        }

        private void Remaining_FormClosed(object sender, FormClosedEventArgs e)
        {
            tokenSource.Cancel(true);
        }

        private void button_terminate_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            button.Enabled = false;
            tokenSource.Cancel(true);
            Text = "中断しました。";
        }
        #endregion
    }
}
