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

namespace AppendExclamation
{
    public partial class Form1 : Form
    {
        OpenFileDialog openfile = new OpenFileDialog(); //Initialize Open File dialogue
        string line = "";                                                  
        List<String> list = new List<String>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            openfile.Filter = "Text Files (.txt)| *.txt"; //Setting up the Open File Dialogue Filter on Form Load
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openfile.FileName); // Initializing Stream Reader to Read the Text from the Selected file
                SelectedName.Text = SelectedName.Text + Path.GetFileNameWithoutExtension(openfile.FileName); //Display the Selected File Name on the Label
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        list.Add(line); //Adding Each Line the Stream Reader Reads From The File to a List
                    }
                }
                sr.Close(); //Closing the Stream Reader
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {


            SaveFileDialog sfg = new SaveFileDialog(); //Initializing Save File Dialogue 
            sfg.Filter = "Text files (*.txt)|*.txt"; //Setting Up the Saving Format
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                var path = sfg.FileName;
                StreamWriter sw = new StreamWriter(path, true); //Initializing the Stream Writer to Create a File in the Path Chosen by Save File Dialogue
                foreach (String s in list)
                {

                    sw.WriteLine(s + "!"); //Appending an Exclamation Point to each Line in the List Then Typing the Lines in the Created File
                }
                sw.Close(); //Closing the Stream Writer
                MessageBox.Show("File Created Successfully"); //Showing a Message to Notify the User When the File is Created
            }


        }



    }
}
