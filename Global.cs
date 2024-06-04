using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace OSTIA
{
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
    }

    public struct Patient
    {
        public string SurName { get; set; }
        public string FirstName { get; set; }

        public string DOB { get; set; }
    }

    internal class Global
    {
        private static Global _instance = null;
        public dbAccess? db = null;
        public users? loginUser = null;
        public Inquiry[] Validation = new Inquiry[3600];
        public Exam Session;
        public DateTime Machine;
        public Patient Person;
        public Global()
        {
            db = new dbAccess();
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
