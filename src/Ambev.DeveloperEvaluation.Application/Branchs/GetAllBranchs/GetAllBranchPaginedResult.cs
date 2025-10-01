﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetAllBranchs
{
    public class GetAllBranchPaginedResult
    {
        public List<GetAllBranchResult> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }        
    }
}
