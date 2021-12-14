using System;
using System.Text.RegularExpressions;

namespace MyWindowsApp
{
    public partial class Form1 : Form
    {
        public String fileName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Font font = new Font("Courier New", 12f);
            maintextbox.Font = font;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        //File related stuff
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                maintextbox.Clear();
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    maintextbox.Text = sr.ReadToEnd();
                    fileName = openFileDialog.FileName;
                    sr.Close();
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save File";
            //checks if dialog box is closed
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter txtcontent = new StreamWriter(saveFileDialog.FileName);
                txtcontent.Write(maintextbox.Text);
                txtcontent.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                StreamWriter txtcontent = new StreamWriter(fileName);
                txtcontent.Write(maintextbox.Text);
                txtcontent.Close();
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save File";
                //checks if dialog box is closed
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter txtcontent = new StreamWriter(saveFileDialog.FileName);
                    fileName = saveFileDialog.FileName;
                    txtcontent.Write(maintextbox.Text);
                    txtcontent.Close();
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Clear();
        }

        //Edit related stuff

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Cut();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.SelectAll();
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }
    }
}