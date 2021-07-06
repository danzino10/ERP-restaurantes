using System;
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

        public double dinheiro;
        public int clientes;

        public frm_dashboard()
        {
            InitializeComponent();
            CostumizarDesign();
        }

        private void CostumizarDesign() 
        {
            p_sub_pedidos.Visible = false;
            p_sub_pessoal.Visible = false;
            p_sub_clientes.Visible = false;
        }

         private void EsconderSubmenu()
        {
            if (p_sub_pedidos.Visible == true)
                p_sub_pedidos.Visible = false;
            
            if (p_sub_clientes.Visible == true)
                p_sub_clientes.Visible = false;
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

        private void btn_perfil_Click(object sender, EventArgs e)
        {

            //
            //
            EsconderSubmenu();
        }

        private void btn_chat_Click(object sender, EventArgs e)
        {
            AbrirJanela(new PessoalRelatorios());
            //
            //
            EsconderSubmenu();
        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(p_sub_clientes);
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


       

        private void btn_tarefas_Click(object sender, EventArgs e)
        {
            AbrirJanela(new PessoalTarefas());

            //
            //
            EsconderSubmenu();
        }

        int h = 0, m = 0, s = 0;

        private void frm_dashboard_Load(object sender, EventArgs e)
        {
            if (NivelAcesso == 2)
            {
                p_sub_pessoal.Controls.Remove(btn_perfil);
                p_sub_clientes.Controls.Remove(btn_registar);
                p_sub_clientes.Controls.Remove(btn_editar);


            }
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
