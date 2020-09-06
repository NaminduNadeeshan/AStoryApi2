using System;
namespace Repository.Common
{
    public interface ICommonController<T>
    {
        T GetAll();

        T GetByID(int id);

        T UpdateById(int id);

        T DeleteById(int id);

    }
}
