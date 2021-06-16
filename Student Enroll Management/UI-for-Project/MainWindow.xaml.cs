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
using System.Data.SqlClient;
using System.Data;
using UI_for_Project.Controller;
using UI_for_Project.Model;

namespace UI_for_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            // GIAO DIỆN STATISTIC CHỈ HIỂN THỊ KHI HOÀN THÀNH CHẤM ĐIỂM
            // NẾU CHƯA HOÀN THÀNH THÌ KHI CLICK VÀO SẼ RA THÔNG BÁO VÀ CHUYỂN VỀ GIAO DIỆN CANDIDATE
            btnCandidate.Style = SelectingStyle();

            if (!(Holder.Content is CandidateList))
            {
                Holder.Content = null;
                while (Holder.NavigationService.RemoveBackEntry() != null) ;
                Holder.Content = new CandidateList();
            }

            btnScoring.Style = IdlingStyle();
            btnStatistic.Style = IdlingStyle();
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            // click button log_out
            confirmPerson.setPersonPermission("NONE");

            var loginWindow = new Login();
            loginWindow.Show();
            this.Close();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Show();

            // KIỂM TRA THỬ PHẦN ĐĂNG KÍ ĐÃ HOÀN THÀNH CHƯA, NẾU HOÀN THÀNH RỒI THÌ HIỂN THỊ MAIN, NẾU CHƯA THÌ HIỂN THỊ PHẦN ĐĂNG KÍ 
            if (confirmFinishRegister.getConfirm() == true)
            {
                if (confirmPerson.getPersonPermission() == "NONE")
                {
                    var intent_login = new Login();
                    intent_login.Show();
                    this.Close();
                }
                if (confirmPerson.getPersonPermission() == "ADMIN")
                {
                    btnLogOut.Content = "log out with admin";
                }
                else if (confirmPerson.getPersonPermission() == "USER")
                {
                    btnLogOut.Content = "log out with user";
                }
            }
            else
            {
                var intent_login = new Login();
                intent_login.Show();
                this.Close();
            }
        }


        // functional menu button events
        private void btnCandidate_Click(object sender, RoutedEventArgs e)
        {
            btnCandidate.Style = SelectingStyle();

            if (!(Holder.Content is CandidateList))
            {
                Holder.Content = null;
                while (Holder.NavigationService.RemoveBackEntry() != null) ;
                Holder.Content = new CandidateList();
            }

            btnScoring.Style = IdlingStyle();
            btnStatistic.Style = IdlingStyle();

            // model manipulation



        }
        private void btnScoring_Click(object sender, RoutedEventArgs e)
        {
            btnScoring.Style = SelectingStyle();

            if (!(Holder.Content is Scoring))
            {
                Holder.Content = null;
                while (Holder.NavigationService.RemoveBackEntry() != null) ;
                Holder.Content = new Scoring(OpenScoreEditingUI);
            }

            btnCandidate.Style = IdlingStyle();
            btnStatistic.Style = IdlingStyle();
        }

        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            if (confirmEditScoring.confirmAllSubject() == true)
            {
                btnStatistic.Style = SelectingStyle();

               // remove current content on the page
            if (!(Holder.Content is Statistic))
                {
                    Holder.Content = null;
                    while (Holder.NavigationService.RemoveBackEntry() != null) ;
                    Holder.Content = new Statistic();
                }

               // style changing
            btnCandidate.Style = IdlingStyle();
                btnScoring.Style = IdlingStyle();
            }
            else
            {
                MessageBox.Show("You need finish Scoring before.");
                btnCandidate.Style = SelectingStyle();

                if (!(Holder.Content is CandidateList))
                {
                    Holder.Content = null;
                    while (Holder.NavigationService.RemoveBackEntry() != null) ;
                    Holder.Content = new CandidateList();
                }

                btnScoring.Style = IdlingStyle();
                btnStatistic.Style = IdlingStyle();
            }
        }
        // changing Style for EveryButton
        Style SelectingStyle()
        {
            // to selected style
            return FindResource("FunctionBtn_Selected") as Style;
        }
        Style IdlingStyle()
        {   // to idel style ( when selecting another )
            return FindResource("FunctionBtn_Idle") as Style;
        }

        void OpenScoreEditingUI(string subjectBtn)
        {
            EditScoring a = new EditScoring(subjectBtn);
            Holder.Content = a;
        }
    }
}
