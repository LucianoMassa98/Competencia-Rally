namespace Competencias___Valle_Fertil
{
    partial class PlayPosiciones
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
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Posicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piloto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Multa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Neto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arranque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penalizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(150, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(572, 41);
            this.label2.TabIndex = 13;
            this.label2.Text = "Posiciones de la  carrera: XXXXX";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Posicion,
            this.Vehiculo,
            this.Piloto,
            this.Multa,
            this.Neto,
            this.Total});
            this.dataGridView1.Location = new System.Drawing.Point(16, 137);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(562, 358);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // Posicion
            // 
            this.Posicion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Posicion.HeaderText = "Posicion";
            this.Posicion.Name = "Posicion";
            this.Posicion.ReadOnly = true;
            this.Posicion.Width = 99;
            // 
            // Vehiculo
            // 
            this.Vehiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Vehiculo.HeaderText = "Vehiculo";
            this.Vehiculo.Name = "Vehiculo";
            this.Vehiculo.ReadOnly = true;
            this.Vehiculo.Width = 104;
            // 
            // Piloto
            // 
            this.Piloto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Piloto.HeaderText = "Piloto";
            this.Piloto.Name = "Piloto";
            this.Piloto.ReadOnly = true;
            this.Piloto.Width = 77;
            // 
            // Multa
            // 
            this.Multa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Multa.HeaderText = "Penalización";
            this.Multa.Name = "Multa";
            this.Multa.ReadOnly = true;
            this.Multa.Width = 135;
            // 
            // Neto
            // 
            this.Neto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Neto.HeaderText = "Neto";
            this.Neto.Name = "Neto";
            this.Neto.ReadOnly = true;
            this.Neto.Width = 73;
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 22;
            this.label1.Text = "Fecha Inicio:";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(528, 589);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(271, 44);
            this.button4.TabIndex = 24;
            this.button4.Text = "PDF";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(596, 137);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 41);
            this.button2.TabIndex = 26;
            this.button2.Text = "Detalle Piloto";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 519);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 28;
            this.label3.Text = "Detalles";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.Arranque,
            this.Freno,
            this.Penalizacion});
            this.dataGridView2.Location = new System.Drawing.Point(16, 544);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(504, 89);
            this.dataGridView2.TabIndex = 29;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Vehiculo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 104;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Ronda";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 86;
            // 
            // Arranque
            // 
            this.Arranque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Arranque.HeaderText = "Arranque";
            this.Arranque.Name = "Arranque";
            this.Arranque.ReadOnly = true;
            this.Arranque.Width = 109;
            // 
            // Freno
            // 
            this.Freno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Freno.HeaderText = "Freno";
            this.Freno.Name = "Freno";
            this.Freno.ReadOnly = true;
            this.Freno.Width = 78;
            // 
            // Penalizacion
            // 
            this.Penalizacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Penalizacion.HeaderText = "Penalizacion";
            this.Penalizacion.Name = "Penalizacion";
            this.Penalizacion.ReadOnly = true;
            this.Penalizacion.Width = 135;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(596, 454);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(203, 41);
            this.button3.TabIndex = 30;
            this.button3.Text = "Completar Ronda";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PlayPosiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(57)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(812, 646);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlayPosiciones";
            this.Text = "PlayArranque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PlayPosiciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private DataGridView dataGridView1;
        private Label label1;
        private Button button4;
        private Button button2;
        private Label label3;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Arranque;
        private DataGridViewTextBoxColumn Freno;
        private DataGridViewTextBoxColumn Penalizacion;
        private Button button3;
        private DataGridViewTextBoxColumn Posicion;
        private DataGridViewTextBoxColumn Vehiculo;
        private DataGridViewTextBoxColumn Piloto;
        private DataGridViewTextBoxColumn Multa;
        private DataGridViewTextBoxColumn Neto;
        private DataGridViewTextBoxColumn Total;
    }
}