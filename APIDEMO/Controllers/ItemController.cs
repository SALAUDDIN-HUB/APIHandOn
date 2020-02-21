using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIDEMO.Models;
namespace APIDEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        masterContext db = new masterContext();
        [HttpGet]
        public List<Item> GetAll()
        {
            return db.Item.ToList();
        }
        [HttpGet("{ItemID}")]
        [Route("GetById/{ItemID}")]
        public Item GetById(int ItemID)
        {
            return db.Item.Find(ItemID);
        }
        [HttpPost("{ItemName}")]
        [Route("GetByName/{ItemName}")]
        public Item GetByName(string ItemName)
        {
            return db.Item.SingleOrDefault(p => p.ItemName == ItemName);
        }
        [HttpPost]
        [Route("AddItem")]
        public void Add(Item num)
        {
            db.Item.Add(num);
            db.SaveChanges();
        }
        [HttpDelete]
        [Route("Delete/{ItemID")]
        public void Delete(int ItemID)
        {
            Item p = db.Item.Find(ItemID);
            db.Remove(p);
            db.SaveChanges();

        }
        [HttpPut]
        [Route("Update/{ItemID}")]
        public void Update(int ItemID)
        {
            Item p = db.Item.Find(ItemID);
            db.Item.Update(p);
            db.SaveChanges();
        }
    }
}
