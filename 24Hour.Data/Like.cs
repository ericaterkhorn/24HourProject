using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Like
    {
        public string LikedPost { get; set; }
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        
    }
}
