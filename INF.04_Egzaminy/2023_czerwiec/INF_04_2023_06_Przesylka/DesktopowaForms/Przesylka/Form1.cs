using Przesylka.Properties;

namespace Przesylka
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
		}

		private void SprawdzCene_ButtonClicked(object sender, EventArgs e)
		{
			if (rbPaczka.Checked)
			{
				obrazPrzesylki.Image = Resources.paczka;
				lbCenaPrzesylki.Text = "Cena: 10 z³";
			}
			else if (rbPocztowka.Checked) 
			{
				obrazPrzesylki.Image = Resources.pocztowka;
				lbCenaPrzesylki.Text = "Cena: 1 z³";
			}
            else if(rbList.Checked)
            {
                obrazPrzesylki.Image= Resources.list;
				lbCenaPrzesylki.Text = "Cena: 1,5 z³";
			}
        }

		private void Zatwierdz_ButtonClicked(object sender, EventArgs e)
		{
			string kodPocztowy = tbKodPocztowy.Text.Trim();

			if(kodPocztowy.Length != 5)
			{
				MessageBox.Show("Nieprawid³owa liczba cyfr w kodzie pocztowym");
			}
			else if(!SprawdzCzyCyfry(kodPocztowy))
			{
				MessageBox.Show("Kod pocztowy powinien siê sk³adaæ z samych cyfr");
			}
			else
			{
				MessageBox.Show("Dane przesy³ki zosta³y wprowadzone");
			}
		}

		private bool SprawdzCzyCyfry(string txtCyfry)
		{
			for(int i = 0; i < txtCyfry.Length; i++)
			{
				if (!char.IsDigit(txtCyfry[i]))
					return false;
			}
			return true;
		}
	}
}
