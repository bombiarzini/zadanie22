namespace PasswordStrengthApp;



public class PasswordStrengthBehavior : Behavior<Entry>

{

    public static readonly BindableProperty StrengthLabelProperty =

     BindableProperty.Create(

      "StrengthLabel",

      typeof(Label),

      typeof(PasswordStrengthBehavior),

      null);



    public Label StrengthLabel

    {

        get { return (Label)GetValue(StrengthLabelProperty); }

        set { SetValue(StrengthLabelProperty, value); }

    }



    protected override void OnAttachedTo(Entry entry)

    {

        entry.TextChanged += OnEntryTextChanged;

        base.OnAttachedTo(entry);

    }



    protected override void OnDetachingFrom(Entry entry)

    {

        entry.TextChanged -= OnEntryTextChanged;

        base.OnDetachingFrom(entry);

    }



    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)

    {

        string password = e.NewTextValue ?? string.Empty;

        string strength = EvaluatePasswordStrength(password);



        if (StrengthLabel != null)

        {

            StrengthLabel.Text = strength;



            // Zmień kolor w zależności od siły 

            if (strength == "Słabe")

                StrengthLabel.TextColor = Colors.Red;

            else if (strength == "Średnie")

                StrengthLabel.TextColor = Colors.Orange;

            else if (strength == "Silne")

                StrengthLabel.TextColor = Colors.Green;

        }

    }



    private string EvaluatePasswordStrength(string password)

    {

        if (string.IsNullOrEmpty(password))

            return "";



        bool hasDigit = password.Any(c => char.IsDigit(c));

        bool hasUpperCase = password.Any(c => char.IsUpper(c));



        if (password.Length < 8)

            return "Słabe";

        else if (hasDigit && hasUpperCase && password.Length > 7)

            return "Silne";

        else if (hasDigit && password.Length > 7)

            return "Średnie";

        else

            return "Słabe";

    }

}