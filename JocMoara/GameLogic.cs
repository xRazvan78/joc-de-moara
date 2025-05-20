using System;
using System.Collections.Generic;
using System.Drawing;

namespace JocMoara {
    public class GameLogic {
        
        public List<Point> ValidPos { get; private set; }
        public List<Piece> PlacedPieces { get; private set; }
        public List<List<int>> ListOfPossibleMoves { get; private set; }
        public Player player1 { get; private set; }
        public Player player2 { get; private set; }
        public Player current_player { get; private set; }
        public Player opponent { get; private set; }
        public PlayerPiece selected_piece { get; set; }
        public List<Point> PossibleMoves { get; set; }

       
        public GameLogic() {
            ValidPos = new List<Point>();
            PlacedPieces = new List<Piece>();
            ListOfPossibleMoves = new List<List<int>>();
            PossibleMoves = new List<Point>();

            InitializeValidPos();
            InitializeListOfPossibleMoves();
            player1 = new Player("White", Color.White);
            player2 = new Player("Black", Color.Black);
            current_player = player1;
            opponent = player2;

        }

        public void DrawBoard(Graphics g) {
            Pen pen_line = new Pen(Color.Black, 3);

            g.DrawRectangle(pen_line, 75, 75, 450, 450);
            g.DrawRectangle(pen_line, 150, 150, 300, 300);
            g.DrawRectangle(pen_line, 225, 225, 150, 150);

            g.DrawLine(pen_line, 300, 75, 300, 225);
            g.DrawLine(pen_line, 300, 525, 300, 375);
            g.DrawLine(pen_line, 75, 300, 225, 300);
            g.DrawLine(pen_line, 375, 300, 525, 300);

            foreach (var piece in PlacedPieces) {
                piece.PaintPiece(g);

                if (piece == selected_piece) {
                    Pen pen_selection = new Pen(Color.Blue, 4);
                    int piece_size = 50;
                    int radius = piece_size / 2;
                    g.DrawEllipse(pen_selection, piece.Position.X - radius, piece.Position.Y - radius, piece_size, piece_size);
                }
            }

            if (current_player.removal_mode == true) {
                foreach (var piece in opponent.Pieces) {
                    if (CanBeRemoved(piece)) {
                        Pen pen_remove = new Pen(Color.DarkRed, 4);
                        int piece_size = 50;
                        int radius = piece_size / 2;
                        g.DrawEllipse(pen_remove, piece.Position.X - radius, piece.Position.Y - radius, piece_size, piece_size);
                    }
                }
            }

            Brush brush_white=new SolidBrush(Color.White); //counter
            Pen pen_black = new Pen(Color.Black, 4);
            g.DrawEllipse(pen_black, 200, 15, 40, 40);
            g.FillEllipse(brush_white, 200, 15, 40, 40);
            

            Brush brush_black = new SolidBrush(Color.Black); //counter
            Pen pen_white = new Pen(Color.White, 4);
            g.DrawEllipse(pen_white,425, 15, 40, 40);
            g.FillEllipse(brush_black, 425,15,40,40);
            

            if (current_player == player1) { //turn 
                g.DrawEllipse(pen_black, 200, 550, 40, 40);
                g.FillEllipse(brush_white, 200, 550, 40, 40);
                pen_black.Dispose();
                brush_white.Dispose();
            }
            else {
                g.DrawEllipse(pen_white, 200, 550, 40, 40);
                g.FillEllipse(brush_black, 200, 550, 40, 40);
                pen_white.Dispose();
                brush_black.Dispose();
            }

            foreach (var move in PossibleMoves) {
                Brush brush = new SolidBrush(Color.LightGreen);
                g.FillEllipse(brush, move.X - 13, move.Y - 13, 26, 26);
            }

            g.Dispose();
        }

