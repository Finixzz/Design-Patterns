using System;

namespace BridgeDemo
{

    public interface Theme
    {
        void setAppTheme();
    }

    public class Light : Theme
    {
        public void setAppTheme()
        {
            Console.WriteLine("App theme set to Light");
        }
    }

    public class Dark : Theme
    {
        public void setAppTheme()
        {
            Console.WriteLine("App theme set to Dark");
        }
    }

    public class WebApp
    {
        private Theme _appTheme;

        public void setWebAppTheme()
        {
            Console.WriteLine("Chose theme");
            Console.WriteLine("1) Light");
            Console.WriteLine("2) Dark");
            Console.Write("Input 1 or 2 in order to chose theme: ");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
            {
                _appTheme = new Light();
                _appTheme.setAppTheme();
            }
            else
            {
                _appTheme = new Dark();
                _appTheme.setAppTheme();
            }
        }
    }

    public class Blog : WebApp
    {
        public string BloggerName { get; set; }

        public string Email { get; set; }

        public Blog(string bloggerName, string email)
        {
            BloggerName = bloggerName;
            Email = email;
            Console.WriteLine($"Created Blog for {BloggerName}. Contact at {Email}");
        }
    }

    public class ECommerce : WebApp
    {
        public string CompanyName { get; set; }

        public ECommerce(string companyName)
        {
            CompanyName = companyName;
            Console.WriteLine($"Created ECommerce site for{this.CompanyName}");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            WebApp myBlog = new Blog("Vitaly", "vita@gmail.com");
            myBlog.setWebAppTheme();
            Console.WriteLine("-------------------------------");
            WebApp ECommerce = new ECommerce("SomeCompanyName");
            ECommerce.setWebAppTheme();
        }
    }
}
