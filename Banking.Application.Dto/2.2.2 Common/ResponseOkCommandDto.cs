using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto.Common
{
    public class ResponseOkCommandDto
    {
        public int httpStatus { get; set; }
        public string message { get; set; }        
    }
}
