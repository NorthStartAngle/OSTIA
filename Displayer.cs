using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace OSTIA
{
    public partial class Displayer : Form
    {
        public Displayer()
        {
            InitializeComponent();
        }

        public void clearLog()
        {
            logEditor.Clear();
        }

        public void appendLog(string  log)
        {
            logEditor.AppendText(log+ "   ");
        }

        public void startLog()
        {
            clearLog();
            lblTooltip.Visible = true;
        }

        public void startDrawing()
        {
            lblTooltip.Visible = false;
            tabControl1.SelectTab(1);
            DrawGraph();
        }

        public void appendSeg(string seg)
        {
            Font _font =logEditor.Font;

            logEditor.AppendText("\n");
            int s = logEditor.SelectionStart + 1;
            int l = seg.Length;
            logEditor.AppendText(seg);
            logEditor.AppendText("\n");

            logEditor.Select(s, l);
            logEditor.SelectionColor = Color.White;

            logEditor.SelectionFont=new Font(_font.FontFamily,_font.Size+2,FontStyle.Bold);
        }

        public void appendPart(string seg)
        {
            Font _font = logEditor.Font;

            logEditor.AppendText("\n");
            int s = logEditor.SelectionStart + 1;
            int l = seg.Length;
            logEditor.AppendText(seg);
            logEditor.AppendText("\n");

            logEditor.Select(s, l);
            logEditor.SelectionColor = Color.AliceBlue;

            logEditor.SelectionFont = new Font(_font.FontFamily, _font.Size + 4, FontStyle.Bold);
        }

        private int MapX(int x, Control target, int minX = 0, int maxX = 640)
        {
            return (x - minX) * target.Width / (maxX - minX);
        }

        // Helper method to map y-coordinate to panel's height
        private int MapY(int y, Control target, int minY = 0, int maxY = 480)
        {
            return target.Height - (y - minY) * target.Height / (maxY - minY);
        }

        private int MapW(int w, Control target, int minX = 0, int maxX = 640)
        {
            return (w - minX) * target.Width / (maxX - minX);
        }

        private int MapH(int h, Control target, int minY = 0, int maxY = 480)
        {
            return (h - minY) * target.Width / (maxY - minY);
        }

        private void _drawText(Graphics g,string s,int x, int y,Color _color, string fontFamily,int fontSize,bool vertical = false)
        {
            if ((vertical)
            {
                g.DrawString(s, new Font(fontFamily, fontSize), new SolidBrush(_color), MapX(x, tabControl1.TabPages[1]), MapY(y, tabControl1.TabPages[1]), new StringFormat() { FormatFlags = StringFormatFlags.DirectionVertical });
            }
            else
            {
                g.DrawString(s, new Font(fontFamily, fontSize), new SolidBrush(_color), MapX(x, tabControl1.TabPages[1]), MapY(y, tabControl1.TabPages[1]));
            }        
        }

        private void _drawLine(Graphics g, Pen _pen, int x1, int y1,int x2,int y2)
        {
            g.DrawLine(_pen, MapX(x1, tabControl1.TabPages[1]), MapY(y1, tabControl1.TabPages[1]), MapX(x2, tabControl1.TabPages[1]), MapY(y2, tabControl1.TabPages[1]));
        }

        public void DrawGraph()
        {
            //Bitmap bm = new Bitmap(640, 480);
            Control target = tabControl1.TabPages[1];
            //Global.Instance.Session.MaxPoints
            Font f1 = new Font("Arial", 12,FontStyle.Italic);

            using (Graphics gr = target.CreateGraphics())// Graphics.FromImage(bm)
            {
                
                gr.Clear(Color.Black);
                /*RectangleF rect = new RectangleF(0f, 480.0f, 640f, 0f);
                PointF[] pts =
                {
                    new PointF(0, bm.Height),
                    new PointF(bm.Width, bm.Height),
                    new PointF(0, 0),
                };
                gr.Transform = new Matrix(rect, pts);*/

                gr.SmoothingMode = SmoothingMode.AntiAlias;

                gr.DrawRectangle(new Pen(Color.White, 2), new Rectangle(MapX(38, target),MapY(48,target),MapW(639,target),MapH(402,target)));

                for(int y =400; y>=50; y-=44)
                {
                    string a = (Math.Abs(((y - 400) / 44)) / 5).ToString() + "-";
                    _drawText(gr, a, 45 - a.Length * 8, y + 6, Color.White, "Arial", 12);

                    _drawLine(gr,new Pen(Color.Blue, 5) { DashStyle = DashStyle. DashDot }, 639, y + 9,38, y + 9);
                }

                _drawText(gr, "W /cm", 5, 250, Color.Yellow, "Arial", 12,true);
                _drawText(gr, "2", 1, 210, Color.Yellow, "Arial", 12, true);
                
                /*Graphics g = tabControl1.TabPages[1].CreateGraphics();//Graphics.FromImage(myBitmap);
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Tomato)
                {
                    Width = 5,
                    Color = System.Drawing.Color.White,
                };
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Aqua)
                {
                    Color = System.Drawing.Color.White,

                };*/

                //g.DrawLine(pen, 20, 10, 300, 100);

                /*System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                float x = 150.0F;
                float y = 50.0F;
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                g.DrawString("Sample Text", drawFont, drawBrush, x, y, drawFormat);*/

                /*graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.SmoothingMode = SmoothingMode.HighSpeed;*/
            }
        }
}
