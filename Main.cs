using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fight_til_the_End
{
    public partial class Main : Form
    {
        static int[,] map =
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,1,0,1,1,1,1,0,1,1,1,1,1,1,0,0,1,1,0,0},
            {0,1,0,1,1,1,0,0,1,1,1,1,1,1,1,2,1,1,0,0},
            {0,1,1,1,1,1,0,1,1,1,0,0,0,1,1,0,1,1,0,0},
            {0,1,0,1,1,2,0,1,0,1,1,1,0,0,1,0,1,1,0,0},
            {0,0,2,0,1,1,1,1,0,1,1,0,2,1,1,1,1,0,2,0},
            {0,1,1,1,0,0,1,1,0,0,1,0,1,1,1,1,1,0,1,0},
            {0,1,1,1,1,0,0,1,0,2,0,0,1,1,1,1,1,1,1,0},
            {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0},
            {0,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
            {0,0,1,1,1,1,1,0,0,1,1,0,1,0,1,1,0,1,1,0},
            {0,0,1,1,0,1,1,0,1,0,2,0,1,0,0,1,0,1,1,0},
            {0,0,1,1,1,1,1,0,1,0,1,0,1,1,0,1,1,1,1,0},
            {0,1,1,0,1,1,1,1,1,1,1,0,1,1,0,0,1,2,1,0},
            {0,1,1,0,0,2,0,1,0,0,1,1,1,1,1,0,1,1,1,0},
            {0,0,2,1,0,0,1,1,0,1,1,1,0,2,1,0,1,1,1,0},
            {0,1,1,0,1,1,1,0,2,0,1,1,1,0,1,1,1,0,0,0},
            {0,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        }; // 0:obstacle, 1:path, 2:barrel //props are hidden under the barrel
        int gameMode;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
            gameMode = menu.getGameMode();
            gameStart();
        }

        void gameStart()
        {
            if (gameMode == 1)
                return;
            else
                Application.Exit();
        }
    }
}
