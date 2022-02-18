using System.Collections.Generic;
using SquareExercise.Interface;
using SquareExercise.Models;

namespace SquareExercise.DependencyInjectionClass.Service
{
    public class ShapeService
    {
        private readonly IShapeService _shape;

        public ShapeService(IShapeService shape)
        {
            _shape = shape;
        }

      
    }
}
