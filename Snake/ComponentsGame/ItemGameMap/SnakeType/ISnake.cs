using GameSnake.Enum;

namespace GameSnake.ComponentsGame.ItemGameMap.SnakeType
{
    public interface ISnake
    {
        public Directions Direction { get; set; }

        public void Move();

        public bool EatFood(Point food);

        public void Draw();

        public void Clear();

        public bool Intersect();

        public bool IntersectBody(Point food);
    }
}
