using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace OSTIA
{
    class VIEW_WINDOW
    {
        private VIEW_WINDOW? _parent = null;
        private Point sPt;
        private Point ePt;

        private Point sCPt;
        private Point eCPt;

        bool isSPT = false;
        bool isCPT = false;

        public VIEW_WINDOW(VIEW_WINDOW parent = null)
        {
            _parent = parent;
        }

        public VIEW_WINDOW setVIEW(int _x1, int _y1, int _x2, int _y2)
        {
            sPt.X = _x1;sPt.Y = _y1;
            ePt.X = _x2;ePt.Y = _y2;

            isSPT = true;
            return this;
        }

        public VIEW_WINDOW setWINDOW(int _x1, int _y1, int _x2, int _y2)
        {
            sCPt.X = _x1; sCPt.Y = _y1;
            eCPt.X = _x2; eCPt.Y = _y2;

            isCPT = true;
            return this;
        }

        public bool isOK()
        {
            return isSPT & isCPT;
        }

        public int X(int _x)
        {
            if (_x > eCPt.X) _x = eCPt.X;
            if (_x < sCPt.X) _x = sCPt.X;
            int x = sPt.X + (_x - sCPt.X) *(ePt.X - sPt.X)/ (eCPt.X - sCPt.X);
            
            if(_parent != null)
            {
                return _parent.X(x);
            }
            else
            {
                return x;
            }
        }

        public int Y(int _y)
        {
            if (_y > eCPt.Y) _y = eCPt.Y;
            if (_y < sCPt.Y) _y = sCPt.Y;
            int y = sPt.Y + (_y - sCPt.Y) * (ePt.Y - sPt.Y) / (eCPt.Y - sCPt.Y);

            if (_parent != null)
            {
                return _parent.Y(y);
            }
            else
            {
                return y;
            }
        }

        public Point PT(Point _pt)
        {
            return new Point(X(_pt.X), Y(_pt.Y));
        }

        public Point PT(int _x,int _y)
        {
            return new Point(X(_x), Y(_y));
        }

    }
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

        public void appendLog(string log)
        {
            logEditor.AppendText(log + "   ");
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
            Font _font = logEditor.Font;

            logEditor.AppendText("\n");
            int s = logEditor.SelectionStart + 1;
            int l = seg.Length;
            logEditor.AppendText(seg);
            logEditor.AppendText("\n");

            logEditor.Select(s, l);
            logEditor.SelectionColor = Color.White;

            logEditor.SelectionFont = new Font(_font.FontFamily, _font.Size + 2, FontStyle.Bold);
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

        private void _drawText(VIEW_WINDOW vw,Graphics g,string s, int x, int y, Color _color, Font _font, bool vertical = false)
        {
            if (vertical)
            {
                g.DrawString(s, _font, new SolidBrush(_color),vw.X(x),vw.Y(y), new StringFormat() { FormatFlags = StringFormatFlags.DirectionVertical });
            }
            else
            {
                g.DrawString(s, _font, new SolidBrush(_color), vw.X(x), vw.Y(y));
            }
        }

        private void _drawTextJustify(VIEW_WINDOW vw, Graphics g, string s, Color _color, int x1, int y1, int x2, int y2, Font font, StringAlignment align = StringAlignment.Center, bool vertical = false)
        {
            RectangleF drawRect = new RectangleF(vw.X(x1), vw.Y(y1), vw.X(x2), vw.Y(y2));

            if (vertical)
            {
                g.DrawString(s, font, new SolidBrush(_color), drawRect, new StringFormat() { FormatFlags = StringFormatFlags.DirectionVertical });
            }
            else
            {
                g.DrawString(s, font, new SolidBrush(_color), drawRect);
            }
        }

        private void _drawLine(VIEW_WINDOW vw, Graphics g,Pen _pen, int x1, int y1, int x2, int y2)
        {
            g.DrawLine(_pen, vw.PT(x1,y1),vw.PT(x2,y2));
        }

        private void _drawFillRect(VIEW_WINDOW vw, Graphics g,Color _color, int x1, int y1, int x2, int y2)
        {
            g.FillRectangle(new SolidBrush(_color),vw.X(x1),vw.Y(y1),vw.X(x2-x1),vw.Y(y2-y1));
        }

        private void _drawRect(VIEW_WINDOW vw, Graphics g,Pen _pen, int x1, int y1, int x2, int y2)
        {
            g.DrawRectangle(_pen, vw.X(x1), vw.Y(y1), vw.X(x2 - x1), vw.Y(y2 - y1));
        }

        private void _drawCircle(VIEW_WINDOW vw, Graphics g, Pen _pen, int x, int y,int r,bool isFill = false)
        {
            if(!isFill)
            {
                g.DrawEllipse(_pen, vw.X(x-r/2), vw.Y(y-r/2), vw.X(x+r/2), vw.Y(y+r/2));
            }
            else
            {
                g.FillEllipse(new SolidBrush(_pen.Color), vw.X(x - r / 2), vw.Y(y - r / 2), vw.X(x + r / 2), vw.Y(y + r / 2));
            }            
        }

        private void _drawImage(VIEW_WINDOW vw, Graphics g,Bitmap bi,int x, int y)
        {
            g.DrawImage(bi, vw.PT(x, y));
        }

        public void DrawGraph(bool temp = false)
        {
            
            int el=3600;
            int sl = 0;
            int CT = 0;
            bool WholeNum = true;
            int[] na = new int[3601];

            tabControl1.SelectTab(1);

            if (!temp)
            {
                el = Global.Instance.Session.MaxPoints;
            }

            lblTooltip.Visible = false;
            //---Start

            /*sl: (0~15min) Start Location
            el: End locattion

            sl = sl * 240;
            el = el * 240;*/

            Point pt1 = PointToScreen(new Point(0, 0));
            Point pt2 =tabPage2.PointToScreen(new Point(0, 0));
            Rectangle rt = Screen.FromControl(this).Bounds;
            Size sz = new Size(rt.Width - (pt2.X-pt1.X)*2-10, rt.Height - (pt2.Y-pt1.Y)-100);

            VIEW_WINDOW vw = new VIEW_WINDOW();
            vw.setVIEW(0,0, sz.Width,sz.Height).setWINDOW(0,0,640,480);

            Bitmap bm = new Bitmap(tabPage2.Width, tabPage2.Height); 

            using (Graphics gr = Graphics.FromImage(bm))// Bitmap bm = new Bitmap(640, 480); Graphics.FromImage(bm)
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
                gr.SmoothingMode = SmoothingMode.HighSpeed;

                _drawRect(vw,gr, new Pen(Color.White, 2), 38, 48, 639, 402);

                double n = 0.0D;
                for (int y = 400; y >= 50; y -= 44)
                {
                    n = (double)(y - 400) / (44*5);
                    string a = Math.Round(Math.Abs(n),3).ToString();
                    _drawText(vw,gr,a, 26, y + 5, Color.White,new Font("Arial", 12));

                    _drawLine(vw,gr,new Pen(Color.Blue, 2) { DashStyle = DashStyle.DashDot }, 639, y + 9, 38, y + 9);
                }

                _drawText(vw,gr,"W /cm", 5, 250, Color.Yellow, new Font("Arial", 12), true);
                _drawText(vw,gr,"2", 5, 210, Color.Yellow, new Font("Arial", 12), true);

                CT = sl / 240;
                if (sl == 0) CT = 0;
                
                for (int x = 36; x <= 638; x += 600 * 240 / (el - sl) )
                {
                    var t = $"- {CT}";
                    if (!WholeNum)
                    {
                        if (t.Length > 4) t = "-        "+t.Substring(0, 3);
                    }
                    _drawText(vw,gr, t, x - 2, 410 , Color.White, new Font("Arial", 12), true);
                    CT += 1;
                }
   
                _drawText(vw,gr, "T I M E", 315, 430, Color.Yellow, new Font("Arial", 12));
                _drawTextJustify(vw,gr, "  OSTIA   ", Color.LightCyan,10,10,150,30, new Font("Arial", 20));

                _drawText(vw,gr, "Case #", 320, 10, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr,  $"{Global.Instance.Session.CaseNumber}", 360, 0, Color.Yellow, new Font("Arial", 12));
                _drawText(vw, gr,  "Test Time: ", 478, 10, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr, Global.Instance.Session.dt.ToString("yyyy-M-d h:mm:s"), 545, 0, Color.Yellow, new Font("Arial", 12));

                _drawText(vw, gr,  "Sample Rate: ", 320, 20, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr,  $"{Global.Instance.Session.SampleRate}", 397, 10, Color.White, new Font("Arial", 12));
                _drawText(vw, gr,  "PPS:", 478, 20, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr,  $"{Global.Instance.Session.SampFreq}", 506, 10, Color.White, new Font("Arial", 12));
                _drawText(vw, gr,  "D: ", 565, 10, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr,  $"{Global.Instance.Session.SampDuty}", 581, 10, Color.White, new Font("Arial", 12));
                _drawText(vw, gr,  "f: ", 615, 10, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr,  $"{Global.Instance.Session.SampBand}", 631, 10, Color.White, new Font("Arial", 12));

                _drawFillRect(vw,gr, Color.Blue, 150, 32, 160, 38);
                _drawText(vw, gr,  "Output Control", 165, 30, Color.White, new Font("Arial", 12));

                _drawFillRect(vw, gr, Color.White, 270, 32, 280, 38);
                _drawText(vw, gr, "Power", 290, 30, Color.White, new Font("Arial", 12));

                _drawFillRect(vw, gr, Color.Brown, 370, 32, 380, 38);
                _drawText(vw, gr, "Patient Response", 390, 30, Color.White, new Font("Arial", 12));

                _drawFillRect(vw, gr,  Color.Red, 500, 32, 510, 38);
                _drawText(vw, gr,  "Pause ON", 515, 30, Color.White, new Font("Arial", 12));

                _drawTextJustify(vw,gr, " @Copyright 1994-2002                              ", Color.White,20, 460,620, 20, new Font("Arial", 12));
                //_drawCircle(vw, gr, new Pen(Color.Beige), 29, 475, 6, true);

                VIEW_WINDOW vw1 = new VIEW_WINDOW(vw);
                vw1.setVIEW(40, 40, 638,440).setWINDOW(sl, 40, el, 440);

                goto jump1;

                for (int x = sl; x <= el - 2; x++)
                {
                    var t = Convert.ToString(Global.Instance.Validation[x].Pause, 2);
                    t = new string('0', 8 - t.Length) + t;
                    t = t.Substring(7, 1);
                    if (t != "0")
                    {
                        _drawLine(vw1,gr, new Pen(Color.Cyan, 5), x - 1, 398, x + 2, 404);
                    }
                }

                vw1.setVIEW(40, 40, 638, 400).setWINDOW(sl, 0, el, 64);
                Point pt = new Point()
                {
                    X = sl,
                    Y = 0
                };
                _drawCircle(vw1,gr,new Pen(Color.White), sl, 0, 1,true);
                
                for (int x = sl; x <= el; x++)
                {
                    _drawLine(vw1,gr,new Pen(Color.White, 2), pt.X, pt.Y, x, Global.Instance.Validation[x].Power);
                    pt.X = x; pt.Y = Global.Instance.Validation[x].Power;
                }

                int thick = 0;
                int Thresh = 5;
                double PowerDelta =0;
                double RespDelta =0;
                int j=0;

                for (j = -1; j <= 1; j++)
                {
                    pt.X = sl; pt.Y = 0;
                    if(el -sl == 3599)
                    {
                        thick = j * ((el - sl) / 600);
                    }
                    else
                    {
                        j = 1;
                        thick = 0;
                    }

                    for(int x =sl;x <= el;x++)
                    {
                        Thresh = 5;
                        if(x > Thresh)
                        {
                            PowerDelta = Global.Instance.Validation[x].Power - Global.Instance.Validation[x - Thresh].Power;
                            PowerDelta = PowerDelta / Thresh;

                            RespDelta = Global.Instance.Validation[x].Response - Global.Instance.Validation[x - Thresh].Response;
                            RespDelta = RespDelta / Thresh;
                        }
                        _drawLine(vw1, gr, new Pen(Color.Brown, 2), pt.X, pt.Y, x+thick, Global.Instance.Validation[x].Response);
                    }
                }

                na[0] = Global.Instance.Validation[0].Dial;
  
                for(int x=sl; x<= el; x++)
                {
                    if (x == 0) x = 1;
                    na[x] = na[x - 1] + (Global.Instance.Validation[x].Dial - Global.Instance.Validation[x-1].Dial); 
                    if(Global.Instance.Validation[x].Dial - Global.Instance.Validation[x-1].Dial < -45)
                    {
                        na[x] = na[x - 1] + (Global.Instance.Validation[x].Dial - Global.Instance.Validation[x - 1].Dial) + 63;
                    }
                    if (Global.Instance.Validation[x].Dial - Global.Instance.Validation[x - 1].Dial > 45)
                    {
                        na[x] = na[x - 1] + (Global.Instance.Validation[x].Dial - Global.Instance.Validation[x - 1].Dial) - 63;
                    }

                    if (na[x] > 63) { na[x] = 63; }
                    if (na[x] < 0) { na[x] = 0; }
                }

                pt.X = sl; pt.Y = 0;
                _drawCircle(vw1, gr, new Pen(Color.White), sl, 0, 1, true);
                thick = j * ((el - sl) / 600);

                for(int x =sl;x<=el;x++)
                {
                    _drawLine(vw1, gr, new Pen(Color.LightBlue, 2), pt.X, pt.Y, x, na[x]);
                    pt.X = x; pt.Y = na[x];
                }

                jump1:
                ;
            }

            tabPage2.BackgroundImage = bm;
            tabPage2.BackgroundImageLayout = ImageLayout.None;
        }
    }
}
