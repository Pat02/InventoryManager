using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Domain.Models
{
    public interface ITrackable
    {
        Guid id { get; set; }
    }
}
