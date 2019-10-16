using GenericRepositoryAndUnitOfWork.Repositories;

namespace GenericRepositoryAndUnitOfWork.UnitOfWork
{
    public interface IGenericUoW
    {
        IRepository<T> Repository<T>() where T : class;

        void SaveChanges();
    }
}