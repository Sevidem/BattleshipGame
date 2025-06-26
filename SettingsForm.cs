using System;
using System.Windows.Forms;
using BattleshipGame.Properties; // Добавьте эту директиву

namespace BattleshipGame
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Правильное обращение к настройкам
            soundCheckBox.Checked = Settings.Default.SoundEnabled;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Сохранение настроек
            Settings.Default.SoundEnabled = soundCheckBox.Checked;
            Settings.Default.Save();
            this.Close();
        }
    }
}