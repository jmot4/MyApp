using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public partial class fmrInformacion : Form
    {
        Datos datos;
        public fmrInformacion()
        {
            InitializeComponent();
        }

        private void ActualizarGrid()
        {
            datos = new Datos();
            DataSet ds = datos.Informacion("Select id,nombre,paterno,materno,telefono,correo,Estado,Municipio from Datos Inner Join Estados On Datos.idEstado = Estados.idEstado Inner Join Municipios On Datos.idMunicipio=Municipios.idMunicipio");

            if (ds != null)
            {               
                dgvInformacion.AutoGenerateColumns = false;

                dgvInformacion.Columns[0].DataPropertyName = "id";
                dgvInformacion.Columns[1].DataPropertyName = "nombre";
                dgvInformacion.Columns[2].DataPropertyName = "paterno";
                dgvInformacion.Columns[3].DataPropertyName = "materno";
                dgvInformacion.Columns[4].DataPropertyName = "telefono";
                dgvInformacion.Columns[5].DataPropertyName = "correo";
                dgvInformacion.Columns[6].DataPropertyName = "Estado";
                dgvInformacion.Columns[7].DataPropertyName = "Municipio";


                dgvInformacion.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("No se pudo obtener la información de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void fmrInformacion_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.Show();
        }

        private void fmrInformacion_Activated(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void dgvInformacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAgregar actualizar = new frmAgregar(dgvInformacion.Rows[e.RowIndex].Cells[1].Value.ToString(),
                dgvInformacion.Rows[e.RowIndex].Cells[2].Value.ToString(),
                dgvInformacion.Rows[e.RowIndex].Cells[3].Value.ToString(),
                dgvInformacion.Rows[e.RowIndex].Cells[4].Value.ToString(),
                dgvInformacion.Rows[e.RowIndex].Cells[5].Value.ToString(),
                Convert.ToInt32(dgvInformacion.Rows[e.RowIndex].Cells[0].Value),
                dgvInformacion.Rows[e.RowIndex].Cells[6].Value.ToString(),
                dgvInformacion.Rows[e.RowIndex].Cells[7].Value.ToString());
            actualizar.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
