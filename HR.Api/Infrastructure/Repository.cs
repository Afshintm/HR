using System;
using System.Collections.Generic;
using HR.Api.Core;

namespace HR.Api.Infrastructure
{
    public interface IRepository<T> where T : AggregateRoot
    {
        T Find(object Id);
        bool Save(T item);
        bool Delete(T Item);
    }
    
    public class InMemoryRepository<T>: IRepository<T> where T : AggregateRoot {
        private List<T> _data = new List<T>();
        
        public T Find(object id)
        {
            var item = _data.Find(x => x.Id == (Guid) id);
            return item;
        }

        public bool Save(T item)
        {
            if (item==null)
            {
                return false;
            }
            _data.Add(item);
            return true;
        }

        public bool Delete(T item)
        {
            if (item == null) return false;
            _data.Remove(item);
            return true;
        }
    }
}