using System;
using System.Collections.Generic;

namespace Model.Data
{
    public interface IDB<T,K> 
        where T : class 
        where K : IConvertible
    {
        void Create(T item);
        T Read(K key);
        ICollection<T> ReadAll();
        void Update(T item);
        void Delete(K key);
        ICollection<T> Find(string index);
    }
}
