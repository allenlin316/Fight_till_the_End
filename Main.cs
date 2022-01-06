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
        int sx1=0, sy1=0, x1=0, y1=0;//player1
        int sx2=0, sy2=0, x2=0, y2=0;//player2
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
                spiderman.Location = new Point(17 * 32, 2 * 32);
                green_gobin.Location = new Point(1 * 32, 17 * 32);
                x1 = 17; y1 = 2;
                x2 = 1; y2 = 17;
                return;
            }
            else
                Application.Exit();
        }

        private void game_timer_Tick(object sender, EventArgs e)
        {
            timerCountDown();
        }

        void timerCountDown()
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
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            sx1 = x1; sy1 = y1;
            sx2 = x2; sy2 = y2;
            if (e.KeyCode == Keys.S) { y1++; goDown(sx1, sy1, x1, y1); }
            if (e.KeyCode == Keys.W) { y1--; goUp(sx1, sy1, x1, y1); }
            if (e.KeyCode == Keys.D) { x1++; goRight(sx1, sy1, x1, y1); }
            if (e.KeyCode == Keys.A) { x1--; goLeft(spiderman, sx1, sy1, x1, y1); }
            // (17 ,2)
            //if (e.KeyCode == Keys.Space) { bomb_put(x1, y1); }

            /*if (e.KeyCode == Keys.Down) { y2 ++; goDown(sx2, sy2, x2, y2); }
            if (e.KeyCode == Keys.Up) { y2--; goUp(sx2, sy2, x2, y2); }
            if (e.KeyCode == Keys.Right) { x2++; goRight(sx2, sy2, x2, y2); }
            if (e.KeyCode == Keys.Left) { x2--; goLeft(sx2, sy2, x2, y2); }*/
            //if (e.KeyCode == Keys.Enter) { bomb_put(x2, y2); }
            
            


            spiderman.Left = 32 * x1;
            spiderman.Top = 32 * y1;
            green_gobin.Left = 32 * x2;
            green_gobin.Top = 32 * y2;


            //check.Text = x1 + " " + y1;
        }
        public void goLeft(PictureBox player, int sx, int sy, int x, int y)//往左
        {
            if (map[sy, x] == 0 || map[sy, x] == 2)
            {
                check.Text = x.ToString();
                y = sy;
                x = sx;
            }
            player.Left = 32 * x;
            check.Text += player.Left.ToString();
        }
        public void goRight(int sx, int sy, int x, int y)//往右
        {
            if (map[sy, x] == 0 || map[sy, x] == 2)
            {
                y = sy;
                x = sx;
            }
        }
        public void goUp(int sx, int sy, int x, int y)//往上
        {
            if (map[y, sx] == 0 || map[y, sx] == 2)
            {
                y = sy;
                x = sx;
            }
        }
        public void goDown(int sx, int sy, int x, int y)//往下
        {
            if (map[y, sx] == 0 || map[y, sx] == 2)
            {
                y = sy;
                x = sx;
            }
        }
    }
}
