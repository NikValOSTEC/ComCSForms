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
    public partial class BigViewForm : Form
    {
        private string[] GetHex(string msg)
        {
            byte[] arr = Encoding.ASCII.GetBytes(msg);
            string s;
            List<string> sL=new List<string>();
            foreach (var i in arr)
            {
                s = Convert.ToString(i, 16).ToUpper();
                if (s.Length == 1)
                    s = "0" + s;
                sL.Add(s);
            }
            return sL.ToArray();
        }
        private string[] GetBin(string msg)
        {
            byte[] arr = Encoding.ASCII.GetBytes(msg);
            List<string> sL = new List<string>();
            foreach (var i in arr)
            {
                sL.Add(Convert.ToString(i, 2).ToUpper());
            }
            return sL.ToArray();
        }
        private string[] GetAscii(char[]ca)
        {
            List<string> SL=new List<string>();
            for(int i=0;i<ca.Length;i++)
            {
                SL.Add(ca[i].ToString());
            }
            return SL.ToArray();
        }
        private string[] GetAsciiH(string st)
        {
            string[] sta = st.Split(' ');
            List<string> SL = new List<string>();
            for (int i = 0; i < sta.Length-1; i++)
            {
                SL.Add(System.Convert.ToChar(System.Convert.ToUInt32(sta[i], 16)).ToString());
            }
            return SL.ToArray();
        }

        private string[] GetAsciiB(string st)
        {
            string[] sta = st.Split(' ');
            List<string> SL = new List<string>();
            for (int i = 0; i < sta.Length - 1; i++)
            {
                SL.Add(System.Convert.ToChar(System.Convert.ToUInt32(sta[i], 2)).ToString());
            }
            return SL.ToArray();
        }

        DataGridViewCellCollection sc;
        string[] ascii;
        string[] hex, bin;
        public BigViewForm(DataGridViewCellCollection isc)
        {
            sc = isc;
            InitializeComponent();
        }
        private void BigViewForm_Load(object sender, EventArgs e)
        {
            dataGrid.ReadOnly = true;
            dataGrid.BackColor = Color.White;
            dataGrid.GridColor = Color.Gray;
            dataGrid.BackgroundColor = Color.White;
            DataGridViewTextBoxColumn clm;
            try
            {
                if (sc.Contains(sc["ASCII"]))
                {
                    ascii = GetAscii(sc["ascii"].Value.ToString().ToCharArray());
                    hex = GetHex(sc["ascii"].Value.ToString());
                    bin = GetBin(sc["ascii"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (sc.Contains(sc["HEX"]))
                    {
                        ascii = GetAsciiH(sc["HEX"].Value.ToString());
                        hex = GetHex(ascii.ToString());
                        bin = GetBin(ascii.ToString());
                    }
                }
                catch (Exception exx) 
                {
                    try
                    {
                        if (sc.Contains(sc["BIN"]))
                        {
                            ascii = GetAsciiB(sc["BIN"].Value.ToString());
                            hex = GetHex(ascii.ToString());
                            bin = GetBin(ascii.ToString());
                        }
                    }
                    catch (Exception exxx) { }
                }
            }

            for(int i=0;i<ascii.Length;i++)
            {
                clm = new DataGridViewTextBoxColumn();
                clm.Name = "cl" + i;
                clm.HeaderText = i.ToString();
                clm.MinimumWidth = 80;
                clm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (i % 2 == 1)
                    clm.DefaultCellStyle.BackColor = Color.LightGray;
                dataGrid.Columns.Add(clm);
            }
            dataGrid.DefaultCellStyle.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            dataGrid.Rows.Add(ascii);
            dataGrid.Rows.Add(hex);
            dataGrid.Rows.Add(bin);
            dataGrid.Rows[0].HeaderCell.Value = "ASCII";
            dataGrid.Rows[1].HeaderCell.Value = "HEX";
            dataGrid.Rows[2].HeaderCell.Value = "BIN";
            dataGrid.RowHeadersVisible = true;
        }
    }
}
