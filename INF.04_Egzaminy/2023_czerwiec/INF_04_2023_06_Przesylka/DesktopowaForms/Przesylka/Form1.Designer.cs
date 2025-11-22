namespace Przesylka
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			gBRodzajPrzesylki = new GroupBox();
			rbPaczka = new RadioButton();
			rbList = new RadioButton();
			rbPocztowka = new RadioButton();
			btSprawdzCene = new Button();
			obrazPrzesylki = new PictureBox();
			lbCenaPrzesylki = new Label();
			groupBox1 = new GroupBox();
			tbMiasto = new TextBox();
			label3 = new Label();
			tbKodPocztowy = new TextBox();
			label2 = new Label();
			tbUlicaNumer = new TextBox();
			label1 = new Label();
			btZatwierdz = new Button();
			gBRodzajPrzesylki.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)obrazPrzesylki).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// gBRodzajPrzesylki
			// 
			gBRodzajPrzesylki.Controls.Add(rbPaczka);
			gBRodzajPrzesylki.Controls.Add(rbList);
			gBRodzajPrzesylki.Controls.Add(rbPocztowka);
			gBRodzajPrzesylki.Location = new Point(56, 48);
			gBRodzajPrzesylki.Name = "gBRodzajPrzesylki";
			gBRodzajPrzesylki.Size = new Size(266, 152);
			gBRodzajPrzesylki.TabIndex = 0;
			gBRodzajPrzesylki.TabStop = false;
			gBRodzajPrzesylki.Text = "Rodzaj przesyłki";
			// 
			// rbPaczka
			// 
			rbPaczka.AutoSize = true;
			rbPaczka.Location = new Point(19, 108);
			rbPaczka.Name = "rbPaczka";
			rbPaczka.Size = new Size(74, 24);
			rbPaczka.TabIndex = 2;
			rbPaczka.TabStop = true;
			rbPaczka.Text = "Paczka";
			rbPaczka.UseVisualStyleBackColor = true;
			// 
			// rbList
			// 
			rbList.AutoSize = true;
			rbList.Location = new Point(19, 78);
			rbList.Name = "rbList";
			rbList.Size = new Size(52, 24);
			rbList.TabIndex = 1;
			rbList.TabStop = true;
			rbList.Text = "List";
			rbList.UseVisualStyleBackColor = true;
			// 
			// rbPocztowka
			// 
			rbPocztowka.AutoSize = true;
			rbPocztowka.Location = new Point(19, 48);
			rbPocztowka.Name = "rbPocztowka";
			rbPocztowka.Size = new Size(100, 24);
			rbPocztowka.TabIndex = 0;
			rbPocztowka.TabStop = true;
			rbPocztowka.Text = "Pocztówka";
			rbPocztowka.UseVisualStyleBackColor = true;
			// 
			// btSprawdzCene
			// 
			btSprawdzCene.Location = new Point(56, 224);
			btSprawdzCene.Name = "btSprawdzCene";
			btSprawdzCene.Size = new Size(266, 30);
			btSprawdzCene.TabIndex = 1;
			btSprawdzCene.Text = "Sprawdź Cenę";
			btSprawdzCene.UseVisualStyleBackColor = true;
			btSprawdzCene.Click += SprawdzCene_ButtonClicked;
			// 
			// obrazPrzesylki
			// 
			obrazPrzesylki.Image = Properties.Resources.pocztowka;
			obrazPrzesylki.Location = new Point(56, 282);
			obrazPrzesylki.Name = "obrazPrzesylki";
			obrazPrzesylki.Size = new Size(100, 63);
			obrazPrzesylki.SizeMode = PictureBoxSizeMode.StretchImage;
			obrazPrzesylki.TabIndex = 2;
			obrazPrzesylki.TabStop = false;
			// 
			// lbCenaPrzesylki
			// 
			lbCenaPrzesylki.AutoSize = true;
			lbCenaPrzesylki.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			lbCenaPrzesylki.Location = new Point(236, 298);
			lbCenaPrzesylki.Name = "lbCenaPrzesylki";
			lbCenaPrzesylki.Size = new Size(84, 32);
			lbCenaPrzesylki.TabIndex = 3;
			lbCenaPrzesylki.Text = "Cena: ";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(tbMiasto);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(tbKodPocztowy);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(tbUlicaNumer);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new Point(426, 48);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(309, 319);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "Dane adresowe";
			// 
			// tbMiasto
			// 
			tbMiasto.Location = new Point(25, 235);
			tbMiasto.Name = "tbMiasto";
			tbMiasto.Size = new Size(265, 27);
			tbMiasto.TabIndex = 5;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(34, 212);
			label3.Name = "label3";
			label3.Size = new Size(54, 20);
			label3.TabIndex = 4;
			label3.Text = "Miasto";
			// 
			// tbKodPocztowy
			// 
			tbKodPocztowy.Location = new Point(24, 155);
			tbKodPocztowy.Name = "tbKodPocztowy";
			tbKodPocztowy.Size = new Size(155, 27);
			tbKodPocztowy.TabIndex = 3;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(25, 132);
			label2.Name = "label2";
			label2.Size = new Size(104, 20);
			label2.TabIndex = 2;
			label2.Text = "Kod pocztowy";
			// 
			// tbUlicaNumer
			// 
			tbUlicaNumer.Location = new Point(24, 67);
			tbUlicaNumer.Name = "tbUlicaNumer";
			tbUlicaNumer.Size = new Size(265, 27);
			tbUlicaNumer.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(25, 44);
			label1.Name = "label1";
			label1.Size = new Size(120, 20);
			label1.TabIndex = 0;
			label1.Text = "Ulica z numerem";
			// 
			// btZatwierdz
			// 
			btZatwierdz.Location = new Point(54, 396);
			btZatwierdz.Name = "btZatwierdz";
			btZatwierdz.Size = new Size(681, 29);
			btZatwierdz.TabIndex = 5;
			btZatwierdz.Text = "Zatwierdż";
			btZatwierdz.UseVisualStyleBackColor = true;
			btZatwierdz.Click += Zatwierdz_ButtonClicked;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btZatwierdz);
			Controls.Add(groupBox1);
			Controls.Add(lbCenaPrzesylki);
			Controls.Add(obrazPrzesylki);
			Controls.Add(btSprawdzCene);
			Controls.Add(gBRodzajPrzesylki);
			Name = "Form1";
			Text = "Nadaj Przesyłkę, PESEL: 00000000000";
			gBRodzajPrzesylki.ResumeLayout(false);
			gBRodzajPrzesylki.PerformLayout();
			((System.ComponentModel.ISupportInitialize)obrazPrzesylki).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox gBRodzajPrzesylki;
		private RadioButton rbPaczka;
		private RadioButton rbList;
		private RadioButton rbPocztowka;
		private Button btSprawdzCene;
		private PictureBox obrazPrzesylki;
		private Label lbCenaPrzesylki;
		private GroupBox groupBox1;
		private TextBox tbUlicaNumer;
		private Label label1;
		private TextBox tbMiasto;
		private Label label3;
		private TextBox tbKodPocztowy;
		private Label label2;
		private Button btZatwierdz;
	}
}
