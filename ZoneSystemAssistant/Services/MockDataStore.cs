using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoneSystemAssistant.Models;

namespace ZoneSystemAssistant.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 1
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 2
                new Item { Id = Guid.NewGuid().ToString(), Text = "3", Description="Shadows" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 4
                new Item { Id = Guid.NewGuid().ToString(), Text = "5", Description="Trees" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "6", Description="Dark side" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 7
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 8
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 9
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 10
                new Item { Id = Guid.NewGuid().ToString(), Text = "11", Description="Light side" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 12
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 13
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 14
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 15
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" }, // 16
                new Item { Id = Guid.NewGuid().ToString(), Text = "17", Description="Sky" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Description="" },
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

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