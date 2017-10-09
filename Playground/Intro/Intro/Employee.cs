using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    public class Employee : Person
    {
        public override string FullName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }
    }
}
