using System;
using System.Windows;

namespace Substitutor
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        public AddItem()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(Command.Text) && !String.IsNullOrEmpty(Subtitutor_title.Text))
            {
                Snippets.List.Add(new Snippet { Command = Command.Text, SubtitutorTitle = Subtitutor_title.Text, ExtraArgs = Extra_args.Text });
                Snippets.Serialize();
                Close();
            }
            else if(String.IsNullOrEmpty(Command.Text) && !String.IsNullOrEmpty(Subtitutor_title.Text))
            {
                MessageBox.Show("Command cannot be left empty!");
            }
            else if (!String.IsNullOrEmpty(Command.Text) && String.IsNullOrEmpty(Subtitutor_title.Text))
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
