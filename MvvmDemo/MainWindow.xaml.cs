using MvvmDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace MvvmDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DemoViewModel viewModel1;
        DemoViewModel viewModel2;
        public MainWindow()
        {
            InitializeComponent();
            viewModel1 = new DemoViewModel("1");
            viewModel2 = new DemoViewModel("2");

            view1.DataContext = viewModel1;
            view2.DataContext = viewModel2;
        }
    }
}
