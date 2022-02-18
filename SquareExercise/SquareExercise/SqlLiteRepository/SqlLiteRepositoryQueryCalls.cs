using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using SquareExercise.Interface;
using SquareExercise.Models;
using SquareExercise.SqlLiteCommands;

namespace SquareExercise.SqlLiteRepository
{
    public class SqlLiteRepositoryQueryCalls : IRepositoryQueryCalls
    {
        public int GetLastIdIfExistsOrReturnZero()
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();
                string getLastIdCommand = SqlLiteQueryCommands.GetLastIdOfCoordinateTable();

                int? lasId = dbConnection.QueryFirstOrDefault<int?>(getLastIdCommand) ?? 0;

                return lasId.Value;
            }
        }
        public int GetNewId()
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();
                string getLastIdCommand = SqlLiteQueryCommands.GetLastIdOfCoordinateTable();

                int? lasId =dbConnection.QueryFirstOrDefault<int?>(getLastIdCommand) ?? 0;

                return lasId.Value + 1;
            }
        }

        public void AddNewCoordinates(CoordinateModel coordinates , int newId)
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string addNewCoordinatesCommand =
                    SqlLiteQueryCommands.AddNewCoordinates(coordinates, newId);

                dbConnection.Execute(addNewCoordinatesCommand);
            }
        }

        public List<CoordinateModel> GetAllExistingCoordinates()
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getAllCommand = SqlLiteQueryCommands.GetAllExistingCoordinates();

                IEnumerable<CoordinateModel> getAllExistingCoordinates = dbConnection.Query<CoordinateModel>(getAllCommand);
                return getAllExistingCoordinates.ToList();
            }
        }

        public CoordinateModel GetSpecificCoordinateById(int id)
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getSpecificCoordinatesCommand = SqlLiteQueryCommands.GetSpecificCoordinateById(id);

                var getSpecificCoordinates = dbConnection.QuerySingle<CoordinateModel>(getSpecificCoordinatesCommand);

                return getSpecificCoordinates;
            }
        }

        public void AddNewCoordinateList(List<CoordinateModel> coordinateList)
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                int newId = GetNewId();

                foreach (var coordinates in coordinateList)
                {
                    var coordinate = new CoordinateModel()
                    {
                        PointX = coordinates.PointX,
                        PointY = coordinates.PointY
                    };

                    string addNewCoordinates = SqlLiteQueryCommands.AddNewCoordinates(coordinate, newId);
                    dbConnection.Execute(addNewCoordinates);
                    newId++;
                }
            }
        }
    }
}