        private void InitializeValidPos() {

            ValidPos.Add(new Point(75, 75));   // poz1
            ValidPos.Add(new Point(300, 75));  // poz2
            ValidPos.Add(new Point(525, 75));
            ValidPos.Add(new Point(150, 150));
            ValidPos.Add(new Point(300, 150));
            ValidPos.Add(new Point(450, 150));
            ValidPos.Add(new Point(225, 225));
            ValidPos.Add(new Point(300, 225));
            ValidPos.Add(new Point(375, 225));
            ValidPos.Add(new Point(75, 300));
            ValidPos.Add(new Point(150, 300));
            ValidPos.Add(new Point(225, 300));
            ValidPos.Add(new Point(375, 300));
            ValidPos.Add(new Point(450, 300));
            ValidPos.Add(new Point(525, 300));
            ValidPos.Add(new Point(225, 375));
            ValidPos.Add(new Point(300, 375));
            ValidPos.Add(new Point(375, 375));
            ValidPos.Add(new Point(150, 450));
            ValidPos.Add(new Point(300, 450));
            ValidPos.Add(new Point(450, 450));
            ValidPos.Add(new Point(75, 525));
            ValidPos.Add(new Point(300, 525));
            ValidPos.Add(new Point(525, 525)); // poz24

        }

        private void InitializeListOfPossibleMoves() {
            for (int i = 0; i < 24; i++)
                ListOfPossibleMoves.Add(new List<int>());

            ListOfPossibleMoves[0].Add(1);
            ListOfPossibleMoves[0].Add(9);
            ListOfPossibleMoves[1].Add(0);
            ListOfPossibleMoves[1].Add(2);
            ListOfPossibleMoves[1].Add(4);
            ListOfPossibleMoves[2].Add(1);
            ListOfPossibleMoves[2].Add(14);
            ListOfPossibleMoves[3].Add(4);
            ListOfPossibleMoves[3].Add(10);
            ListOfPossibleMoves[4].Add(1);
            ListOfPossibleMoves[4].Add(3);
            ListOfPossibleMoves[4].Add(5);
            ListOfPossibleMoves[4].Add(7);
            ListOfPossibleMoves[5].Add(4);
            ListOfPossibleMoves[5].Add(13);
            ListOfPossibleMoves[6].Add(7);
            ListOfPossibleMoves[6].Add(11);
            ListOfPossibleMoves[7].Add(4);
            ListOfPossibleMoves[7].Add(6);
            ListOfPossibleMoves[7].Add(8);
            ListOfPossibleMoves[8].Add(7);
            ListOfPossibleMoves[8].Add(12);
            ListOfPossibleMoves[9].Add(0);
            ListOfPossibleMoves[9].Add(10);
            ListOfPossibleMoves[9].Add(21);
            ListOfPossibleMoves[10].Add(3);
            ListOfPossibleMoves[10].Add(9);
            ListOfPossibleMoves[10].Add(11);
            ListOfPossibleMoves[10].Add(18);
            ListOfPossibleMoves[11].Add(6);
            ListOfPossibleMoves[11].Add(10);
            ListOfPossibleMoves[11].Add(15);
            ListOfPossibleMoves[12].Add(8);
            ListOfPossibleMoves[12].Add(13);
            ListOfPossibleMoves[12].Add(17);
            ListOfPossibleMoves[13].Add(5);
            ListOfPossibleMoves[13].Add(12);
            ListOfPossibleMoves[13].Add(14);
            ListOfPossibleMoves[13].Add(20);
            ListOfPossibleMoves[14].Add(2);
            ListOfPossibleMoves[14].Add(13);
            ListOfPossibleMoves[14].Add(23);
            ListOfPossibleMoves[15].Add(11);
            ListOfPossibleMoves[15].Add(16);
            ListOfPossibleMoves[16].Add(15);
            ListOfPossibleMoves[16].Add(17);
            ListOfPossibleMoves[16].Add(19);
            ListOfPossibleMoves[17].Add(12);
            ListOfPossibleMoves[17].Add(16);
            ListOfPossibleMoves[18].Add(10);
            ListOfPossibleMoves[18].Add(19);
            ListOfPossibleMoves[19].Add(16);
            ListOfPossibleMoves[19].Add(18);
            ListOfPossibleMoves[19].Add(20);
            ListOfPossibleMoves[19].Add(22);
            ListOfPossibleMoves[20].Add(13);
            ListOfPossibleMoves[20].Add(19);
            ListOfPossibleMoves[21].Add(9);
            ListOfPossibleMoves[21].Add(22);
            ListOfPossibleMoves[22].Add(19);
            ListOfPossibleMoves[22].Add(21);
            ListOfPossibleMoves[22].Add(23);
            ListOfPossibleMoves[23].Add(14);
            ListOfPossibleMoves[23].Add(22);
        }

