using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.CoreSystem.Manager.Domain.DTO
{
    public class Base
    {
        public int Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? LastUpdatedOn { get; set; }
    }
}
