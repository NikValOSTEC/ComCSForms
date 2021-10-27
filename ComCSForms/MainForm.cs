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
        static DateTime lastread;

        public Color SendCl;
        public Color GetCl;
        static string glmessage,glmessagedots;
        public string stopstrgt;
        public string stopstrsd;
        public string circlestopmsg;
        static List<TxtClors> TxColors;
        static SerialPort _serialPort;
        static Thread thRead,thSend;
        static DataGridView IO, outp,inp;
        static SplitContainer IOSplit;
        public bool showHEX, showASCII, showBIN,IO1_2;
        public bool blportopen;
        public bool spacecheck;
        public PortForm()
        {
            InitializeComponent();
        }

        public DataGridViewRow CloneRowWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (int index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }



        void CreateIO()
        {
            IO = new DataGridView();
            IO.Name = "IODGV";
            IO.ReadOnly = true;
            IO.AllowUserToAddRows = false;
            IO.BackColor = Color.White;
            IO.RowHeadersVisible = false;
            IO.GridColor = Color.White;
            IO.Dock = DockStyle.Fill;
            IO.BackgroundColor = Color.White;
            IO.CellDoubleClick += dataGridView_CellDoubleClick;
            IO.MouseClick += dataGrid_MouseClick;
            IO.AllowUserToResizeRows = false;
            DataGridViewTextBoxColumn colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "Время";
            colm.Name = "TIME";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            IO.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "Команда";
            colm.Name = "FROM";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            IO.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "ASCII";
            colm.Name = "ASCII";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.MinimumWidth = 50;
            IO.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "HEX";
            colm.Name = "HEX";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.MinimumWidth = 50;
            IO.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "BIN";
            colm.Name = "BIN";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.MinimumWidth = 50;
            IO.Columns.Add(colm);
            //
            //
            //
            outp = new DataGridView();
            outp.Name = "OutDGV";
            outp.ReadOnly = true;
            outp.AllowUserToAddRows = false;
            outp.BackColor = Color.White;
            outp.RowHeadersVisible = false;
            outp.GridColor = Color.White;
            outp.BackgroundColor = Color.White;
            outp.CellDoubleClick += dataGridView_CellDoubleClick;
            outp.MouseClick += dataGrid_MouseClick;
            outp.AllowUserToResizeRows = false;
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "Время";
            colm.Name = "TIME";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            outp.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "Команда";
            colm.Name = "FROM";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colm.Visible = false;
            outp.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "ASCII";
            colm.Name = "ASCII";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.MinimumWidth = 50;
            outp.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "HEX";
            colm.Name = "HEX";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.MinimumWidth = 50;
            outp.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "BIN";
            colm.Name = "BIN";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.MinimumWidth = 50;
            outp.Columns.Add(colm);
            //
            //
            //
            inp = new DataGridView();
            inp.Name = "InDGV";
            inp.ReadOnly = true;
            inp.AllowUserToAddRows = false;
            inp.BackColor = Color.White;
            inp.RowHeadersVisible = false;
            inp.GridColor = Color.White;
            inp.BackgroundColor = Color.White;
            inp.CellDoubleClick += dataGridView_CellDoubleClick;
            inp.MouseClick += dataGrid_MouseClick;
            inp.AllowUserToResizeRows = false;
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "Время";
            colm.Name = "TIME";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            inp.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "Команда";
            colm.Name = "FROM";
            colm.Visible = false;
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colm.Visible = false;
            inp.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "ASCII";
            colm.Name = "ASCII";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.MinimumWidth = 50;
            inp.Columns.Add(colm);
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "HEX";
            colm.Name = "HEX";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.MinimumWidth = 50;
            inp.Columns.Add(colm);
            inp.Dock = DockStyle.Fill;
            outp.Dock = DockStyle.Fill;
            colm = new DataGridViewTextBoxColumn();
            colm.HeaderText = "BIN";
            colm.Name = "BIN";
            colm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colm.MinimumWidth = 50;
            inp.Columns.Add(colm);
            IOSplit = new SplitContainer();
            IOSplit.Size = this.IOGroup.Size;
            IO.Size = this.IOGroup.Size;
            IOSplit.SplitterDistance = IOSplit.Width/2;
            outp.Size = new Size(IOSplit.Panel1.Width, IOSplit.Height);
            inp.Size = new Size(IOSplit.Panel2.Width, IOSplit.Height);
            IOSplit.Panel1.Controls.Add(outp);
            IOSplit.Panel2.Controls.Add(inp);
            this.IOGroup.Controls.Add(IOSplit);
            this.IOGroup.Controls.Add(IO);
            IOSplit.Dock = DockStyle.Fill;
            IOSplit.AutoSize = true;
            IOSplit.IsSplitterFixed = false;
            IOSplit.Dock = DockStyle.Fill;
            IOSplit.Panel1.AutoScroll = true;
            IOSplit.Panel2.AutoScroll = true;
        }

        public void RefreshIO()
        {
            IO.Columns["ASCII"].Visible = showASCII;
            inp.Columns["ASCII"].Visible = showASCII;
            outp.Columns["ASCII"].Visible = showASCII;
            IO.Columns["HEX"].Visible = showHEX;
            inp.Columns["HEX"].Visible = showHEX;
            outp.Columns["HEX"].Visible = showHEX;
            IO.Columns["BIN"].Visible = showBIN;
            inp.Columns["BIN"].Visible = showBIN;
            outp.Columns["BIN"].Visible = showBIN;
            IO.Visible = !IO1_2;
            IOSplit.Visible = IO1_2;
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
            k = str.IndexOf("0x");
            i = str.IndexOf(" 0x");
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
                strHL.Add(str.Substring(i + 2 + Convert.ToInt32(i < k), 2));
                str = str.Substring(i + 4 + Convert.ToInt32(i < k) + Convert.ToInt32(i < k));
                k = str.IndexOf("0x");
                i = str.IndexOf(" 0x");
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
            this.pictureBoxPortStateStop.Visible = true;
            this.pictureBoxPortStateOpen.Visible = false;
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
                this.pictureBoxPortStateStop.Visible = false;
                this.pictureBoxPortStateOpen.Visible = true;
                this.PortOpenButton.Refresh();
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
            TxtClors clset;
            string mgstr = msg + stopstrsd;
            StringBuilder sb = new StringBuilder(mgstr);
            for (int i = 0; i < mgstr.Length; i++)
            {
                if ((int)sb[i] < 40)
                    sb[i] = (char)46;
            }
            mgstr = sb.ToString();
            List<string> stlist = new List<string>();
            stlist.Add(DateTime.Now.TimeOfDay.ToString().Substring(0, 8));
            stlist.Add("Отправка");
            stlist.Add(mgstr);
            stlist.Add(GetHex(msg + stopstrsd));
            stlist.Add(GetBin(msg + stopstrsd));
            outp.Rows.Add(stlist.ToArray());
            clset = new TxtClors();
            clset.cl = SendCl;
            clset.IO = outp;
            clset.row = outp.Rows.Count - 1;
            TxColors.Add(clset);
            IO.Rows.Add(stlist.ToArray());
            clset = new TxtClors();
            clset.cl = SendCl;
            clset.IO = IO;
            clset.row = IO.Rows.Count - 1;
            TxColors.Add(clset);
            if (inp.RowCount > 2)
                inp.FirstDisplayedScrollingRowIndex = inp.RowCount - 1;
            if (IO.RowCount > 2)
                IO.FirstDisplayedScrollingRowIndex = IO.RowCount - 1;

            ChangeColors();
            if(_serialPort!=null)
                _serialPort.Write(
                String.Format(msg+stopstrsd));
        }


        private void btstop(object sender,EventArgs e)
        {
            circle = false;
            Button btsendr, bt;
            btsendr = sender as Button;
            bt = btsendr.Parent.Controls.Find(btsendr.Name.Substring(0, btsendr.Name.Length - 1), false)[0] as Button;
            btsendr.Visible = false;
            btsendr.Enabled = false;
            bt.Visible = true;
            bt.Enabled = true;


        }




        private void Send(string mmsg,object sender)
        {
            if(_serialPort==null)
                MessageBox.Show("Сначала откройте порт", "Порт Закрыт", MessageBoxButtons.OK);
            string msg;
            if (sndformat == SendFormat.HEX)
                msg = deHex(mmsg);
            else if (sndformat == SendFormat.APH)
                msg = deAPH(mmsg);
            else
                msg = mmsg;
            if(spacecheck&&_serialPort!=null)
            {
                if (msg.Contains(' ')) 
                {
                    DialogResult dialogResult = MessageBox.Show("Отправить сообщение вырезав пробелы?", "Обнаружены пробелы в сообщении", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string[] msgNS;
                        msgNS = msg.Split(' ');
                        msg = "";
                        foreach (var item in msgNS)
                        {
                            msg += item;
                        }
                    }
                }
            }
            if (_serialPort != null)
            {
                if (cicleCheck)
                {
                    Button btsendr = sender as Button;
                    Button bt;
                    circle = true;
                    bt = btsendr.Parent.Controls.Find(btsendr.Name+"S",false)[0] as Button;
                    bt.Click -= btstop;
                    bt.Click += btstop;
                    btsendr.Visible = false;
                    btsendr.Enabled = false;
                    bt.Visible = true;
                    bt.Enabled = true;
                    Thread.Sleep(20);
                    ThreadStart starter = delegate { CirSend(msg, btsendr, bt); };
                    thSend = new Thread(starter);
                    thSend.Start();

                }
                else { SimpleSend(msg); }
            }
            if (outp.RowCount > 2)
                outp.FirstDisplayedScrollingRowIndex = outp.RowCount - 1;
            if (IO.RowCount > 2)
                IO.FirstDisplayedScrollingRowIndex = IO.RowCount - 1;

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
            bool save = false;
            string[] PortnamesNOW = SerialPort.GetPortNames();
            for(int i=0;i<PortnamesNOW.Length;i++)
            {
                if(!PortCombobox.Items.Contains(PortnamesNOW[i]))
                {
                    PortCombobox.Items.Add(PortnamesNOW[i]);
                }
            }
            for (int i = 0; i < PortCombobox.Items.Count; i++)
            {
                foreach(string x in PortnamesNOW)
                {
                    if (Equals(x, PortCombobox.Items[i].ToString()))
                        save = true;
                }
                if(!save)
                {
                    PortCombobox.Items.RemoveAt(i);
                }
                save = false;
                    
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
            if (thSend != null)
            {
                circle = false;
                return;
            }
            Send(this.MNtb.Text,sender);
        }
        private void readCOM()
        {
            while (_serialPort.IsOpen)
            {
                try
                {
                    if((Math.Abs(DateTime.Now.Second - lastread.Second)>=1.5)&&((glmessage!="")&&(glmessage!= null)))
                    {
                        IO.Invoke((MethodInvoker)delegate {
                            TxtClors clset;
                            List<string> stlist = new List<string>();
                            stlist.Add(DateTime.Now.TimeOfDay.ToString().Substring(0, 8));
                            stlist.Add("Прием");
                            stlist.Add(glmessagedots);
                            stlist.Add(GetHex(glmessage));
                            stlist.Add(GetBin(glmessage));
                            IO.Rows.Add(stlist.ToArray());
                            clset = new TxtClors();
                            clset.cl = GetCl;
                            clset.IO = IO;
                            clset.row = IO.Rows.Count - 1;
                            TxColors.Add(clset);
                            inp.Rows.Add(stlist.ToArray());
                            clset = new TxtClors();
                            clset.cl = GetCl;
                            clset.IO = inp;
                            clset.row = inp.Rows.Count - 1;
                            TxColors.Add(clset);
                            ChangeColors();
                            glmessage = "";
                            glmessagedots = "";
                            if (inp.RowCount > 2)
                                inp.FirstDisplayedScrollingRowIndex = inp.RowCount - 1;
                            if (IO.RowCount > 2)
                                IO.FirstDisplayedScrollingRowIndex = IO.RowCount - 1;
                        });
                        glmessage = "";
                        glmessagedots = "";
                    }

                    if (stopstrgt != "")
                    {
                        char ch;
                        ch = Convert.ToChar(_serialPort.ReadChar());
                        glmessage +=ch;
                        if ((int)ch < 32)
                            ch = (char)46;
                        glmessagedots += ch;
                        lastread = DateTime.Now;
                        if (glmessage.Length > stopstrgt.Length)
                        {
                            if (glmessage.Substring(glmessage.Length - stopstrgt.Length) == stopstrgt)
                            {
                                if (circle && stop_on && (glmessage.Substring(0, glmessage.Length - stopstrgt.Length) == circlestopmsg))
                                {
                                    circle = false;
                                    var thread = new Thread(
                                        () => { MessageBox.Show("Получен ответ остановки", "Стоп", MessageBoxButtons.OK, MessageBoxIcon.Warning); });
                                    thread.Start();
                                }
                                IO.Invoke((MethodInvoker)delegate {
                                    TxtClors clset;
                                    List<string> stlist = new List<string>();
                                    stlist.Add(DateTime.Now.TimeOfDay.ToString().Substring(0, 8));
                                    stlist.Add("Прием");
                                    stlist.Add(glmessagedots);
                                    stlist.Add(GetHex(glmessage));
                                    stlist.Add(GetBin(glmessage));
                                    IO.Rows.Add(stlist.ToArray());
                                    clset = new TxtClors();
                                    clset.cl = GetCl;
                                    clset.IO = IO;
                                    clset.row = IO.Rows.Count - 1;
                                    TxColors.Add(clset);
                                    inp.Rows.Add(stlist.ToArray());
                                    clset = new TxtClors();
                                    clset.cl = GetCl;
                                    clset.IO = inp;
                                    clset.row = inp.Rows.Count - 1;
                                    TxColors.Add(clset);
                                    ChangeColors();
                                    glmessage = "";
                                    glmessagedots = "";
                                    if (inp.RowCount > 2)
                                        inp.FirstDisplayedScrollingRowIndex = inp.RowCount - 1;
                                    if (IO.RowCount > 2)
                                        IO.FirstDisplayedScrollingRowIndex = IO.RowCount - 1;
                                });
                            }
                        }
                    }
                    else
                    {
                        string msg="";
                        if ((_serialPort != null) && (_serialPort.IsOpen))
                        {
                            msg = _serialPort.ReadExisting();
                            Thread.Sleep(300);
                            if ((_serialPort != null) && (_serialPort.IsOpen))
                                msg += _serialPort.ReadExisting();
                        }
                        string msgdots = msg;
                        StringBuilder sb = new StringBuilder(msgdots);
                        for (int i = 0; i < msgdots.Length; i++)
                        {
                            if ((int)sb[i] < 32)
                                sb[i] = (char)46;
                        }
                        msgdots = sb.ToString();
                        if (msg != "")
                        {
                            IO.Invoke((MethodInvoker)delegate {
                                List<string> stlist = new List<string>();
                                stlist.Add(DateTime.Now.TimeOfDay.ToString().Substring(0, 8));
                                stlist.Add("Прием");
                                stlist.Add(msgdots);
                                stlist.Add(GetHex(msg));
                                stlist.Add(GetBin(msg));
                                IO.Rows.Add(stlist.ToArray());
                                TxtClors clset;
                                clset.cl = GetCl;
                                clset.IO = IO;
                                clset.row = IO.Rows.Count - 1;
                                TxColors.Add(clset);
                                inp.Rows.Add(stlist.ToArray());
                                clset = new TxtClors();
                                clset.cl = GetCl;
                                clset.IO = inp;
                                clset.row = inp.Rows.Count - 1;
                                TxColors.Add(clset);
                                ChangeColors();
                                glmessage = "";
                                glmessagedots = "";
                                if (inp.RowCount > 2)
                                    inp.FirstDisplayedScrollingRowIndex = inp.RowCount - 1;
                                if (IO.RowCount > 2)
                                    IO.FirstDisplayedScrollingRowIndex = IO.RowCount - 1;
                            });
                        }
                    }
                }
                catch (TimeoutException ex)
                {
                    
                }
            }
        }

        private void CirSend(object mmsg,object ooldbt,object bbtnow)
        {
            string msg = mmsg as string;
            Button btold = ooldbt as Button;
            Button btnow = bbtnow as Button;
            TxtClors clset;
            string msgdots = msg;
            StringBuilder sb = new StringBuilder(msgdots);
            for (int i = 0; i < msgdots.Length; i++)
            {
                if ((int)sb[i] < 32)
                    sb[i] = (char)46;
            }
            msgdots = sb.ToString();

            if (cicleCheck)
            {
                circle = true;
                bool csleep = (cicle_time > 100);
                DateTime sendt;
                if (cicle_times > 0)
                    for (int i = 0; i < cicle_times; i++)
                    {
                        if (_serialPort != null&&circle)
                        {
                            _serialPort.Write(msg+stopstrsd);
                            sendt = DateTime.Now.AddMilliseconds(cicle_time);
                            outp.Invoke((MethodInvoker)delegate
                            {
                                List<string> stlist = new List<string>();
                                stlist.Add(DateTime.Now.TimeOfDay.ToString().Substring(0, 8));
                                stlist.Add("Отправка");
                                stlist.Add(msgdots);
                                stlist.Add(GetHex(msg));
                                stlist.Add(GetBin(msg));
                                outp.Rows.Add(stlist.ToArray());
                                clset = new TxtClors();
                                clset.cl = SendCl;
                                clset.IO = outp;
                                clset.row = outp.Rows.Count - 1;
                                TxColors.Add(clset);
                                IO.Rows.Add(stlist.ToArray());
                                clset = new TxtClors();
                                clset.cl = SendCl;
                                clset.IO = IO;
                                clset.row = IO.Rows.Count - 1;
                                TxColors.Add(clset);
                                ChangeColors();
                                if (outp.RowCount > 2)
                                    outp.FirstDisplayedScrollingRowIndex = outp.RowCount - 1;
                                if (IO.RowCount > 2)
                                    IO.FirstDisplayedScrollingRowIndex = IO.RowCount - 1;
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
                            _serialPort.Write(msg+stopstrsd);
                            sendt = DateTime.Now.AddMilliseconds(cicle_time);
                            outp.Invoke((MethodInvoker)delegate
                            {
                                List<string> stlist = new List<string>();
                                stlist.Add(DateTime.Now.TimeOfDay.ToString().Substring(0, 8));
                                stlist.Add("Отправка");
                                stlist.Add(msgdots);
                                stlist.Add(GetHex(msg));
                                stlist.Add(GetBin(msg));
                                outp.Rows.Add(stlist.ToArray());
                                clset = new TxtClors();
                                clset.cl = SendCl;
                                clset.IO = outp;
                                clset.row = outp.Rows.Count - 1;
                                TxColors.Add(clset);
                                IO.Rows.Add(stlist.ToArray());
                                clset = new TxtClors();
                                clset.cl = SendCl;
                                clset.IO = IO;
                                clset.row = IO.Rows.Count - 1;
                                TxColors.Add(clset);
                                ChangeColors();
                                if (outp.RowCount > 2)
                                    outp.FirstDisplayedScrollingRowIndex = outp.RowCount - 1;
                                if (IO.RowCount > 2)
                                    IO.FirstDisplayedScrollingRowIndex = IO.RowCount - 1;
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
            btnow.Invoke((MethodInvoker)delegate 
            {
                btnow.Visible = false;
                btnow.Enabled = false;
                thSend = null;
            });
            return;
            
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
            Properties.Settings.Default.stopstrgt = stopstrgt;
            Properties.Settings.Default.stopstrsd = stopstrsd;
            Properties.Settings.Default.Comands.Clear();
            for(int i=0;i<FlowLP.Controls.Count;i++)
            {
                st = FlowLP.Controls[i].Controls["SCtb"].Text;
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
            spacecheck = false;
            colors=true;
            sndformat = SendFormat.ASCII;
            TxColors = new List<TxtClors>();
            _serialPort = null;
            thRead = null;
            thSend = null;
            blportopen = false;
            PortComboBox_Click(PortCombobox, new EventArgs());
            this.FlowLP.MouseWheel += SLpanel_Scroll;

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
            try
            {
                if (Properties.Settings.Default.stopstrgt.Substring(0, 5) == Environment.NewLine + "   ")
                    stopstrgt = Environment.NewLine;
            }
            catch (Exception ex)
            {
                stopstrgt = Properties.Settings.Default.stopstrgt;
            }
            try
            {
                if (Properties.Settings.Default.stopstrsd.Substring(0, 5) == Environment.NewLine + "   ")
                    stopstrsd = Environment.NewLine;
            }
            catch (Exception ex)
            {
                stopstrsd = Properties.Settings.Default.stopstrsd;
            }
            var list = Properties.Settings.Default.Comands.Cast<string>().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                SendCombo sc = new SendCombo(FlowLP.Size);
                Button bt = (Button)sc.Controls.Find("SCbt", false)[0];
                Button btmin = (Button)sc.Controls.Find("SCbm", false)[0];
                TextBox tb = (TextBox)sc.Controls.Find("SCtb", false)[0];
                sc.Name = "SC" + this.FlowLP.Controls.Count;
                bt.Click += Bt_Click;
                btmin.Click += Btmin_Click;
                tb.KeyUp += SndEnt_KeyUp;
                this.FlowLP.Controls.Add(sc);
                tb.Text = list[i];
            }


        
            GetCl = Color.Blue;
            SendCl = Color.Red;
          
            for (int i = 0; i < 3; i++)
            {
                Plusbt_Click(PLbt, new EventArgs());
            }
            this.timer1.Start();
            CreateIO();
            IO1_2 = false;
            RefreshIO();
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
            SendCombo sc = new SendCombo(FlowLP.Size);
            Button bt = (Button)sc.Controls.Find("SCbt", false)[0];
            Button btmin = (Button)sc.Controls.Find("SCbm", false)[0];            
            TextBox tb = (TextBox)sc.Controls.Find("SCtb", false)[0];
            sc.Name = "SC" + this.FlowLP.Controls.Count;
            bt.Click += Bt_Click;
            btmin.Click += Btmin_Click;
            tb.KeyUp += SndEnt_KeyUp;
            this.FlowLP.Controls.Add(sc);
        }

        private void Btmin_Click(object sender, EventArgs e)
        {
            Button btmn = sender as Button;
            btmn.Parent.Parent.Controls.Remove(btmn.Parent);
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            if (thSend != null)
            {
                circle = false;
                return;
            }
            Button btcl = sender as Button;
            Send(btcl.Parent.Controls.Find("SCtb", true)[0].Text,sender);

        }

        private void Setbt_Click(object sender, EventArgs e)
        {
            bool fi = _serialPort.IsOpen;
            this.ClosePort();
            SetForm stfm = new SetForm(this);
            stfm.ShowDialog();
            if(fi)
                this.OpenPort();
        }

        private void SndEnt_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.KeyCode == Keys.Enter)
            {
                this.Send(tb.Text, tb.Name.Substring(0, 2) + "bt");
            }
        }


        private void SLpanel_Scroll(object sender, ScrollEventArgs e)
        {
            FlowLP.Focus();
            
        }
        private void SLpanel_Scroll(object sender, MouseEventArgs e)
        {
            FlowLP.Focus();

        }

        private void MNtb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            try
            {
                if ((tb.Text.Substring(tb.Text.Length - 2)) == Environment.NewLine)
                    tb.Text = tb.Text.Substring(0, tb.Text.Length - 2);
                tb.SelectionStart = tb.Text.Length;
            }
            catch(Exception ex)
            { }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void PortCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuItemCopy_Click(object sender, System.EventArgs e)
        {
            DataGridView dg = ((sender as MenuItem).Parent as ContextMenu).SourceControl as DataGridView;
            Clipboard.SetText(dg.SelectedCells[0].Value.ToString());
        }

        private void menuItemPaint_Click(object sender, System.EventArgs e)
        {
            DataGridView dg = ((sender as MenuItem).Parent as ContextMenu).SourceControl as DataGridView;
            if (dg.SelectedCells[0].Style.BackColor == Color.Yellow)
            {
                dg.SelectedCells[0].Style.BackColor = dg.Columns[dg.SelectedCells[0].ColumnIndex].DefaultCellStyle.BackColor;
            }
            else
                dg.SelectedCells[0].Style.BackColor = Color.Yellow;
        }

        private void dataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            if (e.Button == MouseButtons.Right)
            {
                var hti = dataGrid.HitTest(e.X, e.Y);
                dataGrid.ClearSelection();
                if (hti.RowIndex >= 0 && hti.ColumnIndex >= 0)
                {
                    dataGrid.Rows[hti.RowIndex].Cells[hti.ColumnIndex].Selected = true;
                    MenuItem mi;
                    ContextMenu m = new ContextMenu();
                    mi = new MenuItem("Выделить");
                    mi.Click += menuItemPaint_Click;
                    m.MenuItems.Add(mi);
                    mi = new MenuItem("Копировать");
                    mi.Click += menuItemCopy_Click;
                    m.MenuItems.Add(mi);
                    m.Show(dataGrid, new Point(e.X, e.Y));
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            IO.Rows.Clear();
            outp.Rows.Clear();
            inp.Rows.Clear();
            IO.Refresh();
            outp.Refresh();
            inp.Refresh();
            TxColors.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FlowLP.Controls.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TimeLable.Text = (DateTime.Now.TimeOfDay.ToString()).Substring(0, 8);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            IO1_2 = !IO1_2;
            if (IO1_2)
            {
                splitbt.Text = "Объединить I/O";
            }
            else
                splitbt.Text = "Разъеденить I/O";
            RefreshIO();
        }
    }
}
