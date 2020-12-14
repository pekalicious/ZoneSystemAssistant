using System;
using System.Collections.Generic;
using System.Text;

namespace ZoneSystemAssistant.Models
{
    public class MockItem : IItem
    {
        public string Id { get { return ""; } }
        public int Ev { get { return -1; } }
        public string Description { get { return ""; } }
    }
}
