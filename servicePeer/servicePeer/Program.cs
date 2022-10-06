using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicePeer
{
    /// <summary>
    /// �������� ����� ���������.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ����� ����� ���������.
        /// </summary>
        /// <param name="args"> ������� ���������.</param>
        public static void Main(string[] args)
        {
            Controllers.UsersController.ReadUsers();
            Controllers.UsersController.SaveUsers();
            Controllers.MessagesController.ReadMessages();
            Controllers.MessagesController.SaveMessages();
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// ����� ��������� IHostBuilder
        /// </summary>
        /// <param name="args"> ������� ���������.</param>
        /// <returns> IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
