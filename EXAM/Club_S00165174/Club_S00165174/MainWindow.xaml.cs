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

namespace Club_S00165174
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Random randomFactory = new Random();
        //4 types of membership
        string[] mtypes = { "Full", "Off Peak", "Student", "OAP" };
        
        Member[] memberArray = new Member[4];
        Member[] filteredArray = new Member[4];
        public MainWindow()
        {
            InitializeComponent();
            //types of membership
            MembershipType full = new MembershipType("Full");
            MembershipType offPeak = new MembershipType("Off Peak");
            MembershipType student = new MembershipType("Student");
            MembershipType oap = new MembershipType("OAP");
            //create members and put in member array
            Member memA = new Member("Joe Bloggs", "0719132142", "1 Main Street", GetRandomYear(), full);
            Member memB = new Member("Mary Bloggs", "0719174546", "Abbey Street", GetRandomYear(), offPeak);
            Member memC = new Member("Jim Bloggs", "0719171148", "25 Hilltop", GetRandomYear(), student);
            Member memD = new Member("Jesse Bloggs", "0719185642", "109 Grange Street", GetRandomYear(), full);
            memberArray[0] = memA;
            memberArray[1] = memB;
            memberArray[2] = memC;
            memberArray[3] = memD;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listNames.ItemsSource = "";
            string typeSelected = comboBox.SelectedValue.ToString();

            Filter(typeSelected);
            listNames.ItemsSource = filteredArray;
        }

        private void Filter(string selType)
        {
            for (int i = 0; i < memberArray.Length; i++)
            {
                // Clean out the FilteredProductArray 
                filteredArray[i] = null;
                string type = memberArray[i].MemberType.ToString();

                //If product found add to filtered array
                if (type.Equals(selType))
                {
                    filteredArray[i] = memberArray[i];

                }
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //clear preexisting content
            lblName.Content = "";
            lblPhone.Content = "";
            lblAddress.Content = "";
            lblMemberType.Content = "";
            lblYearJoined.Content = "";
            if (listNames.SelectedValue != null)
            {
                string memberSelected = listNames.SelectedValue.ToString();
                for (int i = 0; i < memberArray.Length; i++)
                {
                    if (memberArray[i].Name.Equals(memberSelected))
                    {
                        lblName.Content = memberArray[i].Name;
                        lblPhone.Content = memberArray[i].Phone;
                        lblAddress.Content = memberArray[i].Address;
                        lblMemberType.Content = memberArray[i].MemberType;
                        lblYearJoined.Content = memberArray[i].YearJoined;

                    }
                }
            }
        }

        private void tbNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //empty list box
            listNames.ItemsSource = "";

            if (tbNameSearch.Text != null)
            {
                string nameSearch = tbNameSearch.Text.ToUpper();

                for (int i = 0; i < memberArray.Length; i++)
                {
                    filteredArray[i] = null;
                    //two seperate names
                    string[] names = memberArray[i].Name.Split(' ');
                    if (names[0].ToUpper() == nameSearch || names[1].ToUpper() == nameSearch)
                    {
                        filteredArray[i] = memberArray[i];
                    }
                }
                listNames.ItemsSource = filteredArray;
            }
        }

        private int GetRandomYear()
        {
            int start = 2000;
            int year = start + (randomFactory.Next(0,15));
            return year;

        }

        private void onWindowLoaded(object sender, RoutedEventArgs e)
        {
            listNames.ItemsSource = memberArray;
            comboBox.ItemsSource = mtypes;
        }
    }
}
