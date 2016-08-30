using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MusicBeePlugin.Extensions;

namespace MusicBeePlugin
{
    public partial class ConfigureControl : UserControl
    {
        private string configPath;
        private int customTagsBeforeSelectedIndex = 0;

        public ConfigureControl(string configPath)
        {
            this.configPath = configPath;
            InitializeComponent();
        }

        private void Initialize()
        {
            Plugin.MetaDataType[] customTags = Enum.GetValues(typeof(Plugin.MetaDataType))
                .Cast<Plugin.MetaDataType>()
                .Where(type => type.ToString().StartsWith("Custom"))
                .ToArray();
            string[] engines = Enum.GetValues(typeof(APIEngine))
                .Cast<APIEngine>()
                .Select(engine => Config.GetEngineName(engine))
                .ToArray();

            comboBox_customTagArtist.DataSource      = customTags.Clone();
            comboBox_customTagAlbumArtist.DataSource = customTags.Clone();
            comboBox_customTagTitle.DataSource       = customTags.Clone();
            comboBox_customTagAlbum.DataSource       = customTags.Clone();
            comboBox_customTagComposer.DataSource    = customTags.Clone();
            comboBox_apiEngine.DataSource = engines;

            Config.Instance.Load(this.configPath);

            checkBox_customTagArtist.Checked                    = Config.Instance.SortArtist.Enabled;
            comboBox_customTagArtist.SelectedItem               = Config.Instance.SortArtist.SortTag;
            checkBox_customTagAlbumArtist.Checked               = Config.Instance.SortAlbumArtist.Enabled;
            comboBox_customTagAlbumArtist.SelectedItem          = Config.Instance.SortAlbumArtist.SortTag;
            checkBox_customTagTitle.Checked                     = Config.Instance.SortTitle.Enabled;
            comboBox_customTagTitle.SelectedItem                = Config.Instance.SortTitle.SortTag;
            checkBox_customTagAlbum.Checked                     = Config.Instance.SortAlbum.Enabled;
            comboBox_customTagAlbum.SelectedItem                = Config.Instance.SortAlbum.SortTag;
            checkBox_customTagComposer.Checked                  = Config.Instance.SortComposer.Enabled;
            comboBox_customTagComposer.SelectedItem             = Config.Instance.SortComposer.SortTag;
            checkBox_addSortOrderTagsWhenLibraryChanged.Checked = Config.Instance.AddSortOrderTagsWhenLibraryChanged;
            checkBox_dontOverwrite.Checked                      = Config.Instance.DontOverwrite;
            comboBox_apiEngine.SelectedItem                     = Config.GetEngineName(Config.Instance.APIEngine);
            textBox_regExpMatches.Text                          = Config.Instance.MatchesRegExp;
            textBox_regExpReplaces.Text                         = Config.Instance.ReplacesRegExp;

            // 切り替え時にConfigインスタンス内部も変更
            List<CheckBox> customTagCheckBoxes = groupBox_customTags.GetAllControls<CheckBox>().ToList();
            List<ComboBox> customTagComboBoxes = groupBox_customTags.GetAllControls<ComboBox>().ToList();
            PropertyInfo sctPiEnabled = typeof(SortCustomTag).GetProperty("Enabled");
            PropertyInfo sctPiSortTag = typeof(SortCustomTag).GetProperty("SortTag");
            customTagCheckBoxes.ForEach(cb =>
                {
                    string category = cb.Name.Substring("comboBox_customTag".Length);
                    PropertyInfo cPi = typeof(Config).GetProperty("Sort" + category);

                    cb.CheckedChanged += (sender, e) =>
                        {
                            SortCustomTag ct = (SortCustomTag)cPi.GetValue(Config.Instance, null);
                            var newSct = new SortCustomTag(
                                cb.Checked,
                                (Plugin.MetaDataType)sctPiSortTag.GetValue(ct, null));
                            cPi.SetValue(Config.Instance, newSct, null);

                            // チェックが1つの場合は外せないようにする
                            if (customTagCheckBoxes.Count(c => c.Checked) == 1)
                            {
                                customTagCheckBoxes.Single(c => c.Checked).Enabled = false;
                            }
                            else
                            {
                                customTagCheckBoxes.ForEach(c => c.Enabled = true);
                            }
                        };
                });
            customTagComboBoxes.ForEach(cb =>
                {
                    string category = cb.Name.Substring("comboBox_customTag".Length);
                    PropertyInfo cPi = typeof(Config).GetProperty("Sort" + category);

                    cb.TextChanged += (sender, e) =>
                        {
                            SortCustomTag ct = (SortCustomTag)cPi.GetValue(Config.Instance, null);
                            var newSct = new SortCustomTag(
                                (bool)sctPiEnabled.GetValue(ct, null),
                                customTags[cb.SelectedIndex]);
                            cPi.SetValue(Config.Instance, newSct, null);
                        };
                });
        }

