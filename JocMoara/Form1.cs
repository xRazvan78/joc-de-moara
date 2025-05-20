using System;
using System.Drawing;
using System.Windows.Forms;

namespace JocMoara {
    public partial class Menu : Form {
        private Rectangle original_form_size;
        private Rectangle original_button_back_size;
        
        public Menu() {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e) {
            original_form_size = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);   
            original_button_back_size=new Rectangle(btnBack.Location.X,btnBack.Location.Y,btnBack.Width, btnBack.Height);   
            btnBack.Visible = false;
            lblRules.Visible = false;
            lblRules.BackColor = Color.FromArgb(100, 0, 0, 0);
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
 
        private void btnPlayOff_Click(object sender, EventArgs e) {
            Game off_game = new Game();
            this.Hide();
            off_game.ShowDialog();
            this.Show();

        }
        private void btnRules_Click(object sender, EventArgs e) {
            string rules = "         Both players begin with 9 pieces.\n\n" +
         "Each player places 1 piece at a time,the player with white pieces begins.\n\n" +
         "After both players place their 9 pieces you can move your pieces.\n\n" +
         "Try to form a line of 3 pieces, a mill.\n\n" +
         "Once you form a mill, you can remove one of your opponent's pieces.\n\n" +
         "Pieces from a formed mill cannot be removed.\n\n" +
         "You can move the pieces from a mill to unlock it and reform it again later.\n\n" +
         "If you are left with 3 pieces, you will be able to jump.\n\n" +
         "The goal of the game is to make your opponent to reach with 2 pieces.\n\n";
            btnBack.Visible = true;
            btnPlay.Visible = false;
            btnRules.Visible = false;
            btnExit.Visible = false;
            lblRules.Visible = true;
            lblRules.Text = rules;
           
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            btnBack.Visible = false;
            btnRules.Visible = true;
            btnPlay.Visible = true;
            btnExit.Visible = true;
            lblRules.Visible = false;
            bckgphoto.Visible = true;
        }

        private void Menu_Resize(object sender, EventArgs e) {
             ResizeControl(original_button_back_size, btnBack);
        }

       
    }
}
