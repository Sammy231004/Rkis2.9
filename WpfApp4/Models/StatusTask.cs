using System;
using System.Collections.Generic;

namespace WpfApp4
{
    public partial class StatusTask
    {
        public StatusTask()
        {
            Tasks = new HashSet<Task>();
        }

        public int IdstatusTask { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
