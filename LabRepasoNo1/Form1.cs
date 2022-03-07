using System;
using System.Collections.Generic;

using System.IO;

using System.Windows.Forms;

namespace LabRepasoNo1
{
    public partial class Form1 : Form
    {
        List<DatosEmpleado> DE = new List<DatosEmpleado>();
        public Form1()
        {
            InitializeComponent();
            ReadArch(@"Empleados.txt");
            actualizarHoras(@"Enero.txt");
        }
        private void ReadArch(String pathIn)
        {
            FileStream stream = new FileStream(pathIn, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            int counter = 0;
            while (reader.Peek() > -1)
            {
                String lineRead = reader.ReadLine();
                string[] subs = lineRead.Split('|');
                DatosEmpleado auxDatos = new DatosEmpleado(Convert.ToInt32(subs[0]), subs[1], Convert.ToInt32(subs[2]));
                DE.Add(auxDatos);
                comboNoEmpleado.Items.Add(DE[counter].name);
                counter++;
            }
            reader.Close();
        }
        private void actualizarHoras(String pathIn)
        {
            FileStream stream = new FileStream(pathIn, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            int counter = 0;
            while (reader.Peek() > -1)
            {
                String lineRead = reader.ReadLine();
                string[] subs = lineRead.Split('|');
                DE[counter].h_work = Convert.ToInt32(subs[1]);
                DE[counter].mont = (subs[2]);
                counter++;
            }
            reader.Close();
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int index = comboNoEmpleado.SelectedIndex;
            DE[index].totalSueldo = DE[index].sueldo * DE[index].h_work;
            dataGridView1.DataSource = DE[index];
            mostrar();
        }
        void mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = DE;
            dataGridView1.Refresh();
        }
    }
}
