using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ChessGame
{
    class ChessBoard
    {
        private Dictionary<kSides, List<ChessPiece>> sides = null;
        private Texture2D texture;
        private static Texture2D selectedSquareTexture;
        private Vector2 position;

        public Texture2D Texture
        {
            get
            {
                return texture;
            }
        }
        public static Texture2D SelectedSquareTexture
        {
            get
            {
                return selectedSquareTexture;
            }
        }

        private void init()
        {
            sides = new Dictionary<kSides, List<ChessPiece>>();

            List<ChessPiece> whitePieces = new List<ChessPiece>();
            List<ChessPiece> blackPieces = new List<ChessPiece>();

            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kRook, new ChessPosition('A', 1)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kKnight, new ChessPosition('B', 1)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kBishop, new ChessPosition('C', 1)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kQueen, new ChessPosition('D', 1)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kKing, new ChessPosition('E', 1)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kBishop, new ChessPosition('F', 1)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kKnight, new ChessPosition('G', 1)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kRook, new ChessPosition('H', 1)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kPawn, new ChessPosition('A', 2)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kPawn, new ChessPosition('B', 2)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kPawn, new ChessPosition('C', 2)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kPawn, new ChessPosition('D', 2)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kPawn, new ChessPosition('E', 2)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kPawn, new ChessPosition('F', 2)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kPawn, new ChessPosition('G', 2)));
            whitePieces.Add(new ChessPiece(kSides.kWhite, kPieceTypes.kPawn, new ChessPosition('H', 2)));

            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kRook, new ChessPosition('A', 8)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kKnight, new ChessPosition('B', 8)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kBishop, new ChessPosition('C', 8)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kQueen, new ChessPosition('D', 8)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kKing, new ChessPosition('E', 8)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kBishop, new ChessPosition('F', 8)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kKnight, new ChessPosition('G', 8)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kRook, new ChessPosition('H', 8)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kPawn, new ChessPosition('A', 7)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kPawn, new ChessPosition('B', 7)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kPawn, new ChessPosition('C', 7)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kPawn, new ChessPosition('D', 7)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kPawn, new ChessPosition('E', 7)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kPawn, new ChessPosition('F', 7)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kPawn, new ChessPosition('G', 7)));
            blackPieces.Add(new ChessPiece(kSides.kBlack, kPieceTypes.kPawn, new ChessPosition('H', 7)));

            sides.Add(kSides.kWhite, whitePieces);
            sides.Add(kSides.kBlack, blackPieces);

            selectedSquareTexture = Texture2D.FromStream(Game1.Instance.GraphicsDevice, File.OpenRead("Resources\\RedSquare.png"));
            this.texture = Texture2D.FromStream(Game1.Instance.GraphicsDevice, File.OpenRead("Resources\\Boards\\woodenboard300x300.jpg"));
            this.position = new Vector2(0, 0);
        }

        public ChessBoard()
        {
            this.init();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, Color.White);

            foreach (kSides side in sides.Keys)
            {
                foreach (ChessPiece piece in sides[side])
                {
                    piece.Draw(spriteBatch);
                }
            }
            
        }

        public ChessPiece GetSelectedPiece()
        {
            ChessPiece selectedPiece = null;

            foreach (kSides side in sides.Keys)
            {
                foreach (ChessPiece piece in sides[side])
                {
                    if (piece.IsSelected)
                    {
                        selectedPiece = piece;
                        break;
                    }
                }
            }
            return selectedPiece;
        }


        public void HandleMouseClick(Vector2 mousePosition)
        {
            //get the previously selected piece!
            ChessPiece selectedPiece = GetSelectedPiece();
            
            if (selectedPiece != null)
                //no need to keep it selected any more. either it will be moved, or unselected
                selectedPiece.IsSelected = false;

            char row = 'A';
            int column = 1;

            if (mousePosition.X < 25 || mousePosition.X > (float)(25 + 31.5 * 8) ||
                mousePosition.Y > 275 || mousePosition.Y < (float)(275 - 31.5 * 8))
            {
                Console.WriteLine("Out of bounds!!!!");
                return;
            }

            #region get row and column
            //get the row
            int difference = (int)((mousePosition.X - 25) / 31.5);
            switch (difference)
            {
                case 0:
                    row = 'A';
                    break;
                case 1:
                    row = 'B';
                    break;
                case 2:
                    row = 'C';
                    break;
                case 3:
                    row = 'D';
                    break;
                case 4:
                    row = 'E';
                    break;
                case 5:
                    row = 'F';
                    break;
                case 6:
                    row = 'G';
                    break;
                case 7:
                    row = 'H';
                    break;
            }
            //get the column
            column = (int)((275-mousePosition.Y) / 31.5) + 1;
            #endregion

            ChessPosition mouseBoardPosition = new ChessPosition(row, column);

            if (selectedPiece != null && ChessUtils.IsMoveCompatible(selectedPiece, mouseBoardPosition))
            {
                selectedPiece.MovePiece(mouseBoardPosition);
            }
            else
            {
                foreach (kSides side in sides.Keys)
                {
                    foreach (ChessPiece piece in sides[side])
                    {
                        if (piece.Position == mouseBoardPosition)
                        {
                            piece.IsSelected = true;
                        }
                    }
                }
            }
            
        }
    }
}
