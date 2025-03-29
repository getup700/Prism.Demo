using MainModule.Event;
using Prism.Events;
using System;
using System.Windows;

namespace MainModule.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IEventAggregator aggregator)
        {
            InitializeComponent();
        }
    }
}
