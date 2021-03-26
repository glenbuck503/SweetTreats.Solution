using System.Collections.Generic;

namespace SweetTreats.Models
{
  public class Treat
    {
        public Treat()
        {
            this.TreatFlavor = new HashSet<TreatFlavor>();
        }

        public int TreatId { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<TreatFlavor> TreatFlavor { get; set; }
    }
}