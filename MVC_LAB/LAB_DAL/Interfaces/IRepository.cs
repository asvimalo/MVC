using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_DAL.Interfaces
{
    public interface IRepository
    {
       
            void Add(object entity);
            void Update(object Entity);
            void Delete(Guid ID);

            IEnumerable<object> All();

            object Find(Guid ID);
        
    }
}
