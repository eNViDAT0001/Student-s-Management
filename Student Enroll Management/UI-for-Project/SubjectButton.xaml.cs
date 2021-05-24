using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace UI_for_Project
{
    /// <summary>
    /// Interaction logic for SubjectButton.xaml
    /// </summary>
    public partial class SubjectButton : UserControl
    {

        public delegate void GetSubjectName(string SubjectName);
        public GetSubjectName onClickDelegate;


        public string SubjectName { get; set; }
        public int numCount { get; set; }
        public SubjectButton()
        {
            InitializeComponent();
            txtSubjectName.Text = SubjectName;
            txtCount.Text = "Count : " + numCount;
        }
        public SubjectButton(string name, int Count)
        {
            InitializeComponent();
            
            SubjectName = name;
            numCount = Count;
            txtSubjectName.Text = SubjectName;
            txtCount.Text = "Count : " + numCount;
        }

        private void btnS1_Click(object sender, RoutedEventArgs e)
        {
            onClickDelegate(SubjectName);
        }
    }
}
