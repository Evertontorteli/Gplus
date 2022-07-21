﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gplus
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {

            InitializeComponent();
            pnlLogin.Visible = false;

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 250);
            pnlLogin.Visible = true;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 114, 160);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 72, 103);

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ChamarLogin();




        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChamarLogin();

            }
        }


        private void ChamarLogin()
        {
            if (txtUsuario.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o Usuário", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return;
            }

            if (txtSenha.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha a Senha", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            //AQUI VAI O CÓDIGO PARA O LOGIN

           FrmInicio form = new FrmInicio();

            //Fecha a tela de login e abre o de Menu
            this.Hide();
            Limpar();
            form.Show();


        }


        private void Limpar()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtUsuario.Focus();
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 270);
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 270);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
