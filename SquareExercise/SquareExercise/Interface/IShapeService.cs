using System.Collections.Generic;
using SquareExercise.Models;

namespace SquareExercise.Interface
{
    public interface IShapeService
    {
         bool ValidateShapeByCoordinates();
         List<CountPerfectSquareModel> GetAllPointPossibilities(List<PointModel> coordinatesList);
    }
}
