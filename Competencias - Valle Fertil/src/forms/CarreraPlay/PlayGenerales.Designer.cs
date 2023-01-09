namespace Competencias___Valle_Fertil
{
    partial class PlayGenerales
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
            this.TiempoNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arranque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Penalizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Atasco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.TiempoNeto,
            this.Categoria});
            this.dataGridView1.Location = new System.Drawing.Point(16, 174);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(504, 341);
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
            // TiempoNeto
            // 
            this.TiempoNeto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TiempoNeto.HeaderText = "Tiempo Neto";
            this.TiempoNeto.Name = "TiempoNeto";
            this.TiempoNeto.ReadOnly = true;
            this.TiempoNeto.Width = 134;
            // 
            // Categoria
            // 
            this.Categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 149);
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
            this.button4.Location = new System.Drawing.Point(528, 584);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(271, 44);
            this.button4.TabIndex = 24;
            this.button4.Text = "PDF";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(528, 174);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(271, 44);
            this.button2.TabIndex = 26;
            this.button2.Text = "Detalle Piloto";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.Arranque,
            this.Freno,
            this.Penalizacion,
            this.Atasco});
            this.dataGridView2.Location = new System.Drawing.Point(18, 544);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(504, 84);
            this.dataGridView2.TabIndex = 29;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
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
            // Atasco
            // 
            this.Atasco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Atasco.HeaderText = "Atasco";
            this.Atasco.Name = "Atasco";
            this.Atasco.ReadOnly = true;
            this.Atasco.Width = 90;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 21);
            this.label4.TabIndex = 31;
            this.label4.Text = "Nro Vehiculo:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(139, 99);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 27);
            this.numericUpDown1.TabIndex = 32;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.OliveDrab;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(274, 93);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 34);
            this.button3.TabIndex = 33;
            this.button3.Text = "Q";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(528, 404);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 44);
            this.button1.TabIndex = 34;
            this.button1.Text = "PDF Pilotos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(528, 471);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(271, 44);
            this.button5.TabIndex = 35;
            this.button5.Text = "PDF Radios";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.Color.SlateBlue;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(528, 257);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(271, 128);
            this.listBox1.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(527, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 21);
            this.label5.TabIndex = 37;
            this.label5.Text = "Incompletos:";
            // 
            // PlayGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(57)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(812, 641);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
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
            this.Name = "PlayGenerales";
            this.Text = "PlayArranque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PlayGenerales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private DataGridView dataGridView1;
        private Label label1;
        private Button button4;
        private Button button2;
        private DataGridView dataGridView2;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private Button button3;
        private Button button1;
        private Button button5;
        private ListBox listBox1;
        private DataGridViewTextBoxColumn Posicion;
        private DataGridViewTextBoxColumn Vehiculo;
        private DataGridViewTextBoxColumn Piloto;
        private DataGridViewTextBoxColumn TiempoNeto;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Arranque;
        private DataGridViewTextBoxColumn Freno;
        private DataGridViewTextBoxColumn Penalizacion;
        private DataGridViewTextBoxColumn Atasco;
        private Label label5;
    }
}