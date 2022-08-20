using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductGroup
{
    public class GroupDetailViewModel
    {
        public long DetailId { get; set; }
        public long GroupId { get; set; }
        public string DetailTitle { get; set; }
    }
}
