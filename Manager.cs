using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace OSTIA
{
    public partial class Manager : Form
    {
        private SerialPort _serialPort;
        private Task? readMonitor = null;
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private CancellationToken _token;
        private Displayer? display = null;

        public static Manager shared = null;

        CancellationTokenSource _tokenSource1;
        public Manager()
        {
            InitializeComponent();

            _serialPort = new SerialPort();
            _serialPort.PortName = "COM1";
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


        //Task readMonitor = Task.Run(() => test1(_token1), _token1);
        private async Task test1(CancellationToken token)
        {
            /*while (!token.IsCancellationRequested)
            {
                index += 1;
                await Task.Delay(1000, _token).ConfigureAwait(true);

                if (index > 5)
                {

                    _tokenSource1.Cancel();
                }
            }

            Console.WriteLine("Test1 was finished");*/
        }
        static DateTime stDt;
        private async Task Read()
        {
            int seg;
            bool drflag = false;

            this.Invoke(new MethodInvoker(
                delegate ()
                {
                    display?.appendSeg("Waiting for start bit");
                })
            );

            do
            {
                try
                {
                    var span = DateTime.Now - stDt;
                    if (span.TotalSeconds > 3)
                    {
                        this.Invoke(new MethodInvoker(
                            delegate ()
                            {
                                display?.appendLog("Timeout of waiting. quit");
                            })
                        );
                        throw new TimeoutException();
                    }
                    if (_serialPort.BytesToRead > 0)
                    {
                        seg = _serialPort.ReadByte();
                        var binary = Convert.ToString(seg, 2);
                        var strbinary = new string('0', 8 - binary.Length) + binary;
                        Console.WriteLine(strbinary);
                        if (strbinary.Substring(6, 2) == "01")
                        {
                            if (strbinary.Substring(4, 1) == "1")
                            {
                                this.Invoke(new MethodInvoker(
                                    delegate ()
                                    {
                                        display?.appendLog("Accept starting bit");
                                    })
                                );
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

            int index = 0;
            int repeater = 0;

            this.Invoke(new MethodInvoker(
                delegate ()
                {
                    display?.appendPart("Start receiving data in total 3600");
                })
            );

            while (!_token.IsCancellationRequested & index < 3600)
            {
                this.Invoke(new MethodInvoker(
                    delegate ()
                    {
                        display?.appendSeg($"Receiving data as index {index + 1}");
                    })
                );

                try
                {
                    while (!_token.IsCancellationRequested & repeater < 360)
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
                        await Task.Delay(10, _token).ConfigureAwait(false);
                    }

                    if (repeater == 360)
                    {
                        _tokenSource.Cancel(); break;
                    }

                    this.Invoke(new MethodInvoker(
                        delegate ()
                        {
                            display?.appendLog($"{Global.Instance.Validation[index].Response}");
                        })
                    );

                    repeater = 0;

                    while (!_token.IsCancellationRequested & repeater < 360)
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
                        await Task.Delay(10, _token).ConfigureAwait(false);
                    }

                    if (repeater == 360)
                    {
                        _tokenSource.Cancel(); break;
                    }

                    this.Invoke(new MethodInvoker(
                        delegate ()
                        {
                            display?.appendLog($"{Global.Instance.Validation[index].Dial}");
                        })
                    );

                    repeater = 0;

                    while (!_token.IsCancellationRequested & repeater < 360)
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
                        await Task.Delay(10, _token).ConfigureAwait(false);
                    }

                    if (repeater == 360)
                    {
                        _tokenSource.Cancel(); break;
                    }
                    this.Invoke(new MethodInvoker(
                        delegate ()
                        {
                            display?.appendLog($"{Global.Instance.Validation[index].Power}");
                        })
                    );
                    repeater = 0;

                    while (!_token.IsCancellationRequested & repeater < 360)
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
                        await Task.Delay(10, _token).ConfigureAwait(false);
                    }

                    if (repeater == 360)
                    {
                        _tokenSource.Cancel(); break;
                    }

                    this.Invoke(new MethodInvoker(
                        delegate ()
                        {
                            display?.appendLog($"{Global.Instance.Validation[index].Pause}");
                        })
                    );

                    repeater = 0;

                    index += 1;

                }
                catch (TimeoutException)
                {
                    _tokenSource.Cancel();
                }
            }


            if (!_token.IsCancellationRequested)
            {
                this.Invoke(new MethodInvoker(
                    delegate ()
                    {
                        display?.appendSeg("---Receiving was completed--");
                        display?.appendPart("Data Saving");
                    })
                );
                Global.Instance.Session.MaxPoints = index;

                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.Filter = "IAD Image|*.iad";
                    saveFileDialog1.Title = "Save an IAD File";
                    saveFileDialog1.OverwritePrompt = true;
                    saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                    if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                    {
                        if (saveFileDialog1.FileName != "")
                        {
                            using (TextWriter tw = File.CreateText(saveFileDialog1.FileName))
                            {
                                tw.WriteLine(DateTime.Now.ToString("yyyy-M-d h:m:s"));
                                tw.WriteLine(Global.Instance.Person.FirstName + "|" + Global.Instance.Person.SurName + "|" + Global.Instance.Person.DOB);
                                Global.Instance.Session.Completed = DateTime.Now.ToString("yyyy-M-d h:m:s");
                                tw.WriteLine(Global.Instance.Session.toString());
                                for (int i = 0; i < Global.Instance.Session.MaxPoints; i++)
                                {
                                    tw.WriteLine(Global.Instance.Validation[i].Power + "|" + Global.Instance.Validation[i].Response + "|" + Global.Instance.Validation[i].Pause + "|" + Global.Instance.Validation[i].Dial);
                                }
                            }
                        }

                        this.Invoke(new MethodInvoker(
                            delegate ()
                            {
                                display?.appendSeg($"Data successfully saved in {saveFileDialog1.FileName}");
                                OpenFile(true);
                            })
                        );
                    }
                }
            }

            this.Invoke(new MethodInvoker(
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

        public void mnuGather_Click(object sender, EventArgs e)
        {
            display = new Displayer();
            display.MdiParent = this;
            display.WindowState = FormWindowState.Maximized;
            display.Show();
            display.startLog();

            try
            {
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
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                closer = 0;
            }
        }

        private void mnuOpenFile_Click(object sender, EventArgs e)
        {
            display = new Displayer();
            display.MdiParent = this;
            display.WindowState = FormWindowState.Maximized;
            display.Show();
            display.startLog();

            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a IAD file",
                Filter = "IAD files (*.iad)|*.iad",
                Title = "Open IAD file"
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
                    }
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
            display = new Displayer();
            display.MdiParent = this;
            display.WindowState = FormWindowState.Maximized;
            display.Show();

            Task.Delay(1500).ContinueWith(_ =>
            {
                if(display.InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        display?.DrawGraph(true);
                    });                    
                }
                else
                {
                    display?.DrawGraph(true);
                }
                
            }).ConfigureAwait(false);            
        }
    }
}
