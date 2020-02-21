using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandsOnPractice.Models;
using HandsOnPractice.Repositories;

namespace HandsOnPractice.Repositories
{
    public class ProjectRepository
    {
        public List<Project4> GetAll()
        {
            using(masterContext db= new masterContext())
            {
                return db.Project4.ToList();
            }
        }
        public Project4 GetById(int pid)
        {
            using(masterContext db=new masterContext())
            {
                return db.Project4.Find(pid);
            }
        }
        public void Add(Project4 item)
        {
            using (masterContext db = new masterContext())
            {
                db.Project4.Add(item);
                db.SaveChanges();
            }
        }
        public void Delete(int pid)
        {
            using(masterContext db=new masterContext())
            {

                Project4 p = db.Project4.Find(pid);
                db.Project4.Remove(p);
                db.SaveChanges();
            }
        }
        public void Update(Project4 item)
        {
            using (masterContext db = new masterContext())
            {
                db.Project4.Update(item);
                db.SaveChanges();
            }
        }

    }
}
