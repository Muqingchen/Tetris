using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    class Tetris
    {
        public Point firstPoint = new Point(100, 20);//定义方块的起始位置
        public static Color[,] placeColor;//记录方块的颜色
        public static bool[,] place;//记录方块的位置
        public static int conWidth = 0;//最大宽度
        public static int conHeight = 0;//高度
        public static int maxY = 0;
        public static int conMax = 0;
        public static int conMin = 0;
        bool[] tempArray={false,false,false,false};
        Color conColor = Color.Coral;//珊瑚色
        Point[] currentArrayPoint = new Point[4];//当前方块数组
        Point[] lastArrPoint = new Point[4];//前一个方块数组
        int cake = 20;//定义方块大小
        int convertor = 0;//定义变换器
        Control myControl = new Control();
        public Label LblRow = new Label();//
        public Label LblScore = new Label();//
        public static int[] arrayScore = new int[] { 2, 5, 9, 15 };//
        public Timer timer = new Timer();//

        /// <summary>
        /// 设置方块的样式
        /// </summary>
        /// <param name="n">标识，方块的样式</param>
        public void CakeMode(int n)
        {
            currentArrayPoint[0] = firstPoint;
            switch (n)
            {
                case 1:///L型方块
                    {
                        currentArrayPoint[1] = new Point(firstPoint.X, firstPoint.Y - cake);
                        currentArrayPoint[2] = new Point(firstPoint.X, firstPoint.Y + cake);
                        currentArrayPoint[3]=new Point(firstPoint.X+cake,firstPoint.Y+cake);
                        conColor = Color.Fuchsia;//紫红色
                        convertor = 2;
                        break;
                    }
                case 2:///Z型方块
                    {
                        currentArrayPoint[1] = new Point(firstPoint.X, firstPoint.Y - cake);
                        currentArrayPoint[2] = new Point(firstPoint.X-cake, firstPoint.Y - cake);
                        currentArrayPoint[3] = new Point(firstPoint.X+cake, firstPoint.Y );
                        conColor = Color.Yellow;//黄色
                        convertor = 6;
                        break;
                    }
                case 3://J型方块
                    {
                        currentArrayPoint[1] = new Point(firstPoint.X, firstPoint.Y - cake);
                        currentArrayPoint[2] = new Point(firstPoint.X, firstPoint.Y + cake);
                        currentArrayPoint[3] = new Point(firstPoint.X-cake, firstPoint.Y + cake);
                        conColor = Color.CornflowerBlue;//菊蓝色
                        convertor = 8;
                        break;
                    }
                case 4:///S型方块
                    {
                        currentArrayPoint[1] = new Point(firstPoint.X, firstPoint.Y - cake);
                        currentArrayPoint[2] = new Point(firstPoint.X + cake, firstPoint.Y - cake);
                        currentArrayPoint[3] = new Point(firstPoint.X -cake, firstPoint.Y);
                        conColor = Color.Blue;//蓝色
                        convertor = 12;
                        break;
                    }
                case 5:///T型方块，
                    {
                        currentArrayPoint[1] = new Point(firstPoint.X, firstPoint.Y - cake);
                        currentArrayPoint[2] = new Point(firstPoint.X + cake, firstPoint.Y - cake);
                        currentArrayPoint[3] = new Point(firstPoint.X - cake, firstPoint.Y-cake);
                        conColor = Color.Silver;//银白色
                        convertor = 14;
                        break;
                    }
                case 6:///I型方块，初始点为左数第三块
                    {
                        currentArrayPoint[1] = new Point(firstPoint.X+cake, firstPoint.Y );
                        currentArrayPoint[2] = new Point(firstPoint.X - cake, firstPoint.Y );
                        currentArrayPoint[3] = new Point(firstPoint.X - cake*2, firstPoint.Y);
                        conColor = Color.Red;//红色
                        convertor = 18;
                        break;
                    }
                case 7:///O型方块，初始点为右下角
                    {
                        currentArrayPoint[1] = new Point(firstPoint.X - cake, firstPoint.Y);
                        currentArrayPoint[2] = new Point(firstPoint.X - cake, firstPoint.Y-cake);
                        currentArrayPoint[3] = new Point(firstPoint.X , firstPoint.Y-cake);
                        conColor = Color.LightGreen;//浅绿色
                        convertor = 19;
                        break;
                    }
            }
        }

        /// <summary>
        /// 清空游戏背景
        /// </summary>
        public void ConvertorClear()
        {
            if (myControl != null)//如要已载入背景控件
            {
                Graphics g = myControl.CreateGraphics();//创建背景控件的Graphics类
                Rectangle rect = new Rectangle(0, 0, myControl.Width, myControl.Height);//获取背景的区域
                MyPaint(g, new SolidBrush(Color.Black), rect);//用背景色填充背景
            }
        }

        /// <summary>
        /// 设置方块的变换样式
        /// </summary>
        /// <param mode="int">标识，判断变换的样式</param>
        public void ConvertorMode(int mode)
        {
            Point[] tempArrayPoint = new Point[4];//定义一个临时数组
            Point tempPoint = firstPoint;//获取方块的起始位置
            int nextMode = mode;//记录方块的下一个变换样式
            //将当前方块的位置存入到临时数组中
            for (int i = 0; i < tempArrayPoint.Length; i++)
                tempArrayPoint[i] = currentArrayPoint[i];
            switch (mode)//根据标识变换方块的样式
            {
                case 1://设置“L”方块的起始样式
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X, tempPoint.Y - cake);
                        tempArrayPoint[2] = new Point(tempPoint.X, tempPoint.Y + cake);
                        tempArrayPoint[3] = new Point(tempPoint.X + cake, tempPoint.Y + cake);
                        nextMode = 2;//记录变换样式的标志
                        break;
                    }
                case 2://“L”方块向旋转的样式
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X - cake, tempPoint.Y);
                        tempArrayPoint[2] = new Point(tempPoint.X + cake, tempPoint.Y);
                        tempArrayPoint[3] = new Point(tempPoint.X + cake, tempPoint.Y - cake);
                        nextMode = 3;
                        break;
                    }
                case 3://“L”方块向旋转的样式
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X, tempPoint.Y - cake);
                        tempArrayPoint[2] = new Point(tempPoint.X - cake, tempPoint.Y - cake);
                        tempArrayPoint[3] = new Point(tempPoint.X, tempPoint.Y + cake);
                        nextMode = 4;
                        break;
                    }
                case 4://“L”方块向旋转的样式
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X + cake, tempPoint.Y);
                        tempArrayPoint[2] = new Point(tempPoint.X - cake, tempPoint.Y);
                        tempArrayPoint[3] = new Point(tempPoint.X - cake, tempPoint.Y + cake);
                        nextMode = 1;//返回方块的起始样式
                        break;
                    }
                case 5://Z
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X, tempPoint.Y - cake);
                        tempArrayPoint[2] = new Point(tempPoint.X - cake, tempPoint.Y - cake);
                        tempArrayPoint[3] = new Point(tempPoint.X + cake, tempPoint.Y);
                        nextMode = 6;
                        break;
                    }
                case 6:
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X + cake, tempPoint.Y);
                        tempArrayPoint[2] = new Point(tempPoint.X + cake, tempPoint.Y - cake);
                        tempArrayPoint[3] = new Point(tempPoint.X, tempPoint.Y + cake);
                        nextMode = 5;
                        break;
                    }
                case 7://倒L
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X, tempPoint.Y - cake);
                        tempArrayPoint[2] = new Point(tempPoint.X, tempPoint.Y + cake);
                        tempArrayPoint[3] = new Point(tempPoint.X - cake, tempPoint.Y + cake);
                        nextMode = 8;
                        break;
                    }
                case 8:
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X - cake, tempPoint.Y);
                        tempArrayPoint[2] = new Point(tempPoint.X + cake, tempPoint.Y);
                        tempArrayPoint[3] = new Point(tempPoint.X + cake, tempPoint.Y + cake);
                        nextMode = 9;
                        break;
                    }
                case 9:
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X, tempPoint.Y - cake);
                        tempArrayPoint[2] = new Point(tempPoint.X, tempPoint.Y + cake);
                        tempArrayPoint[3] = new Point(tempPoint.X + cake, tempPoint.Y - cake);
                        nextMode = 10;
                        break;
                    }
                case 10:
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X - cake, tempPoint.Y);
                        tempArrayPoint[2] = new Point(tempPoint.X + cake, tempPoint.Y);
                        tempArrayPoint[3] = new Point(tempPoint.X - cake, tempPoint.Y - cake);
                        nextMode = 7;
                        break;
                    }
                case 11://倒Z
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X, tempPoint.Y - cake);
                        tempArrayPoint[2] = new Point(tempPoint.X + cake, tempPoint.Y - cake);
                        tempArrayPoint[3] = new Point(tempPoint.X - cake, tempPoint.Y);
                        nextMode = 12;
                        break;
                    }
                case 12:
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X - cake, tempPoint.Y);
                        tempArrayPoint[2] = new Point(tempPoint.X - cake, tempPoint.Y - cake);
                        tempArrayPoint[3] = new Point(tempPoint.X, tempPoint.Y + cake);
                        nextMode = 11;
                        break;
                    }
                case 13://T
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X, tempPoint.Y - cake);
                        tempArrayPoint[2] = new Point(tempPoint.X + cake, tempPoint.Y - cake);
                        tempArrayPoint[3] = new Point(tempPoint.X - cake, tempPoint.Y - cake);
                        nextMode = 14;
                        break;
                    }
                case 14:
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X, tempPoint.Y - cake);
                        tempArrayPoint[2] = new Point(tempPoint.X, tempPoint.Y + cake);
                        tempArrayPoint[3] = new Point(tempPoint.X + cake, tempPoint.Y);
                        nextMode = 15;
                        break;
                    }
                case 15:
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X - cake, tempPoint.Y);
                        tempArrayPoint[2] = new Point(tempPoint.X + cake, tempPoint.Y);
                        tempArrayPoint[3] = new Point(tempPoint.X, tempPoint.Y - cake);
                        nextMode = 16;
                        break;
                    }
                case 16:
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X, tempPoint.Y - cake);
                        tempArrayPoint[2] = new Point(tempPoint.X - cake, tempPoint.Y);
                        tempArrayPoint[3] = new Point(tempPoint.X, tempPoint.Y + cake);
                        nextMode = 13;
                        break;
                    }
                case 17://一
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X + cake, tempPoint.Y);
                        tempArrayPoint[2] = new Point(tempPoint.X - cake, tempPoint.Y);
                        tempArrayPoint[3] = new Point(tempPoint.X - cake * 2, tempPoint.Y);
                        nextMode = 18;
                        break;
                    }
                case 18:
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X, tempPoint.Y - cake);
                        tempArrayPoint[2] = new Point(tempPoint.X, tempPoint.Y + cake);
                        tempArrayPoint[3] = new Point(tempPoint.X, tempPoint.Y + cake * 2);
                        nextMode = 17;
                        break;
                    }
                case 19://田
                    {
                        tempArrayPoint[1] = new Point(tempPoint.X - cake, tempPoint.Y);
                        tempArrayPoint[2] = new Point(tempPoint.X - cake, tempPoint.Y - cake);
                        tempArrayPoint[3] = new Point(tempPoint.X, tempPoint.Y - cake);
                        nextMode = 19;
                        break;
                    }
            }
            bool isChange = true;//判断方块是否可变
            //遍历方块的各个子方块
            for (int i = 0; i < tempArrayPoint.Length; i++)
            {
                if (tempArrayPoint[i].X / 20 < 0 || tempArrayPoint[i].X / 20 >= conWidth || tempArrayPoint[i].Y / 20 >= conHeight)//变换后是否超出边界
                {
                    isChange = false;//不变换
                    break;
                }
                if (place[tempArrayPoint[i].X / 20, tempArrayPoint[i].Y / 20])//变换后是否与其他方块重叠
                {
                    isChange = false;
                    break;
                }
            }
            if (isChange)//如果当前方块可以变换
            {
                //改变当前方块的样式
                for (int i = 0; i < tempArrayPoint.Length; i++)
                    currentArrayPoint[i] = tempArrayPoint[i];
                firstPoint = tempPoint;//获取当前方块的起始位置
                convertor = nextMode;//获取方块下一次的变换样式
            }
        }


        /// <summary>
        /// 清空当前方块的区域
        /// </summary>
        public void ConvertorDelete()
        {
            Graphics g = myControl.CreateGraphics();//创建背景控件的Graphics类
            for (int i = 0; i < currentArrayPoint.Length; i++)//遍历方块的各个子方块
            {
                Rectangle rect = new Rectangle(currentArrayPoint[i].X, currentArrayPoint[i].Y, 20, 20);//获取各子方块的区域
                MyPaint(g, new SolidBrush(Color.Black), rect);//用背景色填充背景
            }
        }


        /// <summary>
        /// 绘制组合方块
        /// </summary>
        /// <param control="Control">控件</param>
        public void Protract(Control control)
        {
            myControl = control;
            Graphics g = control.CreateGraphics();//创建背景控件的Graphics类
            //绘制方块的各个子方块
            for (int i = 0; i < currentArrayPoint.Length; i++)
            {
                Rectangle rect = new Rectangle(currentArrayPoint[i].X + 1, currentArrayPoint[i].Y + 1, 19, 19);//获取子方块的区域
                MyPaint(g, new SolidBrush(conColor), rect);//绘制子方块
            }
        }

        /// <summary>
        /// 对方块的单个块进行绘制
        /// </summary>
        /// <param g="Graphics">封装一个绘图的类对象</param>
        /// <param SolidB="SolidBrush">画刷</param>
        /// <param rect="Rectangle">绘制区域</param>
        public void MyPaint(Graphics g, SolidBrush SolidB, Rectangle rect)
        {
            g.FillRectangle(SolidB, rect);//填充一个矩形
        }

        /// <summary>
        /// 变换当前方块的样式
        /// </summary>
        public void MyConvertorMode()
        {
            ConvertorDelete();//清空当前方块的区域
            ConvertorMode(convertor);//设置方块的变换样式
            Protract(myControl);//绘制变换后的组合方块
        }

        /// <summary>
        /// 方块移动
        /// </summary>
        /// <param n="int">标识，对左右下进行判断</param>
        public void ConvertorMove(int n)
        {
            //记录方块移动前的位置
            for (int i = 0; i < lastArrPoint.Length; i++)
                lastArrPoint[i] = currentArrayPoint[i];
            switch (n)//方块的移动方向
            {
                case 0://下移
                    {
                        //遍历方块中的子方块
                        for (int i = 0; i < lastArrPoint.Length; i++)
                            lastArrPoint[i] = new Point(lastArrPoint[i].X, lastArrPoint[i].Y + cake);//使各子方块下移一个方块位
                        break;
                    }
                case 1://左移
                    {
                        for (int i = 0; i < lastArrPoint.Length; i++)
                            lastArrPoint[i] = new Point(lastArrPoint[i].X - cake, lastArrPoint[i].Y);
                        break;
                    }
                case 2://右移
                    {
                        for (int i = 0; i < lastArrPoint.Length; i++)
                            lastArrPoint[i] = new Point(lastArrPoint[i].X + cake, lastArrPoint[i].Y);

                        break;
                    }
            }

            bool isOutside = MoveStop(n);//记录方块移动后是否出边界
            if (!isOutside)//如果没有出边界
            {
                ConvertorDelete();//清空当前方块的区域
                //获取移动后方块的位置
                for (int i = 0; i < lastArrPoint.Length; i++)
                    currentArrayPoint[i] = lastArrPoint[i];
                firstPoint = currentArrayPoint[0];//记录方块的起始位置
                Protract(myControl);//绘制移动后方块
            }
            else//如果方块到达底部
            {
                if (isOutside && n == 0)//如果当前方块是下移
                {
                    conMax = 0;//记录方块落下后的顶端位置
                    conMin = myControl.Height;//记录方块落下后的底端位置
                    //遍历方块的各个子方块
                    for (int i = 0; i < currentArrayPoint.Length; i++)
                    {
                        if (currentArrayPoint[i].Y < maxY)//记录方块的顶端位置
                            maxY = currentArrayPoint[i].Y;
                        place[currentArrayPoint[i].X / 20, currentArrayPoint[i].Y / 20] = true;//记录指定的位置已存在方块
                        placeColor[currentArrayPoint[i].X / 20, currentArrayPoint[i].Y / 20] = conColor;//记录方块的颜芭
                        if (currentArrayPoint[i].Y > conMax)//记录方块的顶端位置
                            conMax = currentArrayPoint[i].Y;
                        if (currentArrayPoint[i].Y < conMin)//记录方块的底端位置
                            conMin = currentArrayPoint[i].Y;
                    }
                    if (firstPoint.X == 100 && firstPoint.Y == 20)
                    {
                        timer.Stop();
                        FormTetris.isBegin = false;
                        MessageBox.Show("游戏结束", "提示");
                        return;
                    }

                    Random rand = new Random();//实例化Random
                    int CakeNO = rand.Next(1, 8);//获取随机数
                    firstPoint = new Point(100, 20);//设置方块的起始位置
                    CakeMode(FormTetris.cakeNO);//设置方块的样式
                    Protract(myControl);//绘制组合方块
                    RefurbishRow(conMax, conMin);//去除已填满的行
                    FormTetris.become = true;//标识，判断可以生成下一个方块
                }
            }
        }

        /// <summary>
        /// 去除已添满的行
        /// </summary>
        public void RefurbishRow(int Max, int Min)
        {
            Graphics g = myControl.CreateGraphics();//创建背景控件的Graphics类
            int tempMin = Min / 20;//获取方块的最小位置在多少行
            bool tem_bool = false;
            //初始化记录刷新行的数组
            for (int i = 0; i < tempArray.Length; i++)
                tempArray[i] = false;

            for (int i = 0; i < 4; i++)//查找要刷新的行
            {
                if ((tempMin + i) > 19)//如果超出边界
                    break;//退出本次操作
                tem_bool = false;
                //如果当前行中有空格
                for (int k = 0; k < conWidth; k++)
                {
                    if (!place[k, tempMin + i])//如果当前位置为空
                    {
                        tem_bool = true;
                        break;
                    }
                }
                if (!tem_bool)//如要当行为满行
                {
                    tempArray[i] = true;//记录为刷新行
                }
            }

            int Progression = 0;//记录去除的几行
            if (tempArray[0] == true || tempArray[1] == true || tempArray[2] == true || tempArray[3] == true)//如果有刷新行
            {
                int Trow = 0;//记录最小行数
                for (int i = (tempArray.Length - 1); i >= 0; i--)//遍历记录刷新行的数组
                {
                    if (tempArray[i])//如果是刷新行
                    {
                        Trow = Min / 20 + i;//记录最小行数
                        //将刷新行到背景顶端的区域下移
                        for (int j = Trow; j >= 1; j--)
                        {
                            for (int k = 0; k < conWidth; k++)
                            {
                                placeColor[k, j] = placeColor[k, j - 1];//记录方块的位置
                                place[k, j] = place[k, j - 1];//记录方块的位置
                            }
                        }
                        Min += 20;//方块的最小位置下移一个方块位
                        //将背景的顶端清空
                        for (int k = 0; k < conWidth; k++)
                        {
                            placeColor[k, 0] = Color.Black;//记录方块的位置
                            place[k, 0] = false;//记录方块的位置
                        }
                        Progression += 1;//记录刷新的行数
                    }
                }

                //在背景中绘制刷新后的方块图案
                for (int i = 0; i < conWidth; i++)
                {
                    for (int j = 0; j <= Max / 20; j++)
                    {
                        Rectangle rect = new Rectangle(i * cake + 1, j * cake + 1, 19, 19);//获取各方块的区域
                        MyPaint(g, new SolidBrush(placeColor[i, j]), rect);//绘制已落下的方块
                    }
                }
                //显示当前的刷新行数
                LblRow.Text = Convert.ToString(Convert.ToInt32(LblRow.Text) + Progression);
                //显示当前的得分情况
                LblScore.Text = Convert.ToString(Convert.ToInt32(LblScore.Text) + arrayScore[Progression - 1]);
            }
        }

        /// <summary>
        /// 对信息进行初始化
        /// </summary>
        public void PlaceInitialization()
        {
            conWidth = myControl.Width / 20;//获取背景的总行数
            conHeight = myControl.Height / 20;//获取背景的总列数
            place = new bool[conWidth, conHeight];//定义记录各方块位置的数组
            placeColor = new Color[conWidth, conHeight];//定义记录各方块颜色的数组
            //对各方块的信息进行初始化
            for (int i = 0; i < conWidth; i++)
            {
                for (int j = 0; j < conHeight; j++)
                {
                    place[i, j] = false;//方块为空
                    placeColor[i, j] = Color.Black;//与背景色相同
                }
            }
            maxY = conHeight * cake;//记录方块的最大值
        }

        /// <summary>
        /// 判断方块移动时是否出边界
        /// </summary>
        public bool MoveStop(int n)
        {
            bool isOutside = false;
            int tempWidth = 0;
            int tempHeight = 0;
            switch (n)
            {
                case 0://下移
                    {
                        //遍历方块中的各个子方块
                        for (int i = 0; i < lastArrPoint.Length; i++)
                        {
                            tempWidth = lastArrPoint[i].X / 20;//获取方块的横向坐标值
                            tempHeight = lastArrPoint[i].Y / 20;//获取方块的纵向坐标值
                            if (tempHeight == conHeight || place[tempWidth, tempHeight])//判断是否超出底边界，或是与其他方块重叠
                                isOutside = true;//超出边界
                        }
                        break;
                    }
                case 1://左移
                    {
                        for (int i = 0; i < lastArrPoint.Length; i++)
                        {
                            tempWidth = lastArrPoint[i].X / 20;
                            tempHeight = lastArrPoint[i].Y / 20;
                            if (tempWidth == -1 || place[tempWidth, tempHeight])//判断是否超出左边界，或是与其他方块重叠
                                isOutside = true;
                        }
                        break;
                    }
                case 2://右移
                    {
                        for (int i = 0; i < lastArrPoint.Length; i++)
                        {
                            tempWidth = lastArrPoint[i].X / 20;
                            tempHeight = lastArrPoint[i].Y / 20;
                            if (tempWidth == conWidth || place[tempWidth, tempHeight])//判断是否超出右边界，或是与其他方块重叠
                                isOutside = true;
                        }
                        break;
                    }
            }
            return isOutside;
        }
    }
}
