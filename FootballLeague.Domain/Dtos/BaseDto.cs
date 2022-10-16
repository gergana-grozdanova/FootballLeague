using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Domain.Dtos
{
    public  class BaseDto
    {
      public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
