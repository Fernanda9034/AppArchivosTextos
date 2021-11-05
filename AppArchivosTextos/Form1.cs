using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Security;
using System.Drawing;

namespace AppArchivosTextos
{
    public partial class Form1 : Form
    {
        Libro[] l;
        int p = 0;
        public Form1()
        {
            InitializeComponent();
            l = new Libro[3];
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            {
                
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
               
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string filePath = openFileDialog1.FileName;
                p = 0;

                // Read the file and display it line by line.  
                foreach (string line in System.IO.File.ReadLines(filePath))
                {
                    string[] datos;
                    datos = line.Split('-');
                    Libro n = new Libro();
                    n.Nombre = datos[0];
                    n.Precio = double.Parse(datos[1]);
                    //guardar el libro en la posicion
                    l[p] = n;
                    lstArreglo.Items.Add(l[p]);
                    p++;
                  
                }  
            }
            
        }
        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogo = new SaveFileDialog();
            if (dialogo.ShowDialog() == DialogResult.OK) 
            {
                using (StreamWriter archivo = new StreamWriter(dialogo.FileName ))
                for (int i = 0; i < l.Length; i++)
                {
                   if(l[i] != null)
                        {
                            archivo.WriteLineAsync(l[i].ToString());
                        }
                }
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Libro n = new Libro();
            n.Nombre = txtNombre.Text;
            n.Precio =double.Parse(txtPrecio.Text);
            //guardar el libro en la posicion
            l[p] = n;
            //para verlo en la lista 
            lstArreglo.Items.Add(l[p]);
            p++;
        }
    }
}
