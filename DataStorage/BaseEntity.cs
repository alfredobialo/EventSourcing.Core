using System;

namespace DataStorage
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string ChannelId { get; set; }
        protected bool IsActive { get; set; } = true;

    }
}