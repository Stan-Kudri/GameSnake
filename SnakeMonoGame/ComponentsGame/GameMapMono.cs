using Core.Components;
using Core.Components.GameMapItems;
using Core.Components.GameMapItems.Foods;
using Microsoft.Xna.Framework.Graphics;
using MonoGameSnake.ComponentsGame.ItemGameMap;
using MonoGameSnake.ComponentsGame.ItemGameMap.Foods;

namespace MonoGameSnake.ComponentsGame
{
    public class GameMapMono : GameMap
    {
        public GameMapMono(BorderMono border, SnakeMono snake, SpriteBatch spriteBatch, Texture2D texture2DFood)
            : this(border, snake, new FoodFactoryMono(texture2DFood, spriteBatch))
        {
        }

        public GameMapMono(Border border, Snake snake, FoodFactory foodFactoryMono)
            : base(border, snake, foodFactoryMono)
        {
        }
    }
}
