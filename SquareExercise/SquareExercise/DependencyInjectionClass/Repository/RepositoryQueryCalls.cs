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

        public void AddNewCoordinates(CoordinateModel coordinates, int newId)
        { 
            _repositoryQueryCalls.AddNewCoordinates(coordinates, newId);
        }

        public List<CoordinateModel> GetAllExistingCoordinates()
        {
            return  _repositoryQueryCalls.GetAllExistingCoordinates();
        }

        public CoordinateModel GetSpecificCoordinatesById(int id)
        {
            return _repositoryQueryCalls.GetSpecificCoordinateById(id);
        }

        public int GetLastId()
        {
            return _repositoryQueryCalls.GetLastIdIfExistsOrReturnZero();
        }

        public void AddNewCoordinateList(List<CoordinateModel> coordinateList)
        {
            _repositoryQueryCalls.AddNewCoordinateList(coordinateList);
        }

    }
}
