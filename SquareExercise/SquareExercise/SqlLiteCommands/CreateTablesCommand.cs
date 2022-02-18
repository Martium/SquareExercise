using System.Collections.Generic;

namespace SquareExercise.SqlLiteCommands
{
    public static class CreateTablesCommand
    {
        public static Dictionary<string, string> CreateTablesCommands()
        {
            string coordinatesTableName = "Coordinates";
            string coordinatesTableCommand = 
                $@"
                    CREATE TABLE [{coordinatesTableName}] 
                    (
                      [Id] [Integer] NOT NULL,
                      [PointX] [Numeric] NOT NULL,
                      [PointY] [Numeric] NOT NULL,
                      UNIQUE(Id)
                    );
                ";

            var tables = new Dictionary<string, string>()
            {
                {coordinatesTableName, coordinatesTableCommand}
            };

            return tables;
        }
    }
}
