using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment.Models;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServicesController : ControllerBase
    {
        customerDBContext db = new customerDBContext();
        [HttpGet]
        public List<Customer> GetAll()
        {
            return db.Customer.ToList();
        }
        [HttpGet("{cid}")]
        [Route("GetById/{cid}")]
        public Customer GetById(string cid)
        {
            return db.Customer.Find(cid);
        }
        [HttpGet("{city}")]
        [Route("GetByCity/{city}")]
        public List<Customer> GetByCity(string city)
        {
            return db.Customer.Where(p=>p.City==city).ToList();
        }
        [HttpPost]
        [Route("Add")]
        public void Add(Customer item)
        {
            db.Customer.Add(item);
            db.SaveChanges();
        }
        [HttpPost]
        [Route("Customer/{item}")]
        public void Update(Customer item)
        {
            db.Customer.Update(item);
            db.SaveChanges();
        }
    }
}