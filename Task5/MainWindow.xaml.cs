using System;
using System.Windows;

namespace Task5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Presenter(this);
        }
        private EventHandler myEvent = null;
        public event EventHandler MyEvent
        {
            add { myEvent += value; }
            remove { myEvent -= value; }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myEvent.Invoke(sender, e);
        }
    }
}