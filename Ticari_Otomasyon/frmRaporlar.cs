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
    public partial class frmRaporlar : Form
    {
        public frmRaporlar()
        {
            InitializeComponent();
        }

        private void frmRaporlar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet8.FIRMAHAREKETLER' table. You can move, or remove it, as needed.
            this.FIRMAHAREKETLERTableAdapter.Fill(this.DboTicariOtomasyonDataSet8.FIRMAHAREKETLER);
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet7.MUSTERIHAREKETLER' table. You can move, or remove it, as needed.
            this.MUSTERIHAREKETLERTableAdapter.Fill(this.DboTicariOtomasyonDataSet7.MUSTERIHAREKETLER);
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet2.TBL_MUSTERILER' table. You can move, or remove it, as needed.
            this.TBL_MUSTERILERTableAdapter.Fill(this.DboTicariOtomasyonDataSet2.TBL_MUSTERILER);

            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet4.TBL_PERSONELLER' table. You can move, or remove it, as needed.
            this.TBL_PERSONELLERTableAdapter.Fill(this.DboTicariOtomasyonDataSet4.TBL_PERSONELLER);
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet3.TBL_GIDERLER' table. You can move, or remove it, as needed.
            this.TBL_GIDERLERTableAdapter.Fill(this.DboTicariOtomasyonDataSet3.TBL_GIDERLER);
            // TODO: This line of code loads data into the 'DboTicariOtomasyonDataSet1.TBL_FIRMALAR' table. You can move, or remove it, as needed.
            this.TBL_FIRMALARTableAdapter.Fill(this.DboTicariOtomasyonDataSet1.TBL_FIRMALAR);

            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer7.RefreshReport();
            this.reportViewer5.RefreshReport();
        }
    }
}
