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

namespace ChessGame
{
    class ChessPiece
    {
        #region members
        private kSides side;
        private kPieceTypes pieceType;
        private Texture2D texture;
        private bool isActive;
        private bool isSelected;
        private ChessPosition position;
        #endregion

        #region properties
        public kSides Side
        {
            get
            {
                return side;
            }
        }
        public kPieceTypes PieceType
        {
            get
            {
                return pieceType;
            }
        }
        public Texture2D Texture
        {
            get
            {
                return texture;
            }
        }
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }
        public ChessPosition Position
        {
            get
            {
                return position;
            }
        }
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
            }
        }

        #endregion

        private void initTexture()
        {
            this.texture = Global.GetTextureForPiece(this.Side, this.PieceType);
        }


        public ChessPiece(kSides side, kPieceTypes pieceType, ChessPosition position)
        {
            this.side = side;
            this.pieceType = pieceType;
            this.isActive = true;
            this.isSelected = false;
            this.position = position;
            this.initTexture();
        }

        public void MovePiece(ChessPosition newPosition)
        {
            this.position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2  position = this.position.GetSquarePosition();

            //don't draw from the beginning of the square, leave a 3px margin
            position.X += 3;
            position.Y += 3;

            if (this.IsSelected)
            {
                spriteBatch.Draw(ChessBoard.SelectedSquareTexture, this.position.GetSquarePosition(), Color.White);
            }
            spriteBatch.Draw(this.texture, position, Color.White);
        }
    }
}
