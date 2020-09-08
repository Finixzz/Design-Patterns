using System;
using System.Collections.Generic;

namespace ProxyDemo
{
    public interface IInternet
    {
        void AccessSite(string serverHost);
    }

    public class Internet : IInternet
    {
        private Dictionary<string, string> _bannedHosts;

        public Internet()
        {
            _bannedHosts = new Dictionary<string, string>();
            _bannedHosts.Add("xyz.com", "xyz.com");
            _bannedHosts.Add("somevorbiddendomain.com", "somevorbiddendomain.com");
        }

        private  bool IsAllowed(string serverHost)
        {
            if (_bannedHosts.ContainsKey(serverHost))
                return false;
            if (!serverHost.Contains("https://"))
                return false;
            return true;
        }
        public void AccessSite(string serverHost)
        {
            if(IsAllowed(serverHost))
                Console.WriteLine($"Accessing server {serverHost.Substring(8)} Please wait ...");
            else
                Console.WriteLine("Requested host is not available ...");
        }
    }


    public class InternetProxy : IInternet
    {
        private Internet _internet;

        public InternetProxy()
        {
            _internet = new Internet();
        }
        public void AccessSite(string serverHost)
        {
            _internet.AccessSite(serverHost);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            IInternet internetProxy = new InternetProxy();
            internetProxy.AccessSite("xyz.com");
            internetProxy.AccessSite("https://youtube.com");
        }
    }
}
