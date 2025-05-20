using System;
using System.Collections.Generic;
using System.Drawing;

namespace JocMoara {
    public class Player {

        public String Name { get; set; }

        public List<PlayerPiece> Pieces { get; set; }
        public List<List<Point>> FormedMills { get; set; }
        public Color PlayerColor { get; set; }
        public int pieces_to_place = 9;
        public bool removal_mode = false;

        public Player(String name, Color player_color) {
            Name = name;
            Pieces = new List<PlayerPiece>();
            PlayerColor = player_color;
            FormedMills = new List<List<Point>>();

        }

        public void PlacePiece(PlayerPiece piece, Point pos) {
            piece.MovePos(pos);
            Pieces.Add(piece);
            pieces_to_place--;
        }

        public bool HasPiecesToPlace() {
            return pieces_to_place > 0;
        }

        public void SetRemovalMode(bool state) {
            removal_mode = state;
        }

        public void ResetRemovalMode() {
            removal_mode = false;
        }



    }
}
