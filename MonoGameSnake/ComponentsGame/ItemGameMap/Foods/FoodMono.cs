using Core.Components.GameMapItems.Foods;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSnake.ComponentsGame.ItemGameMap.Foods
{
    public class FoodMono : Food
    {
        private Vector2 _position;
        private Color _color = Color.Green;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture2D;

        public FoodMono(Core.Point position, int scorePoint = 1)
            : base(position, scorePoint)
        {
        }

        public override void Clear()
        {

        }

        public override void Draw()
        {
            _spriteBatch.Draw(_texture2D, _position, _color);
        }

        public void Initialize(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void LoadContent(Texture2D texture2D)
        {
            _texture2D = texture2D;
            _position = new Vector2(Position.X * texture2D.Width, Position.Y * texture2D.Height);
        }
    }
}
