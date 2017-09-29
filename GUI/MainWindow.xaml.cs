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
using Library;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WindowState = WindowState.Maximized;
        }

        private void NewCharacter_Click(object sender, RoutedEventArgs e)
        {
            NewCharacter character = new NewCharacter
            {
                WindowState = WindowState.Maximized
            };
            character.Show();
            //this.Hide();
        }

        private void ShowDivines_Click(object sender, RoutedEventArgs e)
        {
            GodsViewer divine = new GodsViewer
            {
                WindowState = WindowState.Maximized
            };
            divine.Show();
            //this.Hide();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowCharacters_Click(object sender, RoutedEventArgs e)
        {
            Characters characters = new Characters
            {
                WindowState = WindowState.Maximized
            };
            characters.Show();
            //this.Hide();
        }

        private void DummyButton_Click(object sender, RoutedEventArgs e)
        {
            Dummy dummy = new Dummy
            {
                WindowState = WindowState.Maximized
            };
            dummy.Show();
            //this.Hide();
        }
    }
}
