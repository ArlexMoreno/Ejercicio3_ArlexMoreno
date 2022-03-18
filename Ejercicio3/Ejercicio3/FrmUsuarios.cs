using Datos.Acceso;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        UsuarioDA usuarioDA = new UsuarioDA();
        string operacion = string.Empty;
        Usuario user = new Usuario();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = usuarioDA.ListarUsuarios();
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            ApellidoTextBox.Enabled = true;
            EdadTextBox.Enabled = true;
            EmailTextBox.Enabled = true;
            ClaveTextBox.Enabled = true;
            EstaAtivoCheckBox.Enabled = true;

            NuevoButton.Enabled = false;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
        }

        private void DeshabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ApellidoTextBox.Enabled = false;
            EdadTextBox.Enabled = false;
            EmailTextBox.Enabled = false;
            ClaveTextBox.Enabled = false;
            EstaAtivoCheckBox.Enabled = false; ;

            NuevoButton.Enabled = true;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Clear();
            ApellidoTextBox.Clear();
            EdadTextBox.Clear();
            EmailTextBox.Clear();
            ClaveTextBox.Clear();
            EstaAtivoCheckBox.Enabled = false;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            user.IdUsuario = CodigoTextBox.Text;
            user.Nombre = NombreTextBox.Text;
            user.Apellido = ApellidoTextBox.Text;
            user.Edad = EdadTextBox.Text;
            user.CorreoElectronico = EmailTextBox.Text;
            user.Clave = ClaveTextBox.Text;
            user.EstaActivo = EstaAtivoCheckBox.Checked;

            bool inserto = usuarioDA.InsertarUsuario(user);

            if (operacion == "Nuevo")
            {
                if (inserto)
                {
                    MessageBox.Show("Usuario Creado");
                    ListarUsuarios();
                    LimpiarControles();
                    DeshabilitarControles();

                }
                else
                {
                    MessageBox.Show("Usuario no se pudo Crear");
                }
            }
            else if (operacion == "Modificar")
            {
                bool modifico = usuarioDA.ModificarUsuario(user);
                if (modifico)
                {
                    MessageBox.Show("Usuario Modificado");
                    ListarUsuarios();
                    LimpiarControles();
                    DeshabilitarControles();

                }
                else
                {
                    MessageBox.Show("Usuario no se pudo Modificar");
                }
            }
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            operacion = "Modificar";

            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["IdUsuario"].Value.ToString();
                NombreTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                ApellidoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Apellido"].Value.ToString();
                EdadTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Edad"].Value.ToString();
                EmailTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["CorreoElectronico"].Value.ToString();
                ClaveTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Clave"].Value.ToString();              
                EstaAtivoCheckBox.Checked = Convert.ToBoolean(UsuariosDataGridView.CurrentRow.Cells["EstaActivo"].Value);
                HabilitarControles();
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = usuarioDA.EliminarUsuario(UsuariosDataGridView.CurrentRow.Cells["IdUsuario"].Value.ToString());
                if (elimino)
                {
                    MessageBox.Show("Usuario Eliminado");
                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo Eliminar");
                }
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
        }
    }

}

