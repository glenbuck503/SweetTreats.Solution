using System.Collections.Generic;

namespace SweetTreats.Models
{
    public class Flavor
    {
    public Flavor()
    {
        this.TreatFlavor = new HashSet<TreatFlavor>();
    }

    public int FlavorId { get; set; }
    public string Description { get; set; }
    public virtual ApplicationUser User { get; set; }

    public virtual ICollection<TreatFlavor> TreatFlavor { get;}
    }
}