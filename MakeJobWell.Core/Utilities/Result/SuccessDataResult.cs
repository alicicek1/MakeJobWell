﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Core.Utilities.Result
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }

        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
    }
}
