using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Bloc_De_Notas
{
    
    public partial class Form1 : Form
    {
        bool change = true;
        string memo;
        string name;
        string palabra;
        public Form1()
        {
            InitializeComponent();
        }

        private void gUARDARToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            guardar();

        }

        private void aBRIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //si esta en true y no tiene nada solo lo abre

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Archivos de texto|*.txt";
                DialogResult res = dlg.ShowDialog();

                if (res == DialogResult.OK)
                    textBox1.Text = File.ReadAllText(dlg.FileName);
                    name = dlg.FileName;
                    change = false;
                    memo = textBox1.Text;
            

            

        }

        private void gUARDARCOMOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string contenido = textBox1.Text;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Archivos de texto|*.txt";
            DialogResult res = dlg.ShowDialog();


            if (res == DialogResult.OK)
            {
                File.WriteAllText(dlg.FileName, contenido);
                change = false;
            }

            memo = textBox1.Text;
            
        }

        private void guardar()
        {
            string contenido = textBox1.Text;
            //si es true es decir que es nuevo
            if (change == true)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Archivos de texto|*.txt";
                DialogResult res = dlg.ShowDialog();


                if (res == DialogResult.OK)
                    File.WriteAllText(dlg.FileName, contenido);
                name = dlg.FileName;
                change = false;
            }
            //si no solo guarda y sobrescribe
            else
            {
                File.WriteAllText(name, contenido);
                memo = textBox1.Text;
                change = false;
            }


        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //memo comprueba que halla cambos de texto
            if(memo != textBox1.Text)
            {
                change = true;
            }

            //cambios al salir 
            if (change == false)
            {
                this.Close();
            }
            else {
                
                string message = "¿Deseas salir sin guardar?";
                string caption = " No se han guardado cambios ";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
            
            
        }

        // -----------------BUSQUEDA----------//
        private void bUSQUEDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Buscador buscador = new Buscador();
            DialogResult res = buscador.ShowDialog();

            if (res == DialogResult.OK)
            {
                palabra = buscador.word;

                string cad = palabra;
                int resl = cad.Length;
                int res0 = textBox1.Text.IndexOf(palabra);

                if (res0 != -1)
                    textBox1.Select(res0, resl);

                else
                    MessageBox.Show("No se encontro la Palabra buscada", "Error Al Buscar");

            }
        }

        //COPIAR.
        private void cOPIARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        //PEGAR
        private void pEGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }
        //CORTAR
        private void cORTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void nUEVOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult oDlgRes;
            
            string contenido = textBox1.Text;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                oDlgRes = MessageBox.Show("¿Desea guardar el archivo", "BLOCK DE NOTAS",MessageBoxButtons.OKCancel);
                if (oDlgRes ==DialogResult.OK)
                {
                    guardar();
                    change = true;
                    textBox1.Text = "";
                }
                else
                {
                    textBox1.Text = "";
                }

            }


        }

        private void aRCHIVOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
