using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleshipGame
{
    public partial class MainForm : Form
    {
        private Game game;
        private HumanPlayer humanPlayer;
        private AIPlayer aiPlayer;
        private Point lastAttackPoint;

        public MainForm()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            humanPlayer = new HumanPlayer();
            aiPlayer = new AIPlayer();
            game = new Game(humanPlayer, aiPlayer);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            humanPlayer.AutoPlaceShips();
            aiPlayer.AutoPlaceShips();
            humanBoardPanel.Invalidate();
            aiBoardPanel.Invalidate();
            statusLabel.Text = "Игра началась! Ваш ход.";
            aiBoardPanel.Enabled = true;
        }

        private void humanBoardPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics, humanPlayer.Board, true);
        }

        private void aiBoardPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics, aiPlayer.Board, false);
            if (game.LastAttackSuccess == true)
            {
                DrawExplosionMarker(e.Graphics, lastAttackPoint);
            }
        }

        private void DrawBoard(Graphics g, Board board, bool showShips)
        {
            int cellSize = 30;
            Font font = new Font("Arial", 12);

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Rectangle rect = new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize);
                    char cell = board.GetCell(x, y);

                    if (cell == 'X') g.FillRectangle(Brushes.Red, rect);
                    else if (cell == 'O') g.FillRectangle(Brushes.White, rect);
                    else if (cell == '1' && showShips) g.FillRectangle(Brushes.Gray, rect);
                    else g.FillRectangle(Brushes.LightBlue, rect);

                    g.DrawRectangle(Pens.Black, rect);
                    g.DrawString(cell == '1' && showShips ? "1" : "0", font, Brushes.Black,
                                rect.X + 10, rect.Y + 8);
                }
            }
        }

        private void DrawExplosionMarker(Graphics g, Point location)
        {
            g.FillEllipse(Brushes.OrangeRed, location.X + 5, location.Y + 5, 20, 20);
            g.DrawEllipse(new Pen(Color.Yellow, 2), location.X, location.Y, 28, 28);
        }

        private void aiBoardPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (!game.IsPlayerTurn || game.IsGameOver) return;

            int cellSize = aiBoardPanel.Width / 10;
            int x = e.X / cellSize;
            int y = e.Y / cellSize;

            lastAttackPoint = new Point(x * cellSize, y * cellSize);

            game.PlayerAttack(x, y);
            aiBoardPanel.Invalidate();

            if (!game.IsGameOver)
            {
                aiBoardPanel.Enabled = false;
                statusLabel.Text = "Ход компьютера...";
                timerAITurn.Start();
            }
            else
            {
                statusLabel.Text = game.HumanPlayer.Board.AllShipsSunk() ?
                    "Вы проиграли!" : "Вы победили!";
            }
        }

        private void timerAITurn_Tick(object sender, EventArgs e)
        {
            timerAITurn.Stop();
            game.AIAttack();
            humanBoardPanel.Invalidate();

            if (game.IsGameOver)
            {
                statusLabel.Text = game.HumanPlayer.Board.AllShipsSunk() ?
                    "Вы проиграли!" : "Вы победили!";
            }
            else
            {
                statusLabel.Text = "Ваш ход";
                aiBoardPanel.Enabled = true;
            }
        }

        private void rulesButton_Click(object sender, EventArgs e) => new RulesForm().Show();
        private void statsButton_Click(object sender, EventArgs e) => new StatsForm().Show();
        private void settingsButton_Click(object sender, EventArgs e) => new SettingsForm().Show();
        private void historyButton_Click(object sender, EventArgs e) => new HistoryForm().Show();
    }
}