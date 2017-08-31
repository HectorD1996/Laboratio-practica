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

namespace LaboratorioPracticaED2
{
    public partial class Form1 : Form
    {
       
        TagLib.File file = TagLib.File.Create(@"C:\Users\Hector\Music\01 - MOON PRIDE.mp3");
       
        List<Cancion> Canciones = new List<Cancion>();
        List<String> Backup = new List<string>();
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
            folderBrowserDialog1.ShowDialog();
            string[] canc = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*mp3");
            foreach (String Song in canc)
            {
                Cancion Musica = new Cancion(TagLib.File.Create(Song), Song);
                Canciones.Add(Musica);
                
            }
            ListaMusica.Items.Clear();
            LLenar_Listbox();
           
            
            
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
    }
}
