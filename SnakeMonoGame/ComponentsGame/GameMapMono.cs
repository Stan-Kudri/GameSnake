using Core.Components;
using Core.Components.GameMapItems;
using Microsoft.Xna.Framework.Graphics;
using MonoGameSnake.ComponentsGame.ItemGameMap.Foods;
using SnakeMonoGame;

namespace MonoGameSnake.ComponentsGame
{
    public class GameMapMono : GameMap
    {
        public GameMapMono(Border border, Snake snake, SpriteBatch spriteBatch, TextureHolder textureHolder)
            : base(border, snake, new FoodFactoryMono(textureHolder, spriteBatch))
        {
        }

        /*
        public GameMapMono(Border border, Snake snake, FoodFactory foodFactoryMono)
            : base(border, snake, foodFactoryMono)
        {
        }
        */
    }
}
