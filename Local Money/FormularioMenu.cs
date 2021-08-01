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
using System.IO;
using Local_Money.modelos;

namespace Local_Money
{
    public partial class FormularioMenu : Form
    {
        Conexao con = new Conexao();
        frm_dashboard d = (frm_dashboard)Application.OpenForms[1];
        public int flag = 0;
        public FormularioMenu()
        {
            InitializeComponent();
        }

        private void txt_nome_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_count_nome.Text.Split('/');
            lbl_count_nome.Text = txt_nome.Text.Length + "/" + txt_nome.MaxLength;
        }

        private void txt_pass2_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_count_desc.Text.Split('/');
            lbl_count_desc.Text = txt_descricao.Text.Length + "/" + txt_descricao.MaxLength;
        }

        private void btn_concluir_Click(object sender, EventArgs e)
        {
            string caminho = Path.GetFullPath(openFileDialog1.FileName);


            con.abrir();
            if (caminho == null)
            {
                MessageBox.Show("Selecione uma  imagem válida");
            }
            else
            {
                FileStream fs = new FileStream(openFileDialog1.FileName.ToString(), FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] img = null;
                img = br.ReadBytes((int)fs.Length);

                SqlCommand com = new SqlCommand
                {
                    CommandText = "SELECT * FROM tb_produto WHERE nome = '" + txt_nome.Text + "'",
                    Connection = con.SaberConexao(),
                };
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Ja existe um produto associado a este nome");
                }
                else
                {
                    reader.Close();
                    if (flag == 0)
                    {
                        SqlCommand com2 = new SqlCommand
                        {
                            CommandText = "INSERT INTO tb_produto (id_menu,id_categoria,nome,valor,imagem,descricao) VALUES('" + (cb_categoria.SelectedIndex + 1) + "','" + (cb_subcategoria.SelectedIndex + 1) + "','" + txt_nome.Text + "','" + txt_preco.Text + "','img','" + txt_descricao.Text + "')",
                            Connection = con.SaberConexao(),
                        };
                        com2.Parameters.Add(new SqlParameter("@img", ConverterImagem.GetBytes(pb_imagem.Image)));
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Usuário registado com sucesso!!");
                        this.Close();

                    }
                    else
                    {
                        SqlCommand com2 = new SqlCommand
                        {
                            CommandText = "UPDATE tb_user SET id_menu = '" + (cb_categoria.SelectedIndex + 1) + "', id_categoria = '" + (cb_subcategoria.SelectedIndex + 1) + "', nome = '" + txt_nome.Text + "', valor = '" + txt_preco.Text + "', imagem = 'img', descricao = '" + txt_descricao.Text + "' WHERE id_user = '" + int.Parse(txt_id.Text) + "'",
                            Connection = con.SaberConexao(),
                        };
                        com2.Parameters.Add(new SqlParameter("@img", ConverterImagem.GetBytes(pb_imagem.Image)));
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Usuário registado com sucesso!!");
                        this.Close();
                    }
                }
            }
            con.fechar();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Selecione a imagem do ingrediente";
            openFileDialog1.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        lbl_nome.Text = path;
                        pb_imagem.Image = new Bitmap(openFileDialog1.FileName);
                        pb_imagem.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormularioMenu_Load(object sender, EventArgs e)
        {
            SqlCommand com2 = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_menu ",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader2 = com2.ExecuteReader();
            while (reader2.Read())
            {
                cb_categoria.Items.Add(reader2.GetString(1));
            }
            reader2.Close();

            SqlCommand com3 = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_categoria ",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader3 = com2.ExecuteReader();
            while (reader2.Read())
            {
                cb_subcategoria.Items.Add(reader3.GetString(1));
            }
            reader3.Close();
        }
    }
}
