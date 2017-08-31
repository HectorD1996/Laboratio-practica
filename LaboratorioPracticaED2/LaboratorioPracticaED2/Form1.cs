using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace LaboratorioPracticaED2
{
    public partial class Form1 : Form
    {
       
        TagLib.File file = TagLib.File.Create(@"C:\Users\Hector\Music\01 - MOON PRIDE.mp3");
       
        List<Cancion> Canciones = new List<Cancion>();
        List<ListasReproduccion> ListRepro = new List<ListasReproduccion>();
        MusicPlayer player = new MusicPlayer();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = null;
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                string[] canc = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*mp3");
                foreach (String Song in canc)
                {
                    Cancion Musica = new Cancion(TagLib.File.Create(Song), Song);
                    Canciones.Add(Musica);

                }
                ListaMusica.Items.Clear();
                LLenar_Listbox();

                canc = new string[canc.Length];
            }
           
            
        }
        public void LLenar_Listbox()
        {
         
            ListaMusica.Items.Clear();
            foreach (Cancion i in Canciones)
            {

                ListaMusica.Items.Add(i.Titulo);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.stop();
            foreach (Cancion k in Canciones)
            {
                if (ListaMusica.SelectedItem.ToString() == k.Titulo)
                {
                    player.open(k.Archivo.Name);
                }
            }
            player.play();
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            label1.Text = openFileDialog1.FileName;
            player.open(openFileDialog1.FileName);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool encontrada = false;
            
            foreach (Cancion m in Canciones)
            {
                if (m.Titulo.Contains(textBox1.Text))
                {
                    
                    if (!encontrada){ListaMusica.Items.Clear();}
                    encontrada = true;
                    ListaMusica.Items.Add(m.Titulo);
                    btnRegresar.Visible = true;
                    
                }
                                 
                
            }
            if (!encontrada)
            {
                MessageBox.Show("Cancion" + textBox1.Text + "no encontrada revise su entrada en intente otra vez");
            }
            else {
                encontrada = false;
            }
    
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LLenar_Listbox();
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            string name = "";
            if (ListaMusica.SelectedIndex != -1 && ListaListas.SelectedIndex == -1)
            {
                name = ShowMyDialogBox();
                List<Cancion> temp = new List<Cancion>();
                foreach (Cancion k in Canciones)
                {
                    if (ListaMusica.SelectedItem.ToString() == k.Titulo)
                    {
                        temp.Add(k);
                        ListasReproduccion Lista1 = new ListasReproduccion(temp, name);
                        ListRepro.Add(Lista1);
                    }
                }
            }
            else if(ListaMusica.SelectedIndex != -1)
            {

                foreach (ListasReproduccion l in ListRepro)
                {
                    if (ListaListas.SelectedItem.ToString() == l.NombreLista)
                    {
                        foreach (Cancion k in Canciones)
                        {
                            if (ListaMusica.SelectedItem.ToString() == k.Titulo)
                            {
                                l.ListaR.Add(k);
                                
                            }
                        }
                    }
                }
            }

            ListaListas.Items.Clear();
            foreach (ListasReproduccion i in ListRepro)
            {

                ListaListas.Items.Add(i.NombreLista);

            }


        }

        public string ShowMyDialogBox()
        {
            string tlist = "";
            Form2 testDialog = new Form2();
            
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                
                // Read the contents of testDialog's TextBox.
                tlist = testDialog.textBox1.Text;
            }
            else
            {
                tlist = "Cancelled";
            }
            testDialog.Dispose();
            return tlist;
        }

        private void ListaListas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ListaMusica.Items.Clear();
            btnRegresar.Visible = true;
            foreach (ListasReproduccion l in ListRepro)
            {
                if (ListaListas.SelectedItem.ToString() == l.NombreLista)
                {
                    foreach (Cancion k in l.ListaR)
                    {
                        ListaMusica.Items.Add(k.Titulo);
                    }
                }
            }

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            Canciones.Sort();
        }
    }
}
