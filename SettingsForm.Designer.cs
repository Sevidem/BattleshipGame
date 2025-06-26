namespace BattleshipGame
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.soundCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // soundCheckBox
            this.soundCheckBox.AutoSize = true;
            this.soundCheckBox.Location = new System.Drawing.Point(20, 20);
            this.soundCheckBox.Name = "soundCheckBox";
            this.soundCheckBox.Size = new System.Drawing.Size(118, 17);
            this.soundCheckBox.TabIndex = 0;
            this.soundCheckBox.Text = "Звуковые эффекты";
            this.soundCheckBox.UseVisualStyleBackColor = true;

            // saveButton
            this.saveButton.Location = new System.Drawing.Point(100, 120);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            // SettingsForm
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.soundCheckBox);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox soundCheckBox;
        private System.Windows.Forms.Button saveButton;
    }
}