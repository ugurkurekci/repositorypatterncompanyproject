﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int AdminID { get; set; }
        
        public string Name { get; set; }
        
        public string Passw { get; set; }

        public string Mail { get; set; }
    }
    
}
