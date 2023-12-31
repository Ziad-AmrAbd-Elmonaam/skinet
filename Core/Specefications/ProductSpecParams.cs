using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specefications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex {get;set;} = 1;
        private int _pageSize = 6;
        public int PageSize
        {
            get=>_pageSize;
            set=>_pageSize=(value>MaxPageSize)?MaxPageSize:value;
        }
        public int? brandId { get; set; }
        public int? typeId { get; set; }
        public string sort {get;set;}
        public string _search { get; set; }
        public string Search { get=>_search; set=>_search=value.ToLower(); }

    }
}