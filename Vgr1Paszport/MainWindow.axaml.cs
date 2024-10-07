using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Vgr1Paszport;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Submit(object? sender, RoutedEventArgs e)
    {
        var numText = NumberTextBox.Text ?? "";
        var nameText = NameTextBox.Text ?? "";
        var lastnameText = LastnameTextBox.Text ?? "";
        var eyeColorText = "";
        
        
        bool radioButtonChecked;

        if (beerColor.IsChecked ?? false)
            eyeColorText = "piwny";
        else if (greenColor.IsChecked ?? false)
            eyeColorText = "zielony";
        else if (blueColor.IsChecked ?? false)
            eyeColorText = "niebieski";

        if (numText != "" && nameText != "" && lastnameText != "" && eyeColorText != "")
        {
            DialogWindow dialog = new();
            dialog.ShowDialog(this);
        }
        else
        {
            DialogWindow dialog = new();
            dialog.ShowDialog(this);
        }
    }

    private void NumberTextBox_OnLostFocus(object? sender, RoutedEventArgs e)
    {
        var num = NumberTextBox.Text ?? "brak";

        var fingerprintName = $"{num}-odciski.jpg";
        var pictureName = $"{num}-zdjecie.jpg";

        for (;;)
        {
            try
            {
                using var streamFingerprint = AssetLoader.Open(new Uri($"avares://Vgr1Paszport/Assets/{fingerprintName}"));
                FingerprintImage.Source = new Bitmap(streamFingerprint);

                using var streamPicture = AssetLoader.Open(new Uri($"avares://Vgr1Paszport/Assets/{pictureName}"));
                PictureImage.Source = new Bitmap(streamPicture);
                break;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                fingerprintName = $"brak-odciski.jpg";
                pictureName = $"brak-zdjecie.jpg";
            }
        }
        
    }
}