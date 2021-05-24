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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI_for_Project.Model;

namespace UI_for_Project
{
    /// <summary>
    /// Interaction logic for Statistic.xaml
    /// </summary>
    public partial class Statistic : Page
    {
        public Statistic()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // TỔNG SỐ THI SINH THAM GIA
            sumStd.Text = sqlStatistic.number_Candidate();
            nameBestOfAll.Text = sqlStatistic.Name_MaxPoint();
            highScoreOfAll.Text = sqlStatistic.Point_MaxPoint();

            nameBest.Text = sqlStatistic.Name_MaxPoint_Subject("Toán");
            highScore.Text = sqlStatistic.Point_MaxPoint_Subject("Toán");

            sumStdPass.Text = DiemChuan.sumDau_Rot().ToString();
            PassRatio.Text = (DiemChuan.sumDau_Rot() / double.Parse( sqlStatistic.number_Candidate())).ToString() +"%";
        }
        
        private void SubjectCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubjectCmbx.SelectedItem != null)
            {
                string a="";
                string subject = SubjectCmbx.SelectedItem.ToString();
                string[] arr = subject.Split(":");
                for(int i=0;i<arr.Length;i++)
                    a = arr[i].Trim();
                //MessageBox.Show(a);
                if(a != "System.Windows.Controls.ComboBoxItem")
                {
                    nameBest.Text = sqlStatistic.Name_MaxPoint_Subject(a);
                    highScore.Text = sqlStatistic.Point_MaxPoint_Subject(a);
                }
            }
        }
    }
}
