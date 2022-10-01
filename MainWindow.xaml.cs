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
using Wendel_d7_avaliacao.Data;

namespace Wendel_d7_avaliacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Context context;
        public MainWindow(Context context)
        {
            this.context = context;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailText.Text;
            string password = PasswordText.Password;
            
            foreach (var user in context.Users.ToList())
            {
                if (user.Email.Equals(email) && user.Password.Equals(password))
                {
                    ShowPopUp("Usuário autenticado!");
                    return;
                }
            }
            ShowPopUp("Credenciais inválidas!");
        }

        public void ShowPopUp(string text)
        {
            Message msg;
            this.Opacity = 0.53;
            msg = new(text);
            msg.Owner = this;
            msg.ShowDialog();
            this.Opacity = 1.0;
        }
    }
}
