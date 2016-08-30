using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MusicBeePlugin
{
    public partial class WordKanaDictionary : Form
    {
        private const string DefaultFileName = "MB_SortOrderTagCreationPluginUserDic.xml";
        private const string DefaultFileDialogFilter = "ユーザー辞書ファイル(*.xml)|*.xml";

        private string configPath;

        public WordKanaDictionary(string configPath)
        {
            this.configPath = configPath;
            InitializeComponent();

            Config.Instance.Load(configPath);

            configBindingSource.DataSource = Config.Instance;
            configBindingSource.DataMember = "WordKanaCollection";
        }

        private void ImportExportTemplate<TDialog>(bool append)
            where TDialog : FileDialog, new()
        {
            /* 
             * FileDialog を継承するクラスは OpenFileDialog と SaveFileDialog のみなので
             * (dialog is OpenFileDialog) が false ならば、 dialog の型は SaveFileDialog ただ一つに定まる
             */
            using (var dialog = new TDialog())
            {
                dialog.AddExtension = true;
                dialog.CheckFileExists = (dialog is OpenFileDialog);
                dialog.CheckPathExists = (dialog is OpenFileDialog);
                dialog.DefaultExt = "xml";
                dialog.FileName = DefaultFileName;
                dialog.Filter = DefaultFileDialogFilter;
                dialog.FileOk += (sender, e) =>
                    {
                        if (dialog is OpenFileDialog)
                        {
                            UserDictionaryPorter.Import(dialog.FileName, append);
                        }
                        else // dialog is SaveFileDialog
                        {
                            UserDictionaryPorter.Export(dialog.FileName);
                        }
                    };
                dialog.ShowDialog(this);
            }
        }

        private void ExportTemplate()
        {
            this.ImportExportTemplate<SaveFileDialog>(false);
        }


        private void dataGridView_wordKanaPairs_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            string headerText = dgv.Columns[e.ColumnIndex].HeaderText;

            switch (headerText)
            {
                case "有効":
                    dgv.ImeMode = ImeMode.Disable;
                    break;
                case "単語":
                case "読み":
                    dgv.ImeMode = ImeMode.Hiragana;
                    break;
            }
        }

        private void dataGridView_wordKanaPairs_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgv = (DataGridView)sender;

            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    int columnPos = 0, rowPos = dgv.RowHeadersWidth;
                    foreach (int current in Enumerable.Range(0, e.ColumnIndex))
                    {
                        columnPos += dgv.Columns[current].Width;
                    }
                    foreach (int current in Enumerable.Range(0, e.RowIndex))
                    {
                        rowPos += dgv.Rows[current].Height;
                    }

                    if (!dgv.Rows[e.RowIndex].IsNewRow)
                    {
                        DataGridViewCell cell = dataGridView_wordKanaPairs[e.ColumnIndex, e.RowIndex];
                        dgv.ClearSelection();
                        cell.Selected = true;

                        contextMenuStrip_dgv.Show((Control)sender, columnPos, rowPos);
                    }
                }
            }
        }

        private void toolStripMenuItem_delete_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView_wordKanaPairs.CurrentCell.RowIndex;
            
            DataGridViewRow currentRow = dataGridView_wordKanaPairs.Rows[selectedIndex];
            if (currentRow != null && !currentRow.IsNewRow)
            {
                dataGridView_wordKanaPairs.Rows.RemoveAt(selectedIndex);
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Config.Instance.Save(this.configPath);
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem_importOverwrite_Click(object sender, EventArgs e)
        {
            this.ImportExportTemplate<OpenFileDialog>(false);
        }

        private void toolStripMenuItem_importAdd_Click(object sender, EventArgs e)
        {
            this.ImportExportTemplate<OpenFileDialog>(true);
        }

        private void toolStripMenuItem_export_Click(object sender, EventArgs e)
        {
            this.ExportTemplate();
        }
    }

    static class UserDictionaryPorter
    {
        public static void Import(string path, bool append)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("ファイルが見つかりません。");
                return;
            }

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var serializer = new XmlSerializer(typeof(WordKanaCollection));
                WordKanaCollection data = null;
                try
                {
                    data = serializer.Deserialize(fs) as WordKanaCollection;
                    if (data != null)
                    {
                        if (append)
                        {
                            Config.Instance.WordKanaCollection.AddRange(
                                data.Where(wkp =>
                                    {
                                        string[] words = Config.Instance.WordKanaCollection
                                            .Select(item => item.Word)
                                            .ToArray();
                                        return !words.Contains(wkp.Word);
                                    }));
                        }
                        else
                        {
                            Config.Instance.WordKanaCollection = data;
                        }
                    }
                    else throw new InvalidOperationException();
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("ユーザー辞書の復元に失敗しました。");
                }
            }
        }

        public static void Export(string path)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                var serializer = new XmlSerializer(typeof(WordKanaCollection));
                serializer.Serialize(fs, Config.Instance.WordKanaCollection);
            }
        }
    }
}
