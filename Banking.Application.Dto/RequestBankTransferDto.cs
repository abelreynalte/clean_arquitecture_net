using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Application.Dto.Enumeration;
using Banking.Application.Dto.Common;

namespace Banking.Application.Dto
{
    public class RequestBankTransferDto: RequestBaseDto
    {
        public String fromAccountNumber { get; set; }
        public String toAccountNumber { get; set; }
        public decimal amount { get; set; }

        public RequestBankTransferDto()
        {
        }

        public RequestBankTransferDto(String fromAccountNumber, String toAccountNumber, decimal amount, RequestBodyType requestBodyType)
        {
            this.fromAccountNumber = fromAccountNumber;
            this.toAccountNumber = toAccountNumber;
            this.amount = amount;
            this.requestBodyType = requestBodyType;
        }        
    }
}
