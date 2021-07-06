using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Local_Money
{
    public partial class PessoalRelatorios : Form
    {
        Conexao con = new Conexao();


        public PessoalRelatorios()
        {
            InitializeComponent();
        }

        private void PessoalRelatorios_Load(object sender, EventArgs e)
        {
            ct_ano.Titles[0].Text = "Relatório 2021";

            con.abrir();
            try
            {
                SqlCommand com = new SqlCommand
                {
                    CommandText = "SELECT * FROM tb_receita_ano",
                    Connection = con.SaberConexao(),
                };
                SqlDataReader reader = com.ExecuteReader();

                int i = 0;
                while(reader.Read())
                {
                    ct_ano.Series["Receitas"].Points.AddXY(reader.GetString(1), reader.GetValue(2).ToString());
                    ct_ano.Series["Receitas"].Points[i].Label = reader.GetValue(2).ToString();
                    i++;
                }

            }
            catch(Exception er)
            {
                MessageBox.Show("Erro " + er);
            }
            con.fechar();
        }

        private void ct_ano_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_receitas_Click(object sender, EventArgs e)
        {
            ct_ano.Series.Clear();
            ct_ano.Series.Add("Receitas");
            ct_ano.Series["Receitas"].Color = Color.DarkSlateGray;
            ct_ano.Series["Receitas"].Font = new Font("Roboto", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            ct_ano.ChartAreas[0].RecalculateAxesScale();

            p_ureceitas.BackColor = Color.DarkSlateGray;
            p_uclientes.BackColor = SystemColors.Control;
            p_ucozinheiros.BackColor = SystemColors.Control;
            p_uoperadores.BackColor = SystemColors.Control;

            con.abrir();
            try
            {
                SqlCommand com = new SqlCommand
                {
                    CommandText = "SELECT * FROM tb_receita_ano",
                    Connection = con.SaberConexao(),
                };
                SqlDataReader reader = com.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    ct_ano.Series["Receitas"].Points.AddXY(reader.GetString(1), reader.GetValue(2).ToString());
                    ct_ano.Series["Receitas"].Points[i].Label = reader.GetValue(2).ToString();
                    i++;
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Erro " + er);
            }
            con.fechar();
        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
            ct_ano.Series.Clear();
            ct_ano.Series.Add("Clientes");
            ct_ano.Series["Clientes"].Color = Color.DarkSlateGray;
            ct_ano.Series["Clientes"].Font = new Font("Roboto", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            ct_ano.ChartAreas[0].RecalculateAxesScale();

            p_uclientes.BackColor = Color.DarkSlateGray;
            p_ureceitas.BackColor = SystemColors.Control;
            p_ucozinheiros.BackColor = SystemColors.Control;
            p_uoperadores.BackColor = SystemColors.Control;
            con.abrir();
            try
            {
                SqlCommand com = new SqlCommand
                {
                    CommandText = "SELECT * FROM tb_receita_ano",
                    Connection = con.SaberConexao(),
                };
                SqlDataReader reader = com.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    ct_ano.Series["Clientes"].Points.AddXY(reader.GetString(1), reader.GetInt32(3).ToString());
                    ct_ano.Series["Clientes"].Points[i].Label = reader.GetInt32(3).ToString();
                    i++;
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Erro " + er);
            }
            con.fechar();
        }

        private void btn_operadores_Click(object sender, EventArgs e)
        {
            ct_ano.Series.Clear();
            p_uoperadores.BackColor = Color.DarkSlateGray;
            p_uclientes.BackColor = SystemColors.Control;
            p_ucozinheiros.BackColor = SystemColors.Control;
            p_ureceitas.BackColor = SystemColors.Control;
        }

        private void btn_cozinheiros_Click(object sender, EventArgs e)
        {
            ct_ano.Series.Clear();
            p_ucozinheiros.BackColor = Color.DarkSlateGray;
            p_uclientes.BackColor = SystemColors.Control;
            p_ureceitas.BackColor = SystemColors.Control;
            p_uoperadores.BackColor = SystemColors.Control;
        }
    }
}