        private void ConfigureControl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void comboBox_customTags_Enter(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            this.customTagsBeforeSelectedIndex = comboBox.SelectedIndex;
        }

        private void comboBox_customTags_TextChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            IEnumerable<ComboBox> customTagComboBoxes = groupBox_customTags.GetAllControls<ComboBox>();
            
            foreach (ComboBox current in customTagComboBoxes)
            {
                if (comboBox == current) continue;
                if (comboBox.SelectedIndex == current.SelectedIndex)
                {
                    current.SelectedIndex = this.customTagsBeforeSelectedIndex;
                }
            }
        }

        private void checkBox_addSortOrderTagsWhenLibraryChanged_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            Config.Instance.AddSortOrderTagsWhenLibraryChanged = checkBox.Checked;
        }

        private void checkBox_dontOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            Config.Instance.DontOverwrite = checkBox.Checked;
        }

        private void comboBox_apiEngine_TextChanged(object sender, EventArgs e)
        {
            APIEngine[] engines = Enum.GetValues(typeof(APIEngine))
                .Cast<APIEngine>()
                .ToArray();

            var comboBox = (ComboBox)sender;
            Config.Instance.APIEngine = engines[comboBox.SelectedIndex];
        }

        private void textBox_regExpMatches_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            try
            {
                string re = new Regex(textBox.Text).ToString();
                textBox.ResetBackColor();
                Config.Instance.MatchesRegExp = textBox.Text;
            }
            catch (ArgumentException)
            {
                textBox.BackColor = Color.Red;
            }
        }

        private void textBox_regExpReplaces_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            try
            {
                string re = new Regex(textBox.Text).ToString();
                textBox.ResetBackColor();
                Config.Instance.ReplacesRegExp = textBox.Text;
            }
            catch (ArgumentException)
            {
                textBox.BackColor = Color.Red;
            }
        }

        private void button_userDic_Click(object sender, EventArgs e)
        {
            var userDicForm = new WordKanaDictionary(this.configPath);
            var preferencesForm = (Form)this.TopLevelControl;

            DialogResult dr = userDicForm.ShowDialog(preferencesForm);
            if (dr == DialogResult.OK)
            {
                // 再初期化
                this.Initialize();
            }
        }

        private void linkLabel_attensionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var self = (LinkLabel)sender;
            Process.Start(self.Tag as string);
        }

        #region TextBox RightClickMenu
        private TextBox lastActivatedTextBox = null;

        private void textBox_regExps_Enter(object sender, EventArgs e)
        {
            this.lastActivatedTextBox = (TextBox)sender;
        }

        private void 全選択AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lastActivatedTextBox != null)
                this.lastActivatedTextBox.SelectAll();
        }

        private void 切り取りXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lastActivatedTextBox != null && this.lastActivatedTextBox.SelectionLength > 0)
            {
                int startIndex = this.lastActivatedTextBox.SelectionStart;
                int length = this.lastActivatedTextBox.SelectionLength;

                Clipboard.SetText(this.lastActivatedTextBox.Text.Substring(startIndex, length));
                this.lastActivatedTextBox.Text = this.lastActivatedTextBox.Text.Remove(startIndex, length);
                this.lastActivatedTextBox.SelectionStart = startIndex;
            }
        }

        private void コピーCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lastActivatedTextBox != null && this.lastActivatedTextBox.SelectionLength > 0)
                Clipboard.SetText(this.lastActivatedTextBox.SelectedText);
        }

        private void 張り付けVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lastActivatedTextBox != null)
            {
                int startIndex = this.lastActivatedTextBox.SelectionStart;
                int length = this.lastActivatedTextBox.SelectionLength;

                this.lastActivatedTextBox.Text =
                    this.lastActivatedTextBox.Text.Substring(0, startIndex) +
                    Clipboard.GetText() +
                    this.lastActivatedTextBox.Text.Substring(startIndex + length);
                this.lastActivatedTextBox.SelectionStart = startIndex + Clipboard.GetText().Length;
            }
        }
        #endregion
    }
}
