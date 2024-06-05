using Microsoft.VisualBasic.ApplicationServices;
using System.Collections;
using System.Data.OleDb;

namespace OSTIA
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            Initialize();
        }

        public void Initialize()
        {
            return;


            /*string log = Global.Instance.ENC(DateTime.Now.ToString("yyyy-M-D H:M:S") + $"OSTIA {Global.Instance.ver} Initiated");
            
            Global.Instance.recordHistory(log);

            Global.Instance.oldSize = Global.Instance.MaxSize;
            Global.Instance.MaxSize = 274;
            Global.Instance.Xroom = Global.Instance.MaxSize / 64;

            if (File.Exists("ProgData.IAS"))
            {
                using (BinaryReader br = new BinaryReader(File.Open("ProgData.IAS", FileMode.Open)))
                {
                    for (int i = 0; i < Global.Instance.MaxSize + 64; i++)
                    {
                        Global.Instance.buffer[i] = br.ReadByte();
                    }                    

                    br.Close();
                }
            }           

            bool EscPress = false;
            Global.Instance.Decrypt(ref EscPress);

            if(EscPress)
            {
                string m = "OSTIA security checks on this file have failed.\n" + "The file you are trying to load: OSTIA, ~ProgData.IAS" + "^,has been altered or damaged in some form,Because it's been compromised, it won't loaded by this system.";

                MessageBox.Show(this, m, "Trust Violation");
                return;
            }

            Global.Instance.MaxSize = Global.Instance.oldSize;
            Global.Instance.Xroom = Global.Instance.MaxSize / 64;

            using (BinaryWriter bw = new BinaryWriter(File.Open("tmp.ias", FileMode.Create)))
            {
                for (int i = 0; i < Global.Instance.MaxSize; i++)
                {
                    bw.Write(Global.Instance.buffer[i]);
                }

                bw.Close();
            }

            using (BinaryReader br = new BinaryReader(File.Open("tmp.ias", FileMode.Open)))
            {
                var Heade = System.Text.Encoding.ASCII.GetString(br.ReadBytes(79));
                var OfficeName = System.Text.Encoding.ASCII.GetString(br.ReadBytes(35));
                var OfficeAddr1 = System.Text.Encoding.ASCII.GetString(br.ReadBytes(30));
                var OfficeAddr2 = System.Text.Encoding.ASCII.GetString(br.ReadBytes(30));

                for (int i = 0; i < 10; i++)
                {
                    Global.Instance.users[i].Name = System.Text.Encoding.ASCII.GetString(br.ReadBytes(3));
                    Global.Instance.users[i].Password = System.Text.Encoding.ASCII.GetString(br.ReadBytes(5));
                    Global.Instance.users[i].Access = System.Text.Encoding.ASCII.GetString(br.ReadBytes(2));
                }

                br.Close();
            }*/

            //System.Diagnostics.Process.Start("cmd.exe", "copy ProgData.IAS tmp.ias > nul");
            //File.Delete("tmp.ias");

        }

        public void ZeroUsers(bool status, string p = "..")
        {
            if (lblStatus.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate () { lblStatus.Text = p; }));
            }
            else
            {
                lblStatus.Text = p;
                txtUsername.Text = ""; txtPassword.Text = "";
                txtUsername.Focus();

            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string strQuery = $"select * from userlist where name ='{txtUsername.Text.Trim()}' and password='{txtPassword.Text.Trim()}'";

            Global.Instance.db?.RunQueryWithCallBack(strQuery, (OleDbDataReader? reader) =>
            {
                if (reader == null)
                {
                    ZeroUsers(false, "No matching user"); return;
                }

                try
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = SafeGetMethods.SafeGetInt(reader, 0);
                            string username = SafeGetMethods.SafeGetString(reader, 1);
                            string password = SafeGetMethods.SafeGetString(reader, 2);
                            int access_level = SafeGetMethods.SafeGetInt(reader, 3);
                            ZeroUsers(true, "Please wait while login");

                            Global.Instance.loginUser = new users();
                            Global.Instance.loginUser.id = id;
                            Global.Instance.loginUser.username = username;
                            Global.Instance.loginUser.password = password;
                            Global.Instance.loginUser.access_level = access_level;


                            break;
                        }


                        Manager a = new Manager();
                        a.Show();
                        closer = DialogResult.Ignore;
                        this.Close();

                    }
                    else
                    {
                        ZeroUsers(true, "The input user information don't be correctly, Please re-input!");
                    }
                }
                catch (Exception)
                {

                }

                reader?.Close();
            });
        }

        static DialogResult closer = 0;
        
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(closer == 0)
            {
                DialogResult result = MessageBox.Show(this, "Do you want to quit the application?.",
                                   "Quitting?", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    closer = result;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                    closer = 0;
                }
            }else if(closer != DialogResult.Ignore)
            {
                Application.Exit();return;
            }            
        }
    }
}
