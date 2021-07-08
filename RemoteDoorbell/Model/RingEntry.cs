using System;

namespace RemoteDoorbell.Model
{
    public class RingEntry
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public RingEntry()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }
    }
}
