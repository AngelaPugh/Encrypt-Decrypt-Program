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

namespace GTCA_TextDecrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            string filetext = "";     

                //Opens the file dialog to allow user to choose a file to open in the program.
                StreamReader infile = new StreamReader(openFileDialog1.FileName);

                //Reads through the file text until the EndOfStream is reached.
                while (!infile.EndOfStream)
                {
                    //Reads each character.
                    filetext += (char)infile.Read();
                }

                //Closes the textFile.
                infile.Close();

                //Displays the file from the text to textBox1.
                textBox1.Text = filetext;
            DecryptionButton.Enabled = true;
        }

        private void DecryptionButton_Click(object sender, EventArgs e)
        {
       
            string DecryptedString = "";
            int Key;

            if(! int.TryParse(DecryptKeyTextBox.Text, out Key))
            {
                MessageBox.Show("Unable to Decrypt message with key entered.");
            }
            

           foreach(char Letter in textBox1.Text)
            {
                char DecryptedLetter = Convert.ToChar(Letter - Key);
                DecryptedString += DecryptedLetter.ToString();
            }

            textBox1.Text = DecryptedString;
            DecryptionButton.Enabled = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            StreamWriter writeData = new StreamWriter(saveFileDialog1.FileName);

            foreach (char Letter in textBox1.Text)
            {
                writeData.Write(Letter);
            }

            writeData.Close();

        }

       
    }
}
