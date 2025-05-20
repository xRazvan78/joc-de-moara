namespace JocMoara {
    partial class Game {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBlackCounter = new System.Windows.Forms.Label();
            this.lblWhiteCounter = new System.Windows.Forms.Label();
            this.lblPlayerTurn = new System.Windows.Forms.Label();
            this.lblGameAn = new System.Windows.Forms.Label();
            this.btnGive = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.LightSalmon;
            this.panel1.Controls.Add(this.lblBlackCounter);
            this.panel1.Controls.Add(this.lblWhiteCounter);
            this.panel1.Controls.Add(this.lblPlayerTurn);
            this.panel1.Location = new System.Drawing.Point(190, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 600);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblBlackCounter
            // 
            this.lblBlackCounter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBlackCounter.AutoSize = true;
            this.lblBlackCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblBlackCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlackCounter.Location = new System.Drawing.Point(373, 17);
            this.lblBlackCounter.Name = "lblBlackCounter";
            this.lblBlackCounter.Size = new System.Drawing.Size(55, 40);
            this.lblBlackCounter.TabIndex = 7;
            this.lblBlackCounter.Text = "x9";
            // 
            // lblWhiteCounter
            // 
            this.lblWhiteCounter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWhiteCounter.AutoSize = true;
            this.lblWhiteCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblWhiteCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhiteCounter.Location = new System.Drawing.Point(148, 17);
            this.lblWhiteCounter.Name = "lblWhiteCounter";
            this.lblWhiteCounter.Size = new System.Drawing.Size(55, 40);
            this.lblWhiteCounter.TabIndex = 6;
            this.lblWhiteCounter.Text = "x9";
            // 
            // lblPlayerTurn
            // 
            this.lblPlayerTurn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlayerTurn.AutoSize = true;
            this.lblPlayerTurn.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTurn.Location = new System.Drawing.Point(104, 551);
            this.lblPlayerTurn.Name = "lblPlayerTurn";
            this.lblPlayerTurn.Size = new System.Drawing.Size(99, 49);
            this.lblPlayerTurn.TabIndex = 0;
            this.lblPlayerTurn.Text = "Turn:";
            this.lblPlayerTurn.UseCompatibleTextRendering = true;
            // 
            // lblGameAn
            // 
            this.lblGameAn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGameAn.AutoSize = true;
            this.lblGameAn.BackColor = System.Drawing.Color.Transparent;
            this.lblGameAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameAn.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblGameAn.Location = new System.Drawing.Point(184, 47);
            this.lblGameAn.Name = "lblGameAn";
            this.lblGameAn.Size = new System.Drawing.Size(120, 31);
            this.lblGameAn.TabIndex = 8;
            this.lblGameAn.Text = "GameAn";
            // 
            // btnGive
            // 
            this.btnGive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnGive.FlatAppearance.BorderColor = System.Drawing.Color.Peru;
            this.btnGive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnGive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGive.ForeColor = System.Drawing.Color.Red;
            this.btnGive.Location = new System.Drawing.Point(844, 698);
            this.btnGive.Name = "btnGive";
            this.btnGive.Size = new System.Drawing.Size(128, 51);
            this.btnGive.TabIndex = 5;
            this.btnGive.Text = "Give Up";
            this.btnGive.UseVisualStyleBackColor = false;
            this.btnGive.Click += new System.EventHandler(this.btnGive_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.lblGameAn);
            this.Controls.Add(this.btnGive);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game";
            this.Text = "OfflineGame";
            this.Load += new System.EventHandler(this.OfflineGame_Load);
            this.Resize += new System.EventHandler(this.OfflineGame_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGive;
        private System.Windows.Forms.Label lblWhiteCounter;
        private System.Windows.Forms.Label lblBlackCounter;
        private System.Windows.Forms.Label lblPlayerTurn;
        private System.Windows.Forms.Label lblGameAn;
    }
}