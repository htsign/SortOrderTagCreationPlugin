namespace MusicBeePlugin
{
    partial class ConfigureControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox_customTagArtist = new System.Windows.Forms.ComboBox();
            this.comboBox_customTagAlbumArtist = new System.Windows.Forms.ComboBox();
            this.comboBox_customTagTitle = new System.Windows.Forms.ComboBox();
            this.groupBox_customTags = new System.Windows.Forms.GroupBox();
            this.checkBox_customTagComposer = new System.Windows.Forms.CheckBox();
            this.checkBox_customTagAlbum = new System.Windows.Forms.CheckBox();
            this.checkBox_customTagTitle = new System.Windows.Forms.CheckBox();
            this.checkBox_customTagAlbumArtist = new System.Windows.Forms.CheckBox();
            this.checkBox_customTagArtist = new System.Windows.Forms.CheckBox();
            this.comboBox_customTagComposer = new System.Windows.Forms.ComboBox();
            this.comboBox_customTagAlbum = new System.Windows.Forms.ComboBox();
            this.label_apiEngine = new System.Windows.Forms.Label();
            this.comboBox_apiEngine = new System.Windows.Forms.ComboBox();
            this.button_userDic = new System.Windows.Forms.Button();
            this.checkBox_dontOverwrite = new System.Windows.Forms.CheckBox();
            this.label_regExpMatches = new System.Windows.Forms.Label();
            this.label_regExpReplaces = new System.Windows.Forms.Label();
            this.textBox_regExpMatches = new System.Windows.Forms.TextBox();
            this.contextMenuStrip_textBoxes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.全選択AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.切り取りXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.コピーCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.張り付けVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_regExpReplaces = new System.Windows.Forms.TextBox();
            this.label_attensionBefore = new System.Windows.Forms.Label();
            this.linkLabel_attensionLink = new System.Windows.Forms.LinkLabel();
            this.label_attensionAfter = new System.Windows.Forms.Label();
            this.checkBox_addSortOrderTagsWhenLibraryChanged = new System.Windows.Forms.CheckBox();
            this.groupBox_customTags.SuspendLayout();
            this.contextMenuStrip_textBoxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_customTagArtist
            // 
            this.comboBox_customTagArtist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_customTagArtist.FormattingEnabled = true;
            this.comboBox_customTagArtist.Location = new System.Drawing.Point(151, 18);
            this.comboBox_customTagArtist.Name = "comboBox_customTagArtist";
            this.comboBox_customTagArtist.Size = new System.Drawing.Size(105, 20);
            this.comboBox_customTagArtist.TabIndex = 2;
            this.comboBox_customTagArtist.TextChanged += new System.EventHandler(this.comboBox_customTags_TextChanged);
            this.comboBox_customTagArtist.Enter += new System.EventHandler(this.comboBox_customTags_Enter);
            // 
            // comboBox_customTagAlbumArtist
            // 
            this.comboBox_customTagAlbumArtist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_customTagAlbumArtist.FormattingEnabled = true;
            this.comboBox_customTagAlbumArtist.Location = new System.Drawing.Point(151, 43);
            this.comboBox_customTagAlbumArtist.Name = "comboBox_customTagAlbumArtist";
            this.comboBox_customTagAlbumArtist.Size = new System.Drawing.Size(105, 20);
            this.comboBox_customTagAlbumArtist.TabIndex = 4;
            this.comboBox_customTagAlbumArtist.TextChanged += new System.EventHandler(this.comboBox_customTags_TextChanged);
            this.comboBox_customTagAlbumArtist.Enter += new System.EventHandler(this.comboBox_customTags_Enter);
            // 
            // comboBox_customTagTitle
            // 
            this.comboBox_customTagTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_customTagTitle.FormattingEnabled = true;
            this.comboBox_customTagTitle.Location = new System.Drawing.Point(151, 68);
            this.comboBox_customTagTitle.Name = "comboBox_customTagTitle";
            this.comboBox_customTagTitle.Size = new System.Drawing.Size(105, 20);
            this.comboBox_customTagTitle.TabIndex = 6;
            this.comboBox_customTagTitle.TextChanged += new System.EventHandler(this.comboBox_customTags_TextChanged);
            this.comboBox_customTagTitle.Enter += new System.EventHandler(this.comboBox_customTags_Enter);
            // 
            // groupBox_customTags
            // 
            this.groupBox_customTags.Controls.Add(this.checkBox_customTagComposer);
            this.groupBox_customTags.Controls.Add(this.checkBox_customTagAlbum);
            this.groupBox_customTags.Controls.Add(this.checkBox_customTagTitle);
            this.groupBox_customTags.Controls.Add(this.checkBox_customTagAlbumArtist);
            this.groupBox_customTags.Controls.Add(this.checkBox_customTagArtist);
            this.groupBox_customTags.Controls.Add(this.comboBox_customTagComposer);
            this.groupBox_customTags.Controls.Add(this.comboBox_customTagAlbum);
            this.groupBox_customTags.Controls.Add(this.comboBox_customTagTitle);
            this.groupBox_customTags.Controls.Add(this.comboBox_customTagAlbumArtist);
            this.groupBox_customTags.Controls.Add(this.comboBox_customTagArtist);
            this.groupBox_customTags.Location = new System.Drawing.Point(3, 3);
            this.groupBox_customTags.Name = "groupBox_customTags";
            this.groupBox_customTags.Size = new System.Drawing.Size(283, 153);
            this.groupBox_customTags.TabIndex = 1;
            this.groupBox_customTags.TabStop = false;
            this.groupBox_customTags.Text = "ソートに使われるカスタムタグ";
            // 
            // checkBox_customTagComposer
            // 
            this.checkBox_customTagComposer.AutoSize = true;
            this.checkBox_customTagComposer.Location = new System.Drawing.Point(22, 120);
            this.checkBox_customTagComposer.Name = "checkBox_customTagComposer";
            this.checkBox_customTagComposer.Size = new System.Drawing.Size(60, 16);
            this.checkBox_customTagComposer.TabIndex = 9;
            this.checkBox_customTagComposer.Text = "作曲者";
            this.checkBox_customTagComposer.UseVisualStyleBackColor = true;
            // 
            // checkBox_customTagAlbum
            // 
            this.checkBox_customTagAlbum.AutoSize = true;
            this.checkBox_customTagAlbum.Location = new System.Drawing.Point(22, 95);
            this.checkBox_customTagAlbum.Name = "checkBox_customTagAlbum";
            this.checkBox_customTagAlbum.Size = new System.Drawing.Size(63, 16);
            this.checkBox_customTagAlbum.TabIndex = 7;
            this.checkBox_customTagAlbum.Text = "アルバム";
            this.checkBox_customTagAlbum.UseVisualStyleBackColor = true;
            // 
            // checkBox_customTagTitle
            // 
            this.checkBox_customTagTitle.AutoSize = true;
            this.checkBox_customTagTitle.Location = new System.Drawing.Point(22, 70);
            this.checkBox_customTagTitle.Name = "checkBox_customTagTitle";
            this.checkBox_customTagTitle.Size = new System.Drawing.Size(59, 16);
            this.checkBox_customTagTitle.TabIndex = 5;
            this.checkBox_customTagTitle.Text = "タイトル";
            this.checkBox_customTagTitle.UseVisualStyleBackColor = true;
            // 
            // checkBox_customTagAlbumArtist
            // 
            this.checkBox_customTagAlbumArtist.AutoSize = true;
            this.checkBox_customTagAlbumArtist.Location = new System.Drawing.Point(22, 45);
            this.checkBox_customTagAlbumArtist.Name = "checkBox_customTagAlbumArtist";
            this.checkBox_customTagAlbumArtist.Size = new System.Drawing.Size(115, 16);
            this.checkBox_customTagAlbumArtist.TabIndex = 3;
            this.checkBox_customTagAlbumArtist.Text = "アルバムアーティスト";
            this.checkBox_customTagAlbumArtist.UseVisualStyleBackColor = true;
            // 
            // checkBox_customTagArtist
            // 
            this.checkBox_customTagArtist.AutoSize = true;
            this.checkBox_customTagArtist.Location = new System.Drawing.Point(22, 20);
            this.checkBox_customTagArtist.Name = "checkBox_customTagArtist";
            this.checkBox_customTagArtist.Size = new System.Drawing.Size(76, 16);
            this.checkBox_customTagArtist.TabIndex = 1;
            this.checkBox_customTagArtist.Text = "アーティスト";
            this.checkBox_customTagArtist.UseVisualStyleBackColor = true;
            // 
            // comboBox_customTagComposer
            // 
            this.comboBox_customTagComposer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_customTagComposer.FormattingEnabled = true;
            this.comboBox_customTagComposer.Location = new System.Drawing.Point(151, 118);
            this.comboBox_customTagComposer.Name = "comboBox_customTagComposer";
            this.comboBox_customTagComposer.Size = new System.Drawing.Size(105, 20);
            this.comboBox_customTagComposer.TabIndex = 10;
            this.comboBox_customTagComposer.TextChanged += new System.EventHandler(this.comboBox_customTags_TextChanged);
            this.comboBox_customTagComposer.Enter += new System.EventHandler(this.comboBox_customTags_Enter);
            // 
            // comboBox_customTagAlbum
            // 
            this.comboBox_customTagAlbum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_customTagAlbum.FormattingEnabled = true;
            this.comboBox_customTagAlbum.Location = new System.Drawing.Point(151, 93);
            this.comboBox_customTagAlbum.Name = "comboBox_customTagAlbum";
            this.comboBox_customTagAlbum.Size = new System.Drawing.Size(105, 20);
            this.comboBox_customTagAlbum.TabIndex = 8;
            this.comboBox_customTagAlbum.TextChanged += new System.EventHandler(this.comboBox_customTags_TextChanged);
            this.comboBox_customTagAlbum.Enter += new System.EventHandler(this.comboBox_customTags_Enter);
            // 
            // label_apiEngine
            // 
            this.label_apiEngine.AutoSize = true;
            this.label_apiEngine.Location = new System.Drawing.Point(304, 67);
            this.label_apiEngine.Name = "label_apiEngine";
            this.label_apiEngine.Size = new System.Drawing.Size(69, 12);
            this.label_apiEngine.TabIndex = 0;
            this.label_apiEngine.Text = "APIの提供元";
            // 
            // comboBox_apiEngine
            // 
            this.comboBox_apiEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_apiEngine.FormattingEnabled = true;
            this.comboBox_apiEngine.Location = new System.Drawing.Point(387, 64);
            this.comboBox_apiEngine.Name = "comboBox_apiEngine";
            this.comboBox_apiEngine.Size = new System.Drawing.Size(118, 20);
            this.comboBox_apiEngine.TabIndex = 3;
            this.comboBox_apiEngine.TextChanged += new System.EventHandler(this.comboBox_apiEngine_TextChanged);
            // 
            // button_userDic
            // 
            this.button_userDic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_userDic.Location = new System.Drawing.Point(344, 144);
            this.button_userDic.Name = "button_userDic";
            this.button_userDic.Size = new System.Drawing.Size(128, 30);
            this.button_userDic.TabIndex = 6;
            this.button_userDic.Text = "ユーザー辞書";
            this.button_userDic.UseVisualStyleBackColor = true;
            this.button_userDic.Click += new System.EventHandler(this.button_userDic_Click);
            // 
            // checkBox_dontOverwrite
            // 
            this.checkBox_dontOverwrite.AutoSize = true;
            this.checkBox_dontOverwrite.Location = new System.Drawing.Point(306, 39);
            this.checkBox_dontOverwrite.Name = "checkBox_dontOverwrite";
            this.checkBox_dontOverwrite.Size = new System.Drawing.Size(249, 16);
            this.checkBox_dontOverwrite.TabIndex = 2;
            this.checkBox_dontOverwrite.Text = "既にタグが書き込まれている場合は上書きしない";
            this.checkBox_dontOverwrite.UseVisualStyleBackColor = true;
            this.checkBox_dontOverwrite.CheckedChanged += new System.EventHandler(this.checkBox_dontOverwrite_CheckedChanged);
            // 
            // label_regExpMatches
            // 
            this.label_regExpMatches.AutoSize = true;
            this.label_regExpMatches.Location = new System.Drawing.Point(304, 91);
            this.label_regExpMatches.Name = "label_regExpMatches";
            this.label_regExpMatches.Size = new System.Drawing.Size(53, 12);
            this.label_regExpMatches.TabIndex = 0;
            this.label_regExpMatches.Text = "一致判定";
            // 
            // label_regExpReplaces
            // 
            this.label_regExpReplaces.AutoSize = true;
            this.label_regExpReplaces.Location = new System.Drawing.Point(304, 115);
            this.label_regExpReplaces.Name = "label_regExpReplaces";
            this.label_regExpReplaces.Size = new System.Drawing.Size(53, 12);
            this.label_regExpReplaces.TabIndex = 0;
            this.label_regExpReplaces.Text = "置換判定";
            // 
            // textBox_regExpMatches
            // 
            this.textBox_regExpMatches.ContextMenuStrip = this.contextMenuStrip_textBoxes;
            this.textBox_regExpMatches.Location = new System.Drawing.Point(387, 88);
            this.textBox_regExpMatches.Name = "textBox_regExpMatches";
            this.textBox_regExpMatches.Size = new System.Drawing.Size(118, 19);
            this.textBox_regExpMatches.TabIndex = 4;
            this.textBox_regExpMatches.TextChanged += new System.EventHandler(this.textBox_regExpMatches_TextChanged);
            this.textBox_regExpMatches.Enter += new System.EventHandler(this.textBox_regExps_Enter);
            // 
            // contextMenuStrip_textBoxes
            // 
            this.contextMenuStrip_textBoxes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全選択AToolStripMenuItem,
            this.toolStripSeparator1,
            this.切り取りXToolStripMenuItem,
            this.コピーCToolStripMenuItem,
            this.張り付けVToolStripMenuItem});
            this.contextMenuStrip_textBoxes.Name = "contextMenuStrip_textBoxes";
            this.contextMenuStrip_textBoxes.ShowImageMargin = false;
            this.contextMenuStrip_textBoxes.ShowItemToolTips = false;
            this.contextMenuStrip_textBoxes.Size = new System.Drawing.Size(110, 98);
            // 
            // 全選択AToolStripMenuItem
            // 
            this.全選択AToolStripMenuItem.Name = "全選択AToolStripMenuItem";
            this.全選択AToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.全選択AToolStripMenuItem.Text = "全選択(&A)";
            this.全選択AToolStripMenuItem.Click += new System.EventHandler(this.全選択AToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
            // 
            // 切り取りXToolStripMenuItem
            // 
            this.切り取りXToolStripMenuItem.Name = "切り取りXToolStripMenuItem";
            this.切り取りXToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.切り取りXToolStripMenuItem.Text = "切り取り(&X)";
            this.切り取りXToolStripMenuItem.Click += new System.EventHandler(this.切り取りXToolStripMenuItem_Click);
            // 
            // コピーCToolStripMenuItem
            // 
            this.コピーCToolStripMenuItem.Name = "コピーCToolStripMenuItem";
            this.コピーCToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.コピーCToolStripMenuItem.Text = "コピー(&C)";
            this.コピーCToolStripMenuItem.Click += new System.EventHandler(this.コピーCToolStripMenuItem_Click);
            // 
            // 張り付けVToolStripMenuItem
            // 
            this.張り付けVToolStripMenuItem.Name = "張り付けVToolStripMenuItem";
            this.張り付けVToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.張り付けVToolStripMenuItem.Text = "張り付け(&V)";
            this.張り付けVToolStripMenuItem.Click += new System.EventHandler(this.張り付けVToolStripMenuItem_Click);
            // 
            // textBox_regExpReplaces
            // 
            this.textBox_regExpReplaces.ContextMenuStrip = this.contextMenuStrip_textBoxes;
            this.textBox_regExpReplaces.Location = new System.Drawing.Point(387, 112);
            this.textBox_regExpReplaces.Name = "textBox_regExpReplaces";
            this.textBox_regExpReplaces.Size = new System.Drawing.Size(118, 19);
            this.textBox_regExpReplaces.TabIndex = 5;
            this.textBox_regExpReplaces.TextChanged += new System.EventHandler(this.textBox_regExpReplaces_TextChanged);
            this.textBox_regExpReplaces.Enter += new System.EventHandler(this.textBox_regExps_Enter);
            // 
            // label_attensionBefore
            // 
            this.label_attensionBefore.AutoSize = true;
            this.label_attensionBefore.Location = new System.Drawing.Point(13, 164);
            this.label_attensionBefore.Margin = new System.Windows.Forms.Padding(0);
            this.label_attensionBefore.Name = "label_attensionBefore";
            this.label_attensionBefore.Size = new System.Drawing.Size(127, 12);
            this.label_attensionBefore.TabIndex = 7;
            this.label_attensionBefore.Text = "当ソフトウェアでは一部で「";
            // 
            // linkLabel_attensionLink
            // 
            this.linkLabel_attensionLink.AutoSize = true;
            this.linkLabel_attensionLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_attensionLink.Location = new System.Drawing.Point(140, 164);
            this.linkLabel_attensionLink.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel_attensionLink.Name = "linkLabel_attensionLink";
            this.linkLabel_attensionLink.Size = new System.Drawing.Size(62, 12);
            this.linkLabel_attensionLink.TabIndex = 8;
            this.linkLabel_attensionLink.TabStop = true;
            this.linkLabel_attensionLink.Tag = "http://yomi-tan.jp/";
            this.linkLabel_attensionLink.Text = "よみたんAPI";
            this.linkLabel_attensionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_attensionLink_LinkClicked);
            // 
            // label_attensionAfter
            // 
            this.label_attensionAfter.AutoSize = true;
            this.label_attensionAfter.Location = new System.Drawing.Point(202, 164);
            this.label_attensionAfter.Margin = new System.Windows.Forms.Padding(0);
            this.label_attensionAfter.Name = "label_attensionAfter";
            this.label_attensionAfter.Size = new System.Drawing.Size(99, 12);
            this.label_attensionAfter.TabIndex = 9;
            this.label_attensionAfter.Text = "」を使用しています。";
            // 
            // checkBox_addSortOrderTagsWhenLibraryChanged
            // 
            this.checkBox_addSortOrderTagsWhenLibraryChanged.AutoSize = true;
            this.checkBox_addSortOrderTagsWhenLibraryChanged.Location = new System.Drawing.Point(306, 17);
            this.checkBox_addSortOrderTagsWhenLibraryChanged.Name = "checkBox_addSortOrderTagsWhenLibraryChanged";
            this.checkBox_addSortOrderTagsWhenLibraryChanged.Size = new System.Drawing.Size(236, 16);
            this.checkBox_addSortOrderTagsWhenLibraryChanged.TabIndex = 10;
            this.checkBox_addSortOrderTagsWhenLibraryChanged.Text = "ファイルの追加時や編集時に自動で付与する";
            this.checkBox_addSortOrderTagsWhenLibraryChanged.UseVisualStyleBackColor = true;
            this.checkBox_addSortOrderTagsWhenLibraryChanged.CheckedChanged += new System.EventHandler(this.checkBox_addSortOrderTagsWhenLibraryChanged_CheckedChanged);
            // 
            // ConfigureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_addSortOrderTagsWhenLibraryChanged);
            this.Controls.Add(this.label_attensionAfter);
            this.Controls.Add(this.linkLabel_attensionLink);
            this.Controls.Add(this.label_attensionBefore);
            this.Controls.Add(this.textBox_regExpReplaces);
            this.Controls.Add(this.textBox_regExpMatches);
            this.Controls.Add(this.label_regExpReplaces);
            this.Controls.Add(this.label_regExpMatches);
            this.Controls.Add(this.checkBox_dontOverwrite);
            this.Controls.Add(this.button_userDic);
            this.Controls.Add(this.comboBox_apiEngine);
            this.Controls.Add(this.label_apiEngine);
            this.Controls.Add(this.groupBox_customTags);
            this.Name = "ConfigureControl";
            this.Size = new System.Drawing.Size(721, 233);
            this.Load += new System.EventHandler(this.ConfigureControl_Load);
            this.groupBox_customTags.ResumeLayout(false);
            this.groupBox_customTags.PerformLayout();
            this.contextMenuStrip_textBoxes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_customTagArtist;
        private System.Windows.Forms.ComboBox comboBox_customTagAlbumArtist;
        private System.Windows.Forms.ComboBox comboBox_customTagTitle;
        private System.Windows.Forms.GroupBox groupBox_customTags;
        private System.Windows.Forms.Label label_apiEngine;
        private System.Windows.Forms.ComboBox comboBox_apiEngine;
        private System.Windows.Forms.Button button_userDic;
        private System.Windows.Forms.ComboBox comboBox_customTagComposer;
        private System.Windows.Forms.ComboBox comboBox_customTagAlbum;
        private System.Windows.Forms.CheckBox checkBox_customTagComposer;
        private System.Windows.Forms.CheckBox checkBox_customTagAlbum;
        private System.Windows.Forms.CheckBox checkBox_customTagTitle;
        private System.Windows.Forms.CheckBox checkBox_customTagAlbumArtist;
        private System.Windows.Forms.CheckBox checkBox_customTagArtist;
        private System.Windows.Forms.CheckBox checkBox_dontOverwrite;
        private System.Windows.Forms.Label label_regExpMatches;
        private System.Windows.Forms.Label label_regExpReplaces;
        private System.Windows.Forms.TextBox textBox_regExpMatches;
        private System.Windows.Forms.TextBox textBox_regExpReplaces;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_textBoxes;
        private System.Windows.Forms.ToolStripMenuItem 全選択AToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 切り取りXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem コピーCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 張り付けVToolStripMenuItem;
        private System.Windows.Forms.Label label_attensionBefore;
        private System.Windows.Forms.LinkLabel linkLabel_attensionLink;
        private System.Windows.Forms.Label label_attensionAfter;
        private System.Windows.Forms.CheckBox checkBox_addSortOrderTagsWhenLibraryChanged;
    }
}
