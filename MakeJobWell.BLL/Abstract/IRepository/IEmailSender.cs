using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MakeJobWell.BLL.Abstract.IRepository
{
    public interface IEmailSender
    {
        Task Sender(string firstName, string mail, Guid activationCode);
    }
}
