using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace JocMoara {
    public partial class Game : Form {

        private GameLogic game_logic;
        private Rectangle original_button_size;
        private Rectangle original_form_size;
        
        public Game() {
            InitializeComponent();
            panel1.MouseClick += new MouseEventHandler(panel1_ClickToPlacePiece);
            game_logic = new GameLogic();
            
        }

        private void OfflineGame_Load(object sender, EventArgs e) {
            original_form_size = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
            original_button_size = new Rectangle(btnGive.Location.X, btnGive.Location.Y, btnGive.Width, btnGive.Height);
            lblWhiteCounter.Text = $"x{game_logic.player1.pieces_to_place}";
            lblBlackCounter.Text = $"x{game_logic.player2.pieces_to_place}";
            lblGameAn.Visible = false;
            game_logic.PossibleMoves = game_logic.ShowValidPositions();
        }
        private void ResizeControl(Rectangle r, Control c) {
            float x_ratio = (float)(this.Width) / (float)(original_form_size.Width);
            float y_ratio = (float)(this.Height) / (float)(original_form_size.Height);

            int new_x = (int)(r.Location.X * x_ratio);
            int new_y = (int)(r.Location.Y * y_ratio);

            int new_width = (int)(r.Width * x_ratio);
            int new_heigth = (int)(r.Height * y_ratio);

            c.Location = new Point(new_x, new_y);
            c.Size = new Size(new_width, new_heigth);
        }

        
        private void panel1_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            game_logic.DrawBoard(g);
        }

        private void panel1_ClickToPlacePiece(object sender, MouseEventArgs e) {
            lblGameAn.Visible = false;
            int click_X = e.X;
            int click_Y = e.Y;
            game_logic.PossibleMoves.Clear();

            if (game_logic.current_player.pieces_to_place == 0 && game_logic.opponent.pieces_to_place == 0) {
                
                lblGameAn.Visible = true;
                lblGameAn.Text = "              Both players played all their pieces!";
                panel1.MouseClick -= panel1_ClickToPlacePiece;
                panel1.MouseClick += panel1_ClickToMovePiece;
            }

            if (game_logic.current_player.HasPiecesToPlace()) {
                Point valid_pos = game_logic.CheckForValidPos(click_X, click_Y);
                
                if (valid_pos != Point.Empty && !game_logic.PositionIsTaken(valid_pos)) {
                    PlayerPiece new_piece = new PlayerPiece(game_logic.current_player, valid_pos);
                    game_logic.current_player.PlacePiece(new_piece, valid_pos);
                    game_logic.PlacedPieces.Add(new_piece);
                    
                    if (game_logic.current_player == game_logic.player1) 
                    lblWhiteCounter.Text= $"x{game_logic.player1.pieces_to_place}";
                    else
                    lblBlackCounter.Text = $"x{game_logic.player2.pieces_to_place}";

                   
                    game_logic.CheckForMill();
                    if (game_logic.current_player.removal_mode == true) {
                        lblGameAn.Visible = true;
                        lblGameAn.Text = $"      {game_logic.current_player.Name} formed a mill and will remove a piece!";
                        panel1.MouseClick -= panel1_ClickToPlacePiece;
                        panel1.MouseClick += panel1_ClickToRemovePiece;
                    }
                    else {
                        game_logic.SwitchPlayer();
                    }
                    
                    panel1.Invalidate();
                }
                else {
                    lblGameAn.Visible = true;
                    lblGameAn.Text = "                  Position is taken or is not valid!";
                }
            }
            game_logic.PossibleMoves = game_logic.ShowValidPositions();
        }
        private void panel1_ClickToRemovePiece(object sender, MouseEventArgs e) {
            
            int click_X = e.X;
            int click_Y = e.Y;

            PlayerPiece clicked_piece = null;

            foreach (var piece in game_logic.opponent.Pieces) {
                if (game_logic.IsInRange(piece.Position, new Point(click_X, click_Y), 20)) {
                    clicked_piece = piece;
                    break;
                }
            }

            if (clicked_piece != null) {

                if (!game_logic.IsPieceInMill(game_logic.opponent, clicked_piece)) {
                    game_logic.RemoveOpponentPiece(game_logic.opponent, clicked_piece);
                    
                    lblGameAn.Visible = false;

                    game_logic.current_player.ResetRemovalMode();
                    
                    if (game_logic.current_player.pieces_to_place == 0 && game_logic.opponent.pieces_to_place == 0) {
                        panel1.MouseClick -= panel1_ClickToRemovePiece;
                        panel1.MouseClick += panel1_ClickToMovePiece;
                    }
                    else {
                        game_logic.PossibleMoves = game_logic.ShowValidPositions();
                        panel1.Invalidate();
                        panel1.MouseClick -= panel1_ClickToRemovePiece;
                        panel1.MouseClick += panel1_ClickToPlacePiece;
                    }
                    game_logic.SwitchPlayer();

                    if (CheckForWinner())
                        return;

                    panel1.Invalidate();
                }
                else {
                    lblGameAn.Visible = true;
                    lblGameAn.Text = "                     Opponent's piece is in a mill";
                }

            }
            else {
                lblGameAn.Visible = true;
                lblGameAn.Text = "                            No piece selected";
            }
        }

        private void panel1_ClickToMovePiece(object sender, MouseEventArgs e) {
            
            lblGameAn.Visible = false;
            int click_X = e.X;
            int click_Y = e.Y;

            foreach (var piece in game_logic.current_player.Pieces) {
                if (game_logic.IsInRange(piece.Position, new Point(click_X, click_Y), 20)) {
                    if (game_logic.selected_piece == null || game_logic.selected_piece != piece) {
                        game_logic.selected_piece = piece;
                        game_logic.PossibleMoves = game_logic.GetPossibleMoves(game_logic.selected_piece);
                        lblGameAn.Visible = false;
                    }
                    else if (game_logic.selected_piece == piece) {
                        game_logic.selected_piece = null;
                        game_logic.PossibleMoves.Clear();
                    }
                    panel1.Invalidate();

                }
  
            }

            if (game_logic.selected_piece != null) {
                var temp_moves = new List<Point>(game_logic.PossibleMoves);
                foreach (var new_pos in temp_moves) {
                    if (game_logic.IsInRange(new_pos, new Point(click_X, click_Y), 20)) {

                        game_logic.RemoveMillIfPieceMoved(game_logic.selected_piece);
                        game_logic.selected_piece.MovePos(new_pos);
                        game_logic.selected_piece = null;
                        game_logic.PossibleMoves.Clear();
                        game_logic.CheckForMill();

                        if (game_logic.current_player.removal_mode == true) {
                            lblGameAn.Visible = true;
                            lblGameAn.Text = $"      {game_logic.current_player.Name} formed a mill and will remove a piece!";
                            panel1.MouseClick -= panel1_ClickToMovePiece;
                            panel1.MouseClick += panel1_ClickToRemovePiece;
                        }
                        else
                            game_logic.SwitchPlayer();
                        panel1.Invalidate();

                    }
                }
            }

        }

        private void OfflineGame_Resize(object sender, EventArgs e) {
            ResizeControl(original_button_size, btnGive);
        }

        public bool CheckForWinner() {

            if (game_logic.current_player.Pieces.Count < 3 && game_logic.opponent.pieces_to_place == 0 && game_logic.current_player.pieces_to_place == 0) {

                MessageBox.Show($"{game_logic.opponent.Name} won the game!", "Winner", MessageBoxButtons.OK);
                this.Close();
                return true;
            }
            return false;
        }

        private void btnGive_Click(object sender, EventArgs e) {
            MessageBox.Show($"{game_logic.opponent.Name} won the game, {game_logic.current_player.Name} gave up!", "Winner", MessageBoxButtons.OK);
            this.Close();
        }

        


    }
}
