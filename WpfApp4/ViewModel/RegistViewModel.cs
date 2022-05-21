using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace WpfApp4.ViewModel
{
    public class RegistViewModel: BaseViewModel
    {
        private ObservableCollection<User> _users;
        private User _user;
        private RelayCommand _AddUser;


        public RelayCommand AddUser
        {
            get 
            { return _AddUser ??
                (_AddUser = new RelayCommand((x) =>
                {
                    HelpContext helpContext = new HelpContext();
                    User user =  User;
                    user.Iduser = helpContext.Users.Count() + 1;
                    helpContext.Users.Add(user);
                    helpContext.SaveChanges();
                    user = null;

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    foreach (var window in App.Current.Windows)
                    {
                        if (window is Registration registration)
                        {
                            registration.Close();
                        }
                    }


                }));
            }
        }

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        public RegistViewModel()
        {
            HelpContext helpContext = new HelpContext();
            _users = new ObservableCollection<User>(helpContext.Users);
            _user = new User();
        }

    }
}
