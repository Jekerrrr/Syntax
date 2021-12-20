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

        private void maintextbox_Load(object sender, EventArgs e)
        {
            maintextbox.ServiceLinesColor = Color.Gray;
            maintextbox.SelectionColor = Color.Gray;
            maintextbox.CaretColor = Color.Gray;
            plainTextToolStripMenuItem.Text = "Plain Text ✓";
        }

        //Syntax highlighting

        private void visualBasicScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Language = FastColoredTextBoxNS.Language.VB;
            plainTextToolStripMenuItem.Text = "Plain Text";
            cToolStripMenuItem.Text = "C#";
            cToolStripMenuItem1.Text = "C++";
            javaScriptToolStripMenuItem.Text = "JavaScript";
            xMLToolStripMenuItem.Text = "XML";
            pHPToolStripMenuItem.Text = "PHP";
            jSONToolStripMenuItem.Text = "JSON";
            hTMLToolStripMenuItem.Text = "HTML";
            luaToolStripMenuItem.Text = "Lua";
            visualBasicScriptToolStripMenuItem.Text = "Visual Basic Script ✓";
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Language = FastColoredTextBoxNS.Language.CSharp;
            plainTextToolStripMenuItem.Text = "Plain Text";
            cToolStripMenuItem.Text = "C# ✓";
            cToolStripMenuItem1.Text = "C++";
            javaScriptToolStripMenuItem.Text = "JavaScript";
            xMLToolStripMenuItem.Text = "XML";
            pHPToolStripMenuItem.Text = "PHP";
            jSONToolStripMenuItem.Text = "JSON";
            hTMLToolStripMenuItem.Text = "HTML";
            luaToolStripMenuItem.Text = "Lua";
            visualBasicScriptToolStripMenuItem.Text = "Visual Basic Script";
        }

        private void luaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Language = FastColoredTextBoxNS.Language.Lua;
            plainTextToolStripMenuItem.Text = "Plain Text";
            cToolStripMenuItem.Text = "C#";
            cToolStripMenuItem1.Text = "C++";
            javaScriptToolStripMenuItem.Text = "JavaScript";
            xMLToolStripMenuItem.Text = "XML";
            pHPToolStripMenuItem.Text = "PHP";
            jSONToolStripMenuItem.Text = "JSON";
            hTMLToolStripMenuItem.Text = "HTML";
            luaToolStripMenuItem.Text = "Lua ✓";
            visualBasicScriptToolStripMenuItem.Text = "Visual Basic Script";
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Language = FastColoredTextBoxNS.Language.HTML;
            plainTextToolStripMenuItem.Text = "Plain Text";
            cToolStripMenuItem.Text = "C#";
            cToolStripMenuItem1.Text = "C++";
            javaScriptToolStripMenuItem.Text = "JavaScript";
            xMLToolStripMenuItem.Text = "XML";
            pHPToolStripMenuItem.Text = "PHP";
            jSONToolStripMenuItem.Text = "JSON";
            hTMLToolStripMenuItem.Text = "HTML ✓";
            luaToolStripMenuItem.Text = "Lua";
            visualBasicScriptToolStripMenuItem.Text = "Visual Basic Script";
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Language = FastColoredTextBoxNS.Language.JSON;
            plainTextToolStripMenuItem.Text = "Plain Text";
            cToolStripMenuItem.Text = "C#";
            cToolStripMenuItem1.Text = "C++";
            javaScriptToolStripMenuItem.Text = "JavaScript";
            xMLToolStripMenuItem.Text = "XML";
            pHPToolStripMenuItem.Text = "PHP";
            jSONToolStripMenuItem.Text = "JSON ✓";
            hTMLToolStripMenuItem.Text = "HTML";
            luaToolStripMenuItem.Text = "Lua";
            visualBasicScriptToolStripMenuItem.Text = "Visual Basic Script";
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Language = FastColoredTextBoxNS.Language.PHP;
            plainTextToolStripMenuItem.Text = "Plain Text";
            cToolStripMenuItem.Text = "C#";
            cToolStripMenuItem1.Text = "C++";
            javaScriptToolStripMenuItem.Text = "JavaScript";
            xMLToolStripMenuItem.Text = "XML";
            pHPToolStripMenuItem.Text = "PHP ✓";
            jSONToolStripMenuItem.Text = "JSON";
            hTMLToolStripMenuItem.Text = "HTML";
            luaToolStripMenuItem.Text = "Lua";
            visualBasicScriptToolStripMenuItem.Text = "Visual Basic Script";
        }

        private void javaScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Language= FastColoredTextBoxNS.Language.JS;
            plainTextToolStripMenuItem.Text = "Plain Text";
            cToolStripMenuItem.Text = "C#";
            cToolStripMenuItem1.Text = "C++";
            javaScriptToolStripMenuItem.Text = "JavaScript ✓";
            xMLToolStripMenuItem.Text = "XML";
            pHPToolStripMenuItem.Text = "PHP";
            jSONToolStripMenuItem.Text = "JSON";
            hTMLToolStripMenuItem.Text = "HTML";
            luaToolStripMenuItem.Text = "Lua";
            visualBasicScriptToolStripMenuItem.Text = "Visual Basic Script";
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Language = FastColoredTextBoxNS.Language.XML;
            plainTextToolStripMenuItem.Text = "Plain Text";
            cToolStripMenuItem.Text = "C#";
            cToolStripMenuItem1.Text = "C++";
            javaScriptToolStripMenuItem.Text = "JavaScript";
            xMLToolStripMenuItem.Text = "XML ✓";
            pHPToolStripMenuItem.Text = "PHP";
            jSONToolStripMenuItem.Text = "JSON";
            hTMLToolStripMenuItem.Text = "HTML";
            luaToolStripMenuItem.Text = "Lua";
            visualBasicScriptToolStripMenuItem.Text = "Visual Basic Script";
        }

        private void cToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            maintextbox.Language = FastColoredTextBoxNS.Language.CSharp;
            plainTextToolStripMenuItem.Text = "Plain Text";
            cToolStripMenuItem.Text = "C#";
            cToolStripMenuItem1.Text = "C++ ✓";
            javaScriptToolStripMenuItem.Text = "JavaScript";
            xMLToolStripMenuItem.Text = "XML";
            pHPToolStripMenuItem.Text = "PHP";
            jSONToolStripMenuItem.Text = "JSON";
            hTMLToolStripMenuItem.Text = "HTML";
            luaToolStripMenuItem.Text = "Lua";
            visualBasicScriptToolStripMenuItem.Text = "Visual Basic Script";
        }

        private void plainTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintextbox.Language = FastColoredTextBoxNS.Language.Custom;
            plainTextToolStripMenuItem.Text = "Plain Text ✓";
            cToolStripMenuItem.Text = "C#";
            cToolStripMenuItem1.Text = "C++";
            javaScriptToolStripMenuItem.Text = "JavaScript";
            xMLToolStripMenuItem.Text = "XML";
            pHPToolStripMenuItem.Text = "PHP";
            jSONToolStripMenuItem.Text = "JSON";
            hTMLToolStripMenuItem.Text = "HTML";
            luaToolStripMenuItem.Text = "Lua";
            visualBasicScriptToolStripMenuItem.Text = "Visual Basic Script";
        }
    }
}