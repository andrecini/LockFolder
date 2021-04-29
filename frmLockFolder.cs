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

namespace LockFolder
{
    public partial class frmLockFolder : Form
    {
        public frmLockFolder()
        {
            InitializeComponent();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if(txtPath.Text == string.Empty || txtPath.Text == null)
                MessageBox.Show("Nenhuma Pasta foi selecionada. Verifique e tente novamente.");
            else
                Bloquear();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == string.Empty || txtPath.Text == null)
                MessageBox.Show("Nenhuma Pasta foi selecionada. Verifique e tente novamente.");
            else
                Desbloquear();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            fbd.Description = "Selecione uma pasta para realizar o Backup";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog() == DialogResult.OK)    
                txtPath.Text = fbd.SelectedPath;
        }

        private void Bloquear()
        {
            DirectoryInfo dInfo = new DirectoryInfo(txtPath.Text);
            string caminhoArquivo = dInfo.FullName;
            string nomeArquivo = caminhoArquivo.ToString() + ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
            try
            {
                Directory.Move(caminhoArquivo.ToString(), nomeArquivo.ToString());
                MessageBox.Show("Pasta :: BLOQUEADA ::  com sucesso!");
            }
            catch
            {
                MessageBox.Show("Erro! Tente outra pasta.", "Importante", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }
        }

        private void Desbloquear()
        {
            DirectoryInfo PastaInfo = new DirectoryInfo(txtPath.Text);
            string caminhoArquivo = PastaInfo.FullName;
            string nomeArquivo = caminhoArquivo.ToString().Replace(".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}", "");
            try
            {
                Directory.Move(caminhoArquivo.ToString(), nomeArquivo.ToString());
                MessageBox.Show("Pasta DESBLOQUEADA com Sucesso!");
            }
            catch
            {
                MessageBox.Show("Erro! Tente outra pasta.", "Importante", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == string.Empty || txtPath.Text == null)
                MessageBox.Show("Nenhuma Pasta foi selecionada. Verifique e tente novamente.");
            else
            {
                frmEdicao frm = new frmEdicao(txtPath.Text);
                frm.ShowDialog();
            }
        }
    }
}
