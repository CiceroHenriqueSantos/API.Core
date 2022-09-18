using System;

namespace API.CoreSystem.Manager.Domain.Entities
{
    public class Base
    {
        protected Base()
        {
        }
        public int Id { get; protected set; }
        public DateTimeOffset? CreateDate { get; protected set; }
        public DateTimeOffset? LastUpdatedOn { get; protected set; }
    }
}
