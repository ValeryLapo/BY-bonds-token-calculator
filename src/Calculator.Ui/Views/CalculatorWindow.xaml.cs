using System.Windows;
using Calculator.Ui.ViewModels;

namespace Calculator.Ui.Views
{
    /// <summary>
    /// Interaction logic for CalculatorWindow.xaml
    /// </summary>
    public partial class CalculatorWindow
    {
        private readonly CalculatorViewModel _viewModel;

        public CalculatorWindow(CalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}