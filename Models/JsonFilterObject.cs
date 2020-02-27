using System;
using System.Collections.Generic;

namespace massage.Models {
    public class JsonFilterObject {
        public int PractitionerId { get; set; }
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public OldListObject OldList { get; set; }
    }
    public class OldListObject {
        public List<EventObject> OldEventList { get; set; }
    }
    public class EventObject {
        public int Id { get; set; }
        public string Title { get; set; }
        public long Start { get; set; }
        public long End { get; set; }
    }
}