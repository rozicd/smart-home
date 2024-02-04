using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DataTransferObjects.Responses
{
    public class CarChargerActionsDTO
    {
        public string User {  get; set; }
        public string Action { get; set; }
        public string Value {  get; set; }
        public string Field {  get; set; }
        public string Timestamp {  get; set; }
    }
}
