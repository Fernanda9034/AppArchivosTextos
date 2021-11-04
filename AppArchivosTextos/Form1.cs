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
                OpenFileDialog dialogo = new OpenFileDialog();
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Archivos txt|*.txt";
                openFileDialog1.FileName = "Seleccione un archivo de Texto";
                openFileDialog1.Title = "Programa de Lectura";
                openFileDialog1.InitialDirectory = "C:\\";
                openFileDialog1.FileName = this.Text;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                  this.Text = openFileDialog1.FileName;
                }
                    try
                    {
                        var filePath = openFileDialog1.FileName;
                        using (Stream str = openFileDialog1.OpenFile())
                        { 
                            this("notepad.exe", filePath);
                        }
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }

                    //this.textBox1.Text = OpenFileDialog.FileName;
                    //archivo = StreamReader("documento.txt", "w+");
                    //MessageBox.Show(dialogo.FileName);
                    //using (StreamReader archivo = new StreamReader(dialogo.FileName));
                
            }
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "Archivos txt|*.txt";
            //openFileDialog1.FileName = "Seleccione un archivo de Texto";
            //openFileDialog1.Title = "Programa de Lectura";
            //openFileDialog1.InitialDirectory = "C:\\";
            //openFileDialog1.FileName = this.Text;
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //  this.Text = openFileDialog1.FileName;
            //}
            //Text = "";

            //StreamReader sr = new System.IO.StreamReader("", Encoding.Default);//@textBox1.Text, System.Text.Encoding.Default);
            //string texto;
            //texto = sr.ReadToEnd();
            //sr.Close();
            //Text = texto;
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
