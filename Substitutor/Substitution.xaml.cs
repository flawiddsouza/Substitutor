using System.Windows;

namespace Substitutor
{
    /// <summary>
    /// Interaction logic for Substitution.xaml
    /// </summary>
    public partial class Substitution : Window
    {
        private int index;

        public Substitution(int thisIndex)
        {
            InitializeComponent();

            SourceInitialized += (s, e) =>
            {
                MaxHeight = ActualHeight;
            };

            Owner = Application.Current.MainWindow;
            index = thisIndex;

            Title = Snippets.List[index].SubstitutorTitle;
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            if (!Substitute.Text.StartsWith("\"") && !Substitute.Text.EndsWith("\"")) // first check if quotes exist around the string
            {
                if (Substitute.Text.Contains(" ")) // if substitute.text has space, then add quotes around it
                {
                    Substitute.Text = "\"" + Substitute.Text + "\"";
                }
            }

            string executableCommand = string.Join(" ", Snippets.List[index].Command, Substitute.Text, Snippets.List[index].ExtraArgs);
            System.Diagnostics.Process.Start("CMD.exe", "/k"+executableCommand);

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}