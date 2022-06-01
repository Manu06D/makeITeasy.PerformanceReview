using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makeITeasy.PerformanceReview.Models
{
    public partial class FormItem
    {
        public object DatabaseID => Id;
        public FormItemType? FormItemType { get; set; }
    }
}
