using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeMonoGame
{
    public class TextureHolder
    {
        public TextureHolder(Game game)
        {
            var content = game.Content;
            BoardTexture = content.Load<Texture2D>("BorderElement");
            SnakeTexture = content.Load<Texture2D>("SnakeElement");
            FoodTexture = content.Load<Texture2D>("Food");
            GameOverTexture = content.Load<Texture2D>("GameOver");
            Font = content.Load<SpriteFont>("Font");
        }

        public Texture2D BoardTexture { get; private set; }

        public Texture2D SnakeTexture { get; private set; }

        public Texture2D FoodTexture { get; private set; }

        public Texture2D GameOverTexture { get; private set; }

        public SpriteFont Font { get; private set; }
    }
}
