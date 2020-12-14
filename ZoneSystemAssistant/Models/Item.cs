using System;

namespace ZoneSystemAssistant.Models
{
    public class Item : IItem
    {
        public string Id { get; set; }
        public int Ev { get; set; }
        public string Description { get; set; }
    }
}