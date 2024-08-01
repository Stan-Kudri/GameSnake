using Core;
using Core.Components.GameMapItems.Foods;
using Microsoft.Xna.Framework.Graphics;
using SnakeMonoGame;

namespace MonoGameSnake.ComponentsGame.ItemGameMap.Foods
{
    public class FoodFactoryMono : FoodFactory
    {
        private readonly Texture2D _texture2D;
        private readonly SpriteBatch _spriteBatch;

        public FoodFactoryMono(TextureHolder textureHolder, SpriteBatch spriteBatch)
        {
            _texture2D = textureHolder.FoodTexture;
            _spriteBatch = spriteBatch;
        }

        public override Food Create(Point point)
            => new FoodMono(point, _spriteBatch, _texture2D);
    }
}
