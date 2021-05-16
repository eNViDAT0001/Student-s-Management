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
    /// Interaction logic for CandidateList.xaml
    /// </summary>
    public partial class CandidateList : Page
    {
        public class CandidateData
        {
           public int Id { get; set; }
            public string Name { get; set; }
            public string DoB { get; set; }

            public string PoB { get; set; }

            public string Address { get; set; }

            
        }
        public CandidateList()
        {
            InitializeComponent();
            //// id
            //DataGridTextColumn candidate_id = new DataGridTextColumn();
            //candidate_id.Header = "Id";
            //candidate_id.Binding = new Binding("Id");
            //candidate_id.Width = 50;
            //datagridCandidateList.Columns.Add(candidate_id);

            //// name
            //DataGridTextColumn candidate_name = new DataGridTextColumn();
            //candidate_name.Header = "Name";
            //candidate_name.Binding = new Binding("Name");
            //candidate_name.Width = 100;
            //datagridCandidateList.Columns.Add(candidate_name);
            //// date of birth
            //DataGridTextColumn candidate_dob = new DataGridTextColumn();
            //candidate_dob.Header = "Date of Birth";
            //candidate_dob.Binding = new Binding("DoB");
            //candidate_dob.Width = 90;
            //datagridCandidateList.Columns.Add(candidate_dob);



            //// place of birth
            //DataGridTextColumn candidate_pob = new DataGridTextColumn();
            //candidate_pob.Header = "Place of Birth";
            //candidate_pob.Binding = new Binding("Pob");
            //candidate_pob.Width = 150;
            //datagridCandidateList.Columns.Add(candidate_pob);


            //// address
            //DataGridTextColumn candidate_anouce_addrr = new DataGridTextColumn();
            //candidate_anouce_addrr.Header = "Announce Address";
            //candidate_anouce_addrr.Binding = new Binding("Address");
            //candidate_anouce_addrr.Width = 150;
            //datagridCandidateList.Columns.Add(candidate_anouce_addrr);
            datagridCandidateList.IsReadOnly = true;
            
            List<CandidateData> lCandidate = new List<CandidateData>();
            datagridCandidateList.ItemsSource = lCandidate;

           


           
            
        }
    }
}
