using System;
using System.Windows;

namespace Substitutor
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        private int index;

        public EditItem(int thisIndex)
        {
            InitializeComponent();

            SourceInitialized += (s, e) =>
            {
                MaxHeight = ActualHeight;
            };

            Owner = Application.Current.MainWindow;
            index = thisIndex;

            Command.Text = Snippets.List[index].Command;
            Substitutor_title.Text =  Snippets.List[index].SubstitutorTitle;
            Extra_args.Text = Snippets.List[index].ExtraArgs;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(Command.Text) && !String.IsNullOrEmpty(Substitutor_title.Text))
            {
                Snippets.List[index].Command = Command.Text;
                Snippets.List[index].SubstitutorTitle = Substitutor_title.Text;
                Snippets.List[index].ExtraArgs = Extra_args.Text;
                Snippets.Serialize();
                Close();
            }
            else if(String.IsNullOrEmpty(Command.Text) && !String.IsNullOrEmpty(Substitutor_title.Text))
            {
                MessageBox.Show("Command cannot be left empty!");
            }
            else if (!String.IsNullOrEmpty(Command.Text) && String.IsNullOrEmpty(Substitutor_title.Text))
            {
                MessageBox.Show("Substitutor Title cannot be left empty!");
            }
            else
            {
                MessageBox.Show("Command and Substitutor Title both must be filled!");
            }
        }
    }
}
