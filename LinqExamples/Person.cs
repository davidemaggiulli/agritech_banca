using System;
using System.Collections.Generic;
using System.Text;
using LinqExamples;


namespace LinqExamples
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        private int height;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value < 100 || value > 230)
                    throw new ArgumentOutOfRangeException("Altezza deve essere tra 100 e 230");
                height = value;
            }
        }

        public Gender Gender { get; set; }

        public decimal? Salary { get; set; }

        public string City { get; set; }
    }
}
