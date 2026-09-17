using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public partial class Form1 : Form
    {
        List<Persona> personas = new List<Persona>();
        
        public Form1()
        {
            InitializeComponent();
            personas.Add(new Persona(1,"Luis Mota","8717279614"));
            personas.Add(new Persona(2, "Andres Esparza", "8717051313"));
            personas.Add(new Persona(3, "Juan Perez", "8716754135"));
            personas.Add(new Persona(4, "Citlalli Gonzalez", "8714321567"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var Persona in personas)
            {
                dgvInformacion.Rows.Add();
                dgvInformacion[0, dgvInformacion.Rows.Count - 1].Value = Persona.Id;
                dgvInformacion[1, dgvInformacion.Rows.Count - 1].Value = Persona.nombre;
                dgvInformacion[2, dgvInformacion.Rows.Count - 1].Value = Persona.telefono;

            }

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvInformacion.Rows.Add();
            dgvInformacion[0, dgvInformacion.Rows.Count - 1].Value = dgvInformacion.Rows.Count;
            dgvInformacion[1, dgvInformacion.Rows.Count-1].Value = txtNombre.Text;
            dgvInformacion[2, dgvInformacion.Rows.Count-1].Value = mtbTelefono.Text;
        }

        
    }
}
