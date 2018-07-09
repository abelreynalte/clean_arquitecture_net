using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto.Common
{
    public class ResponseErrorDto
    {
        //private int httpStatus;
        //private List<ErrorDto> errors;
        public int httpStatus { get; set; }
        public List<ErrorDto> errors { get; set; }

        public ResponseErrorDto()
        {
        }

        public ResponseErrorDto(List<ErrorDto> errors)
        {
            this.errors = errors;
        }

        //public int getHttpStatus()
        //{
        //    return httpStatus;
        //}

        //public void setHttpStatus(int httpStatus)
        //{
        //    this.httpStatus = httpStatus;
        //}

        //public List<ErrorDto> getErrors()
        //{
        //    return errors;
        //}

        //public void setErrors(List<ErrorDto> errors)
        //{
        //    this.errors = errors;
        //}
    }
}
