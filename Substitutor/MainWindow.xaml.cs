using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Substitutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Snippets.Deserialize();

            ListView.ItemsSource = Snippets.List;
            Snippets.List.ListChanged += delegate { ListView.ItemsSource = Snippets.List; };
        }

        private void Add_Item_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddItem();
            add.ShowDialog();
        }

        private void Edit_Item_Click(object sender, RoutedEventArgs e)
        {
            if (ListView.SelectedIndex >= 0)
            {
                var editItem = new EditItem(ListView.SelectedIndex);
                editItem.ShowDialog();
            }
        }

        private void Remove_Item_Click(object sender, RoutedEventArgs e)
        {
            if (ListView.SelectedIndex >= 0)
            {
                Snippets.List.RemoveAt(ListView.SelectedIndex);
                Snippets.Serialize();
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Only trigger on ListViewItem double-click and not for example when you double-click on the header of the ListView
            DependencyObject obj = (DependencyObject)e.OriginalSource;

            while (obj != null && obj != ListView)
            {
                if (obj.GetType() == typeof(ListViewItem))
                {
                    var substitute = new Substitution(ListView.SelectedIndex);
                    substitute.Show();
                    break;
                }
                obj = VisualTreeHelper.GetParent(obj);
            }
        }
    }
}
