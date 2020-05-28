using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Parcial_02
{
    public partial class frmPrincipal : Form
    {
        private Usuario usuario;
        public frmPrincipal(Usuario pUsuario)
        {
            InitializeComponent();
            usuario = pUsuario;
        }
     
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text =
                "Bienvenido " + usuario.userName + " [" + (usuario.admin ? "Administrador" : "Usuario") + "]";

            if (usuario.admin)
            {
                tabControl1.TabPages[4].Parent = null;
                tabControl1.TabPages[4].Parent = null;
                tabControl1.TabPages[4].Parent = null;
                
                actualizarControlesAdm();
             
            }
            else
            {
                tabControl1.TabPages[0].Parent = null;
                tabControl1.TabPages[0].Parent = null;
                tabControl1.TabPages[0].Parent = null;
                tabControl1.TabPages[0].Parent = null;
                actualizarControlesUsu();
            }
            
        }
        private void actualizarControlesAdm()
        {
            // Realizar consulta a la base de datos
            List<Usuario> listaUsuarios = UsuarioDAO.getlista();
            List<Negocio> listaNegocios = NegocioDAO.getlista();
            List<Ordenes> listaOrdenes = OrdenesDAO.getlista();
            
            // Tabla Usuarios(data grid view)
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = listaUsuarios;
            // Menu desplegable Usuarios (combo box)
            cmbUsuario.DataSource = null;
            cmbUsuario.ValueMember = "idUser";
            cmbUsuario.DisplayMember = "userName";
            cmbUsuario.DataSource = listaUsuarios;
            
            // Menu desplegable Negocios (combo box)
            cmbNegocios.DataSource = null;
            cmbNegocios.ValueMember = "idBusiness";
            cmbNegocios.DisplayMember = "name";
            cmbNegocios.DataSource = listaNegocios;
            
            cmbNegocios2.DataSource = null;
            cmbNegocios2.ValueMember = "idBusiness";
            cmbNegocios2.DisplayMember = "name";
            cmbNegocios2.DataSource = listaNegocios;
            
            cmbNegocios3.DataSource = null;
            cmbNegocios3.ValueMember = "idBusiness";
            cmbNegocios3.DisplayMember = "name";
            cmbNegocios3.DataSource = listaNegocios;
            
            // Menu desplegable Productos (combo box)
            int id = Convert.ToInt32(cmbNegocios3.SelectedValue.ToString());
            List<Producto> listaProductos = ProductoDAO.getlista(id);
            cmbProductos.DataSource = null;
            cmbProductos.ValueMember = "idProduct";
            cmbProductos.DisplayMember = "name";
            cmbProductos.DataSource = listaProductos;            

            // Tabla Ordenes(data grid view)
            dgvOrdenes.DataSource = null;
            dgvOrdenes.DataSource = listaOrdenes;
        }

        private void actualizarControlesUsu()
        {
            // Realizar consulta a la base de datos
            List<Negocio> listaNegocios = NegocioDAO.getlista();
            List<Ordenes> listaOrdenes = OrdenesDAO.ordenesDelUsuario(usuario.idUser);
            List<Direccion> listaDirecciones = DireccionDAO.getlista(usuario.idUser);
            
            // Menu desplegable Negocios (combo box)
            cmbNegocio4.DataSource = null;
            cmbNegocio4.ValueMember = "idBusiness";
            cmbNegocio4.DisplayMember = "name";
            cmbNegocio4.DataSource = listaNegocios;
            
            // Menu desplegable Productos (combo box)
            int id = Convert.ToInt32(cmbNegocio4.SelectedValue.ToString());
            List<Producto> listaProductos = ProductoDAO.getlista(id);
            cmbProductos2.DataSource = null;
            cmbProductos2.ValueMember = "idProduct";
            cmbProductos2.DisplayMember = "name";
            cmbProductos2.DataSource = listaProductos;
            
            // Menu desplegable Direccion (combo box)
            cmbDireccion.DataSource = null;
            cmbDireccion.ValueMember = "idAddress";
            cmbDireccion.DisplayMember = "address";
            cmbDireccion.DataSource = listaDirecciones;
            
            cmbDireccion2.DataSource = null;
            cmbDireccion2.ValueMember = "idAddress";
            cmbDireccion2.DisplayMember = "address";
            cmbDireccion2.DataSource = listaDirecciones;
            
            cmbDireccion3.DataSource = null;
            cmbDireccion3.ValueMember = "idAddress";
            cmbDireccion3.DisplayMember = "address";
            cmbDireccion3.DataSource = listaDirecciones;
            
            // Menu desplegable Ordenes (combo box)
            cmbOrden.DataSource = null;
            cmbOrden.ValueMember = "idOrder";
            cmbOrden.DisplayMember = "idOrder";
            cmbOrden.DataSource = listaOrdenes;
            
            // Tabla Ordenes(data grid view)
            dgvOrdenes2.DataSource = null;
            dgvOrdenes2.DataSource = listaOrdenes;
            
            // Tabla Direcciones(data grid view)
            dgvDirecciones.DataSource = null;
            dgvDirecciones.DataSource = listaDirecciones;
        }
        
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir, " + usuario.userName + "?",
                "Hugo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    e.Cancel = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha sucedido un error, favor intente dentro de un minuto.",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNuevoUsuario.Text.Length >= 5)
                {
                    UsuarioDAO.crearNuevo(txtNombre.Text,txtNuevoUsuario.Text);

                    MessageBox.Show("¡Usuario agregado exitosamente!",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNuevoUsuario.Clear();
                    actualizarControlesAdm();
                }
                else
                    MessageBox.Show("Favor digite un usuario (longitud minima, 5 caracteres)",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario que ha digitado, no se encuentra disponible.",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //btnEliminarUsuario_Click
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar al usuario " + cmbUsuario.Text + "?",
                "Hugo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UsuarioDAO.eliminar(Convert.ToInt32(cmbUsuario.SelectedValue));

                MessageBox.Show("¡Usuario eliminado exitosamente!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                actualizarControlesAdm();
            }
        }

        private void btnAñadirNegocio_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNuevoNegocio.Text.Equals("") ||
                    txtDescripcion.Text.Equals(""))
                {
                    MessageBox.Show("No se pueden dejar campos vacios",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                             
                }
                else
                {
                    NegocioDAO.crearNuevo(txtNuevoNegocio.Text, txtDescripcion.Text);

                    MessageBox.Show("¡Negocio agregado exitosamente!",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNuevoNegocio.Clear();
                    txtDescripcion.Clear();
                    
                    actualizarControlesAdm();
                }
                    
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar el negocio.",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarNegocio_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el negocio " + cmbNegocios.Text + "?",
                "Hugo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(cmbNegocios.SelectedValue.ToString());
                NegocioDAO.eliminar(id);

                MessageBox.Show("¡Negocio eliminado exitosamente!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                actualizarControlesAdm();
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNegocios2.Text.Equals("") ||
                    txtProducto.Text.Equals(""))
                {
                    MessageBox.Show("No se pueden dejar campos vacios",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                             
                }
                else
                {
                    ProductoDAO.crearNuevo(Convert.ToInt32(cmbNegocios2.SelectedValue.ToString()), 
                                                txtProducto.Text);

                    MessageBox.Show("¡Producto agregado exitosamente!",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtProducto.Clear();
                    
                    actualizarControlesAdm();
                }
                    
            }
            catch (Exception)
            {
                MessageBox.Show("El producto no se encuentra disponible.",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el producto " + cmbProductos.Text + "?",
                "Hugo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(cmbProductos.SelectedValue.ToString());
                ProductoDAO.eliminar(id);

                MessageBox.Show("¡Producto eliminado exitosamente!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                txtProducto.Clear();

                actualizarControlesAdm();
            }
        }

        private void btnRealizarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNegocio4.Text.Equals("") ||
                    cmbProductos2.Text.Equals("") ||
                    cmbDireccion.Text.Equals(""))
                {
                    MessageBox.Show("No se pueden dejar campos vacios",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                             
                }
                else
                {
                    int idP = Convert.ToInt32(cmbProductos2.SelectedValue.ToString());
                    int idA = Convert.ToInt32(cmbDireccion.SelectedValue.ToString());
                    OrdenesDAO.crearOrden(DateTime.Now.Date, idP, idA);

                    MessageBox.Show("¡Orden realizada exitosamente!",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    actualizarControlesUsu();
                }
                    
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al realizar la orden.",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDireccion.Text.Equals(""))
                {
                    MessageBox.Show("No se pueden dejar campos vacios",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DireccionDAO.crearNuevo(usuario.idUser, txtDireccion.Text);

                    MessageBox.Show("¡Dirección agregada exitosamente!",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    txtDireccion.Clear();
                    
                    actualizarControlesUsu();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al agragar la direccion.",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarDireccion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar la dirección " + cmbDireccion2.Text + "?",
                "Hugo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(cmbDireccion2.SelectedValue.ToString());
                DireccionDAO.eliminar(id);

                MessageBox.Show("¡Direccion eliminado exitosamente!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                actualizarControlesUsu();
            }
        }

        private void btnModificarDireccion_Click(object sender, EventArgs e)
        {
            if (cmbDireccion3.Text.Equals("") ||
                txtNuevaDireccion.Text.Equals(""))
            {
                MessageBox.Show("¡¡No se pueden dejar campos vacíos!",
                                 "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
            else
            {
                try
                {
                    DireccionDAO.modificar(Convert.ToInt32(cmbDireccion3.SelectedValue.ToString()), 
                                            txtNuevaDireccion.Text);
                                                 
                    MessageBox.Show("¡Dirección modificada exitosamente!", 
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                     actualizarControlesUsu();                            
                   
                }
                catch (Exception) 
                { 
                    MessageBox.Show("¡Direccion no pudo ser actualizada! Favor intente mas tarde.", 
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void btnEliminarOrden_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar la orden #" + cmbOrden.Text + "?",
                "Hugo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(cmbOrden.SelectedValue.ToString());
                OrdenesDAO.eliminar(id);

                MessageBox.Show("¡Orden eliminada exitosamente!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                actualizarControlesUsu();
            }
        }

        private void cmbNegocios3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbNegocios3.SelectedValue.ToString());
            List<Producto> listaProductos = ProductoDAO.getlista(id);
            cmbProductos.DataSource = null;
            cmbProductos.ValueMember = "idProduct";
            cmbProductos.DisplayMember = "name";
            cmbProductos.DataSource = listaProductos;
        }

        private void cmbNegocio4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbNegocio4.SelectedValue.ToString());
            List<Producto> listaProductos = ProductoDAO.getlista(id);
            cmbProductos2.DataSource = null;
            cmbProductos2.ValueMember = "idProduct";
            cmbProductos2.DisplayMember = "name";
            cmbProductos2.DataSource = listaProductos;
        }

    }
}