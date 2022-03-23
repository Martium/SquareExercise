using System.Collections.Generic;
using SquareExercise.Interface;
using SquareExercise.Models;

namespace SquareExercise.DependencyInjectionClass.Repository
{
    public class RepositoryQueryCalls 
    {
        private readonly IRepositoryQueryCalls _repositoryQueryCalls;

        public RepositoryQueryCalls(IRepositoryQueryCalls repositoryQueryCalls)
        {
            _repositoryQueryCalls = repositoryQueryCalls;
        }

        public int GetNewId()
        {
            return _repositoryQueryCalls.GetNewId();
        }

        public void AddNewCoordinates(PointModel points, int newId)
        { 
            _repositoryQueryCalls.AddNewCoordinates(points, newId);
        }

        public List<PointModel> GetAllExistingCoordinates()
        {
            return  _repositoryQueryCalls.GetAllExistingCoordinates();
        }

        public PointModel GetSpecificCoordinatesById(int id)
        {
            return _repositoryQueryCalls.GetSpecificCoordinateById(id);
        }

        public int GetLastId()
        {
            return _repositoryQueryCalls.GetLastIdIfExistsOrReturnZero();
        }

        public void AddNewCoordinateList(List<PointModel> coordinateList)
        {
            _repositoryQueryCalls.AddNewCoordinateList(coordinateList);
        }

    }
}
