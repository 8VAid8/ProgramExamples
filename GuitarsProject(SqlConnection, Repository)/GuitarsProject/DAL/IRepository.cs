using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarsProject.DAL
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> Get(); // получение всех объектов

        void Create(int id, string brand, string model, string color, decimal price);
        void Delete(int id);
        void Update(int id, string brand, string model, string color, decimal price);
    }
}
