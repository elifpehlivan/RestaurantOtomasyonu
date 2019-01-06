namespace MELM
{
    partial class frmRaporlar
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gbIstatistik = new System.Windows.Forms.GroupBox();
            this.lblBaslangıc = new System.Windows.Forms.Label();
            this.dtBaslangıc = new System.Windows.Forms.DateTimePicker();
            this.dtBitis = new System.Windows.Forms.DateTimePicker();
            this.lblBitis = new System.Windows.Forms.Label();
            this.grpMenuBaslik = new System.Windows.Forms.GroupBox();
            this.btnAnaYemek1 = new System.Windows.Forms.Button();
            this.btnİçecekler8 = new System.Windows.Forms.Button();
            this.btnTatlılar7 = new System.Windows.Forms.Button();
            this.btnSalatalar6 = new System.Windows.Forms.Button();
            this.btnFastFood5 = new System.Windows.Forms.Button();
            this.btnÇorbalar2 = new System.Windows.Forms.Button();
            this.btnMakarnalar4 = new System.Windows.Forms.Button();
            this.btnAraSıcaklar3 = new System.Windows.Forms.Button();
            this.chRapor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lvIstatistik = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnZRaporu = new System.Windows.Forms.Button();
            this.btnCıkıs = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.gbIstatistik.SuspendLayout();
            this.grpMenuBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chRapor)).BeginInit();
            this.SuspendLayout();
            // 
            // gbIstatistik
            // 
            this.gbIstatistik.BackColor = System.Drawing.Color.Transparent;
            this.gbIstatistik.Controls.Add(this.lvIstatistik);
            this.gbIstatistik.Controls.Add(this.chRapor);
            this.gbIstatistik.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbIstatistik.ForeColor = System.Drawing.Color.White;
            this.gbIstatistik.Location = new System.Drawing.Point(325, 89);
            this.gbIstatistik.Name = "gbIstatistik";
            this.gbIstatistik.Size = new System.Drawing.Size(385, 299);
            this.gbIstatistik.TabIndex = 1;
            this.gbIstatistik.TabStop = false;
            // 
            // lblBaslangıc
            // 
            this.lblBaslangıc.AutoSize = true;
            this.lblBaslangıc.BackColor = System.Drawing.Color.Transparent;
            this.lblBaslangıc.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslangıc.ForeColor = System.Drawing.Color.White;
            this.lblBaslangıc.Location = new System.Drawing.Point(335, 19);
            this.lblBaslangıc.Name = "lblBaslangıc";
            this.lblBaslangıc.Size = new System.Drawing.Size(122, 19);
            this.lblBaslangıc.TabIndex = 2;
            this.lblBaslangıc.Text = "Başlangıç Tarihi :";
            // 
            // dtBaslangıc
            // 
            this.dtBaslangıc.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBaslangıc.Location = new System.Drawing.Point(463, 12);
            this.dtBaslangıc.Name = "dtBaslangıc";
            this.dtBaslangıc.Size = new System.Drawing.Size(236, 26);
            this.dtBaslangıc.TabIndex = 4;
            // 
            // dtBitis
            // 
            this.dtBitis.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBitis.Location = new System.Drawing.Point(463, 57);
            this.dtBitis.Name = "dtBitis";
            this.dtBitis.Size = new System.Drawing.Size(236, 26);
            this.dtBitis.TabIndex = 5;
            // 
            // lblBitis
            // 
            this.lblBitis.AutoSize = true;
            this.lblBitis.BackColor = System.Drawing.Color.Transparent;
            this.lblBitis.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBitis.ForeColor = System.Drawing.Color.White;
            this.lblBitis.Location = new System.Drawing.Point(335, 64);
            this.lblBitis.Name = "lblBitis";
            this.lblBitis.Size = new System.Drawing.Size(93, 19);
            this.lblBitis.TabIndex = 6;
            this.lblBitis.Text = "Bitiş Tarihi :";
            // 
            // grpMenuBaslik
            // 
            this.grpMenuBaslik.BackColor = System.Drawing.Color.Transparent;
            this.grpMenuBaslik.Controls.Add(this.btnAraSıcaklar3);
            this.grpMenuBaslik.Controls.Add(this.btnMakarnalar4);
            this.grpMenuBaslik.Controls.Add(this.btnÇorbalar2);
            this.grpMenuBaslik.Controls.Add(this.btnFastFood5);
            this.grpMenuBaslik.Controls.Add(this.btnSalatalar6);
            this.grpMenuBaslik.Controls.Add(this.btnTatlılar7);
            this.grpMenuBaslik.Controls.Add(this.btnİçecekler8);
            this.grpMenuBaslik.Controls.Add(this.btnAnaYemek1);
            this.grpMenuBaslik.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpMenuBaslik.ForeColor = System.Drawing.Color.White;
            this.grpMenuBaslik.Location = new System.Drawing.Point(12, 18);
            this.grpMenuBaslik.Name = "grpMenuBaslik";
            this.grpMenuBaslik.Size = new System.Drawing.Size(307, 370);
            this.grpMenuBaslik.TabIndex = 2;
            this.grpMenuBaslik.TabStop = false;
            this.grpMenuBaslik.Text = "Menü";
            // 
            // btnAnaYemek1
            // 
            this.btnAnaYemek1.BackColor = System.Drawing.Color.Red;
            this.btnAnaYemek1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnaYemek1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnaYemek1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnaYemek1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAnaYemek1.Location = new System.Drawing.Point(0, 24);
            this.btnAnaYemek1.Name = "btnAnaYemek1";
            this.btnAnaYemek1.Size = new System.Drawing.Size(155, 82);
            this.btnAnaYemek1.TabIndex = 0;
            this.btnAnaYemek1.Text = "ANA YEMEK";
            this.btnAnaYemek1.UseVisualStyleBackColor = false;
            this.btnAnaYemek1.Click += new System.EventHandler(this.btnAnaYemek1_Click);
            // 
            // btnİçecekler8
            // 
            this.btnİçecekler8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnİçecekler8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnİçecekler8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnİçecekler8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnİçecekler8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnİçecekler8.Location = new System.Drawing.Point(151, 24);
            this.btnİçecekler8.Name = "btnİçecekler8";
            this.btnİçecekler8.Size = new System.Drawing.Size(155, 82);
            this.btnİçecekler8.TabIndex = 1;
            this.btnİçecekler8.Text = "İÇECEKLER";
            this.btnİçecekler8.UseVisualStyleBackColor = false;
            this.btnİçecekler8.Click += new System.EventHandler(this.btnİçecekler8_Click);
            // 
            // btnTatlılar7
            // 
            this.btnTatlılar7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnTatlılar7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTatlılar7.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTatlılar7.Location = new System.Drawing.Point(0, 112);
            this.btnTatlılar7.Name = "btnTatlılar7";
            this.btnTatlılar7.Size = new System.Drawing.Size(155, 82);
            this.btnTatlılar7.TabIndex = 2;
            this.btnTatlılar7.Text = "TATLILAR";
            this.btnTatlılar7.UseVisualStyleBackColor = false;
            this.btnTatlılar7.Click += new System.EventHandler(this.btnTatlılar7_Click);
            // 
            // btnSalatalar6
            // 
            this.btnSalatalar6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSalatalar6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalatalar6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalatalar6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalatalar6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSalatalar6.Location = new System.Drawing.Point(152, 112);
            this.btnSalatalar6.Name = "btnSalatalar6";
            this.btnSalatalar6.Size = new System.Drawing.Size(155, 82);
            this.btnSalatalar6.TabIndex = 3;
            this.btnSalatalar6.Text = "SALATALAR";
            this.btnSalatalar6.UseVisualStyleBackColor = false;
            this.btnSalatalar6.Click += new System.EventHandler(this.btnSalatalar6_Click);
            // 
            // btnFastFood5
            // 
            this.btnFastFood5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFastFood5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFastFood5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFastFood5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFastFood5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFastFood5.Location = new System.Drawing.Point(0, 200);
            this.btnFastFood5.Name = "btnFastFood5";
            this.btnFastFood5.Size = new System.Drawing.Size(155, 82);
            this.btnFastFood5.TabIndex = 4;
            this.btnFastFood5.Text = "FAST FOODS";
            this.btnFastFood5.UseVisualStyleBackColor = false;
            this.btnFastFood5.Click += new System.EventHandler(this.btnFastFood5_Click);
            // 
            // btnÇorbalar2
            // 
            this.btnÇorbalar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnÇorbalar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnÇorbalar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnÇorbalar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnÇorbalar2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnÇorbalar2.Location = new System.Drawing.Point(151, 200);
            this.btnÇorbalar2.Name = "btnÇorbalar2";
            this.btnÇorbalar2.Size = new System.Drawing.Size(155, 82);
            this.btnÇorbalar2.TabIndex = 5;
            this.btnÇorbalar2.Text = "ÇORBALAR";
            this.btnÇorbalar2.UseVisualStyleBackColor = false;
            this.btnÇorbalar2.Click += new System.EventHandler(this.btnÇorbalar2_Click);
            // 
            // btnMakarnalar4
            // 
            this.btnMakarnalar4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnMakarnalar4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMakarnalar4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMakarnalar4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMakarnalar4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMakarnalar4.Location = new System.Drawing.Point(0, 288);
            this.btnMakarnalar4.Name = "btnMakarnalar4";
            this.btnMakarnalar4.Size = new System.Drawing.Size(155, 82);
            this.btnMakarnalar4.TabIndex = 6;
            this.btnMakarnalar4.Text = "MAKARNALAR";
            this.btnMakarnalar4.UseVisualStyleBackColor = false;
            this.btnMakarnalar4.Click += new System.EventHandler(this.btnMakarnalar4_Click);
            // 
            // btnAraSıcaklar3
            // 
            this.btnAraSıcaklar3.BackColor = System.Drawing.Color.Gray;
            this.btnAraSıcaklar3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAraSıcaklar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAraSıcaklar3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAraSıcaklar3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAraSıcaklar3.Location = new System.Drawing.Point(152, 288);
            this.btnAraSıcaklar3.Name = "btnAraSıcaklar3";
            this.btnAraSıcaklar3.Size = new System.Drawing.Size(155, 82);
            this.btnAraSıcaklar3.TabIndex = 7;
            this.btnAraSıcaklar3.Text = "ARA SICAKLAR";
            this.btnAraSıcaklar3.UseVisualStyleBackColor = false;
            this.btnAraSıcaklar3.Click += new System.EventHandler(this.btnAraSıcaklar3_Click);
            // 
            // chRapor
            // 
            this.chRapor.BackColor = System.Drawing.Color.Transparent;
            this.chRapor.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chRapor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chRapor.Legends.Add(legend1);
            this.chRapor.Location = new System.Drawing.Point(6, 25);
            this.chRapor.Name = "chRapor";
            this.chRapor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.Label = "Satislar";
            series1.Legend = "Legend1";
            series1.Name = "Satislar";
            this.chRapor.Series.Add(series1);
            this.chRapor.Size = new System.Drawing.Size(368, 268);
            this.chRapor.TabIndex = 0;
            this.chRapor.Text = "chart1";
            // 
            // lvIstatistik
            // 
            this.lvIstatistik.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvIstatistik.FullRowSelect = true;
            this.lvIstatistik.GridLines = true;
            this.lvIstatistik.Location = new System.Drawing.Point(360, 9);
            this.lvIstatistik.Name = "lvIstatistik";
            this.lvIstatistik.Size = new System.Drawing.Size(14, 10);
            this.lvIstatistik.TabIndex = 1;
            this.lvIstatistik.UseCompatibleStateImageBehavior = false;
            this.lvIstatistik.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ürün Adı";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Adedi";
            // 
            // btnZRaporu
            // 
            this.btnZRaporu.BackColor = System.Drawing.Color.Yellow;
            this.btnZRaporu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZRaporu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZRaporu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnZRaporu.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnZRaporu.Location = new System.Drawing.Point(164, 395);
            this.btnZRaporu.Name = "btnZRaporu";
            this.btnZRaporu.Size = new System.Drawing.Size(155, 82);
            this.btnZRaporu.TabIndex = 7;
            this.btnZRaporu.Text = "TÜM ÜRÜNLER";
            this.btnZRaporu.UseVisualStyleBackColor = false;
            this.btnZRaporu.Click += new System.EventHandler(this.btnZRaporu_Click);
            // 
            // btnCıkıs
            // 
            this.btnCıkıs.BackColor = System.Drawing.Color.Maroon;
            this.btnCıkıs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCıkıs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCıkıs.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCıkıs.Location = new System.Drawing.Point(631, 448);
            this.btnCıkıs.Name = "btnCıkıs";
            this.btnCıkıs.Size = new System.Drawing.Size(68, 29);
            this.btnCıkıs.TabIndex = 13;
            this.btnCıkıs.Text = "ÇIKIŞ";
            this.btnCıkıs.UseVisualStyleBackColor = false;
            this.btnCıkıs.Click += new System.EventHandler(this.btnCıkıs_Click);
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGeriDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeriDon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeriDon.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeriDon.Location = new System.Drawing.Point(544, 448);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(68, 29);
            this.btnGeriDon.TabIndex = 12;
            this.btnGeriDon.Text = "Geri Dön";
            this.btnGeriDon.UseVisualStyleBackColor = false;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // frmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MELM.Properties.Resources._968_4_49b82beabe300b4bad2da77e78359452;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(711, 489);
            this.Controls.Add(this.btnCıkıs);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.btnZRaporu);
            this.Controls.Add(this.grpMenuBaslik);
            this.Controls.Add(this.lblBitis);
            this.Controls.Add(this.dtBitis);
            this.Controls.Add(this.dtBaslangıc);
            this.Controls.Add(this.lblBaslangıc);
            this.Controls.Add(this.gbIstatistik);
            this.Name = "frmRaporlar";
            this.Text = "frmRaporlar";
            this.gbIstatistik.ResumeLayout(false);
            this.grpMenuBaslik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chRapor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbIstatistik;
        private System.Windows.Forms.Label lblBaslangıc;
        private System.Windows.Forms.DateTimePicker dtBaslangıc;
        private System.Windows.Forms.DateTimePicker dtBitis;
        private System.Windows.Forms.Label lblBitis;
        private System.Windows.Forms.GroupBox grpMenuBaslik;
        private System.Windows.Forms.Button btnAraSıcaklar3;
        private System.Windows.Forms.Button btnMakarnalar4;
        private System.Windows.Forms.Button btnÇorbalar2;
        private System.Windows.Forms.Button btnFastFood5;
        private System.Windows.Forms.Button btnSalatalar6;
        private System.Windows.Forms.Button btnTatlılar7;
        private System.Windows.Forms.Button btnİçecekler8;
        private System.Windows.Forms.Button btnAnaYemek1;
        private System.Windows.Forms.ListView lvIstatistik;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chRapor;
        private System.Windows.Forms.Button btnZRaporu;
        private System.Windows.Forms.Button btnCıkıs;
        private System.Windows.Forms.Button btnGeriDon;
    }
}