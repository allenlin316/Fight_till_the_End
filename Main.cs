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
        int gameMode, min=3, sec=0, msec=15;
        public Main()
        {
            InitializeComponent();
            this.SetBounds(0, 0, 660, 680);
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
            if (gameMode == 1) {
                game_timer.Start();
                return;
            }
            else
                Application.Exit();
        }

        private void game_timer_Tick(object sender, EventArgs e)
        {
            countDown();
        }

        void countDown()
        {
            msec--;
            if (msec <= 0)
            {
                msec = 15;
                sec--;
            }
            if (sec <= 0)
            {
                if (min <= 0)
                {
                    timer_display.Text = "時間到";
                }
                timer_display.Text = "時間: " + min.ToString() + " 分 ";
                sec = 59;
                min--;
            }
            else if (min <= 0)
            {
                timer_display.Text = "時間: " + sec + " 秒";
            }
            else
            {
                timer_display.Text = "時間: " + min + " 分 " + sec + " 秒";
            }
        }
    }
}
