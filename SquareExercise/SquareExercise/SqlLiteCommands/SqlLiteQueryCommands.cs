using SquareExercise.Models;

namespace SquareExercise.SqlLiteCommands
{
    public static class SqlLiteQueryCommands
    {
        private const string CoordinatesTableName = "Coordinates";

        public static string GetLastIdOfCoordinateTable()
        {
            string getLastId = 
                $@"
                    SELECT  
                        MAX(C.Id)
                      FROM {CoordinatesTableName} C
                ";

            return getLastId;
        }

        public static string AddNewCoordinates(CoordinateModel coordinates, int newId)
        {
            string createNewCoordinates = 
                $@"
                    INSERT INTO '{CoordinatesTableName}'
                    Values ( {newId}, {coordinates.PointX}, {coordinates.PointY}
                    );
                ";

            return createNewCoordinates;
        }

        public static string GetAllExistingCoordinates()
        {
            string getAll = 
                $@"
                    SELECT * 
                    FROM {CoordinatesTableName}
                ";
            return getAll;
        }

        public static string GetSpecificCoordinateById(int id)
        {
            string getSpecificCoordinate =
                $@"
                    SELECT *
                    FROM {CoordinatesTableName} C
                    WHERE C.Id = {id}
                ";

            return getSpecificCoordinate;
        }
    }
}
