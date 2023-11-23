namespace kalkulator
{
    public partial class MainPage : ContentPage
    {
        double liczba1, liczba2;
        char op;
        public MainPage()
        {
            InitializeComponent();
        }

        private void WriteNumber_Cliked(object sender, EventArgs e)
        {
            string number = ((Button)sender).Text;

            if (out1.Text == "0" || out1.Text == "Prime" || out1.Text == "Not prime")
                out1.Text = number;
            else
                out1.Text += number;
        }

        private void usun_dzialanie(object sender, EventArgs e)
        {
            out1.Text = "0";
            out2.Text = String.Empty;
        }

        private void oblicz(object sender, EventArgs e)
        {
            out2.Text += out1.Text;

            liczba2 = Convert.ToDouble(out1.Text);

            double w = 0;
            switch (op)
            {
                case '+':
                    w = liczba1 + liczba2;
                    break;
                case '-':
                    w = liczba1 - liczba2;
                    break;
                case '*':
                    w = liczba1 * liczba2;
                    break;
                case '/':
                    try
                    {
                        w = liczba1 / liczba2;
                    }
                    catch
                    {
                        out1.Text = "Cannot divide by 0";
                    }
                    break;
                case '^':
                    w = Math.Pow(liczba1, liczba2);
                    break;
                case '&':
                    out2.Text = $"GCD({liczba1},{liczba2})";

                    while (liczba1 != liczba2)
                        if (liczba1 > liczba2)
                            liczba1 -= liczba2;
                        else
                            liczba2 -= liczba1;

                    w = liczba1;
                    break;
            }

            out1.Text = w.ToString();
            out2.Text += " = " + w.ToString();
        }

        private void plus(object sender, EventArgs e)
        {
            out2.Text = out1.Text + " + ";
            liczba1 = Convert.ToDouble(out1.Text);
            op = '+';
            out1.Text = "0";
        }

        private void minus(object sender, EventArgs e)
        {
            out2.Text = out1.Text + " - ";
            liczba1 = Convert.ToDouble(out1.Text);
            op = '-';
            out1.Text = "0";
        }

        private void razy(object sender, EventArgs e)
        {
            out2.Text = out1.Text + " * ";
            liczba1 = Convert.ToDouble(out1.Text);
            op = '*';
            out1.Text = "0";
        }

        private void dzielienie(object sender, EventArgs e)
        {
            out2.Text = out1.Text + " / ";
            liczba1 = Convert.ToDouble(out1.Text);
            op = '/';
            out1.Text = "0";
        }

        private void pierwiastek(object sender, EventArgs e)
        {
            double liczba = Convert.ToDouble(out1.Text);
            liczba = Math.Sqrt(liczba);

            out2.Text = $"sqrt({out1.Text}) = {liczba.ToString()}";
            out1.Text = liczba.ToString();
        }

        private void GCD(object sender, EventArgs e)
        {
            liczba1 = Convert.ToDouble(out1.Text);
            out2.Text = $"GCD({liczba1})";
            op = '&';
            out1.Text = "0";
        }

        private bool czyPierwsza(int liczba)
        {
            if (liczba == 0 || liczba == 1)
                return false;

            for (int i = 2; i < liczba; i++)
                if (liczba % i == 0)
                    return false;

            return true;
        }

        private void prime(object sender, EventArgs e)
        {
            int liczba = Convert.ToInt32(out1.Text);
            out2.Text = $"isPrime({liczba.ToString()}) = ";

            if (czyPierwsza(liczba))
            {
                out1.Text = "Prime";
                out2.Text += "true";
            } 
            else
            {
                out1.Text = "Not prime";
                out2.Text += "false";
            }
        }

        private void potega(object sender, EventArgs e)
        {
            out2.Text = out1.Text + "^";
            liczba1 = Convert.ToDouble(out1.Text);
            op = '^';
            out1.Text = "0";
        }
    }
}