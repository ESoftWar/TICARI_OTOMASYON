using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class frmHareketler : Form
    {
        public frmHareketler()
        {
            InitializeComponent();
        }
        ConSQL cnSql = new ConSQL();
        ListSQL lstSql = new ListSQL();

        void lst()
        {
            gridControl1.DataSource = lstSql.lstMusteriHareketler();
            gridControl2.DataSource = lstSql.lstFirmaHareketler();
        }

        private void frmHareketler_Load(object sender, EventArgs e)
        {
            lst();
        }
    }
}
