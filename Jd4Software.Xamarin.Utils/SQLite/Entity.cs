using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jd4Software.Utils.SQLite
{
    public class Entity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }

        public bool IsPersisted => Id > 0;
        public bool IsFirstItem => Id == 1;

        public Entity()
        {
            Id = 0;
            Created = DateTime.UtcNow;
            Changed = Created;
        }
    }
}
