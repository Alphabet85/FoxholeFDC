using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoxholeFDC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
            CheckIfFieldsAreFilled();
        }

        private static readonly Regex _regex = new Regex("[^0-9-]+");
        private static bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
        }

        private void FixedPointDirection_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }

        private void FixedPointDistance_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }

        private void FixedPointDirection_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FixedPointDirection_TextBox.SelectionStart = 0;
            FixedPointDirection_TextBox.SelectionLength = FixedPointDirection_TextBox.Text.Length;
        }

        private void FixedPointDistance_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FixedPointDistance_TextBox.SelectionStart = 0;
            FixedPointDistance_TextBox.SelectionLength = FixedPointDistance_TextBox.Text.Length;
        }

        private void FixedPointDirection_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfFieldsAreFilled();
        }

        private void FixedPointDistance_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfFieldsAreFilled();
        }

        private void CheckIfFieldsAreFilled()
        {
            if (FixedPointDirection_TextBox.Text != "0" && !string.IsNullOrEmpty(FixedPointDirection_TextBox.Text) &&
                FixedPointDistance_TextBox.Text != "0" && !string.IsNullOrEmpty(FixedPointDistance_TextBox.Text))
            {
                AddArtilleryWindow_Button.IsEnabled = true;
                DeleteArtilleryWindow_Button.IsEnabled = true;
                AddTargetWindow_Button.IsEnabled = true;
                DeleteTargetWindow_Button.IsEnabled = true;
            }
            else
            {
                AddArtilleryWindow_Button.IsEnabled = false;
                DeleteArtilleryWindow_Button.IsEnabled = false;
                AddTargetWindow_Button.IsEnabled = false;
                DeleteTargetWindow_Button.IsEnabled = false;
            }
        }

        private void TargetInformationModelDistance_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }

        private void TargetInformationModelDirection_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }

        private void ArtilleryModelDistance_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }

        private void ArtilleryModelDirection_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }

        private void CheckIfAddArtilleryIsFilled()
        {
            if (ArtilleryModelName_TextBox.Text != "0" && !string.IsNullOrEmpty(ArtilleryModelName_TextBox.Text) &&
                ArtilleryModelDirection_TextBox.Text != "0" && !string.IsNullOrEmpty(ArtilleryModelDirection_TextBox.Text) &&
                ArtilleryModelDistance_TextBox.Text != "0" && !string.IsNullOrEmpty(ArtilleryModelDistance_TextBox.Text))
            {
                AddArtillery_Button.IsEnabled = true;
            }
            else
            {
                AddArtillery_Button.IsEnabled = false;
            }
        }

        private void CheckIfAddTargetIsFilled()
        {
            if (TargetInformationModelName_TextBox.Text != "0" && !string.IsNullOrEmpty(TargetInformationModelName_TextBox.Text) &&
                TargetInformationModelDirection_TextBox.Text != "0" && !string.IsNullOrEmpty(TargetInformationModelDirection_TextBox.Text) &&
                TargetInformationModelDistance_TextBox.Text != "0" && !string.IsNullOrEmpty(TargetInformationModelDistance_TextBox.Text))
            {
                AddTarget_Button.IsEnabled = true;
            }
            else
            {
                AddTarget_Button.IsEnabled = false;
            }
        }

        private void TargetInformationModelName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfAddTargetIsFilled();
        }

        private void TargetInformationModelDirection_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfAddTargetIsFilled();
        }

        private void TargetInformationModelDistance_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfAddTargetIsFilled();
        }

        private void ArtilleryModelName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfAddArtilleryIsFilled();
        }

        private void ArtilleryModelDirection_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfAddArtilleryIsFilled();
        }

        private void ArtilleryModelDistance_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfAddArtilleryIsFilled();
        }

        private void ArtilleryModelName_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ArtilleryModelName_TextBox.SelectionStart = 0;
            ArtilleryModelName_TextBox.SelectionLength = ArtilleryModelName_TextBox.Text.Length;
        }

        private void ArtilleryModelDirection_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ArtilleryModelDirection_TextBox.SelectionStart = 0;
            ArtilleryModelDirection_TextBox.SelectionLength = ArtilleryModelDirection_TextBox.Text.Length;
        }

        private void ArtilleryModelDistance_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ArtilleryModelDistance_TextBox.SelectionStart = 0;
            ArtilleryModelDistance_TextBox.SelectionLength = ArtilleryModelDistance_TextBox.Text.Length;
        }

        private void TargetInformationModelName_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TargetInformationModelName_TextBox.SelectionStart = 0;
            TargetInformationModelName_TextBox.SelectionLength = TargetInformationModelName_TextBox.Text.Length;
        }

        private void TargetInformationModelDirection_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TargetInformationModelDirection_TextBox.SelectionStart = 0;
            TargetInformationModelDirection_TextBox.SelectionLength = TargetInformationModelDirection_TextBox.Text.Length;
        }

        private void TargetInformationModelDistance_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TargetInformationModelDistance_TextBox.SelectionStart = 0;
            TargetInformationModelDistance_TextBox.SelectionLength = TargetInformationModelDistance_TextBox.Text.Length;
        }

        private void GitHub_HyperLink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void BuyMeACoffee_HyperLink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
