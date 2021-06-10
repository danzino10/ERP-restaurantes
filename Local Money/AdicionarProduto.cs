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
using System.Drawing.Imaging;

namespace Local_Money
{
    public partial class AdicionarProduto : Form
    {
        Conexao con = new Conexao();
        Bitmap bmp;

        public AdicionarProduto()
        {
            InitializeComponent();
        }

        private void AdicionarProduto_Load(object sender, EventArgs e)
        {
            con.abrir();
            try
            {
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_menu"
                };
                SqlDataReader reader = com.ExecuteReader();
                while(reader.Read())
                {
                    cb_menu.Items.Add(reader.GetInt32(0).ToString() + " - " + reader.GetString(1));
                    
                }
                reader.Close();
                
            }
            catch(Exception er)
            {
                MessageBox.Show("erro " + er);
            }
            finally
            {
                con.fechar();
            }
        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFd1 = new OpenFileDialog();
            oFd1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = oFd1.ShowDialog();

            if (res == DialogResult.OK)
            {
                string nome = oFd1.FileName;

                bmp = new Bitmap(nome);

                pb_foto.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_foto.Image = Image.FromFile(oFd1.FileName);
            }
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            con.abrir();
            try
            {
                string[] nn = cb_categoria.Text.Split('-');
                string[] vv = txt_preco.Text.Split(' ');
                SqlCommand com2 = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_produto WHERE nome = '" + txt_nome + "'"
                };
                SqlDataReader reader2 = com2.ExecuteReader();
                if(reader2.Read() == false)
                {
                    reader2.Close();

                    MemoryStream memory = new MemoryStream();
                    bmp.Save(memory, ImageFormat.Bmp);
                    byte[] foto = memory.ToArray();

                    SqlCommand com3 = new SqlCommand
                    {
                        Connection = con.SaberConexao(),
                        CommandText = "INSERT INTO tb_produto (nome,valor,descricao,id_categoria,id_menu,imagem,stock) VALUES (@nome,@valor,@descricao,@categoria,@menu,@imagem,@stock)"
                    };

                    SqlParameter nome = new SqlParameter("@nome", SqlDbType.VarChar)
                    {
                        Value = txt_nome.Text
                    };
                    com3.Parameters.Add(nome);

                    SqlParameter valor = new SqlParameter("@valor", SqlDbType.Float)
                    {
                        Value = float.Parse(vv[0])
                    };
                    com3.Parameters.Add(valor);

                    SqlParameter descricao = new SqlParameter("@descricao", SqlDbType.Text)
                    {
                        Value = txt_descricao.Text
                    };
                    com3.Parameters.Add(descricao);

                    SqlParameter categoria = new SqlParameter("@categoria", SqlDbType.Int)
                    {
                        Value = nn[0].Trim()
                    };
                    com3.Parameters.Add(categoria);

                    SqlParameter menu = new SqlParameter("@menu", SqlDbType.Int)
                    {
                        Value = cb_menu.SelectedIndex + 1
                    };
                    com3.Parameters.Add(menu);

                    SqlParameter imagem = new SqlParameter("@imagem", SqlDbType.VarBinary)
                    {
                        Value = foto
                    };
                    com3.Parameters.Add(imagem);

                    SqlParameter stock = new SqlParameter("@stock", SqlDbType.VarChar)
                    {
                        Value = "indisponível"
                    };
                    com3.Parameters.Add(stock);

                    com3.ExecuteNonQuery();

                    MessageBox.Show("Produto adicionado com sucesso");
                    this.Close();
                }
                
            }
            catch (Exception er)
            {
                MessageBox.Show("erro " + er);
            }
            finally
            {
                con.fechar();

            }
        }

        private void cb_menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_categoria.Items.Clear();
            con.abrir();
            try
            {
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_categoria WHERE id_menu = @menu",
                    
                };
                SqlParameter menu = new SqlParameter("@menu", SqlDbType.Int);
                menu.Value = cb_menu.SelectedIndex + 1;
                com.Parameters.Add(menu);

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    cb_categoria.Items.Add(reader.GetInt32(0).ToString() + " - " + reader.GetString(1));

                }
                reader.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show("erro " + er);
            }
            finally
            {
                con.fechar();
            }
        }

        private void cb_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_preco_Click(object sender, EventArgs e)
        {
            txt_preco.Clear();
        }

        private void txt_preco_Leave(object sender, EventArgs e)
        {
            double value;
            if (Double.TryParse(txt_preco.Text, out value))
                txt_preco.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            else
                txt_preco.Text = String.Empty;
        }

        private void txt_nome_Click(object sender, EventArgs e)
        {
            txt_nome.Clear();
        }
    }
}
