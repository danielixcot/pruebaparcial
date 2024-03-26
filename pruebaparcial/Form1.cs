using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaparcial
{
    public partial class Form1 : Form
    {
        List<Temperatura> temperaturas = new List<Temperatura>();
        List<Departamentos> departamentos = new List<Departamentos>();
        List<Reporte> reportes = new List<Reporte>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Temperatura temperatura = new Temperatura();
            temperatura.Codigo = Convert.ToInt32(comboBox1.SelectedValue);
            temperatura.Temp = Convert.ToInt32(textBox1.Text);
            temperatura.FechaLectura = DateTime.Now;

            temperaturas.Add(temperatura);

            Guardar();
        }
        private void Guardar()
        {
            FileStream stream = new FileStream("Temperaturas.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var temperatura in temperaturas)
            {
                writer.WriteLine(temperatura.Codigo);
                writer.WriteLine(temperatura.Temp);
                writer.WriteLine(temperatura.FechaLectura);
            }

            writer.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "Departamentos.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Departamentos departamento = new Departamentos();
                departamento.Codigo = Convert.ToInt16(reader.ReadLine());
                departamento.Nombre = reader.ReadLine();

                departamentos.Add(departamento);
            }

            reader.Close();

            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Codigo";
            comboBox1.DataSource = departamentos;
            comboBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reportes.Clear();
            foreach (var departamento in departamentos)
            {
                foreach (var temperatura in temperaturas)
                {
                    if (departamento.Codigo == temperatura.Codigo)
                    {
                        Reporte reporte = new Reporte();
                        reporte.Nombre = departamento.Nombre;
                        reporte.Temp = temperatura.Temp;
                        reporte.Fecha = temperatura.FechaLectura;

                        reportes.Add(reporte);
                    }
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Reporte> ordentemp = reportes.OrderBy(c => c.Temp).ToList();
            dataGridView1.DataSource = ordentemp;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double sumaTemperaturas = 0;
            foreach (var temperatura in temperaturas)
            {
                sumaTemperaturas += temperatura.Temp;
            }

            double promedioTemperaturas = sumaTemperaturas / temperaturas.Count;
            label3.Text = $"el promedio de temperatura en todo el pais es de {promedioTemperaturas}";
        }
    }
}
