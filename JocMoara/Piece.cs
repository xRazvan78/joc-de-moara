using System.Drawing;

namespace JocMoara {
    public class Piece {
        public Point Position { get; set; }
        public Piece(Point start_pos) {
            Position = start_pos;
        }
        public void MovePos(Point new_pos) {
            Position = new_pos;
        }
        public virtual void PaintPiece(Graphics g) {
            Brush brush = new SolidBrush(Color.Gray);
            int piece_size = 50;
            g.FillEllipse(brush, Position.X - 15, Position.Y - 15, piece_size, piece_size);
            brush.Dispose();
        }
    }
}
