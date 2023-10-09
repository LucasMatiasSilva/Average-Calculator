using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CalcMedia {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e) {
        }
        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'bancoDataSet4.Medias' table. You can move, or remove it, as needed.
            this.mediasTableAdapter.Fill(this.bancoDataSet4.Medias);

        }
        private void label2_Click(object sender, EventArgs e) {
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e) {
            textBox1.MaxLength = 3;
        }
        private void textBox2_TextChanged(object sender, EventArgs e) {
            textBox2.MaxLength = 3;
        }
        private void textBox3_TextChanged(object sender, EventArgs e) {
            textBox3.MaxLength = 3;
        }
        private void textBox4_TextChanged_1(object sender, EventArgs e) {
            textBox4.MaxLength = 3;
        }
        private void label3_Click(object sender, EventArgs e) {
        }
        private void label4_Click(object sender, EventArgs e) {
        }

        private void label7_Click(object sender, EventArgs e) {
        }

        private void button1_Click(object sender, EventArgs e) {
            float som, med, val;
            som = 0;

            try {

                foreach (Control controle in this.Controls) {
                    if (controle is TextBox) {
                        val = Convert.ToSingle(((TextBox)controle).Text);
                        som += val;
                    }

                    med = som / 4;
                    this.Controls["label7"].Text = med.ToString();

                    if (med > 6) {
                        this.Controls["label7"].ForeColor = Color.Green;
                    } else {
                        this.Controls["label7"].ForeColor = Color.Red;
                    }

                    var date = DateTime.Today.ToString("dd/MM/yyyy");
                    var time = DateTime.Now.ToString("hh:mm:ss");

                    StreamWriter x;

                    string Caminho = "Historico de Notas.txt";

                    x = File.AppendText(Caminho);

                    x.WriteLine("SEU HISTÓRICO");
                    x.WriteLine("___________________________________________");
                    x.WriteLine("Nota: " + med.ToString());
                    x.WriteLine("Data e Hora: " + date.ToString() + " | " + time.ToString());
                    x.WriteLine();
                    x.WriteLine();

                    x.Close();
                }

            } catch (Exception) {
                MessageBox.Show("Dados incorretos, por favor verifique as notas digitadas e tente novamente", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Controls["label7"].Text = "";
            }

        }
        private void button2_Click(object sender, EventArgs e) {

            foreach (Control controle in this.Controls) {

                if (controle is TextBox) {
                    ((TextBox)controle).Text = "";
                }

                this.Controls["label7"].Text = "";
            }
        }
        private void label6_Click(object sender, EventArgs e) {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { 
        }
    }
}
