using Option_Pricer_Mvvm.ViewModel;
using System.Windows.Controls;

namespace Option_Pricer_Mvvm.View
{
    /// <summary>
    /// Logique d'interaction pour OptionView.xaml
    /// </summary>
    public partial class OptionView : UserControl
    {
        OptionViewModel optionViewModel = new OptionViewModel();
        public OptionView()
        {
            InitializeComponent();
            this.DataContext = optionViewModel;
        }
    }
}
