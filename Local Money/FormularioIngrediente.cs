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
using Local_Money.modelos;
namespace Local_Money
{
    public partial class FormularioIngrediente : Form
    {
        Conexao con = new Conexao();
        frm_dashboard d = (frm_dashboard)Application.OpenForms[1];
        public int flag = 0;
        public FormularioIngrediente()
        {
            InitializeComponent();
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

        private void txt_nome_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_fornecedor.Text.Split('/');
            lbl_fornecedor.Text = txt_fornecedor.Text.Length + "/" + txt_fornecedor.MaxLength;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_count_fornecedor.Text.Split('/');
            lbl_count_fornecedor.Text = txt_fornecedor.Text.Length + "/" + txt_nome.MaxLength;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                    CommandText = "SELECT * FROM tb_ingrediente WHERE nome = '" + txt_nome.Text + "'",
                    Connection = con.SaberConexao(),
                };
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Ja existe um ingrediente associado a este nome");
                }
                else
                {
                    reader.Close();
                    if (flag == 0)
                    {
                        SqlCommand com2 = new SqlCommand
                        {
                            CommandText = "INSERT INTO tb_ingrediente (nome,un_medida,valor_medio,quantidade,fornecedor,categoria,data_registo,registo_por,imagem) VALUES('" + txt_nome.Text + "','" + cb_medida.Text + "','" + txt_preco.Text + "','" + txt_quantidade.Text + "','" + txt_fornecedor.Text + "','" + cb_categoria.Text + "','" + DateTime.Now.ToString() + "','" + d.Id + "','img')",
                            Connection = con.SaberConexao(),
                        };
                        com2.Parameters.Add(new SqlParameter("@img", ConverterImagem.GetBytes(pb_imagem.Image)));
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Ingrediente registado com sucesso!!");
                        this.Close();

                    }
                    else
                    {
                        SqlCommand com2 = new SqlCommand
                        {
                            CommandText = "UPDATE tb_ingrediente SET nome = '" + txt_nome.Text + "', un_medida = '" + cb_medida.Text + "', valor_medio = '" + txt_preco.Text + "', quantidade = '" + txt_quantidade.Text + "', fornecedor = '" + txt_fornecedor.Text + "', categoria = '" + cb_categoria.Text + "', data_actualização = '" + DateTime.Now.ToString() + "', actualizado_por = '" + d.Id + "', imagem = 'img' WHERE id_ingrediente = '" + int.Parse(txt_id.Text) + "'",
                            Connection = con.SaberConexao(),
                        };
                        com2.Parameters.Add(new SqlParameter("@img", ConverterImagem.GetBytes(pb_imagem.Image)));
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Ingrediente registado com sucesso!!");
                        this.Close();
                    }
                }
            }
            con.fechar();
        }
        
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormularioIngrediente_Load(object sender, EventArgs e)
        {
            if(flag == 0)
            {
                p_ra.Visible = false;
            }
            else
            {
                p_ra.Visible = true;
            }
        }
    }
}
