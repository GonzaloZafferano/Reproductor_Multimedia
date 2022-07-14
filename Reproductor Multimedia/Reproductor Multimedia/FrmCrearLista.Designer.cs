
namespace Reproductor_Multimedia
{
    partial class FrmCrearLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrearLista));
            this.txtNombreLista = new System.Windows.Forms.TextBox();
            this.lblNombreLista = new System.Windows.Forms.Label();
            this.btnCrearLista = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNombreLista
            // 
            this.txtNombreLista.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreLista.Location = new System.Drawing.Point(13, 44);
            this.txtNombreLista.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreLista.MaxLength = 20;
            this.txtNombreLista.Name = "txtNombreLista";
            this.txtNombreLista.Size = new System.Drawing.Size(356, 29);
            this.txtNombreLista.TabIndex = 0;
            // 
            // lblNombreLista
            // 
            this.lblNombreLista.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreLista.Location = new System.Drawing.Point(9, 7);
            this.lblNombreLista.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreLista.Name = "lblNombreLista";
            this.lblNombreLista.Size = new System.Drawing.Size(358, 34);
            this.lblNombreLista.TabIndex = 1;
            this.lblNombreLista.Text = "Ingrese un nombre para la lista:";
            // 
            // btnCrearLista
            // 
            this.btnCrearLista.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearLista.Location = new System.Drawing.Point(253, 89);
            this.btnCrearLista.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrearLista.Name = "btnCrearLista";
            this.btnCrearLista.Size = new System.Drawing.Size(115, 37);
            this.btnCrearLista.TabIndex = 2;
            this.btnCrearLista.Text = "Confirmar";
            this.btnCrearLista.UseVisualStyleBackColor = true;
            this.btnCrearLista.Click += new System.EventHandler(this.btnCrearLista_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(13, 89);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 37);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmCrearLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 138);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCrearLista);
            this.Controls.Add(this.lblNombreLista);
            this.Controls.Add(this.txtNombreLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmCrearLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu: Creación de lista";
            this.Load += new System.EventHandler(this.FrmCrearLista_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreLista;
        private System.Windows.Forms.Label lblNombreLista;
        private System.Windows.Forms.Button btnCrearLista;
        private System.Windows.Forms.Button btnCancelar;
    }
}