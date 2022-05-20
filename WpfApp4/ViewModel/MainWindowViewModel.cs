using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp4.ViewModel
{
    public class MainWindowViewModel:BaseViewModel
    {
        private User user;
        private ObservableCollection<User> users;
        private RelayCommand welcom;
        private RelayCommand registration;



        public RelayCommand Welcom
        {
            get
            {
                return welcom ??
                    (welcom = new RelayCommand(x =>
                    {
                        HelpContext helpContext = new HelpContext();
                        User user = helpContext.Users.FirstOrDefault(y => y.Login == User.Login && y.Password == User.Password);
                        if (user != null)
                        {
                            User.AutoUser = user;

                            Profil profil= new Profil();
                            profil.Show();
                            foreach (var window in App.Current.Windows)
                            {
                                if (window is MainWindow mainWindow)
                                {
                                    mainWindow.Close();

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Данные введены неверно!");
                        }
                    }
                    ));
            }
        }
        public RelayCommand Registration
        {
            get
            {
                return registration ?? (registration = new RelayCommand(x =>
                {
                    Registration window2 = new Registration();
                    window2.Show();
                    foreach (var window in App.Current.Windows)
                    {
                        if (window is MainWindow mainWindow)
                        {
                            mainWindow.Close();
                        }
                    }

                }

                ));
            }
        }
        public User User 
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }
        public MainWindowViewModel()
        {
            HelpContext helpContext = new HelpContext();
          Users = new ObservableCollection<User>(helpContext.Users);
            User = new User();
        }

    }

}
