using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityDemo
{
    
    public interface ILoginHandler
    {
        void HandleRequest(User user);
        void SetNextHandler(ILoginHandler handler);
    }
}
