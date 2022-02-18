using System.IO;
using System.Reflection;

namespace SquareExercise.SqlLiteRepository
{
    public class SqlLiteDataBaseConfiguration
    {
        private static readonly string DatabaseName = "SquareExercise";

        public static string DatabaseFolder => $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\..\\..\\..\\..\\Database";
        public static string DatabaseFile => $"{DatabaseFolder}\\{DatabaseName}.db";
        public static string ConnectionString => $"Data Source={DatabaseFile};Version=3;UseUTF16Encoding=True;";
    }
}
