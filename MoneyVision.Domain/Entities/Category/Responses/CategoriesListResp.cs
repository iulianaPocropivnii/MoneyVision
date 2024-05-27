﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.Category.Responses
{
    public class CategoriesListResp : GenericResp
    {
        public List<Category> Categories { get; set; }
    }
}