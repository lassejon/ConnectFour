using System;
namespace App.Controller
{
    public class Board
    {
        private string[,] Rows { get; set; }
        private const int Size = 9;
        public Board()
        {
            Rows = new string[Size, Size];
        }

        public void SetPiece(string piece, int posX, int posY)
        {
            Rows[posX, posY] = piece;
        }

        public bool IsMainDiagonalWin(int posX, int posY)
        {
            var piece = Rows[posX, posY];
            var countAdjacentPieces = 0;
            
            var x = 0;
            var y = Math.Abs(posY - posX);
            if (posX > posY) (x, y) = (y, x);
            while (y < Size && x < Size)
            {
                if (string.Equals(piece, Rows[x, y]))
                {
                    countAdjacentPieces++;
                }
                else
                {
                    countAdjacentPieces = 0;
                }
                if (countAdjacentPieces >= 4) break;
                x++; y++;
            }
            return countAdjacentPieces >= 4;
        }

        public bool IsAntiDiagonalWin(int posX, int posY)
        {
            var piece = Rows[posX, posY];
            var countAdjacentPieces = 0;

            var x = posX + posY;
            var y = 0;
            if (x > 8)
            {
                x = Size - 1;
                y = posX + posY - x;
            }

            while (x >= 0 && y < Size)
            {
                if (string.Equals(piece, Rows[x, y]))
                {
                    countAdjacentPieces++;
                }
                else
                {
                    countAdjacentPieces = 0;
                }
                if (countAdjacentPieces >= 4) break; 
                x--; y++;
            }

            return countAdjacentPieces >= 4;
        }

        public bool IsRowWin(int posX, int posY)
        {
            var piece = Rows[posX, posY];
            var countAdjacentPieces = 0;

            for (var x = 0; x < Size; x++)
            {
                if (string.Equals(piece, Rows[x, posY]))
                {
                    countAdjacentPieces++;
                }
                else
                {
                    countAdjacentPieces = 0;
                }
                if (countAdjacentPieces >= 4) break; 
            }
            
            return countAdjacentPieces >= 4;
        }
        
        public bool IsColumnWin(int posX, int posY)
        {
            var piece = Rows[posX, posY];
            var countAdjacentPieces = 0;

            for (var y = 0; y < Size; y++)
            {
                if (string.Equals(piece, Rows[posX, y]))
                {
                    countAdjacentPieces++;
                }
                else
                {
                    countAdjacentPieces = 0;
                }
                if (countAdjacentPieces >= 4) break; 
            }
            
            return countAdjacentPieces >= 4;
        }
    }
}

