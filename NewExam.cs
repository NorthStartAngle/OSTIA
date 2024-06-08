using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace OSTIA
{
    public partial class NewExam : Form
    {
        public NewExam()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 3600; x++)
            {
                Global.Instance.Validation[x].Power = 0;
                Global.Instance.Validation[x].Response = 0;
                Global.Instance.Validation[x].Dial = 0;
                Global.Instance.Validation[x].Pause = 0;
            }
            
            Global.Instance.Session.WCB = txtWCB.Text;
            Global.Instance.Session.CaseNumber = txtCASENUMBER.Text;
            Global.Instance.Session.AssesserID = txtASSESSER.Text;
            Global.Instance.Person.FirstName = txtPersonF.Text;
            Global.Instance.Person.SurName = txtPersonS.Text;
            Global.Instance.Person.DOB = dtPersionB.Value.ToString("yyyy-MM-dd");
            Global.Instance.Session.dt = DateTime.Parse(dtSession.Value.ToString("yyyy-MM-dd") + dtCurrentTime.Value.ToString("hh:mm:ss"));
            Global.Instance.Session.InjComplaint = txtInjComplaint.Text;
            Global.Instance.Session.BodyPart = txtBodyPart.Text;

            Global.Instance.Session.SampleRate = comboBox1.SelectedText;
            Global.Instance.Session.SampFreq = comboBox2.SelectedText;
            Global.Instance.Session.SampDuty = comboBox3.SelectedText;
            Global.Instance.Session.SampBand = comboBox4.SelectedText;

            Manager.shared.mnuGather_Click(null,null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 4)
            {
                Global.Instance.Session.SampleRate = Prompt.ShowDialog("Rate", "Custom Rate");
            }
            else
            {
                Global.Instance.Session.SampleRate = comboBox1.SelectedText;
            }
        }
    }
}
