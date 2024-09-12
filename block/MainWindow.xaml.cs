using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
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
using System.Xml.Linq;

namespace block
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ObservableCollection<BSX> Blokkok = new ObservableCollection<BSX>();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "BSX Fájlok | *.bsx",
                Multiselect = false
            };

            while (ofd.ShowDialog() == true)
            {
                if (ofd.FileName != "")
                {
                    XDocument xaml = XDocument.Load(ofd.FileName);
                    foreach (var elem in xaml.Descendants("Item"))
                    {
                        String Id = elem.Element("ItemID").Value;
                        String ItemName = elem.Element("ItemName").Value;
                        String CategoryName = elem.Element("CategoryName").Value;
                        String ColorName = elem.Element("ColorName").Value;
                        String Qty = elem.Element("Qty").Value;

                        BSX bs = new BSX(Id, ItemName, CategoryName, ColorName, Convert.ToInt32(Qty));
                        Blokkok.Add(bs);
                            
                    }
                    dtgAdatok.ItemsSource = Blokkok;
                    tbCategory.ItemsSource = Blokkok.Select(x => x.Categoryname).Distinct().ToList();
                    break;
                }
                else
                {
                    MessageBox.Show("Nincs Kiválasztva File");
                    break;
                }
            }
        }

        private void tbNev_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void tbAzon_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void tbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }


        public void Filter()
        {
            dtgAdatok.ItemsSource = Blokkok.Select(x => x).Where(x => tbNev.Text != "" ? x.Itemname.ToLower().StartsWith(tbNev.Text.ToLower()) : true && tbId.Text != "" ? x.Id.StartsWith(tbId.Text) : true );
        }

    }
}
