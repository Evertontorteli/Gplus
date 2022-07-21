using Gplus.Model;
using System;
using System.Windows.Forms;

namespace Gplus
{
    public partial class Form1 : Form 
    {
        ChildForm formularioConfigBanco;

        Banco banco10 = new Banco();
        Cliente cliente1 = new Cliente();
        Banco banco20 = new Banco();
        Cliente cliente2 = new Cliente();


        public Form1()
        {
            InitializeComponent();
        }

        private void btnBanco1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            {
                ChildForm child = new ChildForm() { TopLevel = false, TopMost = true };

                child.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(child);
                child.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                child.Show();
            }
        }
   
        
        private void btnBanco2_Click(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            {
                ChildForm child = new ChildForm() { TopLevel = false, TopMost = true };

                child.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(child);
                child.Show();
            }
        }

        private void tileItem7_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            ChildForm child = new ChildForm() { TopLevel = false, TopMost = true };

            child.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(child);
            child.Show();
        }

        private void tileItem8_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            {
                ChildForm child = new ChildForm() { TopLevel = false, TopMost = true };

                child.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(child);
                child.Show();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmLogin form = new FrmLogin();

            //Fecha a tela de login e abre o de Menu
            this.Hide();
            form.Show();
        }
    }
}
