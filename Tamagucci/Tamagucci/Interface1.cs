using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagucci
{
    public interface Interface1 <T>
    {
        //CRUD operations
        bool CreateItem(T item); //POST

        T ReadItem(); //GET

        bool UpdateItem(T item); //PUT

        bool DeleteItem(T item); //DELETE
    }
}
