using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REAL_Estate.Objects.Models
{
    public class Filee : AModel
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        [ForeignKey(nameof(Property))]
        public long PropertyId { get; set; }

        // Navigation property
        public virtual Property Property { get; set; }
    }
}
