
namespace Local_Money
{
    partial class Cardapio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flp_cardapio = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flp_cardapio
            // 
            this.flp_cardapio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_cardapio.Location = new System.Drawing.Point(0, 0);
            this.flp_cardapio.Name = "flp_cardapio";
            this.flp_cardapio.Size = new System.Drawing.Size(635, 450);
            this.flp_cardapio.TabIndex = 0;
            this.flp_cardapio.Paint += new System.Windows.Forms.PaintEventHandler(this.flp_cardapio_Paint);
            // 
            // Cardapio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 450);
            this.Controls.Add(this.flp_cardapio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Cardapio";
            this.Text = "Cardapio";
            this.Load += new System.EventHandler(this.Cardapio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flp_cardapio;
    }
}