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
        public bool colors;
        bool circle;
        public int cicle_time;
        public int cicle_times;

        public Color SendCl;
        public Color GetCl;
        static string glmessage;
        public string stopstr;
        public string circlestopmsg;
        static List<TxtClors> TxColors;
        static SerialPort _serialPort;
        static Thread thRead,thSend;
        static DataGridView inp, outp;
        public bool showHEX, showASCII, showBIN;
        public bool blportopen;
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
                I.AllowUserToAddRows = false;
                I.BackColor = Color.White;
                I.RowHeadersVisible = false;
                I.GridColor = Color.White;
                I.BackgroundColor = Color.White;
                I.CellClick += dataGridView_CellClick;
                I.AllowUserToResizeRows = false;
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
                O.AllowUserToAddRows = false;
                O.CellClick += dataGridView_CellClick;
                O.AllowUserToResizeRows = false;

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
                this.splitbt.Text = "Объеденить IO";

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
                Io.AllowUserToAddRows = false;
                Io.CellClick += dataGridView_CellClick;
                Io.AllowUserToResizeRows = false;

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
                this.splitbt.Text = "Разделить IO";
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

        private string deHex(string str)
        {
            string res="";
            int value;
            char charValue;
            List<string> strL = new List<string>();
            string[] strH;

            strH = str.Split(' ');
            

            foreach(var hex in strH)
            {
                value = Convert.ToInt32(hex, 16);
                charValue = (char)value;
                res += charValue;
            }

            return res;
        }

        private string deAPH(string str)
        {
            string res = "";
            int value,i,k;
            char charValue;
            List<string> strHL = new List<string>();
            List<string> strAL = new List<string>();
            string[] strH,strA;
            k = str.IndexOf("0X");
            i = str.IndexOf("0x");
            while ((i!=-1)||(k!= -1))
            {
                if ((i != -1) && (k != -1))
                    i = Math.Min(i, k);
                else if ((i == -1) || (k == -1))
                    i = Math.Max(i, k);
                    if (i == 0)
                    strAL.Add("");
                else
                {
                    strAL.Add(str.Substring(0, i));
                }
                strHL.Add(str.Substring(i + 2, 2));
                str = str.Substring(i + 4);
                k = str.IndexOf("0X");
                i = str.IndexOf("0x");
            }
            if (str.Length > 0)
                strAL.Add(str);
            else
                strAL.Add("");
            strA = strAL.ToArray();
            strH = strHL.ToArray();

            for(i=0;i<strH.Length;i++)
            {
                value = Convert.ToInt32(strH[i], 16);
                charValue = (char)value;
                res +=strA[i]+ charValue;
            }
            res += strA[strA.Length-1];

            return res;
        }


        public void ClosePort()
        {
            blportopen = false;
            if (thRead != null)
                thRead.Join();
            thRead = null;
            if (_serialPort != null)
                _serialPort.Close();
            this.PortOpenButton.Text = "Открыть";
            this.PortCombobox.Enabled = true;
            _serialPort = null;
            circle = false;
        }
        public void OpenPort()
        {
            try
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
                thRead = new Thread(readCOM);
                thRead.Start();
                this.PortOpenButton.Text = "Закрыть";
                PortCombobox.Enabled=false;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message,"Открыть",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _serialPort = null;

            }
        }

        private void SimpleSend(string msg)
        {
            if (_serialPort == null)
            {
                MessageBox.Show("Порт не открыт", "Порт", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TxtClors clset;
            List<string> stlist = new List<string>();
            stlist.Add(DateTime.Now.TimeOfDay.ToString().Substring(0, 8));
            if (inp == outp)
                stlist.Add("Port");
            if (showASCII)
                stlist.Add(msg + stopstr);
            if (showHEX)
                stlist.Add(GetHex(msg + stopstr));
            if (showBIN)
                stlist.Add(GetBin(msg + stopstr));
            outp.Rows.Add(stlist.ToArray());
            clset.cl = SendCl;
            clset.IO = outp;
            clset.row = outp.Rows.Count - 1;
            TxColors.Add(clset);
            ChangeColors();
            _serialPort.WriteLine(
                String.Format(msg+stopstr));
        }


        private void btstop(object sender,EventArgs e)
        {
            circle = false;
        }




        private void Send(string mmsg,object sender)
        {
            string msg;
            if (sndformat == SendFormat.HEX)
                msg = deHex(mmsg);
            else if (sndformat == SendFormat.APH)
                msg = deAPH(mmsg);
            else
                msg = mmsg;
            if (_serialPort != null)
            {
                if (cicleCheck)
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
                    Thread.Sleep(100);
                    ThreadStart starter = delegate { CirSend(msg, btsendr, bt); };
                    thSend = new Thread(starter);
                    thSend.Start();

                }
                else { SimpleSend(msg); }
            }
            if(outp.RowCount>2)
                outp.FirstDisplayedScrollingRowIndex = outp.RowCount-1;
            
        }

        private void ChangeColors()
        {
            if(colors)
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
            else
            {
                OpenPort();
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
            Send(this.MNtb.Text,sender);
        }
        private void readCOM()
        {
            while (blportopen)
            {
                try
                {
                    glmessage += Convert.ToChar(_serialPort.ReadChar());
                    if (glmessage.Length > stopstr.Length)
                    {
                        if(glmessage.Substring(glmessage.Length - stopstr.Length) == stopstr)
                            if (circle && stop_on && (glmessage.Substring(0, glmessage.Length - stopstr.Length) == circlestopmsg))
                            {
                                circle = false;
                                var thread = new Thread(
                                    () => { MessageBox.Show("Получен ответ остановки", "Стоп", MessageBoxButtons.OK, MessageBoxIcon.Warning); });
                                thread.Start();
                            }
                        inp.Invoke((MethodInvoker)delegate
                        {
                            List<string> stlist = new List<string>();
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
                            if (outp.RowCount > 2)
                                inp.FirstDisplayedScrollingRowIndex = inp.RowCount - 1;
                        });
                    }
                }
                catch (TimeoutException) { }
            }
        }

        private void CirSend(object mmsg,object ooldbt,object bbtnow)
        {
            string msg = mmsg as string;
            Button btold = ooldbt as Button;
            Button btnow = bbtnow as Button;

            if (cicleCheck)
            {
                bool csleep = (cicle_time > 1500);
                DateTime sendt;
                if (cicle_times > 0)
                    for (int i = 0; i < cicle_times; i++)
                    {
                        if (_serialPort != null&&circle)
                        {
                            _serialPort.Write(msg);
                            sendt = DateTime.Now.AddMilliseconds(cicle_time);
                            outp.Invoke((MethodInvoker)delegate
                            {
                                List<string> stlist = new List<string>();
                                stlist.Add(DateTime.Now.TimeOfDay.ToString().Substring(0, 8));
                                if (inp == outp)
                                    stlist.Add("You");
                                if (showASCII)
                                    stlist.Add(msg);
                                if (showHEX)
                                    stlist.Add(GetHex(msg));
                                if (showBIN)
                                    stlist.Add(GetBin(msg));
                                outp.Rows.Add(stlist.ToArray());
                                TxtClors clset;
                                clset.cl = GetCl;
                                clset.IO = outp;
                                clset.row = outp.Rows.Count - 2;
                                TxColors.Add(clset);
                                ChangeColors();
                            });
                            if(csleep)
                            {
                                while(sendt>DateTime.Now)
                                {
                                    if (!circle)
                                        break;
                                }
                            }
                            else
                            {
                                Thread.Sleep(cicle_time);
                            }
                        }
                        if (!circle)
                            break;
                    }
                else
                    while (circle)
                    {
                        if ((_serialPort != null)&&circle)
                        {
                            _serialPort.Write(msg);
                            sendt = DateTime.Now.AddMilliseconds(cicle_time);
                            outp.Invoke((MethodInvoker)delegate
                            {
                                List<string> stlist = new List<string>();
                                stlist.Add(DateTime.Now.TimeOfDay.ToString().Substring(0, 8));
                                if (inp == outp)
                                    stlist.Add("You");
                                if (showASCII)
                                    stlist.Add(msg);
                                if (showHEX)
                                    stlist.Add(GetHex(msg));
                                if (showBIN)
                                    stlist.Add(GetBin(msg));
                                outp.Rows.Add(stlist.ToArray());
                                TxtClors clset;
                                clset.cl = GetCl;
                                clset.IO = outp;
                                clset.row = outp.Rows.Count - 2;
                                TxColors.Add(clset);
                                ChangeColors();
                            });
                            if (csleep)
                            {
                                while (sendt > DateTime.Now)
                                {
                                    if (!circle)
                                        break;
                                }
                            }
                            else
                            {
                                Thread.Sleep(cicle_time);
                            }
                        }
                    }
            }

            btold.Invoke((MethodInvoker)delegate
            {
                btold.Enabled = true;
                btold.Visible = true;
            });
            btnow.Invoke((MethodInvoker)delegate { btnow.Parent.Controls.Remove(btnow); });
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            blportopen = false;
            if (thRead != null)
            {
                thRead.Join();
                thRead = null;
            }
            try
            {
                Properties.Settings.Default.ComName = this.PortCombobox.SelectedItem.ToString();
            }
            catch(Exception ex) { }
            string st;
            Properties.Settings.Default.BaudRate = BaudRatec;
            Properties.Settings.Default.Data = Datac;
            Properties.Settings.Default.Flow = Flowc;
            Properties.Settings.Default.Stopbit = Stopbtc;
            Properties.Settings.Default.Parity = Parityc;
            Properties.Settings.Default.stopstr = stopstr;
            Properties.Settings.Default.Comands.Clear();
            for(int i=0;i<SLpanel.Controls.Count;i++)
            {
                st = SLpanel.Controls[i].Controls["SCtb"].Text;
                if (st!="")
                    Properties.Settings.Default.Comands.Add(st);
            }
            Properties.Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            showHEX = true; showASCII = true; showBIN = true;
            circlestopmsg = "";
            stop_on = false;
            cicleCheck = false;
            cicle_time = 0;
            cicle_times = 0;
            circle = false;
            colors=true;
            sndformat = SendFormat.ASCII;
            TxColors = new List<TxtClors>();
            _serialPort = null;
            thRead = null;
            blportopen = false;

            try
            {
                this.PortCombobox.SelectedItem = Properties.Settings.Default.ComName;
            }
            catch (Exception ex) { }
            BaudRatec = Properties.Settings.Default.BaudRate;
            Datac = Properties.Settings.Default.Data;
            Flowc = Properties.Settings.Default.Flow;
            Stopbtc = Properties.Settings.Default.Stopbit;
            Parityc = Properties.Settings.Default.Parity;
            stopstr = Properties.Settings.Default.stopstr;
            var list = Properties.Settings.Default.Comands.Cast<string>().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                SendCombo sc = new SendCombo();
                Button bt = (Button)sc.Controls.Find("SCbt", false)[0];
                Button btmin = (Button)sc.Controls.Find("SCbm", false)[0];
                TextBox tb = (TextBox)sc.Controls.Find("SCtb", false)[0];
                sc.Name = "SC" + this.SLpanel.Controls.Count;
                bt.Click += Bt_Click;
                btmin.Click += Btmin_Click;
                tb.KeyUp += SndEnt_KeyUp;
                this.SLpanel.Controls.Add(sc);
                tb.Text = list[i];
            }


        
            GetCl = Color.Blue;
            SendCl = Color.Red;
          
            for (int i = 0; i < 3; i++)
            {
                Plusbt_Click(PLbt, new EventArgs());
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
            try
            {
                this.MNtb.Text = System.IO.File.ReadAllText(path);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Plusbt_Click(object sender, EventArgs e)
        {
            SendCombo sc = new SendCombo();
            Button bt = (Button)sc.Controls.Find("SCbt", false)[0];
            Button btmin = (Button)sc.Controls.Find("SCbm", false)[0];            
            TextBox tb = (TextBox)sc.Controls.Find("SCtb", false)[0];
            sc.Name = "SC" + this.SLpanel.Controls.Count;
            bt.Click += Bt_Click;
            btmin.Click += Btmin_Click;
            tb.KeyUp += SndEnt_KeyUp;
            this.SLpanel.Controls.Add(sc);
        }

        private void Btmin_Click(object sender, EventArgs e)
        {
            Button btmn = sender as Button;
            btmn.Parent.Parent.Controls.Remove(btmn.Parent);
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            Button btcl = sender as Button;
            Send(btcl.Parent.Controls.Find("SCtb", true)[0].Text,sender);

        }

        private void Setbt_Click(object sender, EventArgs e)
        {
            SetForm stfm = new SetForm(this);
            stfm.ShowDialog();
        }

        private void SndEnt_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.KeyCode == Keys.Enter)
            {
                this.Send(tb.Text, tb.Name.Substring(0, 2) + "bt");
            }
        }

        private void MNtb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            try
            {
                if ((tb.Text.Substring(tb.Text.Length - 2)) == "\r\n")
                    tb.Text = tb.Text.Substring(0, tb.Text.Length - 2);
                tb.SelectionStart = tb.Text.Length;
            }
            catch(Exception ex)
            { }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView DG = sender as DataGridView;
                BigViewForm bvf = new BigViewForm(DG.Rows[e.RowIndex].Cells);
                bvf.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            SLpanel.Controls.Clear();
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
