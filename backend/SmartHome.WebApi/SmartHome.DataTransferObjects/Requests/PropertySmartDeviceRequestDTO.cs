using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Requests
{
    public class PropertySmartDeviceRequestDTO
    {
        public Pagination Page {  get; set; }
        public Guid PropertyId {  get; set; }

        public PropertySmartDeviceRequestDTO()
        {
            Page= new Pagination();
            Page.PageNumber = 1;
            Page.PageSize = 10;
        }
        public PropertySmartDeviceRequestDTO(int pageNumber, int pageSize)
        {
            Page.PageNumber = pageNumber < 1 || pageNumber == null ? 1 : pageNumber;
            Page.PageSize = pageSize > 10 || pageSize == null ? 10 : pageSize;

        }
    }
}
