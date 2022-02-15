using System;
using System.Windows;
using System.Windows.Input;

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Presenter presenter;
        public event EventHandler Add = null;
        public event EventHandler Sub = null;
        public event EventHandler Mult = null;
        public event EventHandler Div = null;
        public event EventHandler Enter = null;
        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Add.Invoke(sender, e);
            Keyboard.Focus(TextBoxMain);
        }

        private void ButtonSub_Click(object sender, RoutedEventArgs e)
        {
            Sub.Invoke(sender, e);
            Keyboard.Focus(TextBoxMain);
        }

        private void ButtonMult_Click(object sender, RoutedEventArgs e)
        {
            Mult.Invoke(sender, e);
            Keyboard.Focus(TextBoxMain);
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            Enter.Invoke(sender, e);
            Keyboard.Focus(TextBoxMain);
        }

        private void ButtonDiv_Click(object sender, RoutedEventArgs e)
        {
            Div.Invoke(sender, e);
            Keyboard.Focus(TextBoxMain);
        }

        public double? GetOperand()
        {
            double? result = null;
            try
            {
                result = double.Parse(TextBoxMain.Text);
                TextBoxMain.Text = "0";
            }
            catch (FormatException exception)
            {
                TextBlockExceprion.Text = exception.Message;
            }
            return result;
        }
    }
}
