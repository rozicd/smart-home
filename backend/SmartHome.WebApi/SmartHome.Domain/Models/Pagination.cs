using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models
{
    public class Pagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public Pagination()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public Pagination(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 || pageNumber == null ? 1 : pageNumber;
            PageSize = pageSize > 10 || pageSize == null ? 10 : pageSize;
           
        }

    }
}
