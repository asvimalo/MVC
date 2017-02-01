using LAB_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_DAL.Repo
{
    public class Repository : IRepository
    {
        public void Add(object entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        public object Find(Guid ID)
        {
            throw new NotImplementedException();
        }

        public void Update(object Entity)
        {
            throw new NotImplementedException();
        }
    }
}
