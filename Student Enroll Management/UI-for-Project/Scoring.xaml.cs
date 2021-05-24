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
using UI_for_Project.Controller;

namespace UI_for_Project
{
    /// <summary>
    /// Interaction logic for Scoring.xaml
    /// </summary>
    public partial class Scoring : Page
    {

        public delegate void OpenScoreEditor(string subjectButton);
        public OpenScoreEditor _openScoreEditor;

        
        public Scoring( OpenScoreEditor parameterDelegate)
        {
            InitializeComponent();
            
            _openScoreEditor += parameterDelegate;

           

            Grid gridScoring = new Grid();
            gridhieu.Width = 360;
            gridhieu.Height = 270;


            // chỉnh sửa front-end trong code thì vào link này 
            //  https://www.c-sharpcorner.com/UploadFile/mahesh/grid-in-wpf/

            // Create Columns    
            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            ColumnDefinition gridCol3 = new ColumnDefinition();
            gridCol1.Width = new GridLength(120);
            gridCol2.Width = new GridLength(120);
            gridCol3.Width = new GridLength(120);
            gridhieu.ColumnDefinitions.Add(gridCol1);
            gridhieu.ColumnDefinitions.Add(gridCol2);
            gridhieu.ColumnDefinitions.Add(gridCol3);

            // Create Rows    
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(90);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(90);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(90);
            gridhieu.RowDefinitions.Add(gridRow1);
            gridhieu.RowDefinitions.Add(gridRow2);
            gridhieu.RowDefinitions.Add(gridRow3);

            
            SubjectButton sub_toan = new SubjectButton("Toán", int.Parse(getNumberOfSubject.getNumberOfSubject_sql("Toán")));
            sub_toan.onClickDelegate = onOpenScoringEditingDelegate;
            Grid.SetRow(sub_toan, 0);
            Grid.SetColumn(sub_toan, 0);
            gridhieu.Children.Add(sub_toan);

            SubjectButton sub_nguvan = new SubjectButton("Ngữ Văn", int.Parse(getNumberOfSubject.getNumberOfSubject_sql("Ngữ Văn")));
            sub_nguvan.onClickDelegate = onOpenScoringEditingDelegate;
            Grid.SetRow(sub_nguvan, 0);
            Grid.SetColumn(sub_nguvan, 1);
            gridhieu.Children.Add(sub_nguvan);

            SubjectButton sub_anhvan = new SubjectButton("Anh Văn", int.Parse(getNumberOfSubject.getNumberOfSubject_sql("Anh Văn")));
            sub_anhvan.onClickDelegate = onOpenScoringEditingDelegate;
            Grid.SetRow(sub_anhvan, 0);
            Grid.SetColumn(sub_anhvan, 2);
            gridhieu.Children.Add(sub_anhvan);

            SubjectButton sub_vatli = new SubjectButton("Vật Lý", int.Parse(getNumberOfSubject.getNumberOfSubject_sql("Vật Lý")));
            sub_vatli.onClickDelegate = onOpenScoringEditingDelegate;
            Grid.SetRow(sub_vatli, 1);
            Grid.SetColumn(sub_vatli, 0);
            gridhieu.Children.Add(sub_vatli);

            SubjectButton sub_hoahoc = new SubjectButton("Hóa Học", int.Parse(getNumberOfSubject.getNumberOfSubject_sql("Hóa Học")));
            sub_hoahoc.onClickDelegate = onOpenScoringEditingDelegate;
            Grid.SetRow(sub_hoahoc, 1);
            Grid.SetColumn(sub_hoahoc, 1);
            gridhieu.Children.Add(sub_hoahoc);

            SubjectButton sub_sinhhoc = new SubjectButton("Sinh Học", int.Parse(getNumberOfSubject.getNumberOfSubject_sql("Sinh Học")));
            sub_sinhhoc.onClickDelegate = onOpenScoringEditingDelegate;
            Grid.SetRow(sub_sinhhoc, 1);
            Grid.SetColumn(sub_sinhhoc, 2);
            gridhieu.Children.Add(sub_sinhhoc);

            SubjectButton sub_lichsu = new SubjectButton("Lịch Sử", int.Parse(getNumberOfSubject.getNumberOfSubject_sql("Lịch Sử")));
            sub_lichsu.onClickDelegate = onOpenScoringEditingDelegate;
            Grid.SetRow(sub_lichsu, 2);
            Grid.SetColumn(sub_lichsu, 0);
            gridhieu.Children.Add(sub_lichsu);

            SubjectButton sub_diali = new SubjectButton("Địa Lí", int.Parse(getNumberOfSubject.getNumberOfSubject_sql("Địa Lí")));
            sub_diali.onClickDelegate = onOpenScoringEditingDelegate;
            Grid.SetRow(sub_diali, 2);
            Grid.SetColumn(sub_diali, 1);
            gridhieu.Children.Add(sub_diali);

            SubjectButton sub_gdcd = new SubjectButton("GDCD", int.Parse(getNumberOfSubject.getNumberOfSubject_sql("GDCD")));
            sub_gdcd.onClickDelegate = onOpenScoringEditingDelegate;
            Grid.SetRow(sub_gdcd, 2);
            Grid.SetColumn(sub_gdcd, 2);
            gridhieu.Children.Add(sub_gdcd);




        }
        public void onOpenScoringEditingDelegate(string subjectName)
        {
            _openScoreEditor(subjectName);
            
        }
    }
}
