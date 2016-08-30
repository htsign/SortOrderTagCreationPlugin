namespace MusicBeePlugin.Windows.Forms
{
    partial class WordKanaDictionary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_description = new System.Windows.Forms.Label();
            this.dataGridView_wordKanaPairs = new System.Windows.Forms.DataGridView();
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.wordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kanaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.contextMenuStrip_dgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_mainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_importOverwrite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_importAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_export = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_wordKanaPairs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configBindingSource)).BeginInit();
            this.contextMenuStrip_dgv.SuspendLayout();
            this.menuStrip_mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_description
            // 
            this.label_description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_description.Location = new System.Drawing.Point(12, 31);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(320, 29);
            this.label_description.TabIndex = 1;
            this.label_description.Text = "単語をかなに変換する際、指定したい読みがある場合はここで指定します。";
            // 
            // dataGridView_wordKanaPairs
            // 
            this.dataGridView_wordKanaPairs.AllowUserToResizeRows = false;
            this.dataGridView_wordKanaPairs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_wordKanaPairs.AutoGenerateColumns = false;
            this.dataGridView_wordKanaPairs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_wordKanaPairs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView_wordKanaPairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_wordKanaPairs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enabledDataGridViewCheckBoxColumn,
            this.wordDataGridViewTextBoxColumn,
            this.kanaDataGridViewTextBoxColumn});
            this.dataGridView_wordKanaPairs.DataSource = this.configBindingSource;
            this.dataGridView_wordKanaPairs.Location = new System.Drawing.Point(12, 64);
            this.dataGridView_wordKanaPairs.Name = "dataGridView_wordKanaPairs";
            this.dataGridView_wordKanaPairs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_wordKanaPairs.RowTemplate.Height = 21;
            this.dataGridView_wordKanaPairs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_wordKanaPairs.Size = new System.Drawing.Size(319, 291);
            this.dataGridView_wordKanaPairs.TabIndex = 7;
            this.dataGridView_wordKanaPairs.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_wordKanaPairs_CellEnter);
            this.dataGridView_wordKanaPairs.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_wordKanaPairs_CellMouseClick);
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "有効";
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            this.enabledDataGridViewCheckBoxColumn.ToolTipText = "チェックのついたもののみが処理されます。一時的に無効にしたい行がある場合にお使いください。";
            this.enabledDataGridViewCheckBoxColumn.Width = 35;
            // 
            // wordDataGridViewTextBoxColumn
            // 
            this.wordDataGridViewTextBoxColumn.DataPropertyName = "Word";
            this.wordDataGridViewTextBoxColumn.HeaderText = "単語";
            this.wordDataGridViewTextBoxColumn.Name = "wordDataGridViewTextBoxColumn";
            this.wordDataGridViewTextBoxColumn.ToolTipText = "変換元となる単語を定義します。";
            // 
            // kanaDataGridViewTextBoxColumn
            // 
            this.kanaDataGridViewTextBoxColumn.DataPropertyName = "Kana";
            this.kanaDataGridViewTextBoxColumn.HeaderText = "読み";
            this.kanaDataGridViewTextBoxColumn.Name = "kanaDataGridViewTextBoxColumn";
            this.kanaDataGridViewTextBoxColumn.ToolTipText = "単語をどのように変換するかを定義します。指定できる文字はひらがなに限りません。";
            // 
            // configBindingSource
            // 
            this.configBindingSource.DataMember = "WordKanaCollection";
            this.configBindingSource.DataSource = typeof(MusicBeePlugin.Config);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(255, 361);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 8;
            this.button_cancel.Text = "キャンセル";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_ok.Location = new System.Drawing.Point(174, 361);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 9;
            this.button_ok.Text = "確定";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // contextMenuStrip_dgv
            // 
            this.contextMenuStrip_dgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_delete});
            this.contextMenuStrip_dgv.Name = "contextMenuStrip_dgv";
            this.contextMenuStrip_dgv.ShowImageMargin = false;
            this.contextMenuStrip_dgv.Size = new System.Drawing.Size(152, 26);
            // 
            // toolStripMenuItem_delete
            // 
            this.toolStripMenuItem_delete.Name = "toolStripMenuItem_delete";
            this.toolStripMenuItem_delete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.toolStripMenuItem_delete.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem_delete.Text = "行を削除";
            this.toolStripMenuItem_delete.Click += new System.EventHandler(this.toolStripMenuItem_delete_Click);
            // 
            // menuStrip_mainMenu
            // 
            this.menuStrip_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_file});
            this.menuStrip_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_mainMenu.Name = "menuStrip_mainMenu";
            this.menuStrip_mainMenu.Size = new System.Drawing.Size(344, 24);
            this.menuStrip_mainMenu.TabIndex = 10;
            // 
            // toolStripMenuItem_file
            // 
            this.toolStripMenuItem_file.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_importOverwrite,
            this.toolStripMenuItem_importAdd,
            this.toolStripSeparator1,
            this.toolStripMenuItem_export});
            this.toolStripMenuItem_file.Name = "toolStripMenuItem_file";
            this.toolStripMenuItem_file.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem_file.Text = "ファイル(&F)";
            // 
            // toolStripMenuItem_importOverwrite
            // 
            this.toolStripMenuItem_importOverwrite.Name = "toolStripMenuItem_importOverwrite";
            this.toolStripMenuItem_importOverwrite.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_importOverwrite.Text = "インポート（上書き） (&O)";
            this.toolStripMenuItem_importOverwrite.Click += new System.EventHandler(this.toolStripMenuItem_importOverwrite_Click);
            // 
            // toolStripMenuItem_importAdd
            // 
            this.toolStripMenuItem_importAdd.Name = "toolStripMenuItem_importAdd";
            this.toolStripMenuItem_importAdd.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_importAdd.Text = "インポート（追加） (&A)";
            this.toolStripMenuItem_importAdd.Click += new System.EventHandler(this.toolStripMenuItem_importAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // toolStripMenuItem_export
            // 
            this.toolStripMenuItem_export.Name = "toolStripMenuItem_export";
            this.toolStripMenuItem_export.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem_export.Text = "エクスポート (&E)";
            this.toolStripMenuItem_export.Click += new System.EventHandler(this.toolStripMenuItem_export_Click);
            // 
            // WordKanaDictionary
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(344, 391);
            this.Controls.Add(this.menuStrip_mainMenu);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.dataGridView_wordKanaPairs);
            this.MainMenuStrip = this.menuStrip_mainMenu;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 300);
            this.Name = "WordKanaDictionary";
            this.Text = "ユーザー辞書";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_wordKanaPairs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configBindingSource)).EndInit();
            this.contextMenuStrip_dgv.ResumeLayout(false);
            this.menuStrip_mainMenu.ResumeLayout(false);
            this.menuStrip_mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.DataGridView dataGridView_wordKanaPairs;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.BindingSource configBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_dgv;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kanaDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip menuStrip_mainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_file;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_importOverwrite;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_export;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_importAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}