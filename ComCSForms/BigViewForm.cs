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
        DataGridViewCellCollection sc;
        string[] ascii;
        string[] hex, bin;
        public BigViewForm(DataGridViewCellCollection isc)
        {
            sc = isc;
            InitializeComponent();
        }

        private void menuItemCopy_Click(object sender, System.EventArgs e)
        {
            DataGridView dg=((sender as MenuItem).Parent as ContextMenu).SourceControl as DataGridView;
            string cb="";
            dg.Rows[dg.SelectedCells[0].RowIndex].Selected = true;
            if(dg.SelectedRows[0].HeaderCell.Value.ToString() =="ASCII")
            {
                for(int i=0;i<dg.SelectedRows[0].Cells.Count;i++)
                {
                    cb += dg.SelectedRows[0].Cells[i].Value.ToString();
                }
            }
            else
            {
                for (int i = 0; i < dg.SelectedRows[0].Cells.Count; i++)
                {
                    cb += dg.SelectedRows[0].Cells[i].Value.ToString()+" ";
                }
                cb = cb.Substring(0, cb.Length);
            }
            Clipboard.SetText(cb);
        }

        private void menuItemPaint_Click(object sender, System.EventArgs e)
        {
            DataGridView dg = ((sender as MenuItem).Parent as ContextMenu).SourceControl as DataGridView;
            if(dg.SelectedCells[0].Style.BackColor==Color.Yellow)
            {
                dg.SelectedCells[0].Style.BackColor = dg.Columns[dg.SelectedCells[0].ColumnIndex].DefaultCellStyle.BackColor;
            }
            else
                dg.SelectedCells[0].Style.BackColor = Color.Yellow;
        }

        private void dataGrid_MouseClick(object sender, MouseEventArgs e)
        {
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

        private void BigViewForm_Load(object sender, EventArgs e)
        {
            dataGrid.ReadOnly = true;
            dataGrid.BackColor = Color.White;
            dataGrid.GridColor = Color.Gray;
            dataGrid.BackgroundColor = Color.White;
            DataGridViewTextBoxColumn clm;
            try
            {
                bin = sc["BIN"].Value.ToString().Split(' ');
                hex = sc["HEX"].Value.ToString().Split(' ');
                ascii = sc["ASCII"].Value.ToString().ToCharArray().Select(c=>c.ToString()).ToArray();
            }
            catch (Exception exxx)
            {

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
