namespace BattleshipGame
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.humanBoardPanel = new System.Windows.Forms.Panel();
            this.aiBoardPanel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.rulesButton = new System.Windows.Forms.Button();
            this.statsButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.timerAITurn = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            // humanBoardPanel
            this.humanBoardPanel.BackColor = System.Drawing.SystemColors.Control;
            this.humanBoardPanel.Location = new System.Drawing.Point(20, 50);
            this.humanBoardPanel.Name = "humanBoardPanel";
            this.humanBoardPanel.Size = new System.Drawing.Size(300, 300);
            this.humanBoardPanel.TabIndex = 0;
            this.humanBoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.humanBoardPanel_Paint);

            // aiBoardPanel
            this.aiBoardPanel.BackColor = System.Drawing.SystemColors.Control;
            this.aiBoardPanel.Location = new System.Drawing.Point(350, 50);
            this.aiBoardPanel.Name = "aiBoardPanel";
            this.aiBoardPanel.Size = new System.Drawing.Size(300, 300);
            this.aiBoardPanel.TabIndex = 1;
            this.aiBoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.aiBoardPanel_Paint);
            this.aiBoardPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.aiBoardPanel_MouseClick);

            // startButton
            this.startButton.Location = new System.Drawing.Point(20, 360);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(80, 30);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Начать игру";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);

            // rulesButton
            this.rulesButton.Location = new System.Drawing.Point(120, 360);
            this.rulesButton.Name = "rulesButton";
            this.rulesButton.Size = new System.Drawing.Size(80, 30);
            this.rulesButton.TabIndex = 3;
            this.rulesButton.Text = "Правила";
            this.rulesButton.UseVisualStyleBackColor = true;
            this.rulesButton.Click += new System.EventHandler(this.rulesButton_Click);

            // statsButton
            this.statsButton.Location = new System.Drawing.Point(220, 360);
            this.statsButton.Name = "statsButton";
            this.statsButton.Size = new System.Drawing.Size(80, 30);
            this.statsButton.TabIndex = 4;
            this.statsButton.Text = "Статистика";
            this.statsButton.UseVisualStyleBackColor = true;
            this.statsButton.Click += new System.EventHandler(this.statsButton_Click);

            // settingsButton
            this.settingsButton.Location = new System.Drawing.Point(320, 360);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(80, 30);
            this.settingsButton.TabIndex = 5;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);

            // historyButton
            this.historyButton.Location = new System.Drawing.Point(420, 360);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(80, 30);
            this.historyButton.TabIndex = 6;
            this.historyButton.Text = "История";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);

            // statusLabel
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(20, 20);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(76, 13);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "Готов к игре";

            // timerAITurn
            this.timerAITurn.Interval = 1000;
            this.timerAITurn.Tick += new System.EventHandler(this.timerAITurn_Tick);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 400);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.historyButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.statsButton);
            this.Controls.Add(this.rulesButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.aiBoardPanel);
            this.Controls.Add(this.humanBoardPanel);
            this.Name = "MainForm";
            this.Text = "Морской бой";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel humanBoardPanel;
        private System.Windows.Forms.Panel aiBoardPanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button rulesButton;
        private System.Windows.Forms.Button statsButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Timer timerAITurn;
    }
}