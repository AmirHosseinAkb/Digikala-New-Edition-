﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;

namespace Digikala.Application.Contracts.ShopManagement.ProductGroup
{
    public class GroupDetailViewModel
    {
        public long DetailId { get; set; }
        public long GroupId { get; set; }
        public string DetailTitle { get; set; }
    }
}
