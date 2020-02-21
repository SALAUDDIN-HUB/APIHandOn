using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandsOnPractice.Models;

namespace HandsOnPractice.Repositories
{
    public class EmployeeRepository
    {
        public List<Employee> GetAll()
        {
            using(masterContext db=new masterContext())
            {
                return db.Employee.ToList();
            }
        }
        public Employee GetById(string Eid)
        {
            using (masterContext db = new masterContext())
            {
                return db.Employee.Find(Eid);
            }

        }
        public void Add(Employee item)
        {
            using (masterContext db = new masterContext())
            {
                db.Employee.Add(item);
                db.SaveChanges();
            }
        }
        public void Delete(string Eid)
        {
            using (masterContext db = new masterContext())
            {
                Employee e = db.Employee.Find(Eid);
                db.Employee.Remove(e);
                db.SaveChanges();
            }
        }
        public void Update(Employee item)
        {
            using (masterContext db = new masterContext())
            {
                db.Employee.Update(item);
                db.SaveChanges();
            }
        }
       
    }
}
