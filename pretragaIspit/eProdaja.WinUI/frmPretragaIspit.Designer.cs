namespace eProdaja.WinUI
{
    partial class frmPretragaIspit
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
            this.txtMinIznos = new System.Windows.Forms.TextBox();
            this.dtpDO = new System.Windows.Forms.DateTimePicker();
            this.dtpOD = new System.Windows.Forms.DateTimePicker();
            this.cbVrstaProizvoda = new System.Windows.Forms.ComboBox();
            this.dgvPretraga = new System.Windows.Forms.DataGridView();
            this.btnTrazi = new System.Windows.Forms.Button();
            this.btnSpasi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSuma = new System.Windows.Forms.Label();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UkupanPromet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPretraga)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMinIznos
            // 
            this.txtMinIznos.Location = new System.Drawing.Point(646, 40);
            this.txtMinIznos.Name = "txtMinIznos";
            this.txtMinIznos.Size = new System.Drawing.Size(125, 27);
            this.txtMinIznos.TabIndex = 0;
            this.txtMinIznos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinIznos_KeyPress);
            // 
            // dtpDO
            // 
            this.dtpDO.Location = new System.Drawing.Point(449, 41);
            this.dtpDO.Name = "dtpDO";
            this.dtpDO.Size = new System.Drawing.Size(146, 27);
            this.dtpDO.TabIndex = 1;
            // 
            // dtpOD
            // 
            this.dtpOD.Location = new System.Drawing.Point(253, 40);
            this.dtpOD.Name = "dtpOD";
            this.dtpOD.Size = new System.Drawing.Size(146, 27);
            this.dtpOD.TabIndex = 2;
            this.dtpOD.Value = new System.DateTime(2022, 6, 22, 0, 0, 0, 0);
            // 
            // cbVrstaProizvoda
            // 
            this.cbVrstaProizvoda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVrstaProizvoda.FormattingEnabled = true;
            this.cbVrstaProizvoda.Location = new System.Drawing.Point(41, 40);
            this.cbVrstaProizvoda.Name = "cbVrstaProizvoda";
            this.cbVrstaProizvoda.Size = new System.Drawing.Size(151, 28);
            this.cbVrstaProizvoda.TabIndex = 3;
            this.cbVrstaProizvoda.SelectedIndexChanged += new System.EventHandler(this.cbVrstaProizvoda_SelectedIndexChanged);
            // 
            // dgvPretraga
            // 
            this.dgvPretraga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPretraga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ime,
            this.UkupanPromet});
            this.dgvPretraga.Location = new System.Drawing.Point(41, 132);
            this.dgvPretraga.Name = "dgvPretraga";
            this.dgvPretraga.RowHeadersWidth = 51;
            this.dgvPretraga.RowTemplate.Height = 29;
            this.dgvPretraga.Size = new System.Drawing.Size(730, 251);
            this.dgvPretraga.TabIndex = 4;
            // 
            // btnTrazi
            // 
            this.btnTrazi.Location = new System.Drawing.Point(646, 85);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(125, 29);
            this.btnTrazi.TabIndex = 5;
            this.btnTrazi.Text = "Traži";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // btnSpasi
            // 
            this.btnSpasi.Location = new System.Drawing.Point(594, 400);
            this.btnSpasi.Name = "btnSpasi";
            this.btnSpasi.Size = new System.Drawing.Size(177, 29);
            this.btnSpasi.TabIndex = 6;
            this.btnSpasi.Text = "Spasi rezultate";
            this.btnSpasi.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vrsta proizvoda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "OD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "DO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(646, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "min iznos";
            // 
            // lblSuma
            // 
            this.lblSuma.AutoSize = true;
            this.lblSuma.Location = new System.Drawing.Point(41, 409);
            this.lblSuma.Name = "lblSuma";
            this.lblSuma.Size = new System.Drawing.Size(0, 20);
            this.lblSuma.TabIndex = 11;
            // 
            // Ime
            // 
            this.Ime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime i prezime";
            this.Ime.MinimumWidth = 6;
            this.Ime.Name = "Ime";
            // 
            // UkupanPromet
            // 
            this.UkupanPromet.DataPropertyName = "Promet";
            this.UkupanPromet.HeaderText = "UkupanPromet";
            this.UkupanPromet.MinimumWidth = 6;
            this.UkupanPromet.Name = "UkupanPromet";
            this.UkupanPromet.Width = 125;
            // 
            // frmPretragaIspit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSuma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSpasi);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.dgvPretraga);
            this.Controls.Add(this.cbVrstaProizvoda);
            this.Controls.Add(this.dtpOD);
            this.Controls.Add(this.dtpDO);
            this.Controls.Add(this.txtMinIznos);
            this.Name = "frmPretragaIspit";
            this.Text = "frmPretragaIspit";
            this.Load += new System.EventHandler(this.frmPretragaIspit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPretraga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtMinIznos;
        private DateTimePicker dtpDO;
        private DateTimePicker dtpOD;
        private ComboBox cbVrstaProizvoda;
        private DataGridView dgvPretraga;
        private Button btnTrazi;
        private Button btnSpasi;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblSuma;
        private DataGridViewTextBoxColumn Ime;
        private DataGridViewTextBoxColumn UkupanPromet;
    }
}