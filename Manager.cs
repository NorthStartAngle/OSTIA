using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSTIA
{
    public partial class Manager : Form
    {
        private  SerialPort _serialPort;
        private Task readMonitor = null;
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private CancellationToken _token;

        public Manager()
        {
            InitializeComponent();

            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";
            _serialPort.BaudRate =1200;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake =Handshake.None;

            // Set the read/write timeouts
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
            _serialPort.ReadBufferSize = 256;

            _serialPort.DataReceived += _serialPort_DataReceived;
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }

        private void GetData(object sender, EventArgs e)
        {
            _serialPort.Open();
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _token.Register(() =>
            {
                _serialPort.Close();
            });
            readMonitor = Task.Run(Read,_token);            
        }

        private async Task Read()
        {
            int seg;
            bool drflag = false;

            do
            {
                if (_serialPort.BytesToRead > 0)
                {
                    seg = _serialPort.ReadByte();
                    var binary = Convert.ToString(seg, 2);
                    var strbinary = new string('0', 8 - binary.Length) + binary;
                    Console.WriteLine(strbinary);
                    if (strbinary.Substring(6, 2) == "01")
                    {
                        Console.WriteLine("Waiting for start bit");
                        if (strbinary.Substring(4, 1) == "1")
                        {
                            Console.WriteLine("Initiating sequence . . .");
                            drflag = true;
                        }
                    }
                }
                await Task.Delay(1, _token).ConfigureAwait(false);
            } while (!_token.IsCancellationRequested & !drflag);

            int index = 0;
            int repeater = 0;

            while (!_token.IsCancellationRequested & index < 3600)
            {
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
                        else
                        {
                            await Task.Delay(10, _token).ConfigureAwait(false);
                        }
                    }

                    if (repeater == 360)
                    {
                        _tokenSource.Cancel(); break;
                    }

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
                        else
                        {
                            await Task.Delay(10, _token).ConfigureAwait(false);
                        }
                    }

                    if (repeater == 360)
                    {
                        _tokenSource.Cancel(); break;
                    }

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
                        else
                        {
                            await Task.Delay(10, _token).ConfigureAwait(false);
                        }
                    }

                    if (repeater == 360)
                    {
                        _tokenSource.Cancel(); break;
                    }

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
                        else
                        {
                            await Task.Delay(10, _token).ConfigureAwait(false);
                        }
                    }

                    if (repeater == 360)
                    {
                        _tokenSource.Cancel(); break;
                    }

                    repeater = 0;

                    index += 1;

                }
                catch (TimeoutException)
                {
                    _tokenSource.Cancel();
                }
            }

            Global.Instance.Session.MaxPoints = index;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "IAD Image|*.iad";
            saveFileDialog1.Title = "Save an IAD File";
            saveFileDialog1.ShowDialog();

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
        }
    }
}
