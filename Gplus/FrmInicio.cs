using Gplus.Controler;
using Gplus.Controles;
using Gplus.Model;
using Gplus.View;
using System;
using System.Windows.Forms;

namespace Gplus
{
    public partial class FrmInicio : Form
    {
        BancoModel banco10 = new BancoModel();
        Cliente cliente1 = new Cliente();
        BancoModel banco20 = new BancoModel();
        Cliente cliente2 = new Cliente();


        public FrmInicio()
        {
            InitializeComponent();

            AbrirTelaInicial();
        }

        private void AbrirTelaInicial()
        {
            var controle = new ucTelaInicial();
            controle.Width = pnControles.Width;
            controle.Height = pnControles.Height;
            pnControles.Controls.Add(controle);
        }

        private void btnBanco1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var banco = new ConfiguracaoBancoBackupController().ObterConfiguracaoBackup1();
            var cliente = new Cliente();
            AbrirConfiguracaoDeBanco(banco, cliente);
        }

        private void AbrirConfiguracaoDeBanco(BancoModel banco, Cliente cliente)
        {
            UserControl controle = new ucConfigurarBanco(banco, cliente);
            pnControles.Controls.Add(controle);
            controle.Dock = DockStyle.Fill;
            controle.Width = pnControles.Width;
            controle.Height = pnControles.Height;
            controle.Show();
            controle.BringToFront();
        }

        private void btnBanco1_Click(object sender, EventArgs e) =>
            AbrirConfiguracaoDeBanco(new BancoModel(), new Cliente());

        private void btnBanco2_Click(object sender, EventArgs e) =>
            AbrirConfiguracaoDeBanco(new BancoModel(), new Cliente());

        private void btnBanco3_Click(object sender, EventArgs e) =>
            AbrirConfiguracaoDeBanco(new BancoModel(), new Cliente());

        private void btnBanco4_Click(object sender, EventArgs e) =>
            AbrirConfiguracaoDeBanco(new BancoModel(), new Cliente());

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FrmLogin form = new FrmLogin();

            Hide();
            form.Show();
        }

        private void btnTelaInicial_Click(object sender, EventArgs e)
        {
            RemoverControles();
            AbrirTelaInicial();
        }

        private void RemoverControles()
        {
            pnControles.Controls.Clear();
            btnBanco1.Checked = false;
            btnBanco2.Checked = false;
            btnBanco3.Checked = false;
            btnBanco4.Checked = false;
        }
    }
}
