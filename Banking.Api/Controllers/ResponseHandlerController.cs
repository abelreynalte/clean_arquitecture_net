using Banking.Application.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Banking.Api.Controllers
{
    public class ResponseHandlerController : ApiController
    {

        [HttpGet]
        public object getOkCommandResponse(String message)
        {
            ResponseDto responseDto = new ResponseDto();
            ResponseOkCommandDto responseOkCommandDto = new ResponseOkCommandDto();
            responseOkCommandDto.httpStatus = Convert.ToInt32(HttpStatusCode.Created);
            responseOkCommandDto.message = message;
            responseDto.response = responseOkCommandDto;
            var val = responseDto.response;
            return  responseDto.response;
        }

        [HttpGet]
        public object getAppCustomErrorResponse(String errorMessages)
        {
            ResponseDto responseDto = new ResponseDto();
            String[] errors = errorMessages.Split(',');
            List<ErrorDto> errorsDto = new List<ErrorDto>();
            foreach (String error in errors)
            {
                errorsDto.Add(new ErrorDto(error));
            }
            ResponseErrorDto responseErrorDto = new ResponseErrorDto(errorsDto);
            responseErrorDto.httpStatus = Convert.ToInt32(HttpStatusCode.BadRequest);
            responseDto.response = responseErrorDto;
            return responseDto.response;
        }

        [HttpGet]
        public object getAppExceptionResponse()
        {
            ResponseDto responseDto = new ResponseDto();
            List<ErrorDto> errorsDto = new List<ErrorDto>();
            errorsDto.Add(new ErrorDto("Server error"));
            ResponseErrorDto responseErrorDto = new ResponseErrorDto(errorsDto);
            responseErrorDto.httpStatus = Convert.ToInt32(HttpStatusCode.InternalServerError);
            responseDto.response = responseErrorDto;
            return responseDto.response;
        }
    }
}
