using Core.Components.GameMapItems;
using Microsoft.Xna.Framework.Graphics;
using MonoGameSnake.ComponentsGame.ItemGameMap;

namespace MonoGameSnake.Extension
{
    public static class SnakeFieldExtension
    {
        public const int DividerLengthHalf = 2;

        public static SnakeMono Creator(this Border border, SpriteBatch spriteBatch, Texture2D texture2D, int length = 4)
            => new SnakeMono((border.Width / DividerLengthHalf) - length, border.Height / DividerLengthHalf, border, spriteBatch, texture2D, length);
    }
}
