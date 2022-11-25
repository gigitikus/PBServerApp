using NPOI.SS.Formula.Functions;
using PBShared.DataTransferObject.Transaksi.TR_Partais.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.Models
{
    public class PagingParams
    {
        public class DynamicCondition
        {
            public string condition { get; set; }
            public int pageNumber { get; set; }
            public int rowsOfPage { get; set; }
        }
        public class GetPartaisResult
        {
            public int TotalCount { get; set; }
            public List<TRPartai>? Models { get; set; }
            public string? errorMessage { get; set; }
        }
    }
}
