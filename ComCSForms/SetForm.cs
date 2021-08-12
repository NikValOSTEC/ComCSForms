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
            StopbitcomboBox.Items.Add("нет");
            StopbitcomboBox.Items.Add(1);
            StopbitcomboBox.Items.Add(1.5);
            StopbitcomboBox.Items.Add(2);
            switch (main.Stopbtc)
            {
                case System.IO.Ports.StopBits.None:
                    StopbitcomboBox.SelectedItem = "Нет";
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

        }
    }
}