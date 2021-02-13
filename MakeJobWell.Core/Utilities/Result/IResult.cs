using System;
using System.Collections.Generic;
using System.Text;

namespace MakeJobWell.Core.Utilities.Result
{
    public interface IResult
    {
        bool Succes { get; }
        string Message { get; }
    }
}
