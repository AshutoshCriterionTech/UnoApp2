using System.Threading.Tasks;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using UnoApp2.Helper;

namespace UnoApp2.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        // Set default language (optional)
        Dictationary.SetLanguage("en");

        // Update UI initially
        UpdateUILanguage();
    }
    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        string username = UsernameTextBox.Text;
        string password = PasswordTextBox.Text;
        
        Login(username, password);
    }

    public async void Login(string username, string password)
    {
        ShowLoader(true);

        //await Task.Delay(4000);


        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ShowLoader(false);

            await ShowMessage("Login Failed", "Incorrect username or password.");
            return;
        }

        else if (username == "Admin" && password == "123")
        {
            ShowLoader(false);

            await ShowMessage("Login Success", "Welcome to Mini Kiosk...");

            Frame.Navigate(typeof(Dasboard));
        }
        else
        {
            await Task.Delay(3000);
            ShowLoader(false);
            await ShowMessage("Login Failed", "Incorrect username or password.");
        }
    }

    private void ShowLoader(bool isVisible)
    {
        LoaderOverlay.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
    }

    private async Task ShowMessage(string title, string message)
    {
        var dialog = new ContentDialog
        {
            Title = title,
            Content = message,
            CloseButtonText = "OK",
            XamlRoot = this.XamlRoot // Important for Uno (especially WebAssembly)
        };

        await dialog.ShowAsync();
    }



    private async Task TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        int i = 0;
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            string username = UsernameTextBox.Text;
            if(username=="" || username == null)
            {
            await ShowMessage("Login Failed", "Please fill Username");
                i = 1;
                return;
            }
            string password = PasswordTextBox.Text;
            if (password == "" || password == null)
            {
                await ShowMessage("Login Failed", "Please fill Password");
                i = 1;
                return;
            }
            if (i == 0)
            {
                Login(username, password);
            }
        }
    }
   
    private void HindiButton_Click(object sender, RoutedEventArgs e)
    {
        Dictationary.SetLanguage("hi");

        UsernameTextBox.PlaceholderText = Dictationary.Translate("enter_username");
        PasswordTextBox.PlaceholderText = Dictationary.Translate("enter_password");
       
    }

    private void EnglishButton_Click(object sender, RoutedEventArgs e)
    {
        Dictationary.SetLanguage("en");

        UsernameTextBox.PlaceholderText = Dictationary.Translate("enter_username");
        PasswordTextBox.PlaceholderText = Dictationary.Translate("enter_password");
        LoginButton.Content = Dictationary.Translate("login");
    }
    private void UpdateUILanguage()
    {
        UsernameTextBox.PlaceholderText = Dictationary.Translate("enter_username");
        PasswordTextBox.PlaceholderText = Dictationary.Translate("enter_password");
        LoginButton.Content = Dictationary.Translate("login");


        // Optional: If you have a Welcome TextBlock
        // WelcomeText.Text = Dictationary.Translate("welcome");
    }

    private void LanguageToggle_Toggled(object sender, RoutedEventArgs e)
    {
        if (LanguageToggle.IsOn)
        {
            Dictationary.SetLanguage("hi");
        }
        else
        {
            Dictationary.SetLanguage("en");
        }

        UpdateUILanguage();
    }



    //#region Popup with Logo Image
    //private async Task ShowMessage(string title, string message)
    //{
    //    var dialog = new ContentDialog
    //    {
    //        Title = title,
    //        CloseButtonText = "OK",
    //        XamlRoot = this.XamlRoot,
    //        Content = new Grid
    //        {
    //            Width = 200,
    //            Height = 150,
    //            Background = new ImageBrush
    //            {
    //                ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/tempImages/Logo.png")),
    //                Stretch = Stretch.UniformToFill
    //            },
    //            Children =
    //    {
    //        new StackPanel
    //        {
    //            HorizontalAlignment = HorizontalAlignment.Center,
    //            VerticalAlignment = VerticalAlignment.Center,
    //            Children =
    //            {
    //                new TextBlock
    //                {
    //                    Text = "This is a custom dialog with a background image.",
    //                    Foreground = new SolidColorBrush(),
    //                    TextWrapping = TextWrapping.Wrap,
    //                    TextAlignment = TextAlignment.Center,
    //                    FontSize = 18
    //                }
    //            }
    //        }
    //    }
    //        }
    //    };

    //    await dialog.ShowAsync();

    //}

    //#endregion

}
