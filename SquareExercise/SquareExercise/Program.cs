using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SquareExercise.DependencyInjectionClass.Repository;
using SquareExercise.SqlLiteRepository;

namespace SquareExercise
{
    public class Program
    {
        private static readonly InitializeRepository Repository = new InitializeRepository(new SqlLiteDataBaseInitializeRepository());

        public static void Main(string[] args)
        {
            bool isDataBaseInitialize = InitializeDataBase();

            if (isDataBaseInitialize)
            {
                CreateHostBuilder(args).Build().Run();
            }
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static bool InitializeDataBase()
        {
            bool isDatabaseInitialize;

            try
            {
                Repository.InitializeRepositoryIfNotExist();
                Repository.DropTable();
                Repository.CreateTable();

                isDatabaseInitialize = true;
            }
            catch
            {
                isDatabaseInitialize = false;
            }

            return isDatabaseInitialize;
        }
    }
}
