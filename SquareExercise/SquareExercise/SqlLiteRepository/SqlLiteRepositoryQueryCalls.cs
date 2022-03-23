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

        public void AddNewCoordinates(PointModel points , int newId)
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string addNewCoordinatesCommand =
                    SqlLiteQueryCommands.AddNewCoordinates(points, newId);

                dbConnection.Execute(addNewCoordinatesCommand);
            }
        }

        public List<PointModel> GetAllExistingCoordinates()
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getAllCommand = SqlLiteQueryCommands.GetAllExistingCoordinates();

                IEnumerable<PointModel> getAllExistingCoordinates = dbConnection.Query<PointModel>(getAllCommand);
                return getAllExistingCoordinates.ToList();
            }
        }

        public PointModel GetSpecificCoordinateById(int id)
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getSpecificCoordinatesCommand = SqlLiteQueryCommands.GetSpecificCoordinateById(id);

                var getSpecificCoordinates = dbConnection.QuerySingle<PointModel>(getSpecificCoordinatesCommand);

                return getSpecificCoordinates;
            }
        }

        public void AddNewCoordinateList(List<PointModel> coordinateList)
        {
            using (var dbConnection = new SQLiteConnection(SqlLiteDataBaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                int newId = GetNewId();

                foreach (var coordinates in coordinateList)
                {
                    var coordinate = new PointModel()
                    {
                        CoordinateX = coordinates.CoordinateX,
                        CoordinateY = coordinates.CoordinateY
                    };

                    string addNewCoordinates = SqlLiteQueryCommands.AddNewCoordinates(coordinate, newId);
                    dbConnection.Execute(addNewCoordinates);
                    newId++;
                }
            }
        }
    }
}
