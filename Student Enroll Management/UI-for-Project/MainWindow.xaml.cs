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
        }
        // functional menu button events
        private void btnCandidate_Click(object sender, RoutedEventArgs e)
        {
            btnCandidate.Style = SelectingStyle();

            if(!(Holder.Content is CandidateList))
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
                Holder.Content = new Scoring();
            }

            btnCandidate.Style = IdlingStyle();
            btnStatistic.Style = IdlingStyle();

            // model manipulation
        }

        private void btnStatistic_Click(object sender,RoutedEventArgs e)
        {   
            btnStatistic.Style = SelectingStyle();

            // remove current content on the page
            Holder.Content = null;
            while (Holder.NavigationService.RemoveBackEntry() != null) ;

            // style changing
            btnCandidate.Style = IdlingStyle();
            btnScoring.Style = IdlingStyle();

            // model manipulation
        }

        // Log Out event
        private void LogOut(object sender, RoutedEventArgs e)
        {

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

        
    }
}
