using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class OpenForm : Form
    {
        
        public OpenForm()
        {
            InitializeComponent();
        }

        private void btn_doikhang1v1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(player_num.Text) == 1 || Int32.Parse(player_num.Text) == 2)
                    PVP.pl_num_pvp = Int32.Parse(player_num.Text);
                else player_name.Text = "";
                PVP.pl_name_pvp = player_name.Text;
                PVP.iph_pvp = hostip.Text;
                frmGame a = new frmGame();
                a.Show();
                this.Hide();
            }
            catch (Exception) when (player_name.Text == "" || player_num.Text == "" || hostip.Text == "")
            {
                MessageBox.Show("Nhap chua du du lieu");
            }
            catch (Exception) when (player_num.Text != "1" && player_num.Text != "2")
            {
                MessageBox.Show("Host/Guest chua hop le!");
            }
        }
    }
}
