namespace OSTIA
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            string log = Global.Instance.ENC(DateTime.Now.ToString("yyyy-M-D H:M:S") + $"OSTIA {Global.Instance.ver} Initiated");
            
            Global.Instance.recordHistory(log);

            Global.Instance.oldSize = Global.Instance.MaxSize;
            Global.Instance.MaxSize = 274;
            Global.Instance.Xroom = Global.Instance.MaxSize / 64;

            if (File.Exists("ProgData.IAS"))
            {
                using (BinaryReader binReader = new BinaryReader(File.Open("ProgData.IAS", FileMode.Open)))
                {
                    for (int i = 0; i < Global.Instance.MaxSize + 64; i++)
                    {
                        Global.Instance.buffer[i] = binReader.ReadByte();
                    }                    
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
        }
    }
}
