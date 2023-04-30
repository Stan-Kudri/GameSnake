using Core.Components.GameMapItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSnake.ComponentsGame.ItemGameMap
{
    public class BoarderMono : Border
    {
        private Color _color = Color.Salmon;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture2D;

        public BoarderMono(int width, int height) : base(width, height)
        {
        }

        public override void Draw()
        {
            Borders.ForEach(x => _spriteBatch.Draw(
                _texture2D,
                new Vector2(x.X * _texture2D.Width, x.Y * _texture2D.Height),
                _color));
        }

        public void Initialize(SpriteBatch spriteBatch) => _spriteBatch = spriteBatch;

        public void LoadContent(Texture2D texture2D) => _texture2D = texture2D;
    }
}
