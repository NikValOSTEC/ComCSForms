using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComCSForms
{
    public partial class SetForm : Form
    {
        PortForm main;
        public SetForm(PortForm mn)
        {
            main = mn;
            InitializeComponent();
        }

        private string deAPH(string str)
        {
            string res = "";
            int value, i, k;
            char charValue;
            List<string> strHL = new List<string>();
            List<string> strAL = new List<string>();
            string[] strH, strA;
            k = str.IndexOf("0x");
            i = str.IndexOf(" 0x");
            while ((i != -1) || (k != -1))
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
                str = str.Substring(i + 4 + Convert.ToInt32(i < k));
                k = str.IndexOf("0x");
                i = str.IndexOf(" 0x");
            }
            if (str.Length > 0)
                strAL.Add(str);
            else
                strAL.Add("");
            strA = strAL.ToArray();
            strH = strHL.ToArray();

            for (i = 0; i < strH.Length; i++)
            {
                value = Convert.ToInt32(strH[i], 16);
                charValue = (char)value;
                res += strA[i] + charValue;
            }
            res += strA[strA.Length - 1];

            return res;
        }

        private void SetForm_Load(object sender, EventArgs e)
        {
            BaudCombobox.Items.Add(110);
            BaudCombobox.Items.Add(300);
            BaudCombobox.Items.Add(600);
            BaudCombobox.Items.Add(1200);
            BaudCombobox.Items.Add(2400);
            BaudCombobox.Items.Add(4800);
            BaudCombobox.Items.Add(9600);
            BaudCombobox.Items.Add(14400);
            BaudCombobox.Items.Add(19200);
            BaudCombobox.Items.Add(38400);
            BaudCombobox.Items.Add(56000);
            BaudCombobox.Items.Add(57600);
            BaudCombobox.Items.Add(115200);
            BaudCombobox.Items.Add(128000);
            BaudCombobox.Items.Add(256000);
            BaudCombobox.SelectedItem = main.BaudRatec;
            //
            //
            //
            DatacomboBox.Items.Add(5);
            DatacomboBox.Items.Add(6);
            DatacomboBox.Items.Add(7);
            DatacomboBox.Items.Add(8);
            DatacomboBox.SelectedItem = main.Datac;
            //
            //
            //
            FlowcomboBox.Items.Add("None");
            FlowcomboBox.Items.Add("XOnXOff");
            FlowcomboBox.Items.Add("RequestToSend");
            FlowcomboBox.Items.Add("RequestToSendXOnXOff");
            switch (main.Flowc)
            {
                case System.IO.Ports.Handshake.None:
                    FlowcomboBox.SelectedItem = "None";
                    break;
                case System.IO.Ports.Handshake.XOnXOff:
                    FlowcomboBox.SelectedItem = "XOnXOff";
                    break;
                case System.IO.Ports.Handshake.RequestToSend:
                    FlowcomboBox.SelectedItem = "RequestToSend";
                    break;
                case System.IO.Ports.Handshake.RequestToSendXOnXOff:
                    FlowcomboBox.SelectedItem = "RequestToSendXOnXOff";
                    break;
                default:
                    break;
            }
            StopbitcomboBox.Items.Add("None");
            StopbitcomboBox.Items.Add(1);
            StopbitcomboBox.Items.Add(1.5);
            StopbitcomboBox.Items.Add(2);
            switch (main.Stopbtc)
            {
                case System.IO.Ports.StopBits.None:
                    StopbitcomboBox.SelectedItem = "None";
                    break;
                case System.IO.Ports.StopBits.One:
                    StopbitcomboBox.SelectedItem = 1;
                    break;
                case System.IO.Ports.StopBits.Two:
                    StopbitcomboBox.SelectedItem = 2;
                    break;
                case System.IO.Ports.StopBits.OnePointFive:
                    StopbitcomboBox.SelectedItem = 1.5;
                    break;

            }
            ParitycomboBox.Items.Add("None");
            ParitycomboBox.Items.Add("Even");
            ParitycomboBox.Items.Add("Space");
            ParitycomboBox.Items.Add("Mark");
            ParitycomboBox.Items.Add("Odd");
            switch (main.Parityc)
            {
                case System.IO.Ports.Parity.None:
                    ParitycomboBox.SelectedItem = "None";
                    break;
                case System.IO.Ports.Parity.Odd:
                    ParitycomboBox.SelectedItem = "Odd";
                    break;
                case System.IO.Ports.Parity.Even:
                    ParitycomboBox.SelectedItem = "Even";
                    break;
                case System.IO.Ports.Parity.Mark:
                    ParitycomboBox.SelectedItem = "Mark";
                    break;
                case System.IO.Ports.Parity.Space:
                    ParitycomboBox.SelectedItem = "Space";
                    break;
                default:
                    break;
            }
            ASCIIcheck.Checked = main.showASCII;
            ColorscheckBox.Checked = main.colors;
            BINcheck.Checked = main.showBIN;
            HEXcheck.Checked = main.showHEX;
            StopstrcomboBoxgt.Items.Clear();
            var list = Properties.Settings.Default.Stopstrcombo.Cast<string>().ToList().ToArray();
            for (int i = 0; i < list.Length; i++)
                if (list[i] != "")
                    StopstrcomboBoxgt.Items.Add(list[i]);
            if (main.stopstrgt == Environment.NewLine)
                StopstrcomboBoxgt.Text= "CRLF";
            else
                StopstrcomboBoxgt.Text = main.stopstrgt;

            StopstrcomboBoxsd.Items.Clear();
            for (int i = 0; i < list.Length; i++)
                if (list[i] != "")
                    StopstrcomboBoxsd.Items.Add(list[i]);
            if (main.stopstrsd == Environment.NewLine)
                StopstrcomboBoxsd.Text = "CRLF";
            else
                StopstrcomboBoxsd.Text = main.stopstrsd;
            Ciclecheck.Checked = main.cicleCheck;
            CicleTimeUD.Value = main.cicle_time;
            CiclNUD.Value = main.cicle_times;
            Stopmsgtext.Text = main.circlestopmsg;
            SendStopCheck.Checked = main.stop_on;
            SpaceCheckBox.Checked = main.spacecheck;
            textBoxSend.ForeColor = main.SendCl;
            textBoxGet.ForeColor = main.GetCl;
            (groupBoxsendformat.Controls.Find("radiobutton" + main.sndformat.ToString(), false)[0] as RadioButton).Checked=true;
        }

        private void SetButt_Click(object sender, EventArgs e)
        {
            main.BaudRatec = Convert.ToInt32(BaudCombobox.SelectedItem);
            main.Datac = Convert.ToInt32(DatacomboBox.SelectedItem);
            switch (FlowcomboBox.SelectedItem)
            {
                case "None":
                    main.Flowc = System.IO.Ports.Handshake.None;
                    break;
                case "RequestToSend":
                    main.Flowc = System.IO.Ports.Handshake.RequestToSend;
                    break;
                case "XOnXOff":
                    main.Flowc = System.IO.Ports.Handshake.XOnXOff;
                    break;
                case "RequestToSendXOnXOff":
                    main.Flowc = System.IO.Ports.Handshake.RequestToSendXOnXOff;
                    break;
                default:
                    break;
            }
            switch (StopbitcomboBox.SelectedItem)
            {
                case "None":
                    main.Stopbtc = System.IO.Ports.StopBits.None;
                    break;
                case 1:
                    main.Stopbtc = System.IO.Ports.StopBits.One;
                    break;
                case 1.5:
                    main.Stopbtc = System.IO.Ports.StopBits.OnePointFive;
                    break;
                case 2:
                    main.Stopbtc = System.IO.Ports.StopBits.Two;
                    break;
                default:
                    break;
            }
            switch (ParitycomboBox.SelectedItem)
            {
                case "None":
                    main.Parityc = System.IO.Ports.Parity.None;
                    break;
                case "Odd":
                    main.Parityc = System.IO.Ports.Parity.Odd;
                    break;
                case "Even":
                    main.Parityc = System.IO.Ports.Parity.Even;
                    break;
                case "Mark":
                    main.Parityc = System.IO.Ports.Parity.Mark;
                    break;
                case "Space":
                    main.Parityc = System.IO.Ports.Parity.Space;
                    break;
                default:
                    break;
            }

            try
            {
                if ((StopstrcomboBoxgt.SelectedText.ToString() == "CRLF") || (StopstrcomboBoxgt.Text == "CRLF"))
                    main.stopstrgt = Environment.NewLine;
                else if (StopstrcomboBoxgt.SelectedIndex != -1)
                    main.stopstrgt = deAPH(StopstrcomboBoxgt.Text.ToString());
                else
                    main.stopstrgt = "";
            }
            catch (Exception ex)
            {
                if (StopbitcomboBox.SelectedIndex != -1)
                    main.stopstrgt = StopstrcomboBoxgt.Text.ToString();
                else
                    main.stopstrgt = "";
            }
            try
            {
                if ((StopstrcomboBoxsd.SelectedText.ToString() == "CRLF") || (StopstrcomboBoxsd.Text == "CRLF"))
                    main.stopstrsd = Environment.NewLine;
                else if (StopstrcomboBoxsd.SelectedIndex != -1)
                    main.stopstrsd = deAPH(StopstrcomboBoxsd.Text.ToString());
                else
                    main.stopstrsd = "";
            }
            catch (Exception ex)
            {
                if (StopbitcomboBox.SelectedIndex != -1)
                    main.stopstrsd = StopstrcomboBoxsd.Text.ToString();
                else
                    main.stopstrgt = "";
            }
            main.showASCII = ASCIIcheck.Checked;
                main.showBIN = BINcheck.Checked;
                main.showHEX = HEXcheck.Checked;
                main.colors = ColorscheckBox.Checked;
                main.SendCl = textBoxSend.ForeColor;
                main.GetCl = textBoxGet.ForeColor;
                main.circlestopmsg = Stopmsgtext.Text.ToString();
                main.cicleCheck = Ciclecheck.Checked;
                main.cicle_time = Convert.ToInt32(CicleTimeUD.Value);
                main.stop_on = SendStopCheck.Checked;
                main.spacecheck = SpaceCheckBox.Checked;
                main.cicle_times = Convert.ToInt32(CiclNUD.Value);
                var checkedButton = groupBoxsendformat.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name.ToString().Substring(11);
            switch (checkedButton)
            {
                case "HEX":
                    main.sndformat = SendFormat.HEX;
                    break;
                case "ASCII":
                    main.sndformat = SendFormat.ASCII;
                    break;
                case "APH":
                    main.sndformat = SendFormat.APH;
                    break;
                default:
                    break;
            }
            main.RefreshIO();
            if (main.blportopen)
            {
                main.ClosePort();
                main.OpenPort();
            }
            this.Close();

        }

        private void textBoxCl_Click(object sender, EventArgs e)
        {
            colorDialogSend.Color = (sender as TextBox).ForeColor;
            colorDialogSend.ShowDialog();
            (sender as TextBox).ForeColor = colorDialogSend.Color;           
        }

        private void formatcheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (!cb.Checked)
                if((!(cb.Parent.Controls.Find("BINcheck", true)[0]as CheckBox).Checked)&& 
                    (!(cb.Parent.Controls.Find("ASCIIcheck", true)[0] as CheckBox).Checked)&& 
                    (!(cb.Parent.Controls.Find("HEXcheck", true)[0] as CheckBox).Checked))
                {
                    cb.Checked = true;
                }
        }

        private void StopstrcomboBox_KeyUp(object sender, KeyEventArgs e)
        {
            ComboBox StopstrcomboBox = sender as ComboBox;
            if (e.KeyCode==Keys.Enter)
            {
                StopstrcomboBox.Items.Add(StopstrcomboBox.Text);
            }
        }

        private void SetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Stopstrcombo.Clear();
            string str;
            for (int i = 0; i < StopstrcomboBoxgt.Items.Count; i++)
            {
                str = StopstrcomboBoxgt.Items[i].ToString();
                if (str != "")
                {
                    if (!Properties.Settings.Default.Stopstrcombo.Contains(str))
                        Properties.Settings.Default.Stopstrcombo.Add(str);
                }
            }
            for (int i = 0; i < StopstrcomboBoxsd.Items.Count; i++)
            {
                str = StopstrcomboBoxgt.Items[i].ToString();
                if (str != "")
                {
                    if (!Properties.Settings.Default.Stopstrcombo.Contains(str))
                        Properties.Settings.Default.Stopstrcombo.Add(str);
                }
            }
        }

        private void clearstoplist_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            ComboBox cb;
            cb=bt.Parent.Controls.Find("StopstrcomboBox"+bt.Name.ToString().Substring(bt.Name.Length - 2),true)[0] as ComboBox;
            cb.Items.Clear();
        }

    }
}