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
        ListasReproduccion Actual = new ListasReproduccion();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //abre Browser para buscar carpeta en de la cual se tomara la seleccion incial de canciones
            folderBrowserDialog1.SelectedPath = null;
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                string[] canc = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*mp3");// se filtran todos los archivos y se tomas son los de MP3
                foreach (String Song in canc)
                {
                    //usando la libreria TagLib se crea un archvio de este tipo para poder acceder la nformacion como titulo Duracion ect
                    Cancion Musica = new Cancion(TagLib.File.Create(Song), Song);//se crea un objeto de tipo musica para agregar a la lista
                    Canciones.Add(Musica);

                }
                ListaMusica.Items.Clear();
                LLenar_Listbox();//Llamada al metodo que llena la lisbox donde se muestran los canciones actuales

                canc = new string[canc.Length];
            }
           
            
        }
        public void LLenar_Listbox()
        {
         //se recorre la lista de canciones y se llena la lisbox para poder mostrarlas
            ListaMusica.Items.Clear();
            foreach (Cancion i in Canciones)
            {

                ListaMusica.Items.Add(i.Titulo);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.stop();// se detiene la cancion que sonaba anteriormente 

            //se compara la cacnion seleccionada en la lisbox con la lista alamcenada y un vez se encuentra
            //se toma su direccion de archivo para abrirlo con el metodo de MusicPlayer
            foreach (Cancion k in Canciones)
            {
                if (ListaMusica.SelectedItem.ToString() == k.Titulo)
                {
                    player.open(k.Archivo.Name);//se le da la dirrecion para poder reproducir el archvio
                    lbInformacion.Visible = true;
                    lbDuracion.Visible = true;
                    lbInformacion.Text = k.Titulo;
                    lbDuracion.Text = k.Archivo.Properties.Duration.ToString();// se muestra la informacion de la cancion actual
                }
            }
            player.play();
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
            
        }

        private void button3_Click(object sender, EventArgs e)// se detiene la cancion actual y se deja de mostrar su informacion
        {
            player.stop();
            lbInformacion.Visible = false;
            lbDuracion.Visible = false;
            lbInformacion.Text = "";
            lbDuracion.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)// boton de busqueda
        {
            //variable para confirmar que se ha encontrado una cacnion
            bool encontrada = false;

            // se compara la busqueda con los titulos guardados en la lista de cada cancion 
            //es case-sensitive pero busca nombres que contiene la busqueda 
            foreach (Cancion m in Canciones)
            {
                if (m.Titulo.Contains(textBox1.Text))
                {
                    
                    if (!encontrada){ListaMusica.Items.Clear();}
                    encontrada = true;
                    ListaMusica.Items.Add(m.Titulo);
                    btnRegresar.Visible = true;
                    //una vez encontrados se muestrn lo resultados en la listbox
                }
                                 
                
            }
            if (!encontrada)// mensaje si la no se ecnontro ninguna concidencia
            {
                MessageBox.Show("Cancion " + textBox1.Text + " no encontrada revise su entrada en intente otra vez");
            }
            else {
                encontrada = false;
            }
    
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            
        }

        //se regresa a la lista original de canciones llamando al metod Llenar_Listbox() y se oculta el boton
        private void button5_Click(object sender, EventArgs e)
        {
            LLenar_Listbox();
            btnRegresar.Visible = false;
            ListaListas.SelectedIndex = -1;
            btnOrdenar.Visible = false;
            cmbOpciones.Visible = false;
        }

        //agregar una cancion a la lista 
        private void btnLista_Click(object sender, EventArgs e)
        {
            string name = "";
            //si no hay una lista selecinada se pdie un nombre para crear una lñista nueva y se agrega la cancion seleccionada
            if (ListaMusica.SelectedIndex != -1 && ListaListas.SelectedIndex == -1)
            {
                name = ShowMyDialogBox();
                if (name != "Cancelled")
                {
                    List<Cancion> temp = new List<Cancion>();
                    foreach (Cancion k in Canciones)
                    {
                        if (ListaMusica.SelectedItem.ToString() == k.Titulo)
                        {
                            // se usa un clase ListaRepruduccion para almacenar la Lista de caciones asi como el Nombre la lista
                            temp.Add(k);
                            ListasReproduccion Lista1 = new ListasReproduccion(temp, name);
                            ListRepro.Add(Lista1);//Esta clase Lista se gurda en otra lista 
                        }
                    }
                }
                
            }
            else if(ListaMusica.SelectedIndex != -1)// en caso de tener una Lista Selecionada se agrega diretamente a esta la cancion seleccionada
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
            // se muestrs la lista de reproduccin en su prpia lisbox
            ListaListas.Items.Clear();
            foreach (ListasReproduccion i in ListRepro)
            {

                ListaListas.Items.Add(i.NombreLista);

            }


        }

        //Form creado para pedir el ingreso de informacion para el nombre de la lista de reproduccion
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
                tlist = "Cancelled";//de cerrarse el cudro de ingreso se envia un resultado para cancelar la operacion
            }
            testDialog.Dispose();
            return tlist;
        }

        private void ListaListas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //se toma la lista seleccionada se busca en la lista de Lista y se toma su lista de cacnciones para mostrarla
        private void button5_Click_1(object sender, EventArgs e)
        {
            btnOrdenar.Visible = true;
            cmbOpciones.Visible = true;
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
                    Actual = l;
                }
            }

        }


        //para ordenar se verifica la opcion seleccionada y se envia a el metodo de ordenamiento de la 
        //clase ListaReproduccion 
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            
            if (cmbOpciones.Text != "")
            {
                Actual.Ordenar(cmbOpciones.Text);
                ListaMusica.Items.Clear();
                foreach (Cancion k in Actual.ListaR)
                {
                    ListaMusica.Items.Add(k.Titulo);
                }
            }
            
        }
    }
}
