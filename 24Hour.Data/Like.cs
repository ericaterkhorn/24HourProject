using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Like
    {
        [Key]
        public int LikeID { get; set; }
        public string LikedPost { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }
        public virtual User User { get; set; }
        
    }
}
