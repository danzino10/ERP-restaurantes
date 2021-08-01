using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using Local_Money.modelos;

namespace Local_Money.objectos
{
    class IngredienteListado
    {
        Conexao con = new Conexao();
        frm_dashboard d = (frm_dashboard)Application.OpenForms[1];

        int Id;
        public IngredienteListado(int id, string nome, string categoria, string unidade, double estoque)
        {
            Id = id;

            LabelId.Text = id.ToString();
            LabelNome.Text = nome;
            LabelCategoria.Text = categoria;
            if (unidade == "Kilograma")
                LabelEstoque.Text = estoque + " Kg";
            else if (unidade == "Litro")
                LabelEstoque.Text = estoque + " L";
            else
                LabelEstoque.Text = estoque + " Un";
            BotaoVizualizar.Click += (sender2, e2) => Visualizar(sender2, e2);
            BotaoEditar.Click += (sender2, e2) => Editar(sender2, e2);
            BotaoEliminar.Click += (sender2, e2) => Eliminar(sender2, e2);

            PainelIngrediente.Controls.Add(LabelId);
            PainelIngrediente.Controls.Add(LabelNome);
            PainelIngrediente.Controls.Add(LabelCategoria);
            PainelIngrediente.Controls.Add(LabelEstoque);
            PainelIngrediente.Controls.Add(BotaoVizualizar);
            PainelIngrediente.Controls.Add(BotaoEditar);
            PainelIngrediente.Controls.Add(BotaoEliminar);
        }

        private Panel PainelIngrediente = new Panel
        {
            Width = 730,
            Height = 80,
        };

