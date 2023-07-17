using System;
using System.Collections.Generic;
using System.Text;

namespace blogPostAppAPI.Core.OperationalResult
{
    public class OperationalResult<TDto>
    {
        public bool IsSuccess { get; set; }
        public string message { get; set; }
        public TDto item { get; set; }

        public OperationalResult(TDto item, string message, bool IsSuccess)
        {
            this.IsSuccess = IsSuccess;
            this.message = message;
            this.item = item;
        }

        public OperationalResult(string message, bool IsSuccess)
        {
            this.message = message;
            this.IsSuccess = IsSuccess;
        }

        public OperationalResult()
        {
   
        }
    }
}
