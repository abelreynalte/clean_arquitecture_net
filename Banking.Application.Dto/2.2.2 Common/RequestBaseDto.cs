using Banking.Application.Dto.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto.Common
{
    public class RequestBaseDto
    {
        protected RequestBodyType requestBodyType;

        public RequestBodyType getRequestBodyType()
        {
            return requestBodyType;
        }

        public void setRequestBodyType(RequestBodyType requestBodyType)
        {
            this.requestBodyType = requestBodyType;
        }
    }
}
