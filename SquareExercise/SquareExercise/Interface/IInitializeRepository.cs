namespace SquareExercise.Interface
{
    public interface IInitializeRepository
    {
        void InitializeDatabaseIfNotExist();
        void DropAllTablesCommand(); 
        void CreateAllTablesCommand();
    }
}
