using System.Drawing;

namespace JocMoara {
    public class PlayerPiece : Piece {

        public Player Owner { get; }

        public PlayerPiece(Player owner, Point start_pos) : base(start_pos) {
            Owner = owner;
        }

        public override void PaintPiece(Graphics g) {
            Brush brush = new SolidBrush(Owner.PlayerColor);
            int piece_size = 50;
            int radius = piece_size / 2;

            if (Owner.PlayerColor == Color.White) {
                Pen pen_black = new Pen(Color.Black, 4);
                g.DrawEllipse(pen_black, Position.X - radius, Position.Y - radius, piece_size, piece_size);
                pen_black.Dispose();
            }
            else {
                Pen pen_white = new Pen(Color.White, 4);
                g.DrawEllipse(pen_white, Position.X - radius, Position.Y - radius, piece_size, piece_size);
                pen_white.Dispose();

            }

            g.FillEllipse(brush, Position.X - radius, Position.Y - radius, piece_size, piece_size);
            brush.Dispose();
        }

    }
}
