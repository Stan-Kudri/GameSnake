namespace GameSnake {
    public class Snake {
        private Point _head;
        private int _lenght = 1;

        public Snake(int x, int y) : this(x, y, 1) { }

        public Snake(int x, int y, int lenght) {
            _head = new Point(x, y, 'o');
            _head.Draw();
        }
    }
}
