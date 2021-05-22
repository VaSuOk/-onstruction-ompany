using System;
using System.Collections.Generic;
using System.Text;

namespace Сonstruction_сompany.Auxiliary_classes
{
    class UserAge
    {
        public List<int> Age { get; set; }
        public UserAge()
        {
            InitAgeList();
        }
        private void InitAgeList()
        {
            Age = new List<int>();
            for(int i = 18; i <= 60; i++)
            {
                Age.Add(i);
            }
        }
    }
}
