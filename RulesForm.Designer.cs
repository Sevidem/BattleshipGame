namespace BattleshipGame
{
    partial class RulesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox rulesTextBox;

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
            this.rulesTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            this.rulesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rulesTextBox.Multiline = true;
            this.rulesTextBox.ReadOnly = true;
            this.rulesTextBox.Text = "Правила игры:\n\n1. Расставьте корабли\n2. По очереди атакуйте\n3. Побеждает тот, кто первым потопит все корабли";

            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.rulesTextBox);
            this.Text = "Правила игры";
            this.ResumeLayout(false);
        }
    }
}