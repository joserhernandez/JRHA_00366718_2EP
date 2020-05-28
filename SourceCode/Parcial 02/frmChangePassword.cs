using System;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            // Actualizar ComboBox
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "password";
            comboBox1.DisplayMember = "userName";
            comboBox1.DataSource = UsuarioDAO.getlista();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            bool actualIgual = comboBox1.SelectedValue.Equals(textBox2.Text);
            bool nuevaIgual = textBox3.Text.Equals(textBox4.Text);
            bool nuevaValida = textBox4.Text.Length > 0;

            if (actualIgual && nuevaIgual && nuevaValida)
            {
                try
                {

                    UsuarioDAO.actualizarPassword(comboBox1.Text, textBox3.Text);
                    
                    MessageBox.Show("¡Contraseña actualizada exitosamente!", 
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Contraseña no actualizada! Favor intente mas tarde.",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("¡¡Favor verifique que los datos sean correctos!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}