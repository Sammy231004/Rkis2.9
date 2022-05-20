using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfApp4.ViewModel
{
    public class ProfilViewModel: BaseViewModel
    {
        private RelayCommand _ListTask;
        private ObservableCollection<User> _users;
        private User _user;
        private string _UserFIO;
        private string _login;
        private string _numberTel;
        private User AutoUser;

        public RelayCommand ListTask
        {
            get
            {
                return _ListTask ??
                    (_ListTask = new RelayCommand((x) =>
                    {
                        TaskWindow taskWindow = new TaskWindow();
                        taskWindow.Show();
                    }));

            }
        }
        public string UserFIO
        {
            get => _UserFIO = User.AutoUser.Surname + " " + User.AutoUser.Name + " " + User.AutoUser.LastName;
        }
        public string UserLogin
        {
            get => _login = User.AutoUser.Login;
        }
        public string UserPhone
        {
            get => _numberTel = User.AutoUser.NumberTel;
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

        
        public ProfilViewModel ()
        {
            HelpContext helpContext = new HelpContext ();
            _users = new ObservableCollection<User>(helpContext.Users);
            _user = new User();
        }
    }
}
