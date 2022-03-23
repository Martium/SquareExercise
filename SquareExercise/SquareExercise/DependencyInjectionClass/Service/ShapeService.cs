using SquareExercise.Interface;

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
