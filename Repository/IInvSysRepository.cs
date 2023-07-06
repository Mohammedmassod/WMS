using WMS.Models;
using WMS.Data;
using System;
using System.Collections.Generic;

namespace WMS.Repository
{
    public interface IInvSysRepository<UEntity>
    {
        IList<UEntity> List();
        UEntity Find(int id);
        void Add(UEntity entity);
        void Edit(int id, UEntity newEntity);
        void Delete(int id);
        List<ItemGroup> ListByFilter(Func<ItemGroup, bool> filter);
    }
}
