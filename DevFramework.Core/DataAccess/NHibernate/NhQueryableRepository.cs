using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NhQueryableRepository<T>: IQueryableRepository<T> where T : class, IEntity, new()
    {
        
        private IQueryable<T> _entities;

        private readonly NHibernateHelper _nHibernateHelper;

        public IQueryable<T> Table => this.Entities;

        public IQueryable<T> Entities => this._entities ?? (this._entities = _nHibernateHelper.OpenSession().Query<T>());

        public NhQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }
    }
}
