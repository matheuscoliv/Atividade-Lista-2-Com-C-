using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBancoDadosMySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text.Equals(""))
            {
                MessageBox.Show("Informe o nome do aluno.");
                return;
            }
            try
            {
                AlunosDB alunoBD = new AlunosDB();
                double media = Double.Parse(txtMedia.Text);
                Alunos alunoReg = new Alunos(int.Parse(TxtMat.Text), TxtNome.Text,
                    Double.Parse(txtN1.Text), Double.Parse(txtN2.Text), media, CalcularStatus(media));
                alunoBD.IncluirAluno(alunoReg);
                MessageBox.Show("Registro salvo com sucesso.");
                button2.PerformClick();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlunosDB alunoBD = new AlunosDB();
            TxtMat.Text = "";
            TxtNome.Text = "";
            txtN1.Text = "";
            txtN2.Text = "";
            txtMedia.Text = "";
            TxtMat.Focus();
            dataGridView1.DataSource = alunoBD.getAlunos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TxtMat.Text.Equals(""))
            {
                MessageBox.Show("Selecione um aluno na tabela.");
                return;
            }
            try
            {
                AlunosDB alunoBD = new AlunosDB();
                double media = Double.Parse(txtMedia.Text);
                Alunos alunoReg = new Alunos(int.Parse(TxtMat.Text), TxtNome.Text,
                    Double.Parse(txtN1.Text), Double.Parse(txtN2.Text), media, CalcularStatus(media));

                int afetados = alunoBD.AtualizarAluno(alunoReg);
                if (afetados > 0)
                    MessageBox.Show("Registro atualizado com sucesso.");
                else
                    MessageBox.Show("Nenhum aluno encontrado com essa matrícula.");
                button2.PerformClick();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (TxtMat.Text.Equals(""))
            {
                MessageBox.Show("Selecione um aluno na tabela.");
                return;
            }
            DialogResult resp = MessageBox.Show("Deseja excluir o aluno " + TxtNome.Text + "?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes) return;

            try
            {
                AlunosDB alunoBD = new AlunosDB();
                int afetados = alunoBD.ExcluirAluno(int.Parse(TxtMat.Text));
                if (afetados > 0)
                    MessageBox.Show("Registro excluído com sucesso.");
                else
                    MessageBox.Show("Nenhum aluno encontrado com essa matrícula.");
                button2.PerformClick();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }
        private string CalcularStatus(double media)
        {
            return media >= 6 ? "Aprovado" : "Reprovado";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow linha = dataGridView1.Rows[e.RowIndex];
            TxtMat.Text = linha.Cells[0].Value.ToString();
            TxtNome.Text = linha.Cells[1].Value.ToString();
            txtN1.Text = linha.Cells[2].Value.ToString();
            txtN2.Text = linha.Cells[3].Value.ToString();
            txtMedia.Text = linha.Cells[4].Value.ToString();
        }

        private void txtMedia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtN1_TextChanged(object sender, EventArgs e)
        {
            AtualizarMedia();
        }

        private void txtN2_TextChanged(object sender, EventArgs e)
        {
            AtualizarMedia();
        }

        private void AtualizarMedia()
        {
            double n1, n2;
            bool okN1 = Double.TryParse(txtN1.Text, out n1);
            bool okN2 = Double.TryParse(txtN2.Text, out n2);

            if (okN1 && okN2)
                txtMedia.Text = ((n1 + n2) / 2).ToString("0.00");
            else
                txtMedia.Text = "";
        }
    }
}
