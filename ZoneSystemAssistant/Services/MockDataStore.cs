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
            InitializeWithRandomItems();
        }

        private void InitializeWithRandomItems()
        {
            items = new List<Item>()
            {
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // -6
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // -5
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // -4
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // -3
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // -2
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // -1
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 0
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 1
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 2
                new Item {Id = Guid.NewGuid().ToString(), Ev = 3, Description = "Shadows"},
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 4
                new Item {Id = Guid.NewGuid().ToString(), Ev = 5, Description = "Trees"},
                new Item {Id = Guid.NewGuid().ToString(), Ev = 6, Description = "Dark side"},
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 7
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 8
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 9
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 10
                new Item {Id = Guid.NewGuid().ToString(), Ev = 11, Description = "Light side"},
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 12
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 13
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 14
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 15
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 16
                new Item {Id = Guid.NewGuid().ToString(), Ev = 17, Description = "Sky"},
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 18
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 19
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 20
                new Item {Id = Guid.NewGuid().ToString(), Ev = -1, Description = ""}, // 21
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            int index = item.Ev + 6;
            var existingItem = items[index];
            existingItem.Ev = item.Ev;
            existingItem.Description += $",{item.Description}";

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
            //items.Remove(oldItem);
            oldItem.Ev = -1;
            oldItem.Description = "";

            return await Task.FromResult(true);
        }

        public async Task<bool> ClearAll()
        {
            InitializeWithRandomItems();
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