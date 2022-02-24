using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OptimisticConcurrentHandle.Domain
{
    public class Pencil
    {
        public Guid PencilId { get; set; }
        public string Color { get; set; }

        public byte[] RowVersion { get; set; }

        public bool? Buyed { get; set; } 

        public DateTime? LastUpdate { get; set; }
        public Guid? UpdateBy { get; set; }
    }

    public static class PencilExtension
    {
        public static Pencil DeepCopy(this Pencil pencil)
        {
            return new Pencil()
            {
                PencilId = pencil.PencilId,
                Color = pencil.Color,
                RowVersion = pencil.RowVersion,
                Buyed = pencil.Buyed,
                LastUpdate = pencil.LastUpdate,
                UpdateBy = pencil.UpdateBy
            };
        }
    }
}
