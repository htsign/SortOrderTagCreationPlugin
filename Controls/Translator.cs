using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicBeePlugin.Extensions;
using static MusicBeePlugin.Plugin;

namespace MusicBeePlugin
{
    using System.Threading;

    public partial class Translator : Form
    {
        private const int RemainingTimeUpdateInterval = 100;

        private MusicBeeApiInterface mbApiInterface;
        private string[] songs;
        private Stopwatch sw = new Stopwatch();
        private Timer startRemainingUpdating;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        public Translator(MusicBeeApiInterface api, string[] songs)
        {
            InitializeComponent();

            mbApiInterface = api;
            this.songs = songs;

            label_entireCount.Text = songs.Length.ToString();
            progressBar_completed.Maximum = songs.Length;
        }

        #region public properties
        private int completed = 0;
        public int Completed
        {
            get { return completed; }
            set
            {
                new Task(() =>
                {
                    label_completedCount.Text = value.ToString();
                    completed = value;
                })
                .RunSynchronously(uiScheduler);
            }
        }

        private bool isOpened = false;
        public bool IsOpened => isOpened;

        public bool Terminated => tokenSource.IsCancellationRequested;
        #endregion

        #region public methods
        public async Task TranslateSongsAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                var tasks = new List<Task>();

                foreach (string path in songs)
                {
                    Task task = AddSortOrderTagToFileAsync(path);
                    task.ContinueWith(_ => ++Completed);
                    tasks.Add(task);
                }
                Task.WaitAll(tasks.ToArray());
            }, tokenSource.Token)
            .ContinueWith(_ => MessageBox.Show("タグ付けが完了しました。"),
                TaskContinuationOptions.OnlyOnRanToCompletion)
            .ContinueWith(_ => MessageBox.Show("ユーザーの操作により中断されました。"),
                TaskContinuationOptions.OnlyOnCanceled)
            .ContinueWith(_ => Close());
        }

        public async Task SetRemainingTimeAsync(TimeSpan remaining)
        {
            await Task.Factory.StartNew(() =>
            {
                if (label_remainingTime.IsDisposed) return;
                label_remainingTime.Text = remaining.ToString();
            },
            tokenSource.Token, TaskCreationOptions.None, uiScheduler);
        }
        #endregion

        #region private methods
        private async Task AddSortOrderTagToFileAsync(string filepath)
        {
            var song = new SongFile(mbApiInterface, filepath);

            string query = string.Join(YomiGetter.Separator,
                song.Artist, song.AlbumArtist, song.TrackTitle, song.Album, song.Composer);
            string[] options;

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
            TextTranslation.ChangeOriginToTemporary(ref query, out options);

            string result;
            if (Regex.IsMatch(query, Config.Instance.MatchesRegExp))
            {
                // 漢字が含まれていればWebAPIでさらに変換する
                YomiGetter getter = YomiGetter.Create(Config.Instance.APIEngine, query);
                result = await getter?.GetYomiAsync();
            }
            else
            {
                // 漢字がなければ変換を終了
                result = query;
            }

            if (result != null)
            {
                // 退避させておいたアルファベットと記号を戻す
                TextTranslation.ChangeTemporaryToOrigin(ref result, options);

                // タグの書き込み
                string[] resultParts = result.Split(YomiGetter.Separator);
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
        private async void Remaining_LoadAsync(object sender, EventArgs e)
        {
            Location = new Point(
                Owner.Location.X + (Owner.Width  - Width)  / 2,
                Owner.Location.Y + (Owner.Height - Height) / 2);
            await SetRemainingTimeAsync(TimeSpan.FromSeconds(0));
        }

        private async void Remaining_ShownAsync(object sender, EventArgs e)
        {
            startRemainingUpdating = new Timer(async _ =>
                {
                    double parTime = sw.Elapsed.TotalSeconds / Completed;
                    int remainingTime = (int)(parTime * (songs.Length - Completed));

                    await SetRemainingTimeAsync(TimeSpan.FromSeconds(remainingTime));
                },
                null, 0, RemainingTimeUpdateInterval);

            isOpened = true;
            sw.Start();

            await TranslateSongsAsync();
        }

        private void Remaining_FormClosed(object sender, FormClosedEventArgs e)
        {
            tokenSource.Cancel(true);
            startRemainingUpdating.Change(Timeout.Infinite, Timeout.Infinite);
            startRemainingUpdating.Dispose();
        }

        private async void label_completedCount_TextChangedAsync(object sender, EventArgs e)
        {
            var label = (Label)sender;

            await Task.Factory.StartNew(
                () => progressBar_completed.Value = int.Parse(label.Text),
                tokenSource.Token, TaskCreationOptions.None, uiScheduler);
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
