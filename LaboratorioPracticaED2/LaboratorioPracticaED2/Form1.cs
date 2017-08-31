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
        Dictionary<TagLib.File, String> ListaCanciones = new Dictionary<TagLib.File, string>();
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
            openFileDialog1.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            folderBrowserDialog1.ShowDialog();
           string[] canciones =  Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*mp3");

            string k=    file.Properties.Duration.ToString();
    
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            
        }
    }
}
