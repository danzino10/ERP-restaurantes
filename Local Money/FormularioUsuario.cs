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
    public partial class FormularioUsuario : Form
    {
        Conexao con = new Conexao();
        public int flag = 0;
        private int na = 2;
        public FormularioUsuario()
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lbl_count_fornecedor_Click(object sender, EventArgs e)
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
                    CommandText = "SELECT * FROM tb_ingrediente WHERE email = '" + txt_email.Text + "'",
                    Connection = con.SaberConexao(),
                };
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Ja existe um usuário associado a este nome");
                }
                else
                {
                    reader.Close();
                    if (flag == 0)
                    {
                        SqlCommand com2 = new SqlCommand
                        {
                            CommandText = "INSERT INTO tb_user (nome,email,telefone,saldo,nivel_acesso,password,data_hora_registo,imagem) VALUES('" + txt_nome.Text + "','" + txt_email.Text + "','" + txt_telefone.Text + "','0','" + na + "','" + txt_pass.Text + "','" + DateTime.Now.ToString() + "','img')",
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
                            CommandText = "UPDATE tb_user SET nome = '" + txt_nome.Text + "', email = '" + txt_email.Text + "', telefone = '" + txt_telefone.Text + "', nivel_acesso = '" + na + "', password = '" + txt_pass.Text + "', imagem = 'img' WHERE id_user = '" + int.Parse(txt_id.Text) + "'",
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

        private void cb_nivel_acesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_nivel_acesso.Text == "Administrador")
                na = 0;
            else
                na = 1;
        }

        private void txt_nome_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_count_nome.Text.Split('/');
            lbl_count_nome.Text = txt_nome.Text.Length + "/" + txt_nome.MaxLength;
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_count_email.Text.Split('/');
            lbl_count_email.Text = txt_email.Text.Length + "/" + txt_email.MaxLength;
        }

        private void txt_telefone_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_count_telefone.Text.Split('/');
            lbl_count_telefone.Text = txt_telefone.Text.Length + "/" + txt_telefone.MaxLength;
        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_count_pass.Text.Split('/');
            lbl_count_pass.Text = txt_pass.Text.Length + "/" + txt_pass.MaxLength;
        }

        private void txt_pass2_TextChanged(object sender, EventArgs e)
        {
            string[] s = lbl_count_pass2.Text.Split('/');
            lbl_count_pass2.Text = txt_pass2.Text.Length + "/" + txt_pass2.MaxLength;
        }
    }
}