        public Point CheckForValidPos(int x, int y) {
            int range = 20;
            foreach (var pos in ValidPos) {
                if (Math.Abs(x - pos.X) <= range && Math.Abs(y - pos.Y) <= range) {
                    return pos;
                }
            }
            return Point.Empty;
        }

        public void CheckForMill() {
            List<Point> mill_line = MillFormed(current_player);
            if (mill_line != null) {
                current_player.FormedMills.Add(mill_line);
                current_player.SetRemovalMode(true);
            }
            if (AllOpponentPiecesInMill(opponent)) {
                current_player.SetRemovalMode(false);
            }
        }

        public bool IsInRange(Point c1, Point c2, int range) {
            return Math.Abs(c1.X - c2.X) <= range && Math.Abs(c1.Y - c2.Y) <= range;
        }

        public bool PositionIsTaken(Point pos) {
            foreach (var piece in PlacedPieces) {
                if (piece.Position == pos)
                    return true;
            }
            return false;
        }

        private List<Point> MillFormed(Player player) {
            List<List<Point>> horizontal_lines = GetHorizontalLines();
            foreach (var line in horizontal_lines) {
                if (IsMillOnLine(player, line) && !IsMillAlreadyFormed(player, line))
                    return line;
            }
            List<List<Point>> vertical_lines = GetVerticalLines();
            foreach (var line in vertical_lines) {
                if (IsMillOnLine(player, line) && !IsMillAlreadyFormed(player, line))
                    return line;
            }
            return null;
        }

        private List<List<Point>> GetHorizontalLines() {
            return new List<List<Point>> {
           new List<Point> { new Point(75, 75), new Point(300, 75), new Point(525, 75) },   // Linie orizontala sus
        new List<Point> { new Point(150, 150), new Point(300, 150), new Point(450, 150) }, // Linie orizontala sus-mijloc
        new List<Point> { new Point(225, 225), new Point(300, 225), new Point(375, 225) }, // Linie orizontala sus-jos
        new List<Point> { new Point(75, 300), new Point(150, 300), new Point(225, 300) },   // Linie orizontala stanga
        new List<Point> { new Point(375, 300), new Point(450, 300), new Point(525, 300) }, // Linie orizontala dreapta
        new List<Point> { new Point(225, 375), new Point(300, 375), new Point(375, 375) }, // Linie orizontala jos-sus
        new List<Point> { new Point(150, 450), new Point(300, 450), new Point(450, 450) }, // Linie orizontala jos-mijloc
        new List<Point> { new Point(75, 525), new Point(300, 525), new Point(525, 525) }    // Linie orizontala jos
        };
        }

        private List<List<Point>> GetVerticalLines() {
            return new List<List<Point>> {
             new List<Point> { new Point(75, 75), new Point(75, 300), new Point(75, 525) },   // Linie verticala stanga
        new List<Point> { new Point(150, 150), new Point(150, 300), new Point(150, 450) }, // Linie verticala stanga-mijloc
        new List<Point> { new Point(225, 225), new Point(225, 300), new Point(225, 375) }, // Linie verticala stanga-dreapta
        new List<Point> { new Point(300, 75), new Point(300, 150), new Point(300, 225) }, // Linie verticala sus
        new List<Point> { new Point(300, 375), new Point(300, 450), new Point(300, 525) }, // Linie verticala jos
        new List<Point> { new Point(375, 225), new Point(375, 300), new Point(375, 375) }, // Linie verticala dreapta-stanga
        new List<Point> { new Point(450, 150), new Point(450, 300), new Point(450, 450) }, // Linie verticala dreapta-mijloc
        new List<Point> { new Point(525, 75), new Point(525, 300), new Point(525, 525) }    // Linie verticala dreapta
             };
        }

