using ItemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemService.Repositories
{
    public class ItemRepository : IITemRepository
    {
        private readonly ShopDBContext _context;
        public ItemRepository(ShopDBContext context)
        {
            _context = context;
        }
   
        
        public void AddItems(Items obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteItem(string id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }

        public List<Items> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public Items GetById(string id)
        {
            return _context.Items.Find(id);
        }

        public void UpdateItem(Items obj)
        {
            _context.Items.Update(obj);
            _context.SaveChanges();
        }
    }
}

