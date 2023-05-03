using Core;
using Core.Components.GameMapItems.Foods;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSnake.ComponentsGame.ItemGameMap.Foods
{
    public class FoodFactoryMono : FoodFactory
    {
        private readonly Texture2D _texture2D;
        private readonly SpriteBatch _spriteBatch;

        public FoodFactoryMono(Texture2D texture2D, SpriteBatch spriteBatch)
        {
            _texture2D = texture2D;
            _spriteBatch = spriteBatch;
        }

        public override Food Create(Point point)
        {
            var food = new FoodMono(point);
            food.Initialize(_spriteBatch);
            food.LoadContent(_texture2D);

            return food;
        }
    }
}