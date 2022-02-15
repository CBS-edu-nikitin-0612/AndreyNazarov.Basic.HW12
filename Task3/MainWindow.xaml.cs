using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Presenter presenter;
        public event EventHandler Start = null;
        public event EventHandler Stop = null;
        public event EventHandler Reset = null;
        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {            
            Start.Invoke(sender, e);
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            Stop.Invoke(sender, e);
        }

        public void PrintException(string exceptionMessage)
        {
            TextBoxExeptions.Text = exceptionMessage;
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            Reset.Invoke(sender, e);
        }

        public void UpdateProgressBar(double value)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate () { ProgressBar.Value = ProgressBar.Maximum - value; });
        }
        public void UpdateTextBoxElapsed(string value)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate () { TextBoxElapsed.Text = value; });
        }
    }
}
