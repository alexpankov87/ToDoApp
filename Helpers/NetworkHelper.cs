using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace ToDoApp.Helpers
{
    public static class NetworkHelper
    {
        public static bool IsInternetAvailable()
        {
            try
            {
               
                using var ping = new Ping();
                var reply = ping.Send("8.8.8.8", 1000); // Пинг до Google DNS (8.8.8.8) с таймаутом 1 секунда
                return reply.Status == IPStatus.Success;

            }
            catch
            {
                return false;
            }
        }
    }
}

