using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityDemo
{
    public abstract class BaseLoginHandler : ILoginHandler
    {
        protected ILoginHandler _nextHandler;

        public BaseLoginHandler()
        {
            _nextHandler = null;
        }
        public abstract void HandleRequest(User user);
        

        public void SetNextHandler(ILoginHandler handler)
        {
            this._nextHandler = handler;
        }
    }
}
