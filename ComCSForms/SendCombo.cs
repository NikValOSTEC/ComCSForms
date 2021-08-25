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
    public partial class SendCombo : UserControl
    {
        public SendCombo(Size lys)
        {
            InitializeComponent();
            this.Size= new Size(lys.Width - 50, this.Size.Height);
        }

        private void SCtb_SizeChanged(object sender, EventArgs e)
        {
            this.SCtb.Size = new Size(this.Width-100, SCtb.Size.Height);
            this.SCtb.Location = new Point(0,SCtb.Location.Y);
        }

        private void SendCombo_Load(object sender, EventArgs e)
        {

        }
    }
}
