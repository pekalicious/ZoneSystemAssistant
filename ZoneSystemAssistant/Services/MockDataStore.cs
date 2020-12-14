using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoneSystemAssistant.Models;

namespace ZoneSystemAssistant.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item {Id = Guid.NewGuid().ToString(), Ev = 3, Description = "Shadows"},
                new Item {Id = Guid.NewGuid().ToString(), Ev = 5, Description = "Trees"},
                new Item {Id = Guid.NewGuid().ToString(), Ev = 6, Description = "Dark side"},
                new Item {Id = Guid.NewGuid().ToString(), Ev = 11, Description = "Light side"},
                new Item {Id = Guid.NewGuid().ToString(), Ev = 17, Description = "Sky"},
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            var existingItem = items.SingleOrDefault(i => i.Ev == item.Ev);

            if (existingItem != null)
            {
                existingItem.Ev = item.Ev;
                existingItem.Description += $",{item.Description}";
            }
            else
            {
                items.Add(item);
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            //var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            //items.Remove(oldItem);
            //items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> ClearAll()
        {
            items.Clear();
            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}