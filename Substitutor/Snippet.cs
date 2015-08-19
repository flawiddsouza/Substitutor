using System.ComponentModel;

namespace Substitutor
{
    public class Snippet : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string command;
        public string Command
        {
            get { return command; }
            set
            {
                command = value;
                OnPropertyChanged(Command);
            }
        }

        private string substitutorTitle;
        public string SubstitutorTitle
        {
            get { return substitutorTitle; }
            set
            {
                substitutorTitle = value;
                OnPropertyChanged(SubstitutorTitle);
            }
        }

        private string extraArgs;
        public string ExtraArgs
        {
            get { return extraArgs; }
            set
            {
                extraArgs = value;
                OnPropertyChanged(ExtraArgs);
            }
        }
    }
}