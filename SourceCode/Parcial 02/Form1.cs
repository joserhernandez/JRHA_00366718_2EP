using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        { 
            poblarControles();
        }
        private void poblarControles()
        {
            // Actualizar ComboBox
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "password";
            comboBox1.DisplayMember = "userName";
            comboBox1.DataSource = UsuarioDAO.getlista();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.Equals(textBox2.Text))
            {
                Usuario u = (Usuario) comboBox1.SelectedItem;
                                    
                MessageBox.Show("¡Bienvenido!", 
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                frmPrincipal ventana = new frmPrincipal(u);
                ventana.Show();
                this.Hide();
            }
            else
                MessageBox.Show("¡Contraseña incorrecta!", "Hugo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword unaVentana = new frmChangePassword();
            unaVentana.ShowDialog();
        }

        
    }
}