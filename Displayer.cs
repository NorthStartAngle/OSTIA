using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace OSTIA
{    
    public partial class Displayer : Form
    {
        public int Scales;
        public Displayer()
        {
            InitializeComponent();

            Scales = 100;
        }
        ~Displayer()
        {

        }

        public void setScale(int _scale)
        {
            if(_scale != Scales)
            {
                 Scales= _scale;
                DrawGraph();
            }
        }

        public void clearLog()
        {
            logEditor.Clear();
        }

        public void appendLog(string log)
        {
            Invoke((Action)(() =>
            {
                logEditor.AppendText(log + "   ");
            }));
        }

        public void startLog()
        {
            clearLog();
            lblDrawPanel.Text = " Loading graph...";
        }

        public void startDrawing()
        {
            lblDrawPanel.Text = "";
            tabControl1.SelectTab(1);
            DrawGraph(Global.Instance.Session.MaxPoints);
        }

        public void appendSeg(string seg)
        {
            Invoke((Action)(() => {
                Font _font = logEditor.Font;

                logEditor.AppendText("\n");
                int s = logEditor.SelectionStart + 1;
                int l = seg.Length;
                logEditor.AppendText(seg);
                logEditor.AppendText("\n");

                logEditor.Select(s, l);
                logEditor.SelectionColor = Color.White;

                logEditor.SelectionFont = new Font(_font.FontFamily, _font.Size + 2, FontStyle.Bold);
                logEditor.ScrollToCaret();
            }));            
        }

        public void appendPart(string seg)
        {
            Invoke((Action)(() => {
                Font _font = logEditor.Font;

                logEditor.AppendText("\n");
                int s = logEditor.SelectionStart + 1;
                int l = seg.Length;
                logEditor.AppendText(seg);
                logEditor.AppendText("\n");

                logEditor.Select(s, l);
                logEditor.SelectionColor = Color.AliceBlue;

                logEditor.SelectionFont = new Font(_font.FontFamily, _font.Size + 4, FontStyle.Bold);

                logEditor.ScrollToCaret();
            }));            
        }

        private void _drawText(VIEW_WINDOW vw, Graphics g, string s, int x, int y, Color _color, Font _font, bool vertical = false)
        {
            if (vertical)
            {
                g.DrawString(s, _font, new SolidBrush(_color), (int)vw.X(x), (int)vw.Y(y), new StringFormat() { FormatFlags = StringFormatFlags.DirectionVertical });
            }
            else
            {
                g.DrawString(s, _font, new SolidBrush(_color), (int)vw.X(x), (int)vw.Y(y));
            }
        }

        private void _drawTextJustify(VIEW_WINDOW vw, Graphics g, string s, Color _color, int x1, int y1, int x2, int y2, Font font, StringAlignment align = StringAlignment.Center, bool vertical = false)
        {
            RectangleF drawRect = new RectangleF((int)vw.X(x1), (int)vw.Y(y1), (int)vw.W(x2-x1), (int)vw.H(y2-y1));

            if (vertical)
            {
                g.DrawString(s, font, new SolidBrush(_color), drawRect, new StringFormat() { FormatFlags = StringFormatFlags.DirectionVertical });
            }
            else
            {
                g.DrawString(s, font, new SolidBrush(_color), drawRect);
            }
        }

        private void _drawLine(VIEW_WINDOW vw, Graphics g, Pen _pen, int x1, int y1, int x2, int y2)
        {
            g.DrawLine(_pen, vw.PT(x1, y1), vw.PT(x2, y2));
        }

        private void _drawFillRect(VIEW_WINDOW vw, Graphics g, Color _color, int x1, int y1, int x2, int y2)
        {
            g.FillRectangle(new SolidBrush(_color), (int)vw.X(x1), (int)vw.Y(y1), (int)vw.W(x2 - x1), (int)vw.H(y2 - y1));
        }

        private void _drawRect(VIEW_WINDOW vw, Graphics g, Pen _pen, int x1, int y1, int x2, int y2)
        {
            g.DrawRectangle(_pen, (int)vw.X(x1), (int)vw.Y(y1), (int)vw.W(x2 - x1), (int)vw.H(y2 - y1));
        }

        private void _drawCircle(VIEW_WINDOW vw, Graphics g, Pen _pen, int x, int y, int r, bool isFill = false)
        {
            if (!isFill)
            {
                g.DrawEllipse(_pen, (int)vw.X(x - r / 2), (int)vw.Y(y - r / 2), (int)vw.W( r / 2), (int)vw.H( r / 2));
            }
            else
            {
                g.FillEllipse(new SolidBrush(_pen.Color), (int)vw.X(x - r / 2), (int)vw.Y(y - r / 2), (int)vw.W(r / 2), (int)vw.H(r / 2));
            }
        }

        private void _drawImage(VIEW_WINDOW vw, Graphics g, Bitmap bi, int x, int y)
        {
            g.DrawImage(bi, vw.PT(x, y));
        }

        public void DrawGraph(int el = 3600, int sl = 0)
        {

            int CT = 0;
            bool WholeNum = true;
            int[] na = new int[3601];

            tabControl1.SelectTab(1);

            lblDrawPanel.Text = "";
            //---Start

            /*sl: (0~15min) Start Location
            el: End locattion

            sl = sl * 240;
            el = el * 240;*/

            Point pt1 = PointToScreen(new Point(0, 0));

            Point pt2 = tabPage2.PointToScreen(new Point(0, 0));
            
            Size sz = new Size(1920 * Scales / 100, 1020 );//new Size(rt.Width - (pt2.X - pt1.X) * 2 - 10, rt.Height - (pt2.Y - pt1.Y) - 100);
            lblDrawPanel.Size = new Size(sz.Width + 14, sz.Height + 44);

            VIEW_WINDOW vw = new VIEW_WINDOW();
            vw.setVIEW(0, 0, sz.Width, sz.Height).setWINDOW(0, 0, 640, 440);

            Bitmap bm = new Bitmap(lblDrawPanel.Width, lblDrawPanel.Height);

            using (Graphics gr = Graphics.FromImage(bm))// Bitmap bm = new Bitmap(640, 480); Graphics.FromImage(bm)
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias; // |SmoothingMode.AntiAlias

                gr.Clear(ColorTranslator.FromHtml("#000000"));                
                
                //gr.SmoothingMode = SmoothingMode.HighSpeed;

                _drawRect(vw, gr, new Pen(Color.White, 2), 38, 48, 639, 402);

                double n = 0.0D;
                for (int y = 400; y >= 50; y -= 44)
                {
                    n = (double)(y - 400) / (44 * 7);
                    string a = Math.Round(Math.Abs(n*100)).ToString() + "%";
                    _drawText(vw, gr, a, 20, y + 5, Color.White, new Font("Arial", 12));

                    _drawLine(vw, gr, new Pen(Color.FromArgb(100,211,211,211), 2) { DashStyle = DashStyle.DashDot, DashPattern = new float[]{1,8 } }, 639, y + 9, 38, y + 9);
                }

                _drawText(vw, gr, "W /cm", 5, 250, Color.Yellow, new Font("Arial", 12), true);
                _drawText(vw, gr, "2", 5, 210, Color.Yellow, new Font("Arial", 12), true);

                CT = sl / 240;
                if (sl == 0) CT = 0;

                for (int x = 36; x <= 638; x += 600 * 240 / (el - sl))
                {
                    var t = $"- {CT}";
                    if (!WholeNum)
                    {
                        if (t.Length > 4) t = "-        " + t.Substring(0, 3);
                    }
                    _drawText(vw, gr, t, x - 2, 410, Color.White, new Font("Arial", 12), true);
                    CT += 1;
                }

                //_drawText(vw, gr, "T I M E", 315, 450, Color.Yellow, new Font("Arial", 12));
                _drawTextJustify(vw, gr, "  OSTIA   ", Color.LightCyan, 10, 10, 150, 30, new Font("Arial", 20));

                _drawText(vw, gr, "Case #", 320, 10, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr,  $"{Global.Instance.Session.CaseNumber}", 360, 0, Color.Yellow, new Font("Arial", 12));
                _drawText(vw, gr, "Test Time: ", 478, 10, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr, Global.Instance.Session.dt.ToString("yyyy-M-d h:mm:s"), 545, 0, Color.Yellow, new Font("Arial", 12));

                _drawText(vw, gr, "Sample Rate: ", 320, 20, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr,  $"{Global.Instance.Session.SampleRate}", 397, 10, Color.White, new Font("Arial", 12));
                _drawText(vw, gr, "PPS:", 478, 20, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr,  $"{Global.Instance.Session.SampFreq}", 506, 10, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr, "D: ", 565, 10, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr,  $"{Global.Instance.Session.SampDuty}", 581, 10, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr, "f: ", 615, 10, Color.White, new Font("Arial", 12));
                //_drawText(vw, gr,  $"{Global.Instance.Session.SampBand}", 631, 10, Color.White, new Font("Arial", 12));

                _drawFillRect(vw, gr, ColorTranslator.FromHtml("#808080"), 150, 32, 160, 38);
                _drawText(vw, gr, "Output Control", 165, 30, Color.White, new Font("Arial", 12));

                _drawFillRect(vw, gr, Color.White, 270, 32, 280, 38);
                _drawText(vw, gr, "Power", 290, 30, Color.White, new Font("Arial", 12));

                _drawFillRect(vw, gr, Color.Orange, 370, 32, 380, 38);
                _drawText(vw, gr, "Patient Response", 390, 30, Color.White, new Font("Arial", 12));

                _drawFillRect(vw, gr, Color.Red, 500, 32, 510, 38);
                _drawText(vw, gr, "Pause ON", 515, 30, Color.White, new Font("Arial", 12));

                _drawTextJustify(vw, gr, "@Copyright 1994-2002", Color.White, 20, 460, 600, 480, new Font("Arial", 12));
                //_drawCircle(vw, gr, new Pen(Color.Beige), 29, 475, 6, true);

                VIEW_WINDOW vw1 = new VIEW_WINDOW(vw);
                vw1.setVIEW(40, 40, 638, 440).setWINDOW(sl, 40, el, 440);

 /// Pause Status Drawing
 /// 
                for (int x = sl; x <= el - 2; x++)
                {
                    var t = Convert.ToString(Global.Instance.Validation[x].Pause, 2);
                    t = new string('0', 8 - t.Length) + t;
                    /*t = t.Substring(6, 2);
                    if (t == "10")
                    {
                        _drawFillRect(vw1, gr, Color.Red, x - 2, 403, x + 2, 407);
                    }*/
                    t = t.Substring(7, 1);
                    if (t == "1")
                    {
                        _drawFillRect(vw1, gr, Color.Red, x - 2, 403, x + 2, 407);
                    }
                }

                vw1.setVIEW(40, 40, 638, 400).setWINDOW(sl, 80, el, 0);

                Point pt = new Point()
                {
                    X = sl,
                    Y = 0
                };
                
                int thick = 0;
                int Thresh = 5;
                double PowerDelta = 0;
                double RespDelta = 0;
                int j = 0;

/// Output Control
/// 
                na[0] = Global.Instance.Validation[0].Dial;

                for (int x = sl; x < el; x++)
                {
                    if (x == 0) x = 1;
                    na[x] = na[x - 1] + (Global.Instance.Validation[x].Dial - Global.Instance.Validation[x - 1].Dial);
                    if (Global.Instance.Validation[x].Dial - Global.Instance.Validation[x - 1].Dial < -45)
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

                _drawCircle(vw1, gr, new Pen(ColorTranslator.FromHtml("#808080")), sl, 0, 1, true);
                thick = j * ((el - sl) / 600);

                for (int x = sl; x < el; x++)
                {
                    _drawLine(vw1, gr, new Pen(Color.FromArgb(100,124,124,124), 3), pt.X, pt.Y, x, na[x]);//ColorTranslator.FromHtml("#808080")
                    pt.X = x; pt.Y = na[x];
                }

/// Power
/// 
                pt.X = sl; pt.Y = 0;
                _drawCircle(vw1, gr, new Pen(Color.White), sl, 0, 5, true);

                for (int x = sl; x < el; x++)
                {
                    //_drawLine(vw1, gr, new Pen(Color.Black, 4), pt.X, pt.Y, x, Global.Instance.Validation[x].Power);
                    //pt.X = x; pt.Y = Global.Instance.Validation[x].Power;

                    _drawLine(vw1, gr, new Pen(Color.White, 2), pt.X, pt.Y, x, Global.Instance.Validation[x].Power);
                    

                    pt.X = x; pt.Y = Global.Instance.Validation[x].Power;
                }

/// Patient Response
/// 
                for (j = -1; j <= 1; j++)
                {
                    pt.X = sl; pt.Y = 0;
                    if (el - sl == 3599)
                    {
                        thick = j * ((el - sl) / 600);
                    }
                    else
                    {
                        j = 1;
                        thick = 0;
                    }

                    for (int x = sl; x < el; x++)
                    {
                        Thresh = 5;
                        if (x > Thresh)
                        {
                            PowerDelta = Global.Instance.Validation[x].Power - Global.Instance.Validation[x - Thresh].Power;
                            PowerDelta = PowerDelta / Thresh;

                            RespDelta = Global.Instance.Validation[x].Response - Global.Instance.Validation[x - Thresh].Response;
                            RespDelta = RespDelta / Thresh;
                        }

                        
                        _drawLine(vw1, gr, new Pen(Color.Orange, 2), pt.X, pt.Y, x + thick, Global.Instance.Validation[x].Response);
                        _drawLine(vw1, gr, new Pen(Color.Orange, 2), pt.X, pt.Y, x + thick, Global.Instance.Validation[x].Response);
                        _drawLine(vw1, gr, new Pen(Color.Orange, 2), pt.X, pt.Y, x + thick, Global.Instance.Validation[x].Response);


                        pt.X = x + thick; pt.Y = Global.Instance.Validation[x].Response;
                    }
                }
            }

            lblDrawPanel.BackgroundImage = bm;
            lblDrawPanel.BackgroundImageLayout = ImageLayout.Center;
        }
    }
}
