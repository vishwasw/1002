﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socrates.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName;  }
        }
    }
}