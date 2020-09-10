using System;

namespace ChainOfResponsibilityDemo
{

    public class EmailValidationHandler : BaseLoginHandler
    {
        public override void HandleRequest(User user)
        {

            if (!user.Email.Contains("@"))
            {
                Console.WriteLine("Email address is not valid. Please provide valid email address");
                return;
            }
            else
            {
                Console.WriteLine("Model state is valid. Processing next handler...");
                if(_nextHandler!=null)
                    this._nextHandler.HandleRequest(user);
            }
        }
    }

    public class IsAuthenticatedHandler : BaseLoginHandler
    {
        public override void HandleRequest(User user)
        {
            if (user.IsAuthenticated)
            {
                Console.WriteLine("User authenticated successfuly. Processing next handler...");
                if(_nextHandler!=null)
                    _nextHandler.HandleRequest(user);
            }
            else
            {
                Console.WriteLine("Please provide valid credentials in order to access site..");
                return;
            }
        }
    }

    public class IsAuthorizedHandler : BaseLoginHandler
    {
        public override void HandleRequest(User user)
        {
            if (user.Roles.Contains("System User"))
            {
                Console.WriteLine("User authorization complete. Welcome user...");
                if(_nextHandler!=null)
                    _nextHandler.HandleRequest(user);
            }
            else
            {
                Console.WriteLine("The resource you are looking for is not available. Error 404");
                return;
            }
        }
    }


    public class DirectorLoginHandler
    {
        private IsAuthenticatedHandler _isAuthenticatedHandler;
        private IsAuthorizedHandler _isAuthorizedHandler;
        private EmailValidationHandler _emailHandler;

        public DirectorLoginHandler()
        {
            _isAuthenticatedHandler = new IsAuthenticatedHandler();
            _isAuthorizedHandler = new IsAuthorizedHandler();
            _emailHandler = new EmailValidationHandler();
            _emailHandler.SetNextHandler(_isAuthenticatedHandler);
            _isAuthenticatedHandler.SetNextHandler(_isAuthorizedHandler);
        }


        public void HandleLoginRequest(User user)
        {
            _emailHandler.HandleRequest(user);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectorLoginHandler loginHanlder = new DirectorLoginHandler();
            User user = new User();
            loginHanlder.HandleLoginRequest(user);
            Console.WriteLine("------------------------------------------");
            user.Login();
            loginHanlder.HandleLoginRequest(user);
        }
    }
}
