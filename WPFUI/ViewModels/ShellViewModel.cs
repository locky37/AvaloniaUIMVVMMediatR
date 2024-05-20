using Caliburn.Micro;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "TextBlock";
        private string _lastName;
        private BindableCollection<PersonModel> _people = [];
        private PersonModel _selectedPerson;

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "FirstName", LastName = "FirstLastName" });
            People.Add(new PersonModel { FirstName = "SecondName", LastName = "SecondLastName" });
            People.Add(new PersonModel { FirstName = "ThirdName", LastName = "ThirdLastName" });
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName) //=> !string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName);
        {
            //return !string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName);
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItemAsync(new FirstChildViewModel());
        }
        public void LoadPageTwo()
        {
            ActivateItemAsync(new SecondChildViewModel());
        }
    }
}
