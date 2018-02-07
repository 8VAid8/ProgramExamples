using System;
using System.Collections.Generic;

namespace GuitarsProject.DAL
{
    interface IRepository<T> : IDisposable where T : class
    {
        List<T> Get(); // получение всех объектов
        Guitar Get(int id); //получение гитары
        void Create(Guitar guitar); //создание
        bool Delete(int id); //удаление
        void Update(Guitar guitar); //обновление
        bool IsExists(int id);
    }
}
