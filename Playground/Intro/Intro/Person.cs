using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
