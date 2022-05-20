using System;
using System.Collections.Generic;
using WpfApp4.ViewModel;

namespace WpfApp4
{
    public partial class Task:BaseViewModel

    {
        private StatusTask _IdstatusTaskNavigation;
        public int Idtask { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DatePuplic { get; set; }
        public int IduserCreated { get; set; }
        public int IduserAccept { get; set; }
        public int IdstatusTask { get; set; }

        public virtual StatusTask IdstatusTaskNavigation 
        {
        get=> _IdstatusTaskNavigation;
            set
            {
                _IdstatusTaskNavigation = value;
                OnPropertyChanged();
            }
   
        }
        public virtual User IduserAcceptNavigation { get; set; } = null!;
        public virtual User IduserCreatedNavigation { get; set; } = null!;
    }
}
