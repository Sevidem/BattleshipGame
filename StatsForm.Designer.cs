namespace BattleshipGame
{
    partial class StatsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView statsDataGridView;

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
            this.statsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.statsDataGridView)).BeginInit();
            this.SuspendLayout();

            // statsDataGridView
            this.statsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;

            // StatsForm
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.statsDataGridView);
            this.Text = "Статистика";
            ((System.ComponentModel.ISupportInitialize)(this.statsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }
    }
}