using System.Data.SQLite;
using System.IO;
using SquareExercise.Interface;
using SquareExercise.SqlLiteCommands;

namespace SquareExercise.SqlLiteRepository
{
    public class SqlLiteDataBaseInitializeRepository : IInitializeRepository
    {
        private void DeleteLeftoverFilesAndFolders()
        {
            var directory = new DirectoryInfo(SqlLiteDataBaseConfiguration.DatabaseFolder);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                subDirectory.Delete(true);
            }
        }

        private void DropTable(string tableName)
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();
                string dropTableQuery = $"DROP TABLE IF EXISTS [{tableName}]";
                SQLiteCommand tableCommand = new SQLiteCommand(dropTableQuery, dbConnection);
                tableCommand.ExecuteNonQuery();
            }
        }

        private void CreateTable(string tableCommand)
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();
                SQLiteCommand sqLiteCommand = new SQLiteCommand(tableCommand, dbConnection);
                sqLiteCommand.ExecuteNonQuery();
            }
        }

        public void InitializeDatabaseIfNotExist()
        {
            if (File.Exists(SqlLiteDataBaseConfiguration.DatabaseFile))
            {
#if DEBUG

#else
                return;
#endif
            }

            if (!Directory.Exists(SqlLiteDataBaseConfiguration.DatabaseFolder))
            {
                Directory.CreateDirectory(SqlLiteDataBaseConfiguration.DatabaseFolder);
            }
            else
            {
                DeleteLeftoverFilesAndFolders();
            }

            SQLiteConnection.CreateFile(SqlLiteDataBaseConfiguration.DatabaseFile);
        }

        public void DropAllTablesCommand()
        {
            var allTableCommands = CreateTablesCommand.CreateTablesCommands();

            foreach(var tableCommand in allTableCommands)
            {
                DropTable(tableCommand.Key);
            }
        }

        public void CreateAllTablesCommand()
        {
            var allTableCommands = CreateTablesCommand.CreateTablesCommands();

            foreach(var tableCommand in allTableCommands)
            {
                CreateTable(tableCommand.Value);
            }
        }
    }
}
