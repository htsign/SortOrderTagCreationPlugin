namespace MusicBeePlugin.Windows.Forms
{
    partial class Translator
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
            if (disposing)
            {
                if (tokenSource != null)
                {
                    tokenSource.Dispose();
                }
                components?.Dispose();
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
            this.progressBar_completed = new ProgressBarEx();
            this.label_summary = new System.Windows.Forms.Label();
            this.label_completedCount = new System.Windows.Forms.Label();
            this.label_slash = new System.Windows.Forms.Label();
            this.label_entireCount = new System.Windows.Forms.Label();
            this.label_remainingTimeSummary = new System.Windows.Forms.Label();
            this.label_remainingTime = new System.Windows.Forms.Label();
            this.button_terminate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar_completed
            // 
            this.progressBar_completed.Location = new System.Drawing.Point(12, 34);
            this.progressBar_completed.MarqueeAnimationSpeed = 10;
            this.progressBar_completed.Name = "progressBar_completed";
            this.progressBar_completed.Size = new System.Drawing.Size(196, 23);
            this.progressBar_completed.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar_completed.TabIndex = 0;
            // 
            // label_summary
            // 
            this.label_summary.AutoSize = true;
            this.label_summary.Location = new System.Drawing.Point(12, 9);
            this.label_summary.Name = "label_summary";
            this.label_summary.Size = new System.Drawing.Size(97, 12);
            this.label_summary.TabIndex = 0;
            this.label_summary.Text = "完了数 / 全体数 :";
            this.label_summary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_completedCount
            // 
            this.label_completedCount.Location = new System.Drawing.Point(111, 9);
            this.label_completedCount.Name = "label_completedCount";
            this.label_completedCount.Size = new System.Drawing.Size(34, 12);
            this.label_completedCount.TabIndex = 0;
            this.label_completedCount.Text = "0";
            this.label_completedCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_slash
            // 
            this.label_slash.AutoSize = true;
            this.label_slash.Location = new System.Drawing.Point(144, 9);
            this.label_slash.Name = "label_slash";
            this.label_slash.Size = new System.Drawing.Size(11, 12);
            this.label_slash.TabIndex = 0;
            this.label_slash.Text = "/";
            this.label_slash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_entireCount
            // 
            this.label_entireCount.Location = new System.Drawing.Point(152, 9);
            this.label_entireCount.Name = "label_entireCount";
            this.label_entireCount.Size = new System.Drawing.Size(34, 12);
            this.label_entireCount.TabIndex = 0;
            this.label_entireCount.Text = "0";
            this.label_entireCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_remainingTimeSummary
            // 
            this.label_remainingTimeSummary.AutoSize = true;
            this.label_remainingTimeSummary.Location = new System.Drawing.Point(13, 71);
            this.label_remainingTimeSummary.Name = "label_remainingTimeSummary";
            this.label_remainingTimeSummary.Size = new System.Drawing.Size(55, 12);
            this.label_remainingTimeSummary.TabIndex = 0;
            this.label_remainingTimeSummary.Text = "残り時間 :";
            // 
            // label_remainingTime
            // 
            this.label_remainingTime.AutoSize = true;
            this.label_remainingTime.Location = new System.Drawing.Point(74, 71);
            this.label_remainingTime.Name = "label_remainingTime";
            this.label_remainingTime.Size = new System.Drawing.Size(0, 12);
            this.label_remainingTime.TabIndex = 0;
            // 
            // button_terminate
            // 
            this.button_terminate.Location = new System.Drawing.Point(154, 66);
            this.button_terminate.Name = "button_terminate";
            this.button_terminate.Size = new System.Drawing.Size(54, 23);
            this.button_terminate.TabIndex = 1;
            this.button_terminate.Text = "中断";
            this.button_terminate.UseVisualStyleBackColor = true;
            this.button_terminate.Click += new System.EventHandler(this.button_terminate_Click);
            // 
            // Remaining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 94);
            this.ControlBox = false;
            this.Controls.Add(this.button_terminate);
            this.Controls.Add(this.label_remainingTime);
            this.Controls.Add(this.label_remainingTimeSummary);
            this.Controls.Add(this.label_entireCount);
            this.Controls.Add(this.label_slash);
            this.Controls.Add(this.label_completedCount);
            this.Controls.Add(this.label_summary);
            this.Controls.Add(this.progressBar_completed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Remaining";
            this.Text = "進捗状況";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Remaining_FormClosed);
            this.Load += new System.EventHandler(this.Remaining_Load);
            this.Shown += new System.EventHandler(this.Remaining_ShownAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProgressBarEx progressBar_completed;
        private System.Windows.Forms.Label label_summary;
        private System.Windows.Forms.Label label_completedCount;
        private System.Windows.Forms.Label label_slash;
        private System.Windows.Forms.Label label_entireCount;
        private System.Windows.Forms.Label label_remainingTimeSummary;
        private System.Windows.Forms.Label label_remainingTime;
        private System.Windows.Forms.Button button_terminate;
    }
}