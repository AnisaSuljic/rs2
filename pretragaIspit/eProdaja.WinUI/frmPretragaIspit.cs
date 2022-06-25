using eProdaja.Services.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI
{
    public partial class frmPretragaIspit : Form
    {
        APIService _vrsteProizvodaService = new APIService("VrsteProizvodum");
        APIService _korisniciService = new APIService("filterPretraga");
        APIService _izlazService = new APIService("Izlazi");
        public frmPretragaIspit()
        {
            InitializeComponent();
            dgvPretraga.AutoGenerateColumns = false;
        }


        private async void frmPretragaIspit_Load(object sender, EventArgs e)
        {            
            var listaVrstaProizvoda = await _vrsteProizvodaService.Get<List<Model.VrsteProizvodum>>();

            cbVrstaProizvoda.DataSource = listaVrstaProizvoda; 
            cbVrstaProizvoda.DisplayMember = "Naziv"; 
            cbVrstaProizvoda.ValueMember = "VrstaId";
        }
        
        private void txtMinIznos_KeyPress(object sender, KeyPressEventArgs e)
        {
            var x = char.IsControl(e.KeyChar);
            var y = char.IsDigit(e.KeyChar);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            try
            {
                bool correct = true;
                decimal suma = 0;
                if (cbVrstaProizvoda.SelectedIndex == -1)
                {
                    MessageBox.Show("Odaberite vrstu proizvoda.");
                    correct = false;
                }
                if (dtpOD.Value > dtpDO.Value)
                {
                    MessageBox.Show("Početni datum mora biti prije krajnjeg.");
                    correct = false;
                }
                if (txtMinIznos.Text == "")
                {
                    MessageBox.Show("Unesite minimalan iznos.");
                    correct = false;
                }
                if (correct == true)
                {
                    Model.SearchObjects.PretragaIspitSearchObject searchObj = new Model.SearchObjects.PretragaIspitSearchObject()
                    {
                        VrstaProizvodaId = (int)cbVrstaProizvoda.SelectedValue,
                        minIznosPrometa = double.Parse(txtMinIznos.Text),
                        periodOD = dtpOD.Value,
                        periodDO = dtpDO.Value
                    };
                    if(searchObj != null)
                    {
                        var listaPretrage = await _korisniciService.Get<List<Model.Korisnici>>(searchObj);
                      
                        suma = listaPretrage.Sum(x => x.Promet);
                        if (listaPretrage != null)
                        {
                            dgvPretraga.DataSource = listaPretrage.ToList();
                            lblSuma.Text = suma.ToString();
                        }
                        else
                            MessageBox.Show("Pretraga neuspješna.");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw;
            }
        }
        private void cbVrstaProizvoda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
