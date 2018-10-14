using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pingpon20215
{
    public partial class Form1 : Form
    {
        int[] directions = new int[] { -1, 1 };

        private Random rand;

        int speed_upper_bound = 5, speed_lower_bound = 1;
        int npc_speed_x = 3;

        int ball_init_space_interval;
        int ball_vx, ball_vy;
        
        public Form1()
        {
            InitializeComponent();

            rand = new Random();

            ball_init_space_interval = -1;

            // top
            ball_init_space_interval = NPC.Bottom > ball_init_space_interval ? NPC.Bottom : ball_init_space_interval;
            // bottom
            ball_init_space_interval = (Width - board.Top) + ball.Height > ball_init_space_interval ? (Width - board.Top) + ball.Height : ball_init_space_interval;
            // right
            ball_init_space_interval = ball.Width > ball_init_space_interval ? ball.Width : ball_init_space_interval;

            //MessageBox.Show("ball_init_space_interval = " + ball_init_space_interval.ToString());

            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        // 初始化各項變數
        private void init()
        {
            // init the location of ball randomly
            ball.Top = rand.Next(ball_init_space_interval, Height - ball_init_space_interval);
            ball.Left = rand.Next(ball_init_space_interval, Width - ball_init_space_interval);

            // init the velocity of ball randomly
            ball_vx = directions[rand.Next(1)] * rand.Next(speed_lower_bound, speed_upper_bound);
            ball_vy = directions[rand.Next(1)] * rand.Next(speed_lower_bound, speed_upper_bound);

            lblNotification.Visible = true;
        }

        private void catch_or_not(Label l, string message)
        {
            if (ball.Right >= l.Left && ball.Left <= l.Right) //球在球拍寬度範圍內
            {
                // catch
                //double F = ((double)center - (double)l.Left) / (double)l.Width; // 以擊球點計算擊球力道
                //if (ball_vx < 0) { F = (1.0 - F); } // 力道方向調整
                //F = F + 0.5; // 力道大小修正

                double a = (ball.Left - (l.Left - ball.Width)) / (double)(l.Width + 2 * ball.Width); // 以擊球點計算擊球力道
                a = ball_vx < 0 ? 1.0 - a : a; // 力道方向調整
                a += 1.5; // 力道大小修正

                // 施加力道
                ball_vx += (int)Math.Round(a * timer1.Interval);
                //反彈
                ball_vy = -ball_vy;
            }
            else // 沒接到
            {
                // didn't catch
                // 結束球的運動
                timer1.Stop();

                //顯示訊息結束遊戲
                MessageBox.Show(message);
                
                // 重新開始
                Form1_Load(this, null);
            }
        }

        //球的移動控制
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*** 處理球的碰撞 ***/
            //X方向移動
            //Y方向移動
            // motion of ball
            ball.Top += ball_vy * timer1.Interval;
            ball.Left += ball_vx * timer1.Interval;
            
            //處理左邊界碰撞
            //處理右邊界碰撞
            // the collision of left and right boundary
            ball_vx = ball.Left >= 0 && ball.Right < Width ? ball_vx : -ball_vx;
            
            if (ball.Top < NPC.Bottom) //高於NPC高度時(可能碰撞板子)
                catch_or_not(NPC, "You win");

            if (ball.Bottom > board.Top) //低於擊球板高度時(可能碰撞板子)
                catch_or_not(board, "Game over");

            /*** 處理NPC的移動 ***/
            int npc_center = (NPC.Right + NPC.Left) / 2;
            int ball_center = (ball.Left + ball.Right) / 2; //球的中點X座標

            if (ball_center < npc_center) // 球在左邊向左移
                NPC.Left -= npc_speed_x * timer1.Interval;
            else if (ball_center > npc_center) // 球在右邊向右移
                NPC.Left += npc_speed_x * timer1.Interval;
        }

        int mdx; //球拍拖曳X起點

        //開始拖曳
        private void P_MouseDown(object sender, MouseEventArgs e)
        {
            if(timer1.Enabled == false) // 如果遊戲還沒開始
            {
                timer1.Start();
                lblNotification.Visible = false;
            }

            //拖曳X起點
            // the x coordinate in the container of  mouse
            mdx = e.X;
        }

        //拖曳中
        private void P_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //左鍵按下(拖曳)狀態
                board.Left += e.X - mdx;
        }
    }
}
