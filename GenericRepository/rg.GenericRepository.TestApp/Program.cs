using System;
using System.Linq;
using rg.GenericRepository.Impl.InMemory;

namespace rg.GenericRepository.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new InMemoryRepository<Foo>();

            repo.Insert(new Foo());
            repo.Insert(new Foo());
            repo.Insert(new Foo());

            var entities = repo.GetAll();

            Console.WriteLine(entities.Count());
        }
    }
}
