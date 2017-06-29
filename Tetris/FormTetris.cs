using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class FormTetris : Form
    {
        public FormTetris()
        {
            InitializeComponent();
        }

        Tetris myTetris = new Tetris();//实例化Tetris类，用于操作游戏
        Tetris tempTetris = new Tetris();//实例化Tetris类，用于生成下一个方块样式
        public static int cakeNO = 0;//记录下一个方块样式的标识
        public static bool become = false;//判断是否生成下一个方块的样式
        public static bool isBegin = false;//判断当前游戏是否开始
        public bool isPause = false;//判断是否暂停游戏,默认不暂停

        private void Btn_start_Click(object sender, EventArgs e)
        {
            myTetris.ConvertorClear();//清空整个控件
            myTetris.firstPoint = new Point(100, 20);//设置方块的起始位置
            myTetris.LblRow = lblRow;//将label3控件加载到Tetris类中
            myTetris.LblScore = lblScore;//将label4控件加载到Tetris类中
            timer1.Interval = 500;//下移的速度
            timer1.Enabled = true;//开始计时
            Random rand = new Random();//实例化Random
            cakeNO = rand.Next(1, 8);//获取随机数
            myTetris.CakeMode(cakeNO);//设置方块的样式
            myTetris.Protract(panelMain);//绘制组合方块
            nextGraph();//生成下一个方块的样式
            myTetris.PlaceInitialization();//初始化Random类中的信息
            isBegin = true;//判断是否开始
            isPause = false;//判断是否暂停
            myTetris.timer = timer1;
            Btn_pause.Text = "暂停";
            textBox1.Focus();//获取焦点
        }

        private void Btn_pause_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Stop();//暂停
                Btn_pause.Text = "继续";
                isPause = true;
                textBox1.Focus();//获取焦点
            }
            else
            {
                timer1.Start();//继续
                Btn_pause.Text = "暂停";
                isPause = false;
                textBox1.Focus();//获取焦点
            }
        }


        /// <summary>
        /// 生成下一个方块的样式
        /// </summary>
        public void nextGraph()
        {
            Graphics nextGraph = panelNext.CreateGraphics();
            nextGraph.FillRectangle(new SolidBrush(Color.Black), 0, 0, panelNext.Width, panelNext.Height);
            Random rand = new Random();//实例化Random
            cakeNO = rand.Next(1, 8);//获取随机数
            tempTetris.firstPoint = new Point(40, 30);//设置方块的起始位置
            tempTetris.CakeMode(cakeNO);//设置方块的样式
            tempTetris.Protract(panelNext);//绘制组合方块
        }

   
        private void FormTetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isBegin)//如果没有开始游戏
                return;
            if (isPause)//如果游戏暂停
                return;
            if (e.KeyCode == Keys.Up)//如果当前按下的是↑键
                myTetris.MyConvertorMode();//变换当前方块的样式
            if (e.KeyCode == Keys.Down)//如果当前按下的是↓键
            {
                timer1.Interval = 300;//增加下移的速度
                myTetris.ConvertorMove(0);//方块下移
            }
            if (e.KeyCode == Keys.Left)//如果当前按下的是←键
                myTetris.ConvertorMove(1);//方块左移
            if (e.KeyCode == Keys.Right)//如果当前按下的是→键
                myTetris.ConvertorMove(2);//方块右移
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            myTetris.ConvertorMove(0);//方块下移
            if (become)//如果显示新的方块
            {
                nextGraph();//生成下一个方块
                become = false;
            }
            textBox1.Focus();//获取焦点
        }

        private void FormTetris_KeyUp(object sender, KeyEventArgs e)
        {
            if (!isBegin)//如果游戏没有开始
                return;
            if (isPause)//如果暂停游戏
                return;
            if (e.KeyCode == Keys.Down)//如果当前松开的是↓键
            {
                timer1.Interval = 500;//恢复下移的速度
            }
            textBox1.Focus();//获取焦点
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            if (isBegin)//如是游戏开始
            {
                //重绘背景上的方块
                for (int i = 0; i <= (panelMain.Width / 20 - 1); i++)
                {
                    for (int j = 0; j <= (panelMain.Height / 20 - 1); j++)
                    {
                        Rectangle rect = new Rectangle(i * 20 + 1, j * 20 + 1, 19, 19);//获取各方块的绘制区域
                        e.Graphics.FillRectangle(new SolidBrush(Tetris.placeColor[i, j]), rect);//绘制方块
                    }
                }
            }
        }

 

        private void panelNext_Paint(object sender, PaintEventArgs e)
        {
            if (isBegin)//如果游戏开始
            {
                tempTetris.firstPoint = new Point(50, 30);//设置方块的起始位置
                tempTetris.CakeMode(cakeNO);//设置方块的样式
                tempTetris.Protract(panelNext);//绘制组合方块
            }
        }

    }
}
