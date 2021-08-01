using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Local_Money
{
    public partial class frm_dashboard : Form
    {
        public int Id;
        public string Nome;
        public string Email;
        public int NivelAcesso;
        public string data;
        private Form janelaAberta = null;
        public int metaClientes;
        public double metaDinheiro;
        public double dinheiro;
        public int clientes;

        Conexao con = new Conexao();
        public frm_dashboard()
        {
            InitializeComponent();
            CostumizarDesign();
        }

        private void CostumizarDesign() 
        {
            p_sub_pedidos.Visible = false;
            p_sub_pessoal.Visible = false;
            p_sub_restaurante.Visible = false;
        }

         private void EsconderSubmenu()
        {
            if (p_sub_pedidos.Visible == true)
                p_sub_pedidos.Visible = false;
            
            if (p_sub_restaurante.Visible == true)
                p_sub_restaurante.Visible = false;
            if (p_sub_pessoal.Visible == true)
                p_sub_pessoal.Visible = false;
        }

        private void MostrarSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                EsconderSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        public void AbrirJanela(Form janela)
        {
            if(janelaAberta != null)
            {
                janelaAberta.Close();
            }
            janelaAberta = janela;
            janela.TopLevel = false;
            janela.FormBorderStyle = FormBorderStyle.None;
            janela.Dock = DockStyle.Fill;
            p_janela.Controls.Add(janela);
            janela.BringToFront();
            janela.Show();
        }

        private void btn_pedidos_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(p_sub_pedidos);
        }

        private void btn_novo_pedido_Click(object sender, EventArgs e)
        {
            PedidoNovo pn = new PedidoNovo();
            if (janelaAberta != null)
            {
                janelaAberta.Close();
            }
            janelaAberta = pn;
            pn.mesa = 0;
            pn.TopLevel = false;
            pn.FormBorderStyle = FormBorderStyle.None;
            pn.Dock = DockStyle.Fill;
            p_janela.Controls.Add(pn);
            pn.BringToFront();
            pn.Show();

            lbl_pagina.Text = "Pedido Novo";
            //
            //
            EsconderSubmenu();
        }

        private void btn_alterar_pedido_Click(object sender, EventArgs e)
        {
            AbrirJanela(new PedidoAlterar());
            //
            //
            EsconderSubmenu();
        }

        private void btn_ver_pedido_Click(object sender, EventArgs e)
        {
            //
            //
            EsconderSubmenu();
        }
        
        private void btn_desempenho_Click(object sender, EventArgs e)
        {
            //
            //
        }

        private void btn_pessoal_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(p_sub_pessoal);
        }

        

        private void btn_chat_Click(object sender, EventArgs e)
        {
            AbrirJanela(new PessoalRelatorios());
            //
            //
            EsconderSubmenu();
            lbl_pagina.Text = "Relatórios";
        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "UPDATE tb_user SET ultimo_logout = '" + DateTime.Now.ToString() + "' WHERE id_user = '" + Id + "'",
                Connection = con.SaberConexao()
            };
            com.ExecuteNonQuery();
            con.fechar();

            Application.Exit();
        }


       

        private void btn_tarefas_Click(object sender, EventArgs e)
        {
            AbrirJanela(new PessoalTarefas());

            //
            //
            EsconderSubmenu();
            lbl_pagina.Text = "Tarefas";
        }

        

        private void btn_Restaurante_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(p_sub_restaurante);

        }

        private void btn_funcionarios_Click(object sender, EventArgs e)
        {
            AbrirJanela(new PessoalFuncionarios());
            EsconderSubmenu();
            lbl_pagina.Text = "Funcionários";
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            AbrirJanela(new RestauranteMenu());
            EsconderSubmenu();
            lbl_pagina.Text = "Menu";
        }

        private void frm_dashboard_Load(object sender, EventArgs e)
        {
            lbl_clientes_meta.Text = metaClientes.ToString();
            lbl_dinheiro_meta.Text = metaDinheiro.ToString();
            lbl_clientes.Text = clientes.ToString();
            lbl_dinheiro.Text = dinheiro.ToString();

            if (NivelAcesso != 1)
            {
                p_sub_pessoal.Controls.Remove(btn_funcionarios);
                p_sidemenu.Controls.Remove(btn_Restaurante);
                p_sidemenu.Controls.Remove(p_sub_restaurante);
            }
        }

        int h = 0, m = 0, s = 0;

        private void btn_info_Click(object sender, EventArgs e)
        {
            AbrirJanela(new RestauranteInformacoes());

            lbl_pagina.Text = "Informações";
            EsconderSubmenu();

        }

        private void btn_ingredientes_Click(object sender, EventArgs e)
        {
            AbrirJanela(new RestauranteIngredientes());
            EsconderSubmenu();
            lbl_pagina.Text = "Ingredientes";
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            s++;
            if(s == 60)
            {
                m++;
                s = 0;
            }

            if (m == 60)
            {
                h++;
                m = 0;
            }

            if (s < 10 && m < 10 && h < 10)
            {
                lbl_timer.Text = h + "0:0" + m + ":0" + s;
            }
            else if(s < 10 && m < 10)
            {
                lbl_timer.Text = h + ":0" + m + ":0" + s;
            }
            else if (s < 10 && h < 10)
            {
                lbl_timer.Text = h + "0:" + m + ":0" + s;
            }
            else if (h < 10 && m < 10)
            {
                lbl_timer.Text = h + "0:0" + m + ":" + s;
            }
            else if (s < 10)
            {
                lbl_timer.Text = h + ":" + m + ":0" + s;
            }
            else if (m < 10)
            {
                lbl_timer.Text = h + ":0" + m + ":" + s;
            }
            else if (h < 10)
            {
                lbl_timer.Text = h + "0:" + m + ":" + s;
            }
        }
    }
}
