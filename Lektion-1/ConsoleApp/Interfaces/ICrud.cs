namespace ConsoleApp.Interfaces
{
    public interface ICrud<T> where T : class
    {
        void Create(T type);
        T Get(Func<T, bool> predicate);
        List<T> GetAll();
        void Update(T type);
        void Delete(Func<T, bool> predicate);
    }
}
