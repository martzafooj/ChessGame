using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace ChessGame
{
    public enum kPieceTypes
    {
        kPawn,
        kBishop,
        kKnight,
        kRook,
        kQueen,
        kKing
    }

    public enum kSides
    {
        kWhite,
        kBlack
    }

    class ChessPosition
    {
        public char Row { get; set; }
        public int Column { get; set; }

        public ChessPosition(char row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public Vector2 GetSquarePosition()
        {
            //this is the position for A 1
            Vector2 position = new Vector2(25, 245);

            int noOfColumnIncrement = 1 - this.Column;
            int noOfRowIncrement = this.Row - 'A';
            position.Y = (float)(position.Y + 31.5 * noOfColumnIncrement);
            position.X = (float)(position.X + 31.5 * noOfRowIncrement);

            return position;
        }

        public static bool operator ==(ChessPosition pos1, ChessPosition pos2)
        {
            return (pos1.Row == pos2.Row) && (pos1.Column == pos2.Column);
        }

        public static bool operator !=(ChessPosition pos1, ChessPosition pos2)
        {
            return (pos1.Row != pos2.Row) || (pos1.Column != pos2.Column);
        }
    }

    class Global
    {
        public static Dictionary<kSides, string> kPieceColourDict;
        public static Dictionary<kPieceTypes, string> kPieceStrDict;
        
        #region methods

        public static void Init()
        {
            kPieceColourDict = new Dictionary<kSides, string>();
            kPieceStrDict = new Dictionary<kPieceTypes, string>();

            kPieceColourDict.Add(kSides.kWhite, "white");
            kPieceColourDict.Add(kSides.kBlack, "black");

            kPieceStrDict.Add(kPieceTypes.kPawn, "p");
            kPieceStrDict.Add(kPieceTypes.kBishop, "b");
            kPieceStrDict.Add(kPieceTypes.kKnight, "n");
            kPieceStrDict.Add(kPieceTypes.kRook, "r");
            kPieceStrDict.Add(kPieceTypes.kQueen, "q");
            kPieceStrDict.Add(kPieceTypes.kKing, "k");
            
        }

        public static Texture2D GetTextureForPiece(kSides side, kPieceTypes pieceType)
        {
            string fileName = string.Format("Resources\\Pieces\\old_{0}_{1}_25x25.png", kPieceColourDict[side], kPieceStrDict[pieceType]);
            Texture2D texture = Texture2D.FromStream(Game1.Instance.GraphicsDevice, File.OpenRead(fileName));
            return texture;
        }

        #endregion

    }
}
