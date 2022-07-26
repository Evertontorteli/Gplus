using FluentScheduler;
using Gplus.Model;
using Gplus.Tarefas;
using System;
using System.Windows.Forms;

namespace Gplus.Controles
{
    public partial class ucConfigurarBanco : UserControl
    {
        Cliente objCliente;
        BancoModel objBanco;

        public ucConfigurarBanco(BancoModel banco, Cliente cliente)
        {
            InitializeComponent();
            objBanco = new BancoModel();
            objCliente = new Cliente();

            if (banco.InstanciaBanco != null)  
                PreencherCampos(banco, cliente);
        }

        private void PreencherCampos(BancoModel banco, Cliente cliente)
        {
            txtInstancia.Text = banco.InstanciaBanco;
            txtLogin.Text = banco.LoginBanco;
            txtSenha.Text = banco.SenhaBanco;

            txtNomeBanco.Text = banco.NomeBanco;
            txtEmail.Text = cliente.EmailUpload;
            txtEmailSenha.Text = cliente.SenhaUpload;

            if (cliente.ServicoUpload == "Mega")
                radioMega.Checked = true;
            else if(cliente.ServicoUpload == "Google Drive")
                radioGoogleDrive.Checked = true;

            txtLocalSalvar.Text = banco.CaminhoSalvarBackup;
            numTempoBackup.Value = banco.HoraBackup;
        }

        public bool ValidarCamposPreenchidos()
        {

            if (txtInstancia.Text == "" || txtLogin.Text == "" || txtSenha.Text == "" || txtEmail.Text == "" || txtEmailSenha.Text == "" || numTempoBackup.Value == 0 && (radioMega.Checked == false || radioGoogleDrive.Checked == false))
            {
                return false;
            }
            else
            {
                objBanco.InstanciaBanco = txtInstancia.Text;
                objBanco.LoginBanco = txtLogin.Text;
                objBanco.SenhaBanco = txtSenha.Text;
                objBanco.NomeBanco = txtNomeBanco.Text;
                objBanco.HoraBackup = (int)numTempoBackup.Value;

                objCliente.EmailUpload = txtEmail.Text;
                objCliente.SenhaUpload = txtEmailSenha.Text;

                if (radioMega.Checked)
                {
                    objCliente.ServicoUpload = radioMega.Text;
                }
                else
                {
                    objCliente.ServicoUpload = radioGoogleDrive.Text;
                }

                return true;
            }
        }


        private void btnSalvarConfigBanco_Click(object sender, EventArgs e)
        {
            if (ValidarCamposPreenchidos())
            {
                //Job para relaizar backup
                JobManager.Initialize(new AgendadordeTarefas(objBanco, objCliente, objBanco.HoraBackup));

                Parent.Controls.Remove(this);
            }
            else
                MessageBox.Show("Existe campos não preenchidos. Verifique e tente novamente.");
        }
    }
}
