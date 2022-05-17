namespace Snake
{
    partial class OpenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_doikhang1v1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.player_name = new System.Windows.Forms.TextBox();
            this.hostip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.player_num = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(55, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên người chơi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(55, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tham gia phòng";
            // 
            // btn_doikhang1v1
            // 
            this.btn_doikhang1v1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btn_doikhang1v1.Location = new System.Drawing.Point(327, 319);
            this.btn_doikhang1v1.Name = "btn_doikhang1v1";
            this.btn_doikhang1v1.Size = new System.Drawing.Size(150, 91);
            this.btn_doikhang1v1.TabIndex = 3;
            this.btn_doikhang1v1.Text = "Bắt đầu trò chơi";
            this.btn_doikhang1v1.UseVisualStyleBackColor = true;
            this.btn_doikhang1v1.Click += new System.EventHandler(this.btn_doikhang1v1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button1.Location = new System.Drawing.Point(538, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // player_name
            // 
            this.player_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.player_name.Location = new System.Drawing.Point(60, 158);
            this.player_name.Name = "player_name";
            this.player_name.Size = new System.Drawing.Size(417, 32);
            this.player_name.TabIndex = 6;
            // 
            // hostip
            // 
            this.hostip.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.hostip.Location = new System.Drawing.Point(60, 237);
            this.hostip.Name = "hostip";
            this.hostip.Size = new System.Drawing.Size(686, 32);
            this.hostip.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.label3.Location = new System.Drawing.Point(244, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(321, 33);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rắn săn mồi đối kháng!";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button5.Location = new System.Drawing.Point(121, 378);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(138, 32);
            this.button5.TabIndex = 10;
            this.button5.Text = "Hướng dẫn";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.Location = new System.Drawing.Point(471, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 26);
            this.label4.TabIndex = 11;
            this.label4.Text = "Host/Guest (Điền 1 hoặc 2)";
            // 
            // player_num
            // 
            this.player_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.player_num.Location = new System.Drawing.Point(583, 158);
            this.player_num.Name = "player_num";
            this.player_num.Size = new System.Drawing.Size(163, 32);
            this.player_num.TabIndex = 12;
            // 
            // Open
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.player_num);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hostip);
            this.Controls.Add(this.player_name);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_doikhang1v1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Open";
            this.Text = "SnakeGameSurvival";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_doikhang1v1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox player_name;
        private System.Windows.Forms.TextBox hostip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox player_num;
    }
}