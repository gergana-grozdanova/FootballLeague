using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Data.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
