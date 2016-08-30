using System.Windows.Forms;

namespace MusicBeePlugin.Windows.Forms
{
    class ProgressBarEx : ProgressBar
    {
        public new int Value
        {
            get { return base.Value; }
            set
            {
                SuspendLayout();
                ++Maximum;
                base.Value = value + 1;
                base.Value = value;
                --Maximum;
                ResumeLayout(true);
            }
        }
    }
}
