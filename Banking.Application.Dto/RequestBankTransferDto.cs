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
        ////private String fromAccountNumber;
        ////private String toAccountNumber;
        ////private decimal amount;
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

        //public String getFromAccountNumber()
        //{
        //    return fromAccountNumber;
        //}

        //public void setFromAccountNumber(String fromAccountNumber)
        //{
        //    this.fromAccountNumber = fromAccountNumber;
        //}

        //public String getToAccountNumber()
        //{
        //    return toAccountNumber;
        //}

        //public void setToAccountNumber(String toAccountNumber)
        //{
        //    this.toAccountNumber = toAccountNumber;
        //}

        //public decimal getAmount()
        //{
        //    return amount;
        //}

        //public void setAmount(decimal amount)
        //{
        //    this.amount = amount;
        //}
    }
}
