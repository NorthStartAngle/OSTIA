﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace OSTIA
{
    public class VIEW_WINDOW
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
            sPt.X = _x1; sPt.Y = _y1;
            ePt.X = _x2; ePt.Y = _y2;

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

        public double X(double _x)
        {
            //if (_x > eCPt.X) _x = eCPt.X;
            //if (_x < sCPt.X) _x = sCPt.X;

            double x = sPt.X + (double)(_x - sCPt.X) * (ePt.X - sPt.X) / (eCPt.X - sCPt.X);

            if (_parent != null)
            {
                return _parent.X(x);
            }
            else
            {
                return x;
            }
        }

        public double Y(double _y)
        {
            //if (_y > eCPt.Y) _y = eCPt.Y;
            //if (_y < sCPt.Y) _y = sCPt.Y;
            double y = sPt.Y + (double)(_y - sCPt.Y) * (ePt.Y - sPt.Y) / (eCPt.Y - sCPt.Y);

            if (_parent != null)
            {
                return _parent.Y(y);
            }
            else
            {
                return y;
            }
        }

        public double W(double _w)
        {
            double w = _w * (double)(ePt.X - sPt.X) / (eCPt.X - sCPt.X);
            if (_parent != null)
            {
                return _parent.W(w);
            }
            else
            {
                return w;
            }
        }

        public double H(double _h)
        {
            double h = _h * (double)(ePt.Y - sPt.Y) / (eCPt.Y - sCPt.Y);
            if (_parent != null)
            {
                return _parent.H(h);
            }
            else
            {
                return h;
            }
        }

        public Point PT(Point _pt)
        {
            return new Point((int)X(_pt.X), (int)Y(_pt.Y));
        }

        public Point PT(int _x, int _y)
        {
            return new Point((int)X(_x), (int)Y(_y));
        }

    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption,string _default="100")
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            textBox.Text = _default;
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }

    public struct User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Access { get; set; }
    }
        
    public struct Inquiry
    {
        public int Power;
        public int Response;
        public int Pause;
        public int Dial;
        public string toString()
        {
            return $"{Power}|{Response}|{Pause}|{Dial}";
        }

        public static Inquiry Parse(string s)
        {
            if (string.IsNullOrEmpty(s)) return new Inquiry();
            Inquiry exam = new Inquiry();
            string[] sep = s.Split('|');
            try
            {
                if (sep.Length > 0) { exam.Power = Convert.ToInt32(sep[0]); }
                if (sep.Length > 1) { exam.Response = Convert.ToInt32(sep[1]); }
                if (sep.Length > 2) { exam.Pause = Convert.ToInt32(sep[2]); }
                if (sep.Length > 3) { exam.Dial = Convert.ToInt32(sep[3]); }
            }
            catch (Exception)
            {
            }


            return exam;
        }

    }
    
    public struct Exam
    {
        public int MaxPoints;
        public string WCB;
        public string InjComplaint;
        public string BodyPart;
        public string CaseNumber;
        public string AssesserID;
        public DateTime dt;
        public string SampleRate;
        public string SampFreq;
        public string SampDuty;
        public string SampBand;
        public string Completed;
        public string VerifySurName;
        public string toString()
        {
            return $"{MaxPoints}|{WCB}|{InjComplaint}|{BodyPart}|{CaseNumber}|{AssesserID}|{dt.ToString("yyyy-M-d h:m:s")}|{SampleRate}|{SampFreq}|{SampDuty}|{SampBand}|{Completed}|{VerifySurName}|";
        }

        public static Exam Parse(string s)
        {
            if (string.IsNullOrEmpty(s)) return new Exam();
            Exam exam = new Exam();
            string[] sep = s.Split('|');
            try
            {
                if (sep.Length > 0) { exam.MaxPoints = Convert.ToInt32(sep[0]); }
                if (sep.Length > 1) { exam.WCB = sep[1]; }
                if (sep.Length > 2) { exam.InjComplaint = sep[2]; }
                if (sep.Length > 3) { exam.BodyPart = sep[3]; }
                if (sep.Length > 4) { exam.CaseNumber = sep[4]; }
                if (sep.Length > 5) { exam.AssesserID = sep[5]; }
                if (sep.Length > 6) { exam.dt = DateTime.Parse(sep[6]); }
                if (sep.Length > 7) { exam.SampleRate = sep[7]; }
                if (sep.Length > 8) { exam.SampFreq = sep[8]; }
                if (sep.Length > 9) { exam.SampDuty = sep[9]; }
                if (sep.Length > 10) { exam.SampBand = sep[10]; }
                if (sep.Length > 11) { exam.Completed = sep[11]; }
                if (sep.Length > 12) { exam.VerifySurName = sep[12]; }
            }
            catch(Exception)
            {
            }
            

            return exam;
        }
    }

    public struct Patient
    {
        public string SurName { get; set; }
        public string FirstName { get; set; }

        public string DOB { get; set; }

        public string toString()
        {
            return $"{FirstName}|{SurName}|{DOB}";
        }

        public static Patient Parse(string s)
        {
            if (string.IsNullOrEmpty(s)) return new Patient();
            Patient exam = new Patient();
            string[] sep = s.Split('|');
            try
            {
                if (sep.Length > 0) { exam.FirstName = sep[0]; }
                if (sep.Length > 1) { exam.SurName = sep[1]; }
                if (sep.Length > 2) { exam.DOB = sep[2]; }
            }
            catch (Exception)
            {
            }


            return exam;
        }
    }

    internal class Global
    {
        private static Global? _instance = null;
        public dbAccess? db = null;
        public users? loginUser = null;
        public Inquiry[] Validation = new Inquiry[3601];
        public Exam Session;
        public DateTime Machine;
        public Patient Person;

        public string OfficeName;
        public string OfficeAddr1;
        public string OfficeAddr2;

        internal static string key = "northstar-1121";
        public string version = "5.0.1";

        public Global()
        {
            db = new dbAccess();
            _instance = null;
        }

        public static Global Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Global();
                }

                return _instance;
            }
        }

        public byte[] buffer = new byte[15040];
        public char[,] Char = new char[256,16];
        public int MaxSize = 274;
        public int Xroom = 274 / 64;
        public int oldSize = 0;
        public const string FHeader = "ASTIN Data File (IAD) Format R33, Nov 4, 1996 ";

        public string ENC(string s)
        {
            string ret = "";
            for(int i = 0; i< s.Length; i++)
            {
                ret += (char)(s[i] ^ 25);
            }

            return ret;
        }

        public string ver { get { return "v1.01"; } }

        public void recordHistory(string content)
        {
            if (File.Exists("Log.IAS"))
            {
                using (TextWriter tw = File.AppendText("Log.IAS"))
                {
                    tw.WriteLine(content);
                }
            }
        }

        public void Decrypt(ref bool EscPress)
        {
            double CRC = 0;
            int x = MaxSize;

            for(int b=0; b< MaxSize; b+= Xroom)
            {
                x += 1;
                CRC = ArSum(buffer,b,b+Xroom-1);
                CRC = CRC % Xroom;

                if (x > MaxSize + 64) break;
                if (buffer[x-1] != (int)(CRC))
                {
                    EscPress = true;
                    return;
                }
            }

            for(int i=0; i< MaxSize; i++)
            {
                buffer[i] = (byte)(buffer[i] ^ (i % 255));
                buffer[i] = (byte)(255-buffer[i]);
            }

            for (int i = 0; i < MaxSize; i+=2)
            {
                Swap<byte>(ref buffer[i],ref buffer[i+1]);
            }

            for (int i = 0; i < MaxSize; i += 7)
            {
                buffer[i] = (byte)(buffer[i+1] ^ (int)('K'));
                buffer[i+1] = (byte)(buffer[i + 1] ^ (int)('e'));
                buffer[i+2] = (byte)(buffer[i + 2] ^ (int)('y'));
                buffer[i+3] = (byte)(buffer[i + 3] ^ (int)('w'));
                buffer[i+4] = (byte)(buffer[i + 4] ^ (int)('o'));
                if (i + 5 > MaxSize) break;
                buffer[i+5] = (byte)(buffer[i + 5] ^ (int)('r'));
                buffer[i + 6] = (byte)(buffer[i + 6] ^ (int)('d'));
            }
        }

        public void Swap<T>(ref T a,ref T b)
        {
            T c = a;
            a = b; b = c;
        }

        public double ArSum(byte[] Ary,int rstart,int rend)
        {
            double tmp =0;
            byte s;
            for(int i = rstart; i<= rend;i++)
            {
                s = Ary[i];
                tmp += (int)s;
            }
            return tmp;
        }

        public User[] users =new User[10];
    }
}
