using System;
using System.Collections.Generic;

namespace WpfApp4
{
    public partial class User
    {
        public User()
        {
            TaskIduserAcceptNavigations = new HashSet<Task>();
            TaskIduserCreatedNavigations = new HashSet<Task>();
        }

        public int Iduser { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string NumberTel { get; set; } = null!;

        public static User AutoUser { get; set; }

        public virtual ICollection<Task> TaskIduserAcceptNavigations { get; set; }
        public virtual ICollection<Task> TaskIduserCreatedNavigations { get; set; }
    }
}
