using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace OSTIA
{
    public partial class Summery : Form
    {
        int[] peaks = new int[1000];
        int[] peaksr = new int[1000];

        public Summery()
        {
            InitializeComponent();
        }


        private void btnAppy_Click(object sender, EventArgs e)
        {
            if (txtThresh.Value == 0 || txtSecs.Value == 0 || txtPosReq.Value == 0) return;
            string strLine = "\n";
            string MS= Char.ConvertFromUtf32(13);
            MS += "This single page report was printed on " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "." + strLine + strLine;
            MS += "                    Case Number: " + Global.Instance.Session.CaseNumber + strLine;

            MS = MS + "                    Assessor ID: " + Global.Instance.Session.AssesserID + strLine + strLine;
            MS = MS + "                    Stimulation Cycle: " + Global.Instance.Session.SampDuty + " %" + strLine;
            MS = MS + "                    Pulses Per Second: " + Global.Instance.Session.SampFreq + strLine;
            MS = MS + "                    Frequency: " + Global.Instance.Session.SampBand + " Mhz" + strLine;
            MS = MS + "                     Threshold Level (mW): " + $"{txtThresh.Value}" + strLine;
            MS = MS + "                     Response Delay (sec): " + $"{txtSecs.Value}" + strLine + strLine;

            MS = MS + "Positive Correlation Factor (%): " + $"{txtPosReq.Value}" + strLine + strLine;
            MS = MS + "This is a fair and accurate summation of an Assessment of Soft Tissue Injury examination, that was performed on " + Global.Instance.Session.dt.ToString("yyyy-MM-dd hh:mm:ss") + "." + strLine + strLine;
            MS = MS + "This examination was performed upon " + Global.Instance.Person.FirstName + " " + Global.Instance.Person.SurName + ", by a specially trained Injury Assessment professional at " + Global.Instance.OfficeName + " located at " + Global.Instance.OfficeAddr1 + " " + Global.Instance.OfficeAddr2 + "." + strLine + strLine;

            MS = MS + "This examination involved the use of ultrasonic energy, with wave train characteristics of " + Global.Instance.Session.SampFreq + " pulses per second, a duty cycle of " + Global.Instance.Session.SampDuty + "%, and an insonation frequency of " + Global.Instance.Session.SampBand + " Mhz.";
            MS = MS + "  The complaint that was being investigated was '" + Global.Instance.Session.InjComplaint + "' and the specific body part being assessed was " + Global.Instance.Session.BodyPart + ".  ";
            MS = MS + "This examination lasted" + $"{Global.Instance.Session.MaxPoints / 4}" + " seconds, and consisted of data being sampled electronically and recorded every " + Global.Instance.Session.SampleRate + " seconds." + strLine + strLine;

            MS = MS + "This examination provides an objective assessment of the presence and extent of soft tissue injury.  It is not designed to detect broken bones, ";
            MS = MS + "skin sensitivities, or sensations of discomfort caused by neurological disorders." + strLine + strLine;

            var Granul = 0.25f;
            var peak = 0;
            var GoingUp = 0;
            var GoingDown = 0;

            for(int i=2; i< Global.Instance.Session.MaxPoints;i++)
            {
                if (Global.Instance.Validation[i].Power > txtThresh.Value*35)
                {
                    if (Global.Instance.Validation[i].Power > Global.Instance.Validation[i-1].Power)
                    {
                        GoingUp += Global.Instance.Validation[i].Power - Global.Instance.Validation[i - 1].Power;
                    }else if(Global.Instance.Validation[i].Power < Global.Instance.Validation[i - 1].Power)
                    {
                        GoingUp += Global.Instance.Validation[i-1].Power - Global.Instance.Validation[i].Power;
                        if(GoingDown > GoingUp * Granul)
                        {
                            if(Granul == 0.1)
                            {
                                Granul = 0.25f;
                            }

                            peaks[peak++] = i;

                            while(true)
                            {
                                if(Global.Instance.Validation[i].Power > txtThresh.Value*35)
                                {
                                    i += 1;
                                }else
                                {
                                    break;
                                }
                            }
                            GoingDown = 0;
                            GoingUp = 0;
                        }
                    }
                }else if (Global.Instance.Validation[i].Power == 0 && GoingUp > 5 && GoingDown< 5)
                {
                    peaks[peak++] = i;
                    while (true)
                    {
                        if (Global.Instance.Validation[i].Power  == 0 )
                        {
                            i += 1;
                            if (i < Global.Instance.Session.MaxPoints) break;
                        }
                        else
                        {
                            if(Global.Instance.Validation[i].Power > txtThresh.Value*35)
                            {
                                GoingUp = Global.Instance.Validation[i].Power;
                                Granul = 0.1f;
                            }
                              
                            break;
                        }
                    }
                }
                else
                {
                    GoingUp = 0;
                    GoingDown = 0;
                }
            }

            var peakr = 0;
            GoingUp = 0;
            GoingDown = 0;

            for(int i =2; i<= Global.Instance.Session.MaxPoints; i++)
            {
                if (Global.Instance.Validation[i].Response > 0)
                {
                    if(Global.Instance.Validation[i].Response > Global.Instance.Validation[i-1].Response)
                    {
                        GoingUp += Global.Instance.Validation[i].Response - Global.Instance.Validation[i - 1].Response;
                    }
                    else if(Global.Instance.Validation[i].Response < Global.Instance.Validation[i - 1].Response)
                    {
                        GoingUp += Global.Instance.Validation[i-1].Response - Global.Instance.Validation[i].Response;
                        if(GoingDown > GoingUp * Granul)
                        {
                            peakr = peakr + 1;
                            peaksr[peakr] = i;
                            while(true)
                            {
                                if(Global.Instance.Validation[i].Response>0)
                                {
                                    i += 1;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            GoingDown = 0;
                            GoingUp = 0;
                        }
                    }
                }
                else
                {
                    GoingUp = 0;
                    GoingDown = 0;
                }
            }

            var PosCor = 0;
            for(int i =1; i<= peak;i++)
            {
                for(int j=1; j<= peakr;j++)
                {
                    if (peaks[i] <= peaksr[j] && peaksr[j] <= peaks[i] + txtSecs.Value*4)
                    {
                        PosCor += 1;
                        break;
                    }
                }
            }

            string Decision;
            if(peak*(txtPosReq.Value/100)  <= PosCor)
            {
                Decision = "VALID";
            }
            else
            {
                Decision = "NOT SUPPORTED";
            }

            MS += "This examination produced a total of" + $"{peak}" + " distinct instances of invisible stimulation to the affected area.  Our analysis indicates that there were" + $"{PosCor}" + "positive responses to ";
            MS += "the controlled invisible stimulus.  Because of ratio of positive responses in this examination, the authenticity of this patient's claims of discomfort due to soft tissue injury are " + Decision + ".  ";

            MS += "This Assessment of Soft Tissue Injury may also be used to assess the benefits of various forms of therapy for injuries.  This examination may have been one of a series of examinations that have been tracking the ";
            MS += "effectiveness of therapy.  As such, this report must be viewed as one of a sequence of examination reports, outlining changing responses in healing tissues." + strLine + strLine;
            MS += "Please speak directly to the assessor identified at the top of this report, for further detailed information regarding this examination." + strLine + strLine;
            MS += "...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n...";

            MS += "Go to New Page";
            string s = "OSTIA Soft Tissue Injury assessment Project";
            MS += new string(' ', 37 - s.Length / 2) + s;
            s = "Evaluative Analysis Report";
            MS += new string(' ', 37 - s.Length / 2) + s;

            txtDoc.Text = MS;
        }
    }
}
