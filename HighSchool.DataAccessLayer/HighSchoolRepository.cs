using HighSchool.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchool.DataAccessLayer
{
    public class HighSchoolRepository
    {
        private HighSchoolContext context;

        public HighSchoolRepository()
        {
            context = new HighSchoolContext();
        }

        public List<Person> GetAllPerson() 
        {
            //var personList = (from p in context.Person select context);
            return null;

        }
    }
}
