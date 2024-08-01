using Core.Components.GameMapItems.Foods;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSnake.ComponentsGame.ItemGameMap.Foods
{
    public class FoodMono : Food
    {
        private readonly Vector2 _position;
        private readonly Color _color = Color.Green;
        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D _texture2D;

        public FoodMono(Core.Point position, SpriteBatch spriteBatch, Texture2D texture2D, int scorePoint = 1)
            : base(position, scorePoint)
        {
            _spriteBatch = spriteBatch;
            _texture2D = texture2D;
            _position = new Vector2(Position.X * texture2D.Width, Position.Y * texture2D.Height);
        }

        public override void Draw()
            => _spriteBatch.Draw(_texture2D, _position, _color);
    }
}
