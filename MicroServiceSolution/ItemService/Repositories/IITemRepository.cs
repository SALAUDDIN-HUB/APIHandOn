using ItemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemService.Repositories
{
   public interface IITemRepository
    {
        List<Items> GetAllItems();
        Items GetById(string id);
        void AddItems(Items obj);
        void DeleteItem(string id);
        void UpdateItem(Items obj);

    }
}
