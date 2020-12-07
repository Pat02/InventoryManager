using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public class Trackable : ITrackable
    {
        public Guid id { get; set; }
    }
}
