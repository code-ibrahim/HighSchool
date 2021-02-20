using HighSchool.DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace HighSchool.DataAccessLayer
{
    public class HighSchoolRepository
    {
        private HighSchoolContext context;

        public HighSchoolRepository()
        {
            //context = new HighSchoolContext();
        }

        public List<Person> GetAllPerson() 
        {
            context = new HighSchoolContext();
            var personList = (from p in context.Person orderby p.PersonId select p).ToList<Person>();
            return personList;

        }

        public Person GetPersonById(long id)
        {
            context = new HighSchoolContext();
            var per1 = (from p in context.Person orderby p.PersonId where p.PersonId == id select p).FirstOrDefault();
            var per = context.Person.Where(p => p.PersonId == id).FirstOrDefault();
            return per;

        }
    }
}