        public List<Point> ShowValidPositions() {
            List<Point> valid_moves = new List<Point>();
            if (current_player.removal_mode==true || (current_player.pieces_to_place==0 && opponent.pieces_to_place==0)) {
                return valid_moves;
            }
            foreach (var pos in ValidPos) {
                    if (!PositionIsTaken(pos)) {
                        valid_moves.Add(pos);
                    }
            }
                return valid_moves;
        }
        public List<Point> GetPossibleMoves(PlayerPiece piece) {
            List<Point> valid_moves = new List<Point>();
            if (CanJump(current_player)) {
                foreach (var pos in ValidPos) {
                    if (!PositionIsTaken(pos)) {
                        valid_moves.Add(pos);
                    }
                }
                return valid_moves;
            }

            int current_index = -1;
            for (int i = 0; i < ValidPos.Count; i++) {
                if (ValidPos[i] == piece.Position) {
                    current_index = i;
                    break;
                }
            }

            if (current_index == -1)
                return valid_moves;

            foreach (int index in ListOfPossibleMoves[current_index]) {
                if (!PositionIsTaken(ValidPos[index])) {
                    valid_moves.Add(ValidPos[index]);
                }
            }
            return valid_moves;
        }


        private bool CanJump(Player player) {
            return player.Pieces.Count == 3;
        }

        private bool IsMillOnLine(Player player, List<Point> line) {
            int count = 0;
            foreach (var point in line) {
                foreach (var piece in PlacedPieces) {
                    if (piece.Position == point && piece is PlayerPiece && ((PlayerPiece)piece).Owner == player) {
                        count++;
                    }
                }
            }
            return count == 3;
        }

        private bool IsMillAlreadyFormed(Player player, List<Point> line) {
            foreach (var mill in player.FormedMills) {
                if (AreListsEqual(mill, line)) {
                    return true;
                }
            }
            return false;
        }

        private bool AreListsEqual(List<Point> list1, List<Point> list2) {
            if (list1.Count != list2.Count)
                return false;
            for (int i = 0; i < list1.Count; i++) {
                if (list1[i].X != list2[i].X || list1[i].Y != list2[i].Y)
                    return false;
            }
            return true;
        }

        public void SwitchPlayer() {
            current_player = (current_player == player1) ? player2 : player1;
            opponent = (current_player == player1) ? player2 : player1;
        }

        public bool IsPieceInMill(Player player, Piece piece) {
            foreach (var mill in player.FormedMills) {
                if (mill.Contains(piece.Position)) {
                    return true;
                }
            }
            return false;
        }

        public void RemoveOpponentPiece(Player opponent, PlayerPiece piece) {
            opponent.Pieces.Remove(piece);
            PlacedPieces.Remove(piece);
        }

        private bool AllOpponentPiecesInMill(Player opponent) {
            foreach (var piece in opponent.Pieces) {
                if (!IsPieceInMill(opponent, piece)) {
                    return false;
                }
            }
            return true;
        }

        public void RemoveMillIfPieceMoved(PlayerPiece piece) {
            List<List<Point>> remove_mills = new List<List<Point>>();
            foreach (var mill in current_player.FormedMills) {
                if (mill.Contains(piece.Position)) {
                    remove_mills.Add(mill);
                }
            }
            foreach (var mill in remove_mills) {
                current_player.FormedMills.Remove(mill);
            }
        }

        public bool CanBeRemoved(Piece piece) {
            return !IsPieceInMill(opponent, piece);
        }

    }
}
