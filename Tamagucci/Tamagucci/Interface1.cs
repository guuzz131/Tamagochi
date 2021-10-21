using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tamagucci
{
    public interface Interface1 <T>
    {
        //CRUD operations
        Task<bool> CreateItem(T item); //POST

        Task<T> ReadItem(); //GET

        Task<bool> UpdateItem(T item); //PUT

        Task<bool> DeleteItem(T item); //DELETE
    }
}
