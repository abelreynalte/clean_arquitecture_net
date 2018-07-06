using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto.Common
{
    public class ResponseDto
    {
        private Object response;

        public Object getResponse()
        {
            return response;
        }

        public void setResponse(Object response)
        {
            this.response = response;
        }
    }
}
