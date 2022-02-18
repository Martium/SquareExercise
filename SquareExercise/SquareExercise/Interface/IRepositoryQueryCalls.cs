using System.Collections.Generic;
using SquareExercise.Models;

namespace SquareExercise.Interface
{
    public interface IRepositoryQueryCalls
    { 
        int GetNewId();
        void AddNewCoordinates(CoordinateModel coordinates, int newId);
        List<CoordinateModel> GetAllExistingCoordinates();
        public CoordinateModel GetSpecificCoordinateById(int id); 
        int GetLastIdIfExistsOrReturnZero();
        void AddNewCoordinateList(List<CoordinateModel> coordinateList);
    }
}
