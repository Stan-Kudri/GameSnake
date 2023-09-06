using System;
using Core.Components.GameMapItems;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SnakeMonoGame;

namespace MonoGameSnake.ComponentsGame.ItemGameMap
{
    public class SnakeMono : Snake
    {
        private readonly Color _color = Color.Red;
        private readonly IServiceProvider _serviceProvider;
        private readonly Texture2D _texture2D;

        public SnakeMono(Border border, IServiceProvider serviceProvider, TextureHolder textureHolder)
            : base(border)
        {
            _serviceProvider = serviceProvider;
            _texture2D = textureHolder.SnakeTexture;
        }

        public override void Draw()
        {
            Body.ForEach(x => _serviceProvider.GetRequiredService<SpriteBatch>().Draw(
                _texture2D,
                new Vector2(x.X * _texture2D.Width, x.Y * _texture2D.Height),
                _color));
        }
    }
}
