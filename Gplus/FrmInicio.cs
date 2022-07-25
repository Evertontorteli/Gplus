using Gplus.Controles;
using Gplus.Model;
using System;
using System.Windows.Forms;

namespace Gplus
{
    public partial class FrmInicio : Form
    {
        Banco banco10 = new Banco();
        Cliente cliente1 = new Cliente();
        Banco banco20 = new Banco();
        Cliente cliente2 = new Cliente();


        public FrmInicio()
        {
            InitializeComponent();
        }

        private void btnBanco1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e) =>
            AbrirConfiguracaoDeBanco();

        private void AbrirConfiguracaoDeBanco()
        {
            UserControl controle = new ucConfigurarBanco();
            pnControles.Controls.Add(controle);
            controle.Dock = DockStyle.Fill;
            controle.Width = pnControles.Width;
            controle.Height = pnControles.Height;
            controle.Show();
        }

        private void btnBanco1_Click(object sender, EventArgs e) =>
            AbrirConfiguracaoDeBanco();

        private void btnBanco2_Click(object sender, EventArgs e) =>
            AbrirConfiguracaoDeBanco();

        private void btnBanco3_Click(object sender, EventArgs e) =>
            AbrirConfiguracaoDeBanco();

        private void btnBanco4_Click(object sender, EventArgs e) =>
            AbrirConfiguracaoDeBanco();

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FrmLogin form = new FrmLogin();

            //Fecha a tela de login e abre o de Menu
            this.Hide();
            form.Show();
        }

        private void pnControles_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
