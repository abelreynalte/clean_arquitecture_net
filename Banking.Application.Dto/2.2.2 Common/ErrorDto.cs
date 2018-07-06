using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto.Common
{
    public class ErrorDto
    {
        private String message;

        public ErrorDto()
        {
        }

        public ErrorDto(String message)
        {
            this.message = message;
        }

        public String getMessage()
        {
            return message;
        }

        public void setMessage(String message)
        {
            this.message = message;
        }
    }
}
