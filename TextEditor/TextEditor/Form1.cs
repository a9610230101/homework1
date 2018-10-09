using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TextEditor
{
    //Project(homework) : 文字編輯器
    //Author : 林紘毅
    //Date : 10/09


    public partial class FormEditor : Form
    {
        String filePath = null;


        public FormEditor()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setFilePath(null);
            richTextBox.Text = "";
        }

        public static String fileToText(String filePath)
        {
            StreamReader file = new StreamReader(filePath);
            String text = file.ReadToEnd();
            file.Close();
            return text;
        }

        public static void textToFile(String filePath, String text)
        {
            StreamWriter file = new StreamWriter(filePath);
            file.Write(text);
            file.Close();
        }

        private void saveDialog()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                setFilePath(saveFileDialog.FileName);
                textToFile(saveFileDialog.FileName, richTextBox.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                setFilePath(openFileDialog.FileName);
                richTextBox.Text = fileToText(openFileDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath == null)
                saveDialog();
            else
                textToFile(saveFileDialog.FileName, richTextBox.Text);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作者:資科一甲 林紘毅(A107222011)");
              

                }

        private void setFilePath(String path)
        {
            filePath = path;
            this.Text = filePath;
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void 完整關閉程式ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("感謝您的使用");
            this.Close();
        }
    }
}
