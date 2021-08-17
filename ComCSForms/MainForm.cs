using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace ComCSForms
{
    public enum SendFormat { HEX, ASCII, APH };
    public partial class PortForm : Form
    {
        struct TxtClors
        {
            public Color cl;
            public DataGridView IO;
            public int row;
        }
        public SendFormat sndformat;
        public int BaudRatec;
        public int Datac;
        public Parity Parityc;
        public StopBits Stopbtc;
        public Handshake Flowc;
        public bool cicleCheck;
        public bool stop_on;
        bool circle;
        public int cicle_time;
        public int cicle_times;

        static Color SendCl;
        static Color GetCl;
        static string glmessage;
        public string stopstr;
        public string circlestopmsg;
        static List<TxtClors> TxColors;
        static SerialPort _serialPort;
        static Thread th;
        static DataGridView inp, outp;
        public bool showHEX, showASCII, showBIN;
        bool blportopen;
        public PortForm()
        {
            InitializeComponent();
        }

        void RefreshIO(bool one_tow)
        {
            if (one_tow)
            {
                this.IOLayout.Controls.Clear();
                SplitContainer sc = new SplitContainer();
                sc.Size = this.IOLayout.Size;
                sc.SplitterDistance = sc.Width / 2;
                sc.IsSplitterFixed = true;
                DataGridView I = new DataGridView();
                I.Name = "IDGV";
                I.Size = sc.Panel1.Size;
                I.ReadOnly = true;
                I.BackColor = Color.White;
                I.RowHeadersVisible = false;
                I.GridColor = Color.White;
                I.BackgroundColor = Color.White;
                DataGridViewTextBoxColumn colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "TIME";
                colm.Name = "TIME";
                colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                I.Columns.Add(colm);
                if (showASCII)
                {
                    colm = new DataGridViewTextBoxColumn();
                    colm.HeaderText = "ASCII";
                    colm.Name = "ASCII";
                    colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    I.Columns.Add(colm);
                }
                if (showHEX)
                {
                    colm = new DataGridViewTextBoxColumn();
                    colm.HeaderText = "HEX";
                    colm.Name = "HEX";
                    colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    I.Columns.Add(colm);
                }
                if(showBIN)
                {
                    colm = new DataGridViewTextBoxColumn();
                    colm.HeaderText = "BIN";
                    colm.Name = "BIN";
                    colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    I.Columns.Add(colm);
                }
                sc.Panel1.Controls.Add(I);
                inp = I;

                DataGridView O = new DataGridView();
                O.Name = "ODGV";
                O.Size = sc.Panel2.Size;
                O.ReadOnly = true;
                O.BackColor = Color.White;
                O.RowHeadersVisible = false;
                O.GridColor = Color.White;
                O.BackgroundColor = Color.White;

                colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "TIME";
                colm.Name = "TIME";
                colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                O.Columns.Add(colm);
                if (showASCII)
                {
                    colm = new DataGridViewTextBoxColumn();
                    colm.HeaderText = "ASCII";
                    colm.Name = "ASCII";
                    colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    O.Columns.Add(colm);
                }
                if (showHEX)
                {
                    colm = new DataGridViewTextBoxColumn();
                    colm.HeaderText = "HEX";
                    colm.Name = "HEX";
                    colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    O.Columns.Add(colm);
                }
                if (showBIN)
                {
                    colm = new DataGridViewTextBoxColumn();
                    colm.HeaderText = "BIN";
                    colm.Name = "BIN";
                    colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    O.Columns.Add(colm);
                }
                sc.Panel2.Controls.Add(O);
                outp = O;
                this.IOLayout.Controls.Add(sc);
                this.button3.Text = "Объеденить IO";

            }
            else
            {
                this.IOLayout.Controls.Clear();
                DataGridView Io = new DataGridView();
                Io.Name = "IODGV";
                Io.Size = IOLayout.Size;
                Io.ReadOnly = true;
                Io.BackColor = Color.White;
                Io.RowHeadersVisible = false;
                Io.GridColor = Color.White;
                Io.BackgroundColor = Color.White;
                DataGridViewTextBoxColumn colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "TIME";
                colm.Name = "TIME";
                colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Io.Columns.Add(colm);
                colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "From";
                colm.Name = "From";
                colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Io.Columns.Add(colm);
                if (showASCII)
                {
                    colm = new DataGridViewTextBoxColumn();
                    colm.HeaderText = "ASCII";
                    colm.Name = "ASCII";
                    colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Io.Columns.Add(colm);
                }
                if (showHEX)
                {
                    colm = new DataGridViewTextBoxColumn();
                    colm.HeaderText = "HEX";
                    colm.Name = "HEX";
                    colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Io.Columns.Add(colm);
                }
                if (showBIN)
                {
                    colm = new DataGridViewTextBoxColumn();
                    colm.HeaderText = "BIN";
                    colm.Name = "BIN";
                    colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Io.Columns.Add(colm);
                }
                inp = Io;
                outp = Io;
                this.IOLayout.Controls.Add(Io);
                this.button3.Text = "Разделить IO";
            }
            if(TxColors.Count!=0)
                TxColors.Clear();
        }

        public void RefreshIO()
        {
            RefreshIO(inp != outp);
        }



        private string GetHex(string msg)
        {
            string message = "";
            byte[] arr = Encoding.ASCII.GetBytes(msg);
            string s;
            foreach (var i in arr)
            {
                s = Convert.ToString(i, 16).ToUpper();
                if (s.Length == 1)
                    s = "0" + s;
                message += s + " ";
            }
            return message;
        }
        private string GetBin(string msg)
        {
            string message = "";
            byte[] arr = Encoding.ASCII.GetBytes(msg);
            foreach (var i in arr)
            {
                message += Convert.ToString(i, 2).ToUpper() + " ";
            }
            return message;
        }


        public void ClosePort()
        {
            blportopen = false;
            if (th != null)
                th.Join();
            th = null;
            if (_serialPort != null)
                _serialPort.Close();
            this.PortOpenButton.Text = "Открыть";
            _serialPort = null;
        }




        private void SimpleSend(string msg)
        {
            if (_serialPort == null)
                return;
            TxtClors clset;
            List<string> stlist = new List<string>();
            stlist.Add(DateTime.Now.TimeOfDay.ToString().Substring(0, 8));
            if (inp == outp)
                stlist.Add("Port");
            if (showASCII)
                stlist.Add(msg);
            if (showHEX)
                stlist.Add(GetHex(msg));
            if (showBIN)
                stlist.Add(GetBin(msg));
            outp.Rows.Add(stlist.ToArray());
            clset.cl = SendCl;
            clset.IO = outp;
            clset.row = outp.Rows.Count - 2;
            TxColors.Add(clset);
            ChangeColors();
            _serialPort.WriteLine(
                String.Format(msg));
        }


       private void btstop(object sender,EventArgs e)
        {
            circle = false;
            Button btsendr = sender as Button;
            Button bt;
            bt = btsendr.Parent.Controls.Find(btsendr.Name.Substring(0, btsendr.Name.Length - 3),false)[0] as Button;
            bt.Enabled = true;
            bt.Visible = true;
            btsendr.Parent.Controls.Remove(btsendr);

        }


        private void Send(string msg,object sender)
        {
            if (cicleCheck)
            {
                if (cicle_times == 0)
                {
                    circle = true;
                    Button btsendr = sender as Button;
                    Button bt = new Button();
                    bt.Size = btsendr.Size;
                    bt.Text = "Стоп";
                    bt.Location = btsendr.Location;
                    bt.Name = btsendr.Name + "_2_";
                    bt.Click += btstop;
                    (btsendr.Parent).Controls.Add(bt);
                    btsendr.Visible = false;
                    btsendr.Enabled = false;
                    while (circle)
                    {
                        SimpleSend(msg);
                        Thread.Sleep(cicle_time);
                    }
                }
                else
                {
                    int i = cicle_times;
                    while (i > 0)
                    {
                        SimpleSend(msg);
                        i--;
                    }
                }
            }
            else
                SimpleSend(msg);
        }

        private void ChangeColors()
        {
            for (int i = 0; i < TxColors.Count; i++)
            {
                TxColors[i].IO.Rows[TxColors[i].row].DefaultCellStyle.ForeColor = TxColors[i].cl;
            }
        }

        private void PortOpenButton_Click(object sender, EventArgs e)
        {
            if (_serialPort != null)
            {
                ClosePort();
            }
            else if (this.PortCombobox.SelectedIndex != -1)
            {
                _serialPort = new SerialPort();
                _serialPort.PortName = this.PortCombobox.SelectedItem.ToString();
                _serialPort.BaudRate = BaudRatec;
                _serialPort.Parity = Parityc;
                _serialPort.DataBits = Datac;
                _serialPort.StopBits = Stopbtc;
                _serialPort.Handshake = Flowc;

                // Set the read/write timeouts
                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;
                _serialPort.Open();
                blportopen = true;
                th = new Thread(readCOM);
                th.Start();
                this.PortOpenButton.Text = "Закрыть";
            }
        }

        private void PortComboBox_Click(object sender, EventArgs e)
        {
            string[] PortnamesNOW = SerialPort.GetPortNames();
            if (this.PortCombobox.Items.Count == 0)
            {
                this.PortCombobox.Items.Clear();
                this.PortCombobox.Items.AddRange(PortnamesNOW);
            }
        }

        private void PortCombobox_DropDown(object sender, EventArgs e)
        {
            string[] PortnamesNOW = SerialPort.GetPortNames();
            if (PortnamesNOW.Contains(this.PortCombobox.SelectedText))
            {
                string curPort = this.PortCombobox.SelectedText;
                this.PortCombobox.Items.Clear();
                this.PortCombobox.Items.AddRange(PortnamesNOW);
                this.PortCombobox.SelectedText = curPort;
            }
            else
            {
                this.PortCombobox.Items.Clear();
                this.PortCombobox.Items.AddRange(PortnamesNOW);
            }
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            Send(this.mainSend.Text,sender);
        }
        private void readCOM()
        {
            while (blportopen)
            {
                try
                {
                    glmessage += Convert.ToChar(_serialPort.ReadChar());
                    if (glmessage.Length > stopstr.Length)
                        if (glmessage.Substring(glmessage.Length - stopstr.Length) == stopstr)
                            inp.Invoke((MethodInvoker)delegate
                            {
                                if (stop_on&&(glmessage.Substring(0, glmessage.Length - stopstr.Length) == circlestopmsg))
                                {
                                    circle = false;
                                    System.Windows.Forms.MessageBox.Show("Stop msg resived");
                                }
                                List<string> stlist=new List<string>();
                                stlist.Add(DateTime.Now.TimeOfDay.ToString().Substring(0, 8));
                                if (inp == outp)
                                    stlist.Add("Port");
                                if (showASCII)
                                    stlist.Add(glmessage);
                                if (showHEX)
                                    stlist.Add(GetHex(glmessage));
                                if (showBIN)
                                    stlist.Add(GetBin(glmessage));
                                inp.Rows.Add(stlist.ToArray());
                                TxtClors clset;
                                clset.cl = GetCl;
                                clset.IO = inp;
                                clset.row = inp.Rows.Count - 2;
                                TxColors.Add(clset);
                                ChangeColors();
                                glmessage = "";
                            });
                }
                catch (TimeoutException) { }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            blportopen = false;
            if (th != null)
            {
                th.Join();
                th = null;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            showHEX = true; showASCII = true; showBIN = true;
            circlestopmsg = "";
            stop_on = false;
            cicleCheck = false;
            cicle_time = 0;
            cicle_times = 0;
            sndformat = SendFormat.ASCII;
            TxColors = new List<TxtClors>();
            _serialPort = null;
            th = null;
            blportopen = false;
            BaudRatec = 19200;
            Datac = 8;
            Parityc = Parity.None;
            Flowc = Handshake.None;
            Stopbtc = StopBits.One;
            GetCl = Color.Blue;
            SendCl = Color.Red;
            stopstr = "\r\n";
            for (int i = 0; i < 5; i++)
            {
                button1_Click(button1, new EventArgs());
            }
            this.timer1.Start();
            RefreshIO(false);
        }

        private void FileSend_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            FD.ShowDialog();
            string path = FD.FileName;
            Send(System.IO.File.ReadAllText(path),sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = new Button();
            Button btmin = new Button();
            TextBox tb = new TextBox();
            bt.Name = "SLbt" + this.flowLayoutPanel1.Controls.Count / 3;
            bt.Text = "Отправить";
            bt.Click += Bt_Click;
            bt.Size = new Size(75, 25);
            tb.Size = new Size(this.flowLayoutPanel1.Size.Width - 130, 25);
            btmin.Text = "-";
            btmin.Click += Btmin_Click;
            btmin.Size = new Size(25, 25);
            btmin.Name = "SLbm" + this.flowLayoutPanel1.Controls.Count / 3;
            tb.Name = "SLtb" + this.flowLayoutPanel1.Controls.Count / 3;
            this.flowLayoutPanel1.Controls.Add(tb);
            this.flowLayoutPanel1.Controls.Add(bt);
            this.flowLayoutPanel1.Controls.Add(btmin);
        }

        private void Btmin_Click(object sender, EventArgs e)
        {
            Button btmn = sender as Button;
            Console.WriteLine(btmn.Name.Substring(3));
            this.flowLayoutPanel1.Controls.Remove(this.flowLayoutPanel1.Controls.Find("SLtb" + btmn.Name.Substring(4), true)[0]);
            this.flowLayoutPanel1.Controls.Remove(this.flowLayoutPanel1.Controls.Find("SLbt" + btmn.Name.Substring(4), true)[0]);
            this.flowLayoutPanel1.Controls.Remove(btmn);
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            Button btcl = sender as Button;
            Send(this.flowLayoutPanel1.Controls.Find("SLtb" + btcl.Name.Substring(4), true)[0].Text,sender);

        }

        private void Setbt_Click(object sender, EventArgs e)
        {
            SetForm stfm = new SetForm(this);
            stfm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inp.Rows.Clear();
            outp.Rows.Clear();
            inp.Refresh();
            outp.Refresh();
            TxColors.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TimeLable.Text = (DateTime.Now.TimeOfDay.ToString()).Substring(0, 8);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (inp == outp)
                RefreshIO(true);
            else
                RefreshIO(false);
        }
    }
}
