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

namespace UI_for_Project
{
    /// <summary>
    /// Interaction logic for SubjectButton.xaml
    /// </summary>
    public partial class SubjectButton : UserControl
    {
        public string SubjectName = "defaultSubject";
        public int numCount = 0;
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
    }
}
