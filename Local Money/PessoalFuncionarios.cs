using Local_Money.objectos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Local_Money
{
    public partial class PessoalFuncionarios : Form
    {
        Conexao con = new Conexao();
        public PessoalFuncionarios()
        {
            InitializeComponent();
        }


        private void PessoalFuncionarios_Load(object sender, EventArgs e)
        {
            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_user",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            int i = 0;
            string cargo;
            while(reader.Read())
            {
                if(reader.GetInt32(5) == 1)
                {
                    cargo = "Gerente";
                }
                else if (reader.GetInt32(5) == 2)
                {
                    cargo = "Garçom";
                }
                else if (reader.GetInt32(5) == 3)
                {
                    cargo = "Caixa";
                }
                else
                {
                    cargo = "Operador";
                }
                FuncionarioListado fl = new FuncionarioListado(int.Parse(reader.GetValue(0).ToString()), reader.GetString(1), cargo, reader.GetValue(9).ToString(), reader.GetValue(10).ToString());
                flp_funcionario_listado.Controls.Add(fl.Criar());
            }
            con.fechar();
        }

        private void txt_pesquisar_TextChanged(object sender, EventArgs e)
        {
            txt_pesquisar.Text = "";
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            frm_dashboard d = (frm_dashboard)Application.OpenForms[1];
            d.AbrirJanela(new FormularioUsuario());
        }
    }
}
