using System.Collections.Generic;

namespace SquareFish.Core
{
    public class Leader : BaseEntity<int>
    {
        public Leader(int id, string name)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; set; }
        public ICollection<BookingLeader> BookingLeader { get; private set; }
    }
}
