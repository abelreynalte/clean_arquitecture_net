using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto.Common
{
    public class ResponseOkQueryDto<T>
    {
        private int httpStatus;
        private List<T> data;

        public int getHttpStatus()
        {
            return httpStatus;
        }

        public void setHttpStatus(int httpStatus)
        {
            this.httpStatus = httpStatus;
        }

        public List<T> getData()
        {
            return data;
        }

        public void setData(List<T> data)
        {
            this.data = data;
        }
    }
}
