using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp4.ViewModel
{
    public class TaskViewModel: BaseViewModel
    {
        
        private RelayCommand _Find;
        private RelayCommand _UpdateStatus;
        private RelayCommand _GivTask;
        private RelayCommand _HistoryComplateTask;
        private RelayCommand _FreeTask;
  
        private ObservableCollection<Task> _tasks;
        private Task _task;
        private int _count = 0;
        private int _count1 = 0;
        private int _count2 = 0;
        private string _loginUser;


        public RelayCommand Find
        {
            get => _Find ??
                (_Find = new RelayCommand((x) =>
                {
                    _count2++;
                   HelpContext helpContext = new HelpContext();
                    Tasks = new ObservableCollection<Task>(helpContext.Tasks.Where(p => p.IduserCreatedNavigation.Login == loginUser));
                    if (_count2 % 2 == 0)
                    {
                        Tasks = new ObservableCollection<Task>(helpContext.Tasks);
                    }
                }));
        }

        public RelayCommand FreeTask
        {
            get => _FreeTask ??
                (_FreeTask = new RelayCommand((x) =>
                {
                    _count1++;
                    HelpContext helpContext = new HelpContext();
                    Tasks = new ObservableCollection<Task>(helpContext.Tasks.Where(p => p.IdstatusTask == 1));
                    if (_count1 % 2 == 0)
                    {
                        Tasks = new ObservableCollection<Task>(helpContext.Tasks);
                    }
                }));
        }
        public RelayCommand HistoryComplateTask
        {
            get => _HistoryComplateTask ??
                (_HistoryComplateTask = new RelayCommand((x) =>
                {
                    _count++;
                    HelpContext helpContext = new HelpContext();
                    Tasks = new ObservableCollection<Task>(helpContext.Tasks.Where(p => p.IdstatusTask == 3));
                    if (_count % 2 == 0)
                    {
                        Tasks = new ObservableCollection<Task>(helpContext.Tasks);
                    }
                }));

        }
        public RelayCommand GivTask
        {
            get => _GivTask ??
                (_GivTask = new RelayCommand((x) =>
                {
                    if (x is Task task)
                    {
                        if(task.IdstatusTask == 1)
                        {
                            task.IduserAccept = User.AutoUser.Iduser;
                            task.IdstatusTask = 2;
                            HelpContext helpContext = new HelpContext();
                            task.IdstatusTaskNavigation = helpContext.StatusTasks.Find(2);
                            helpContext.Tasks.Update(task);
                            helpContext.SaveChanges();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Кто-то уже взял это задание.");
                    }
                }));
            
        }
        public RelayCommand UpdateStatus
        {

            get => _UpdateStatus ??
                (_UpdateStatus = new RelayCommand((x) =>
                {
                    if (x is Task task)
                    {
                        if (task.IduserCreated == User.AutoUser.Iduser)
                        {


                            HelpContext helpContext = new HelpContext();
                            helpContext.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            if (task.IdstatusTask == 1)
                            {
                                task.IdstatusTask = 2;
                                task.IdstatusTaskNavigation = helpContext.StatusTasks.Find(2);
                                helpContext.Tasks.Update(task);
                                helpContext.SaveChanges();
                            }
                            else if (task.IdstatusTask == 2)
                            {
                                task.IdstatusTask = 3;
                                task.IdstatusTaskNavigation = helpContext.StatusTasks.Find(3);
                                helpContext.Tasks.Update(task);
                                helpContext.SaveChanges();
                            }
                            else if (task.IdstatusTask == 3)
                            {
                                task.IdstatusTask = 1;
                                task.IdstatusTaskNavigation = helpContext.StatusTasks.Find(1);
                                helpContext.Tasks.Update(task);
                                helpContext.SaveChanges();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Изменение доступно только для своих задач!");
                        }
                    
                    }
                }

                ));

        }
      
        public string loginUser
        {
            get => _loginUser;
            set
            {
                _loginUser = value;
                OnPropertyChanged();
            }
        }
       
        public ObservableCollection<Task> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }

        }
        public Task Task
        {
            get => _task;
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }
        
       
        public TaskViewModel()
        {
            HelpContext helpContext = new HelpContext();
            _tasks = new ObservableCollection<Task>(helpContext.Tasks);
          
            _task = new Task();
        }
    }
}
