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

namespace LockFolder
{
    public partial class frmEdicao : Form
    {
        public frmEdicao(string folderPath)
        {
            InitializeComponent();
            SetFilePath(folderPath);
            
        }

        private string _filePath;

        private void SetFilePath(string folderPath)
        {
            _filePath = folderPath + @"\Segredo.txt";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                File.AppendAllText(_filePath, txtNewFileContent.Text);
            }
            catch (Exception exptn)
            {
                MessageBox.Show("Erro ao tentar abrir o arquivo!!! \n\n" + exptn.Message);
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
