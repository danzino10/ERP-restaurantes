using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Local_Money
{
    public partial class btn_takwaway : Form
    {
        public int Id;
        public string Nome, Email;
        private Form janelaAberta = null;
        public btn_takwaway()
        {
            InitializeComponent();
            CostumizarDesign();
        }

        private void CostumizarDesign() 
        {
            p_sub_pedidos.Visible = false;
            p_sub_takeaway.Visible = false;
            p_sub_pessoal.Visible = false;
            p_sub_clientes.Visible = false;
        }

         private void EsconderSubmenu()
        {
            if (p_sub_pedidos.Visible == true)
                p_sub_pedidos.Visible = false;
            if (p_sub_takeaway.Visible == true)
                p_sub_takeaway.Visible = false;
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

        private void AbrirJanela(Form janela)
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
            AbrirJanela(new PedidoNovo());
            //
            //
            EsconderSubmenu();
        }

        private void btn_alterar_pedido_Click(object sender, EventArgs e)
        {
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

        private void btn_take_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(p_sub_takeaway);
        }

        private void btn_novo_takeaway_Click(object sender, EventArgs e)
        {
            //
            //
            EsconderSubmenu();
        }

        private void btn_alterar_takeaway_Click(object sender, EventArgs e)
        {
            //
            //
            EsconderSubmenu();
        }

        private void btn_ver_takeaway_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_tarefas_Click(object sender, EventArgs e)
        {
            //
            //
            EsconderSubmenu();
        }

        


        


    }
}
