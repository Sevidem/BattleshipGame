using System;
using System.Collections.Generic;

namespace BattleshipGame
{
    public interface IShip
    {
        void Place(int x, int y, bool horizontal);
        bool IsSunk();
        void Hit();
        List<Tuple<int, int>> GetPositions();
    }

    public class Ship : IShip
    {
        protected int size;
        protected int hits;
        protected List<Tuple<int, int>> positions = new List<Tuple<int, int>>();

        public Ship(int size) { this.size = size; hits = 0; }

        public void Place(int x, int y, bool horizontal)
        {
            positions.Clear();
            for (int i = 0; i < size; i++)
            {
                positions.Add(horizontal ? Tuple.Create(x + i, y) : Tuple.Create(x, y + i));
            }
        }

        public bool IsSunk() => hits >= size;
        public void Hit() => hits++;
        public List<Tuple<int, int>> GetPositions() => positions;
    }

    public class Board
    {
        private const int SIZE = 10;
        private char[,] grid = new char[SIZE, SIZE];
        private List<IShip> ships = new List<IShip>();

        public Board()
        {
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    grid[i, j] = '0';
        }

        public void AddShip(IShip ship)
        {
            ships.Add(ship);
            foreach (var pos in ship.GetPositions())
            {
                if (pos.Item1 >= 0 && pos.Item1 < SIZE && pos.Item2 >= 0 && pos.Item2 < SIZE)
                {
                    grid[pos.Item2, pos.Item1] = '1';
                }
            }
        }

        public char GetCell(int x, int y) => grid[y, x];

        public bool Attack(int x, int y)
        {
            if (x < 0 || x >= SIZE || y < 0 || y >= SIZE)
                return false;

            if (grid[y, x] == '1')
            {
                grid[y, x] = 'X';
                foreach (var ship in ships)
                {
                    foreach (var pos in ship.GetPositions())
                    {
                        if (pos.Item1 == x && pos.Item2 == y)
                        {
                            ship.Hit();
                            return true;
                        }
                    }
                }
            }
            else if (grid[y, x] == '0')
            {
                grid[y, x] = 'O';
            }
            return false;
        }

        public bool AllShipsSunk()
        {
            foreach (var ship in ships)
            {
                if (!ship.IsSunk())
                    return false;
            }
            return true;
        }
    }

    public class HumanPlayer
    {
        public Board Board { get; } = new Board();

        public void AutoPlaceShips()
        {
            int[] shipSizes = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
            Random rand = new Random();

            foreach (int size in shipSizes)
            {
                bool placed = false;
                while (!placed)
                {
                    int x = rand.Next(10);
                    int y = rand.Next(10);
                    bool horizontal = rand.Next(2) == 0;

                    var ship = new Ship(size);
                    ship.Place(x, y, horizontal);

                    bool canPlace = true;
                    foreach (var pos in ship.GetPositions())
                    {
                        if (pos.Item1 < 0 || pos.Item1 >= 10 || pos.Item2 < 0 || pos.Item2 >= 10)
                        {
                            canPlace = false;
                            break;
                        }
                        if (Board.GetCell(pos.Item1, pos.Item2) == '1')
                        {
                            canPlace = false;
                            break;
                        }
                    }

                    if (canPlace)
                    {
                        Board.AddShip(ship);
                        placed = true;
                    }
                }
            }
        }
    }

    public class AIPlayer
    {
        public Board Board { get; } = new Board();
        private Random random = new Random();

        public void AutoPlaceShips()
        {
            int[] shipSizes = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            foreach (int size in shipSizes)
            {
                bool placed = false;
                while (!placed)
                {
                    int x = random.Next(10);
                    int y = random.Next(10);
                    bool horizontal = random.Next(2) == 0;

                    var ship = new Ship(size);
                    ship.Place(x, y, horizontal);

                    bool canPlace = true;
                    foreach (var pos in ship.GetPositions())
                    {
                        if (pos.Item1 < 0 || pos.Item1 >= 10 || pos.Item2 < 0 || pos.Item2 >= 10)
                        {
                            canPlace = false;
                            break;
                        }
                        if (Board.GetCell(pos.Item1, pos.Item2) == '1')
                        {
                            canPlace = false;
                            break;
                        }
                    }

                    if (canPlace)
                    {
                        Board.AddShip(ship);
                        placed = true;
                    }
                }
            }
        }

        public Tuple<int, int> MakeMove()
        {
            return Tuple.Create(random.Next(10), random.Next(10));
        }
    }

    public class Game
    {
        public HumanPlayer HumanPlayer { get; }
        public AIPlayer AIPlayer { get; }
        public bool IsPlayerTurn { get; set; } = true;
        public bool IsGameOver { get; private set; }
        public bool? LastAttackSuccess { get; private set; }

        public Game(HumanPlayer humanPlayer, AIPlayer aiPlayer)
        {
            HumanPlayer = humanPlayer;
            AIPlayer = aiPlayer;
        }

        public void PlayerAttack(int x, int y)
        {
            if (!IsGameOver && IsPlayerTurn)
            {
                LastAttackSuccess = AIPlayer.Board.Attack(x, y);
                if (AIPlayer.Board.AllShipsSunk())
                {
                    IsGameOver = true;
                }
                IsPlayerTurn = false;
            }
        }

        public void AIAttack()
        {
            if (!IsGameOver && !IsPlayerTurn)
            {
                var move = AIPlayer.MakeMove();
                HumanPlayer.Board.Attack(move.Item1, move.Item2);
                if (HumanPlayer.Board.AllShipsSunk())
                {
                    IsGameOver = true;
                }
                IsPlayerTurn = true;
            }
        }
    }
}