using SquareExercise.Interface;

namespace SquareExercise.DependencyInjectionClass.Repository
{
    public class InitializeRepository
    {
        private readonly IInitializeRepository _repository;

        public InitializeRepository(IInitializeRepository repository)
        {
            _repository = repository;
        }

        public void InitializeRepositoryIfNotExist()
        {
            _repository.InitializeDatabaseIfNotExist();
        }
       
    }
}
