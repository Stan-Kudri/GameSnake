using System;
using Core.Components;
using Core.Components.GameMapItems;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SnakeMonoGame;

namespace MonoGameSnake.ComponentsGame.ItemGameMap
{
    public class BorderMono : Border
    {
        private readonly Color _color = Color.Salmon;
        private readonly IServiceProvider _serviceProvider;
        private readonly Texture2D _texture2D;

        public BorderMono(BorderSize size, IServiceProvider serviceProvider, TextureHolder textureHolder)
            : base(size)
        {
            _serviceProvider = serviceProvider;
            _texture2D = textureHolder.BoardTexture;
        }

        public Texture2D Texture2D => _texture2D;

        public override void Draw()
        {
            Borders.ForEach(x => _serviceProvider.GetRequiredService<SpriteBatch>().
                Draw(
                    _texture2D,
                    new Vector2(x.X * _texture2D.Width, x.Y * _texture2D.Height),
                    _color));
        }
    }
}
