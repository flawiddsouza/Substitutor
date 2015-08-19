﻿using System.Windows;

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
            Owner = Application.Current.MainWindow;
            index = thisIndex;

            Title = Snippets.List[index].SubtitutorTitle;
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            if(Substitute.Text.Contains(" ")) // if substitute.text has space, then add quotes around it
            {
                Substitute.Text = "\"" + Substitute.Text + "\"";
            }

            string executableCommand = string.Join(" ", Snippets.List[index].Command, Substitute.Text, Snippets.List[index].ExtraArgs);
            System.Diagnostics.Process.Start("CMD.exe", "/k"+executableCommand);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}