        private Label LabelId = new Label
        {
            AutoSize = true,
            Location = new Point(15, 35),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)))
        };

        private Label LabelNome = new Label
        {
            AutoSize = true,
            Location = new Point(80, 35),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)))
        };

        private Label LabelCategoria = new Label
        {
            AutoSize = true,
            Location = new Point(225, 35),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)))
        };

        private Label LabelEstoque = new Label
        {
            AutoSize = true,
            Location = new Point(375, 35),
            Font = new Font("Roboto", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)))
        };

        private Button BotaoActualizar = new Button
        {
            AutoSize = true,
            Location = new Point(450, 35),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.DarkSlateGray,
            Height = 35,
            Width = 35,
            BackgroundImage = Properties.Resources.reload,
            BackgroundImageLayout = ImageLayout.Zoom,
        };

        private Button BotaoVizualizar = new Button
        {
            AutoSize = true,
            Location = new Point(555, 35),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.DarkSlateGray,
            Height = 35,
            Width = 35,
            BackgroundImage = Properties.Resources.user,
            BackgroundImageLayout = ImageLayout.Zoom,
        };

        private Button BotaoEditar = new Button
        {
            AutoSize = true,
            Location = new Point(610, 35),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.Gold,
            Height = 35,
            Width = 35,
            BackgroundImage = Properties.Resources.editar_arquivo,
            BackgroundImageLayout = ImageLayout.Zoom,
        };

        private Button BotaoEliminar = new Button
        {
            AutoSize = true,
            Location = new Point(665, 35),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.Brown,
            Height = 35,
            Width = 35,
            BackgroundImage = Properties.Resources.delete,
            BackgroundImageLayout = ImageLayout.Zoom,
        };

        public Panel Criar()
        {
            return PainelIngrediente;
        }

        private void Eliminar(Object sender, EventArgs e)
        {
            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "DELETE FROM tb_ingrediente WHERE id_ingrediente = '" + Id + "'",
                Connection = con.SaberConexao(),
            };
            com.ExecuteNonQuery();
            con.fechar();
            MessageBox.Show("Ingrediente removido!!");
            
            d.AbrirJanela(new RestauranteIngredientes());
        }

        private void Visualizar(Object sender, EventArgs e)
        {
            con.abrir();
            FormularioIngrediente fi = new FormularioIngrediente();
            fi.flag = 1;
            fi.p_ra.Visible = true;
            fi.p_id.Visible = true;
            fi.txt_actualizacao.Enabled = false;
            fi.txt_registo.Enabled = false;
            fi.txt_id.Enabled = false;
            fi.txt_nome.Enabled = false;
            fi.txt_preco.Enabled = false;
            fi.txt_quantidade.Enabled = false;
            fi.txt_fornecedor.Enabled = false;
            fi.cb_categoria.Enabled = false;
            fi.cb_medida.Enabled = false;
            fi.btn_upload.Visible = false;
            fi.btn_concluir.Visible = false;
            fi.btn_cancelar.Visible = false;

            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_ingrediente WHERE id_ingrediente ='" + Id + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                fi.txt_id.Text = reader.GetInt32(0).ToString();
                fi.txt_nome.Text = reader.GetString(1);
                fi.cb_medida.Text = reader.GetString(2);
                fi.txt_preco.Text = reader.GetValue(3).ToString();
                fi.txt_quantidade.Text = reader.GetValue(4).ToString();
                fi.txt_fornecedor.Text = reader.GetString(5);
                fi.cb_categoria.Text = reader.GetString(6);
                fi.txt_registo.Text = reader.GetString(7) + " - " + reader.GetInt32(8);


                if (!DBNull.Value.Equals(reader[9]) || !DBNull.Value.Equals(reader[10]))
                {
                    fi.txt_actualizacao.Text = reader.GetString(9) + " - " + reader.GetInt32(10);
                }
                else
                {
                    fi.txt_actualizacao.Text = "";
                }
                if (!DBNull.Value.Equals(reader.GetValue(11)))
                {
                    byte[] img = (byte[])(reader.GetValue(11));
                    //fi.pb_imagem.Image = ConverterImagem.GetImage((byte[])reader.GetValue(11));
                    fi.pb_imagem.Image = null;
                }
                else
                {
                    fi.pb_imagem.Image = null;
                }
            }
            con.fechar();
            d.AbrirJanela(fi);
        }

        private void Editar(Object sender, EventArgs e) 
        {
            con.abrir();
            FormularioIngrediente fi = new FormularioIngrediente();
            fi.flag = 1;
            fi.p_ra.Visible = true;
            fi.p_id.Visible = true;
            fi.txt_actualizacao.Enabled = true;
            fi.txt_registo.Enabled = true;
            fi.txt_id.Enabled = true;
            fi.txt_nome.Enabled = true;
            fi.txt_preco.Enabled = true;
            fi.txt_quantidade.Enabled = true;
            fi.txt_fornecedor.Enabled = true;
            fi.cb_categoria.Enabled = true;
            fi.cb_medida.Enabled = true;
            fi.btn_upload.Visible = true;
            fi.btn_concluir.Visible = true;
            fi.btn_cancelar.Visible = true;

            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_ingrediente WHERE id_ingrediente ='" + Id + "'",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                fi.txt_id.Text = reader.GetInt32(0).ToString();
                fi.txt_nome.Text = reader.GetString(1);
                fi.cb_medida.Text = reader.GetString(2);
                fi.txt_preco.Text = reader.GetValue(3).ToString();
                fi.txt_quantidade.Text = reader.GetValue(4).ToString();
                fi.txt_fornecedor.Text = reader.GetString(5);
                fi.cb_categoria.Text = reader.GetString(6);
                fi.txt_registo.Text = reader.GetString(7) + " - " + reader.GetInt32(8);

                if (!DBNull.Value.Equals(reader[9]) || !DBNull.Value.Equals(reader[10]))
                {
                    fi.txt_actualizacao.Text = "";
                }
                else
                {
                    fi.txt_actualizacao.Text = reader.GetString(9) + " - " + reader.GetInt32(10);
                }

                byte[] img = (byte[])(reader[11]);
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    fi.pb_imagem.Image = null;
                    //fi.pb_imagem.Image = Image.FromStream(ms);
                }
            }
            con.fechar();
            d.AbrirJanela(fi);
        }
    }
}
