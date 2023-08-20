﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } 
        public int UpdatedBy { get; set;}
        public DateTime UpdatedOn { get; set;}
        public int DeleteBy { get; set; }
        public DateTime DeleteOn { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
