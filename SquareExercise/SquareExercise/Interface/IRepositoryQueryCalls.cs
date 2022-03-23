using System.Collections.Generic;
using SquareExercise.Models;

namespace SquareExercise.Interface
{
    public interface IRepositoryQueryCalls
    { 
        int GetNewId();
        void AddNewCoordinates(PointModel points, int newId);
        List<PointModel> GetAllExistingCoordinates();
        public PointModel GetSpecificCoordinateById(int id); 
        int GetLastIdIfExistsOrReturnZero();
        void AddNewCoordinateList(List<PointModel> coordinateList);
    }
}
