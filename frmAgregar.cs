using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{

    public partial class frmAgregar : Form
    {
        bool updateMode = false,inicio=false;
        int id;
        Datos datos;
        public frmAgregar()
        {
            InitializeComponent();
           
        }

        public frmAgregar(string nombre, string paterno, string materno,
            string telefono, string correo, int id, string estado, string municipio)
        {
            InitializeComponent();
            txtNombre.Text = nombre;
            txtPaterno.Text = paterno;
            txtMaterno.Text = materno;
            txtTelefono.Text = telefono;
            txtCorreo.Text = correo;
           
            btnAgregar.Text = "Actualiza";
            updateMode = true;
            this.id = id;
            cargaInformacionCombo();
            cmbEstados.Text = estado;
            cmbMunicipios.Text = municipio;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            datos = new Datos();
            if (updateMode == false)
            {
                bool f = 
                    
                    datos.ejecutar("Insert Into Datos(nombre,paterno,materno," +
                "telefono,correo,idEstado,idMunicipio)Values('"
                + txtNombre.Text + "','" + txtPaterno.Text + "','" + txtMaterno.Text
                + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "'," 
                + cmbEstados.SelectedValue 
                + "," +cmbMunicipios.SelectedValue +")");
                if (f)
                {
                    MessageBox.Show("Registro agregado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar el registro");
                }
            }
            else
            {
                SqlCommand comando = new SqlCommand("Update Datos Set nombre=@nombre," +
                    "paterno=@paterno,materno=@materno,telefono=@telefono," +
                    "correo=@correo Where id=@id");
                comando.Parameters.AddWithValue("@nombre", txtNombre.Text);
                comando.Parameters.AddWithValue("@paterno", txtPaterno.Text);
                comando.Parameters.AddWithValue("@materno", txtMaterno.Text);
                comando.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                comando.Parameters.AddWithValue("@correo", txtCorreo.Text);
                comando.Parameters.AddWithValue("@id", id);
                bool f = datos.ejecutar(comando);
                if (f)
                {
                    MessageBox.Show("Registro actualizado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el registro");
                }
            }



        }

        private void cargaInformacionCombo() 
        {
            datos = new Datos();
            DataSet dsEstados;

            dsEstados = datos.Informacion("Select * From Estados");
            if (dsEstados != null && dsEstados.Tables.Count > 0)
            {
                cmbEstados.DataSource = dsEstados.Tables[0];
                cmbEstados.DisplayMember = "Estado";
                cmbEstados.ValueMember = "idEstado";              

            }
            CambiosMunicipio(Convert.ToInt32(cmbEstados.SelectedIndex));
            inicio = true;
        }
      

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(inicio)
            CambiosMunicipio(Convert.ToInt32(cmbEstados.SelectedIndex+1));
          
        }

        private void CambiosMunicipio(int idEstado)
        {
            DataSet dsMunicipios;
            dsMunicipios = datos.Informacion("Select * " +
                    "From Municipios Where idEstado="
                    + idEstado);
            if (dsMunicipios != null && dsMunicipios.Tables.Count > 0)
            {
                cmbMunicipios.DataSource = dsMunicipios.Tables[0];
                cmbMunicipios.DisplayMember = "Municipio";
                cmbMunicipios.ValueMember = "idMunicipio";
            }
        }
    }
}
