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
    public partial class RestauranteInformacoes : Form
    {
        Conexao con = new Conexao();

        public RestauranteInformacoes()
        {
            InitializeComponent();
        }

        private void RestauranteInformacoes_Load(object sender, EventArgs e)
        {
            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_restaurante WHERE nif = 5122334445",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            while(reader.Read())
            {
                txt_nome.Text = reader.GetString(1);
                txt_email.Text = reader.GetString(2);
                txt_nif.Text = reader.GetString(0);
                txt_endereco1.Text = reader.GetString(3);
                txt_endereco2.Text = reader.GetString(4);
                txt_telefone1.Text = reader.GetInt32(5).ToString();
                txt_telefone2.Text = reader.GetInt32(6).ToString();
                txt_telefone3.Text = reader.GetInt32(7).ToString();
                txt_telefone4.Text = reader.GetInt32(8).ToString();
                txt_iva.Text = reader.GetInt32(9).ToString();
            }
            reader.Close();

            SqlCommand com2 = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_receita_ano",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader2 = com2.ExecuteReader();

            string[] s = DateTime.Today.ToString().Split('/');
            int mes = int.Parse(s[1]);
            int i = 1;
            while(reader2.Read())
            {
                cb_mes.Items.Add(reader2.GetString(1));
                if(i == mes)
                {
                    txt_receita.Text = reader2.GetValue(4).ToString();
                    txt_cliente.Text = reader2.GetInt32(5).ToString();
                }
                i++;
            }

            con.fechar();
        }

        private void txt_iva_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            int iva = int.Parse(txt_iva.Text);
            txt_iva.Text = (iva + 1).ToString();
            if (iva == 100)
            {
                btn_up.Enabled = false;
            }
            btn_down.Enabled = true;
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            int iva = int.Parse(txt_iva.Text);
            txt_iva.Text = (iva - 1).ToString();
            if(iva == 0)
            {
                btn_down.Enabled = false;
            }
            btn_up.Enabled = true;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            txt_nome.Enabled = true;
            txt_email.Enabled = true;
            txt_nif.Enabled = true;
            txt_endereco1.Enabled = true;
            txt_endereco2.Enabled = true;
            txt_telefone1.Enabled = true;
            txt_telefone2.Enabled = true;
            txt_telefone3.Enabled = true;
            txt_telefone4.Enabled = true;
            btn_up.Enabled = true;
            btn_down.Enabled = true;
            btn_concluir.Visible = true;
            btn_editar1.Visible = false;
        }

        private void btn_concluir_Click(object sender, EventArgs e)
        {
            txt_nome.Enabled = false;
            txt_email.Enabled = false;
            txt_nif.Enabled = false;
            txt_endereco1.Enabled = false;
            txt_endereco2.Enabled = false;
            txt_telefone1.Enabled = false;
            txt_telefone2.Enabled = false;
            txt_telefone3.Enabled = false;
            txt_telefone4.Enabled = false;
            btn_up.Enabled = false;
            btn_down.Enabled = false;
            btn_concluir.Visible = false;
            btn_editar1.Visible = true;

            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "UPDATE tb_restaurante SET nome = '" + txt_nome.Text + "', email = '" + txt_email.Text + "', nif = '" + txt_nif.Text + "', endereco1 = '" + txt_endereco1.Text + "', endereço2 = '" + txt_endereco2.Text + "', telefone1 = '" + int.Parse(txt_telefone1.Text) + "', telefone2 = '" + int.Parse(txt_telefone2.Text) + "', telefone3 = '" + int.Parse(txt_telefone3.Text) + "', telefone4 = '" + int.Parse(txt_telefone4.Text) + "', iva = '" + int.Parse(txt_iva.Text) + "'",
                Connection = con.SaberConexao(),
            };
            com.ExecuteNonQuery();
            con.fechar();
            MessageBox.Show("Informações do Restaurante actualizadas!!");
        }

        private void btn_editar2_Click(object sender, EventArgs e)
        {
            cb_mes.Enabled = true;
            
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            cb_mes.Enabled = false;
            txt_receita.Enabled = false;
            txt_cliente.Enabled = false;
            btn_actualizar.Visible = false;
            btn_editar2.Visible = true;

            con.abrir();
            int index = cb_mes.SelectedIndex;
            SqlCommand com2 = new SqlCommand
            {
                CommandText = "UPDATE tb_receita_ano SET meta_receita = '" + double.Parse(txt_receita.Text) +"', meta_clientes = '" + int.Parse(txt_cliente.Text) + "' WHERE id_mes = '" + (index + 1).ToString() + "' ",
                Connection = con.SaberConexao(),
            };
            com2.ExecuteNonQuery();

            string[] s = DateTime.Today.ToString().Split('/');
            int mes = int.Parse(s[1]);
            int dias = 0;
            if(cb_mes.SelectedIndex + 1 == mes)
            {
                if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                {
                    dias = 31;
                }
                else if (mes == 2)
                {
                    dias = 29;
                }
                else
                {
                    dias = 30;
                }

                SqlCommand com3 = new SqlCommand
                {
                    CommandText = "DELETE FROM tb_mes",
                    Connection = con.SaberConexao(),
                };
                com3.ExecuteNonQuery();

                for (int i = 1; i <= dias; i++)
                {
                    SqlCommand com4 = new SqlCommand
                    {
                        CommandText = "INSERT INTO tb_mes (dia,meta_receita,meta_clientes) Values('" + i + "','" + Math.Round(double.Parse(txt_receita.Text)/dias) + "','" + Math.Round(double.Parse(txt_cliente.Text)/dias) + "')",
                        Connection = con.SaberConexao(),
                    };
                    com4.ExecuteNonQuery();
                }
            }
            con.fechar();

        }

        private void cb_mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.abrir();
            int index = cb_mes.SelectedIndex;
            SqlCommand com2 = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_receita_ano WHERE id_mes = '" + (index + 1).ToString() + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader2 = com2.ExecuteReader();

            string[] s = DateTime.Today.ToString().Split('/');
            int mes = int.Parse(s[1]);
            while (reader2.Read())
            {
                txt_receita.Text = reader2.GetValue(4).ToString();
                txt_cliente.Text = reader2.GetInt32(5).ToString();
            }
            if(index + 1 >= mes)
            {
                txt_receita.Enabled = true;
                txt_cliente.Enabled = true;
                btn_actualizar.Enabled = true;
                btn_editar2.Visible = false;
                btn_actualizar.Visible = true;
            }
            else
            {
                txt_receita.Enabled = false;
                txt_cliente.Enabled = false;
                btn_actualizar.Enabled = false;
                btn_editar2.Visible = true;
                btn_actualizar.Visible = false;

            }
            con.fechar();
        }

        private void txt_nome_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_nome.Text.Split('/');
            lbl_nome.Text = txt_nome.Text.Length + "/" + txt_nome.MaxLength;
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_email.Text.Split('/');
            lbl_email.Text = txt_email.Text.Length + "/" + txt_email.MaxLength;
        }

        private void txt_endereco1_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_endereco1.Text.Split('/');
            lbl_endereco1.Text = txt_endereco1.Text.Length + "/" + txt_endereco1.MaxLength;
        }

        private void txt_telefone1_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_telefone1.Text.Split('/');
            lbl_telefone1.Text = txt_telefone1.Text.Length + "/" + txt_telefone1.MaxLength;
        }

        private void txt_telefone2_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_telefone2.Text.Split('/');
            lbl_telefone2.Text = txt_telefone2.Text.Length + "/" + txt_telefone2.MaxLength;
        }

        private void txt_telefone3_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_telefone3.Text.Split('/');
            lbl_telefone3.Text = txt_telefone3.Text.Length + "/" + txt_telefone3.MaxLength;
        }

        private void txt_telefone4_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_telefone4.Text.Split('/');
            lbl_telefone4.Text = txt_telefone4.Text.Length + "/" + txt_telefone4.MaxLength;
        }

        private void txt_endereco2_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_endereco2.Text.Split('/');
            lbl_endereco2.Text = txt_endereco2.Text.Length + "/" + txt_endereco2.MaxLength;
        }

        private void txt_nif_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_nif.Text.Split('/');
            lbl_nif.Text = txt_nif.Text.Length + "/" + txt_nif.MaxLength;
        }
    }
}
