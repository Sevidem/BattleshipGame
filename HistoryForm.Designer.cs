namespace BattleshipGame
{
    partial class HistoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox historyListBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.historyListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // historyListBox
            this.historyListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyListBox.Items.AddRange(new object[] {
                "Игра 1: Победа",
                "Игра 2: Поражение",
                "Игра 3: Победа"});

            // HistoryForm
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.historyListBox);
            this.Text = "История игр";
            this.ResumeLayout(false);
        }
    }
}