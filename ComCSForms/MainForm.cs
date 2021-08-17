﻿using System;
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
    public partial class PortForm : Form
    {
        struct TxtClors
        {
            public Color cl;
            public DataGridView IO;
            public int row;
        }
        public int BaudRatec;
        public  int Datac;
        public Parity Parityc;
        public StopBits Stopbtc;
        public Handshake Flowc;
        public  bool cicle;
        public  bool stop_on;

        static Color SendCl;
        static Color GetCl;
        static string glmessage;
        public string stopstr;
        static List<TxtClors> TxColors;
        static SerialPort _serialPort;
        static Thread th;
        static DataGridView inp,outp;
        bool showHEX, showASCII, showBYTE;
        bool blportopen;
        public PortForm()
        {
            InitializeComponent();
        }

        private string GetByte(string msg)
        {
            string message = "";
            byte[] arr = Encoding.ASCII.GetBytes(msg);
            foreach (var i in arr)
            {
                message += i+" ";
            }
            return message;
        }


        private void Send(string msg)
        {
            if (_serialPort == null)
                return;
            TxtClors clset;
            if(inp==outp)
                inp.Rows.Add((DateTime.Now.TimeOfDay.ToString()).Substring(0, 8), "YOU",msg,GetByte(msg));
            else
                outp.Rows.Add((DateTime.Now.TimeOfDay.ToString()).Substring(0, 8), msg, GetByte(msg));
            clset.cl = SendCl;
            clset.IO = outp;
            clset.row = outp.Rows.Count-2;
            TxColors.Add(clset);
            ChangeColors();
            _serialPort.WriteLine(
                String.Format(msg));
        }

        private void ChangeColors()
        {
            for(int i=0;i<TxColors.Count;i++)
            {
                TxColors[i].IO.Rows[TxColors[i].row].DefaultCellStyle.ForeColor = TxColors[i].cl;
            }
        }

        private void PortOpenButton_Click(object sender, EventArgs e)
        {
            if (_serialPort!=null)
            {
                blportopen = false;
                th.Join();
                th = null;
                _serialPort.Close();
                this.PortOpenButton.Text = "Открыть";
                _serialPort = null;
                
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
            string[] PortnamesNOW= SerialPort.GetPortNames();
            if (this.PortCombobox.Items.Count == 0)
            {
                this.PortCombobox.Items.Clear();
                this.PortCombobox.Items.AddRange(PortnamesNOW);
            }            
        }

        private void PortCombobox_DropDown(object sender, EventArgs e)
        {/*
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
            }*/
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            Send(this.textBox3.Text);
        }
        private void readCOM()
        {
            while (blportopen)
            {
                try
                {
                    glmessage+= Convert.ToChar( _serialPort.ReadChar());
                    if (glmessage.Length > stopstr.Length)
                        if (glmessage.Substring(glmessage.Length - stopstr.Length) == stopstr)
                            inp.Invoke((MethodInvoker)delegate
                            {
                                // Running on the UI thread
                                TxtClors clset;
                                if (inp == outp)
                                    inp.Rows.Add((DateTime.Now.TimeOfDay.ToString()).Substring(0, 8),"PORT",glmessage,glmessage);
                                else
                                    inp.Rows.Add((DateTime.Now.TimeOfDay.ToString()).Substring(0, 8), glmessage, glmessage);
                                clset.cl = GetCl;
                                clset.IO = inp;
                                clset.row = inp.Rows.Count-2;
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
            colm.Width = IOLayout.Width * 2 / 12;
            Io.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "From";
            colm.Name = "From";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.Width = IOLayout.Width * 19 / 120;
            Io.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "ASCII";
            colm.Name = "ASCII";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.Width = IOLayout.Width * 4 / 12;
            Io.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "HEX";
            colm.Name = "HEX";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.Width = IOLayout.Width * 4 / 12;
            Io.Columns.Add(colm);
            inp = Io;
            outp = Io;
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
            this.IOLayout.Controls.Add(Io);
            stopstr = System.Environment.NewLine;
            for(int i=0;i<5;i++)
            {
                button1_Click(button1, new EventArgs());
            }
            this.timer1.Start();
        }

        private void FileSend_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.ShowDialog();
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
            btmin.Size=new Size(25,25);
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
            Send(this.flowLayoutPanel1.Controls.Find("SLtb" + btcl.Name.Substring(4), true)[0].Text);
            
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
            this.TimeLable.Text = (DateTime.Now.TimeOfDay.ToString()).Substring(0,8);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (inp == outp)
            {
                this.IOLayout.Controls.Clear();
                SplitContainer sc = new SplitContainer();
                sc.Size = this.IOLayout.Size;
                sc.SplitterDistance = sc.Width / 2;
                DataGridView I = new DataGridView();
                I.Name = "IDGV";
                I.Size = sc.Panel1.Size;
                I.ReadOnly = true;
                I.BackColor = Color.White;
                I.RowHeadersVisible = false;
                DataGridViewTextBoxColumn colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "TIME";
                colm.Name = "TIME";
                colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colm.Width = sc.Panel1.Width * 29 / 130;
                I.Columns.Add(colm);
                colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "ASCII";
                colm.Name = "ASCII";
                colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colm.Width = sc.Panel1.Width * 5 / 13;
                I.Columns.Add(colm);
                colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "HEX";
                colm.Name = "HEX";
                colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colm.Width = sc.Panel1.Width * 5 / 13;
                I.Columns.Add(colm);
                sc.Panel1.Controls.Add(I);
                inp = I;
                DataGridView O = new DataGridView();
                O.Name = "ODGV";
                O.Size = sc.Panel2.Size;
                O.ReadOnly = true;
                O.BackColor = Color.White;
                O.RowHeadersVisible = false;
                colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "TIME";
                colm.Name = "TIME";
                colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colm.Width = sc.Panel2.Width * 29 / 130;
                O.Columns.Add(colm);
                colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "ASCII";
                colm.Name = "ASCII";
                colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colm.Width = sc.Panel2.Width * 5 / 13;
                O.Columns.Add(colm);
                colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "HEX";
                colm.Name = "HEX";
                colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colm.Width = sc.Panel2.Width * 5 / 13;
                O.Columns.Add(colm);
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
                DataGridViewTextBoxColumn colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "TIME";
                colm.Name = "TIME";
                colm.Width = IOLayout.Width * 2 / 12;
                Io.Columns.Add(colm);
                colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "From";
                colm.Name = "From";
                colm.Width = IOLayout.Width * 19 / 120;
                Io.Columns.Add(colm);
                colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "ASCII";
                colm.Name = "ASCII";
                colm.Width = IOLayout.Width * 4 / 12;
                Io.Columns.Add(colm);
                colm = new DataGridViewTextBoxColumn();
                colm.HeaderText = "HEX";
                colm.Name = "HEX";
                colm.Width = IOLayout.Width * 4 / 12;
                Io.Columns.Add(colm);
                inp = Io;
                outp = Io;
                this.IOLayout.Controls.Add(Io);
                this.button3.Text = "Разделить IO";
            }
            TxColors.Clear();
        }
    }
}
