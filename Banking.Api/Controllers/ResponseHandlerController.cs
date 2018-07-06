using Banking.Application.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Banking.Api.Controllers
{
    public class ResponseHandlerController : ApiController
    {
        //// GET: api/Common
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Common/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Common
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Common/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Common/5
        //public void Delete(int id)
        //{
        //}
        [HttpGet]
        public IHttpActionResult getOkCommandResponse(String message)
        {
            ResponseDto responseDto = new ResponseDto();
            ResponseOkCommandDto responseOkCommandDto = new ResponseOkCommandDto();
            responseOkCommandDto.setHttpStatus(Convert.ToInt32(HttpStatusCode.Created));
            responseOkCommandDto.setMessage(message);
            responseDto.setResponse(responseOkCommandDto);
            return Json(responseDto.getResponse());
        }

        [HttpGet]
        public IHttpActionResult getAppCustomErrorResponse(String errorMessages)
        {
            ResponseDto responseDto = new ResponseDto();
            String[] errors = errorMessages.Split(',');
            List<ErrorDto> errorsDto = new List<ErrorDto>();
            foreach (String error in errors)
            {
                errorsDto.Add(new ErrorDto(error));
            }
            ResponseErrorDto responseErrorDto = new ResponseErrorDto(errorsDto);
            responseErrorDto.setHttpStatus(Convert.ToInt32(HttpStatusCode.BadRequest));
            responseDto.setResponse(responseErrorDto);
            return Json(responseDto.getResponse());
        }

        [HttpGet]
        public IHttpActionResult getAppExceptionResponse()
        {
            ResponseDto responseDto = new ResponseDto();
            List<ErrorDto> errorsDto = new List<ErrorDto>();
            errorsDto.Add(new ErrorDto("Server error"));
            ResponseErrorDto responseErrorDto = new ResponseErrorDto(errorsDto);
            responseErrorDto.setHttpStatus(Convert.ToInt32(HttpStatusCode.InternalServerError));
            responseDto.setResponse(responseErrorDto);
            return Json(responseDto.getResponse());
        }
    }
}
