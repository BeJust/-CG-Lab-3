using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class MainWindow : Form
    {
        Graphics gBitmap;
        Graphics gScreen;
        Bitmap bitmap;
        public List<Point> points = new List<Point>();


        public MainWindow()
        {
            InitializeComponent();
            gBitmap = CreateGraphics();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            gScreen = CreateGraphics();
            bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
        }

        private void MainWindow_MouseClick(object sender, MouseEventArgs e)
        {
            if (points.Count < 4)
            {
                int x, y;
                x = e.Location.X;
                y = e.Location.Y;
                points.Add(new Point(x, y));
                gBitmap.FillEllipse(Brushes.Brown, x, y, 5, 5);
                if (points.Count == 4)
                {
                    Draw();
                }
            }
        }

        public bool Intersection(Point A, Point B, Point C, Point D, out Point result)
        {
            result = new Point();
            double xo = A.X, yo = A.Y;
            double p = B.X - A.X, q = B.Y - A.Y;

            double x1 = C.X, y1 = C.Y;
            double p1 = D.X - C.X, q1 = D.Y - C.Y;

            double x = (xo * q * p1 - x1 * q1 * p - yo * p * p1 + y1 * p * p1) /
                       (q * p1 - q1 * p);
            double y = (yo * p * q1 - y1 * p1 * q - xo * q * q1 + x1 * q * q1) /
                       (p * q1 - p1 * q);

            result = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
            double pTo0 = Math.Sqrt(Math.Pow(result.X - A.X, 2) + Math.Pow(result.Y - A.Y, 2));
            double pTo1 = Math.Sqrt(Math.Pow(result.X - B.X, 2) + Math.Pow(result.Y -B.Y, 2));
            double pTo2 = Math.Sqrt(Math.Pow(result.X - C.X, 2) + Math.Pow(result.Y - C.Y, 2));
            double pTo3 = Math.Sqrt(Math.Pow(result.X - D.X, 2) + Math.Pow(result.Y - A.Y, 2));
            double To01 = Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(points[1].Y - A.Y, 2));
            double To23 = Math.Sqrt(Math.Pow(D.X - C.X, 2) + Math.Pow(points[3].Y - C.Y, 2));

            if (Math.Abs(pTo0 + pTo1 - To01) <= 0.1 || Math.Abs(pTo2 + pTo3 - To23) <= 0.1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw()
        {
            Point result = new Point();
            DDA(points[0].X, points[0].Y, points[1].X, points[1].Y);
            DDA(points[2].X, points[2].Y, points[3].X, points[3].Y);
            if (Intersection(points[0], points[1], points[2], points[3], out result))
            {
                gBitmap.FillEllipse(Brushes.Red, result.X - 3, result.Y - 3, 10, 10);
            }
            else
            {
                MessageBox.Show("Отрезки не пересекаются");
            }

            gBitmap.Dispose();
            gScreen.Dispose();
            bitmap.Dispose();
        }

        public void DDA(int x1, int y1, int x2, int y2)
        {
            float L = Math.Max(Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            float dx = (x2 - x1) / L;
            float dy = (y2 - y1) / L;
            float x = x1;
            float y = y1;
            for (int i = 0; i <= L; i++)
            {
                x += dx;
                y += dy;
                gBitmap.FillRectangle(Brushes.Black, x, y, 1, 1);
            }

        }

        private void Clean_btn_Click(object sender, EventArgs e)
        {
            gBitmap = CreateGraphics();
            gScreen = CreateGraphics();
            bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            gBitmap.Clear(Color.AliceBlue);
            gScreen.Clear(Color.AliceBlue);
            points.Clear();
        }
    }
}