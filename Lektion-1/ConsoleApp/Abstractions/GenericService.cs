using ConsoleApp.Interfaces;

namespace ConsoleApp.Abstractions
{
    public abstract class GenericService<T> where T : class
    {
        public virtual void Create(T type)
        {
            throw new NotImplementedException();
        }

        public virtual T Get(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T type)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
