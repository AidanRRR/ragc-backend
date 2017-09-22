﻿using System.Collections.Generic;

namespace API.Mediatr
{
    public class ApiResult<T>
    {
        public bool HasErrors { get; set; }
        public bool HasWarnings { get; set; }

        public List<string> ErrorMessages { get; set; }
        public List<string> WarningMessages { get; set; }

        public T Data { get; set; }

        public ApiResult()
        {
            this.HasErrors = false;
            this.HasWarnings = false;

            this.ErrorMessages = new List<string>();
            this.WarningMessages = new List<string>();
        }
    }
}
