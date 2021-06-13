    using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UI_for_Project.Controller;
using UI_for_Project.Model;

namespace UI_for_Project
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        public delegate void getData(bool data);
        public getData myData;



        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Admin username : admin 
            // pass : admin

            //User username : user
            // pass : user
            confirm_Login();

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                confirm_Login();
            }
        }

        public void confirm_Login()
        {
            confirmLogin confirmLogin;
            confirmLogin = new confirmLogin(txtUserName.Text.ToString(), txtPassword.Password.ToString());
            if (confirmLogin.confirm_Login() == "admin")
            {
                confirmPerson.setPersonPermission("ADMIN");
                if (confirmFinishRegister.getConfirm() == true)
                {
                    var main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else
                {
                    var exam =new  ExamRegister();
                    exam.Show();
                    this.Close();
                }
            }
            if (confirmLogin.confirm_Login() == "user")
            {
                confirmPerson.setPersonPermission("USER");
                if (confirmFinishRegister.getConfirm() == true)
                {
                    var main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else
                {
                    var exam = new ExamRegister();
                    exam.Show();
                    this.Close();
                }
            }
            else if (confirmLogin.confirm_Login() == "none")
            {
                if (MessageBox.Show("Syntax Error.\nPlease retype.", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    //do no stuff
                    
                   
                }
                else
                {
                    //do yes stuff
                    this.Close();
                }
                //MessageBox.Show("       Syntax Error. \n Please re-type again or app will br close.");
            }
        }
    }
}
