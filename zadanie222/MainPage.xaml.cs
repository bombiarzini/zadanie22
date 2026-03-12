

namespace zadanie222
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        public void OnEmailTextChanged(object sender, TextChangedEventArgs e)
        {
            var email = EmailEntry.Text;
            if (email.Contains("@") && email.Contains(".") && !string.IsNullOrWhiteSpace(email))
            {

                EmailErrorLabel.IsVisible = false;
            }
            else
            {
                EmailErrorLabel.IsVisible = true;


            }


            if (EmailErrorLabel.IsVisible == true || PasswordErrorLabel.IsVisible == true)
            {
                LoginButton.Background = Colors.Grey;
            }
            else
            {
                LoginButton.Background = Colors.Green;
            }
        }


        public void OnPasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            var password = PasswordEntry.Text;
            if (password.Length >= 6 && !string.IsNullOrWhiteSpace(password))
            {
                PasswordErrorLabel.IsVisible = false;
            }
            else
            {
                PasswordErrorLabel.IsVisible = true;

            }


            if (EmailErrorLabel.IsVisible == true || PasswordErrorLabel.IsVisible == true)
            {
                LoginButton.Background = Colors.Grey;
            }

            else
            {
                LoginButton.Background = Colors.Green;
            }
        }
        public void OnLoginClicked(object sender, EventArgs e)
        {
            if(EmailErrorLabel.IsVisible == false && PasswordErrorLabel.IsVisible == false)
            {
                DisplayAlert("Login", "gicio!", "OK");
            }
            else
            {
                DisplayAlert("Login", "nie gicio!", "nie OK");
            }
            

        }
    }
}
