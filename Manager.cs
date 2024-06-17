using System.IO.Ports;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace OSTIA
{
    public partial class Manager : Form
    {
        private SerialPort _serialPort;
        private Task readMonitor = null;
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private CancellationToken _token;
        private Displayer display = null;

        public static Manager shared = null;

        CancellationTokenSource _tokenSource1;
        public Manager()
        {
            InitializeComponent();

            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";
            _serialPort.BaudRate = 1200;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;

            // Set the read/write timeouts
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
            _serialPort.ReadBufferSize = 256;

            shared = this;

        }

        private void Displayer_FormClosed(object? sender, FormClosedEventArgs e)
        {
            display = null;
        }

        static DateTime stDt;
        private async Task Read()
        {
            int index = 0;
            int seg;
            bool drflag = false;

            display?.appendSeg("Waiting for start bit");

            stDt = DateTime.Now;
            do
            {
                try
                {
                    var span = DateTime.Now - stDt;
                    if (span.TotalSeconds > 10)
                    {
                        display?.appendLog("Timeout of waiting. quit");
                        throw new TimeoutException();
                    }
                    if (_serialPort.BytesToRead > 0)
                    {
                        stDt = DateTime.Now;
                        seg = _serialPort.ReadByte();
                        var binary = Convert.ToString(seg, 2);
                        var strbinary = new string('0', 8 - binary.Length) + binary;
                        Console.WriteLine(strbinary);
                        if (strbinary.Substring(6, 2) == "01")
                        {
                            if (strbinary.Substring(4, 1) == "1")
                            {
                                display?.appendLog("Accept starting bit");
                                drflag = true;
                            }
                        }
                    }
                    await Task.Delay(1, _token).ConfigureAwait(false);
                }
                catch (TimeoutException)
                {
                    _tokenSource.Cancel();
                }


            } while (!_token.IsCancellationRequested & !drflag);


            int repeater = 0;

            if (!_token.IsCancellationRequested)
            {
                display?.appendPart("Start receiving data in total 3600");
            }

            while (!_token.IsCancellationRequested & index < 3600)
            {
                display?.appendSeg($"Receiving data as index {index + 1}");

                //
                while (!_token.IsCancellationRequested & repeater < 360)
                {
                    try
                    {
                        if (_serialPort.BytesToRead > 0)
                        {
                            seg = _serialPort.ReadByte();
                            var binary = Convert.ToString(seg, 2);
                            var strbinary = new string('0', 8 - binary.Length) + binary;

                            if (strbinary.Substring(6, 2) != "10")
                            {
                                Global.Instance.Validation[index].Response = Convert.ToInt32(strbinary.Substring(0, 6), 2);
                                break;
                            }
                            else
                            {
                                repeater += 1;
                            }
                        }
                        else
                        {
                            repeater += 1;
                        }
                        await Task.Delay(5, _token).ConfigureAwait(false);
                    }
                    catch (Exception)
                    {
                        _tokenSource.Cancel(); break;
                    }
                }

                if (repeater == 360)
                {
                    _tokenSource.Cancel(); break;
                }

                if (_token.IsCancellationRequested) break;

                display?.appendLog($"{Global.Instance.Validation[index].Response}");

                repeater = 0;

                while (!_token.IsCancellationRequested & repeater < 360)
                {
                    try
                    {
                        if (_serialPort.BytesToRead > 0)
                        {
                            seg = _serialPort.ReadByte();
                            var binary = Convert.ToString(seg, 2);
                            var strbinary = new string('0', 8 - binary.Length) + binary;

                            if (strbinary.Substring(6, 2) != "11")
                            {
                                Global.Instance.Validation[index].Dial = Convert.ToInt32(strbinary.Substring(0, 6), 2);
                                break;
                            }
                            else
                            {
                                repeater += 1;
                            }
                        }
                        else
                        {
                            repeater += 1;
                        }
                        await Task.Delay(5, _token).ConfigureAwait(false);
                    }
                    catch (Exception)
                    {
                        _tokenSource.Cancel(); break;
                    }
                }

                if (repeater == 360)
                {
                    _tokenSource.Cancel(); break;
                }

                if (_token.IsCancellationRequested) break;

                display?.appendLog($"{Global.Instance.Validation[index].Dial}");

                repeater = 0;

                while (!_token.IsCancellationRequested & repeater < 360)
                {
                    try
                    {
                        if (_serialPort.BytesToRead > 0)
                        {
                            seg = _serialPort.ReadByte();
                            var binary = Convert.ToString(seg, 2);
                            var strbinary = new string('0', 8 - binary.Length) + binary;

                            if (strbinary.Substring(6, 2) != "00")
                            {
                                Global.Instance.Validation[index].Power = Convert.ToInt32(strbinary.Substring(0, 6), 2);
                                break;
                            }
                            else
                            {
                                repeater += 1;
                            }
                        }
                        else
                        {
                            repeater += 1;
                        }
                        await Task.Delay(5, _token).ConfigureAwait(false);
                    }
                    catch (Exception)
                    {
                        _tokenSource.Cancel(); break;
                    }

                }

                if (repeater == 360)
                {
                    _tokenSource.Cancel(); break;
                }

                if (_token.IsCancellationRequested) break;

                display?.appendLog($"{Global.Instance.Validation[index].Power}");
                repeater = 0;

                while (!_token.IsCancellationRequested & repeater < 360)
                {
                    try
                    {
                        if (_serialPort.BytesToRead > 0)
                        {
                            seg = _serialPort.ReadByte();
                            var binary = Convert.ToString(seg, 2);
                            var strbinary = new string('0', 8 - binary.Length) + binary;

                            if (strbinary.Substring(6, 2) != "01")
                            {
                                Global.Instance.Validation[index].Pause = Convert.ToInt32(strbinary.Substring(0, 6), 2);
                                break;
                            }
                            else
                            {
                                repeater += 1;
                            }
                        }
                        else
                        {
                            repeater += 1;
                        }
                        await Task.Delay(5, _token).ConfigureAwait(false);
                    }
                    catch (Exception)
                    {
                        _tokenSource.Cancel(); break;
                    }
                }

                if (repeater == 360)
                {
                    _tokenSource.Cancel(); break;
                }

                if (_token.IsCancellationRequested) break;

                display?.appendLog($"{Global.Instance.Validation[index].Pause}");

                repeater = 0;

                index += 1;
            }

            if (index > 0)
            {
                display?.appendSeg("---Receiving was completed--");
                display?.appendPart("Data Saving");

                Global.Instance.Session.MaxPoints = index;

                string fileName = "";
                SaveFileDialog saveFileDialog1 = new SaveFileDialog()
                {
                    Filter = "NCR Image|*.ncr",
                    Title = "Save an NCR File",
                    OverwritePrompt = true,
                    InitialDirectory = Environment.CurrentDirectory,
                };

                this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                    {
                        fileName = saveFileDialog1.FileName;
                    }
                });


                if (!string.IsNullOrEmpty(fileName))
                {
                    SaveMemory(fileName);

                    display?.appendSeg($"Data successfully saved in {fileName}");
                    OpenFile(true);
                }
            }

            this.Invoke(new System.Windows.Forms.MethodInvoker(
                delegate ()
                {
                    mnuGather.Enabled = true;
                })
            );

            if (_token.IsCancellationRequested)
            {
                _tokenSource.Cancel();
                _tokenSource.Dispose();
            }
        }

        private void SaveMemory(string filename)
        {
            Global.Instance.Session.Completed = DateTime.Now.ToString("yyyy-M-d h:m:s");

            using (TextWriter tw = File.CreateText(filename))
            {
                tw.WriteLine(AESCryptor.Encrypt(DateTime.Now.ToString("yyyy-M-d h:m:s"), Global.key));
                tw.WriteLine(AESCryptor.Encrypt(Global.Instance.Person.toString(), Global.key));
                tw.WriteLine(AESCryptor.Encrypt(Global.Instance.Session.toString(), Global.key));

                for (int i = 0; i < Global.Instance.Session.MaxPoints; i++)
                {
                    tw.WriteLine(AESCryptor.Encrypt(Global.Instance.Validation[i].toString(), Global.key));
                }
                /*using (Aes myAes = Aes.Create())
                {
                    
                }*/
            }
            /*using (TextWriter tw = File.CreateText(fileName))
            {
                tw.WriteLine(DateTime.Now.ToString("yyyy-M-d h:m:s"));
                tw.WriteLine(Global.Instance.Person.FirstName + "|" + Global.Instance.Person.SurName + "|" + Global.Instance.Person.DOB);
                Global.Instance.Session.Completed = DateTime.Now.ToString("yyyy-M-d h:m:s");
                tw.WriteLine(Global.Instance.Session.toString());
                for (int i = 0; i < Global.Instance.Session.MaxPoints; i++)
                {
                    tw.WriteLine(Global.Instance.Validation[i].Power + "|" + Global.Instance.Validation[i].Response + "|" + Global.Instance.Validation[i].Pause + "|" + Global.Instance.Validation[i].Dial);
                }

            }*/
        }
        public void mnuGather_Click(object sender, EventArgs e)
        {
            if (display == null)
            {
                display = new Displayer();
                display.MdiParent = this;
                display.WindowState = FormWindowState.Maximized;
                display.Show();

                display.FormClosed += Displayer_FormClosed;
            }

            display.startLog();

            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                _serialPort.Open();
                _tokenSource = new CancellationTokenSource();
                _token = _tokenSource.Token;
                _token.Register(() =>
                {
                    _serialPort.Close();
                });
                readMonitor = Task.Run(Read, _token);
                stDt = DateTime.Now;
                mnuGather.Enabled = false;
            }
            catch (Exception)
            {

            }
        }
        static DialogResult closer = 0;

        private void Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closer != 0) return;
            DialogResult result = MessageBox.Show(this, "Do you want to quit the application?.",
                                   "Quitting?", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                closer = result;
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                e.Cancel = true;
                closer = 0;
            }
        }

        private void mnuOpenFile_Click(object sender, EventArgs e)
        {
            if (display == null)
            {
                display = new Displayer();
                display.MdiParent = this;
                display.WindowState = FormWindowState.Maximized;
                display.Show();

                display.FormClosed += Displayer_FormClosed;
            }

            display.startLog();

            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a NCR file",
                Filter = "NCR files (*.ncr)|*.ncr",
                Title = "Open NCR file",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                OpenFile(false, openFileDialog1.FileName);
            }
        }

        public void OpenFile(bool inMemory, string filePath = "")
        {
            if (!inMemory)
            {
                try
                {
                    //goto jump1;
                    using (TextReader tr = File.OpenText(filePath))
                    {
                        string? strline;

                        try
                        {
                            if ((strline = tr.ReadLine()) != null)
                            {
                                DateTime dt = DateTime.Parse(AESCryptor.Decrypt(strline, Global.key));
                            }

                            if ((strline = tr.ReadLine()) != null)
                            {
                                Patient? _person = Patient.Parse(AESCryptor.Decrypt(strline, Global.key));
                            }

                            if ((strline = tr.ReadLine()) != null)
                            {
                                Global.Instance.Session = Exam.Parse(AESCryptor.Decrypt(strline, Global.key));
                            }

                            int i = 0;
                            while ((strline = tr.ReadLine()) != null)
                            {
                                Inquiry _validation = Inquiry.Parse(AESCryptor.Decrypt(strline, Global.key));
                                Global.Instance.Validation[i].Power = _validation.Power;
                                Global.Instance.Validation[i].Response = _validation.Response;
                                Global.Instance.Validation[i].Pause = _validation.Pause;
                                Global.Instance.Validation[i].Dial = _validation.Dial;
                                i += 1;
                            }

                        }
                        catch (Exception)
                        {

                        }
                    }

                    /*jump1:
                    using (TextReader tr = File.OpenText(filePath))
                    {
                        string? strline;

                        if ((strline = tr.ReadLine()) != null)
                        {
                            DateTime dt = DateTime.Parse(strline);
                        }

                        if ((strline = tr.ReadLine()) != null)
                        {
                            Patient? _person = Patient.Parse(strline);
                        }

                        if ((strline = tr.ReadLine()) != null)
                        {
                            Global.Instance.Session = Exam.Parse(strline);
                        }

                        int i = 0;
                        while ((strline = tr.ReadLine()) != null)
                        {
                            Inquiry _validation = Inquiry.Parse(strline);
                            Global.Instance.Validation[i].Power = _validation.Power;
                            Global.Instance.Validation[i].Response = _validation.Response;
                            Global.Instance.Validation[i].Pause = _validation.Pause;
                            Global.Instance.Validation[i].Dial = _validation.Dial;
                            i += 1;
                        }
                    }*/
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }

            display?.startDrawing();

        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            /*display = new Displayer();
            display.MdiParent = this;
            display.WindowState = FormWindowState.Maximized;
            display.Show();

            Task.Delay(1500).ContinueWith(_ =>
            {
                if (display.InvokeRequired)
                {
                    Invoke((System.Windows.Forms.MethodInvoker)delegate ()
                    {
                        display?.DrawGraph();
                    });
                }
                else
                {
                    display?.DrawGraph();
                }

            }).ConfigureAwait(false);*/
        }

        private void mnuScale_Click(object sender, EventArgs e)
        {
            if (display == null) return;
            var strScale = Prompt.ShowDialog("Enter Scale", "Custom Scaling", $"{display.Scales}");
            if (string.IsNullOrEmpty(strScale)) { return; }
            int scales = 100;
            if (!Int32.TryParse(strScale, out scales))
            {
                display.setScale(100);
            }

            display.setScale(scales);
        }

        private void saveMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog()
            {
                Filter = "NCR Image|*.ncr",
                Title = "Save an NCR File",
                OverwritePrompt = true,
                InitialDirectory = Environment.CurrentDirectory,
            };

            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
            }

            if (!string.IsNullOrEmpty(fileName))
            {
                SaveMemory(fileName);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Summery summery = new Summery();
            summery.MdiParent = this;
            summery.WindowState = FormWindowState.Maximized;
            summery.Show();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tokenSource != null)
            {
                _tokenSource.Cancel();
            }
        }
    }
}
