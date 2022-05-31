using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLBusiness
{
    public class Query
    {
        private readonly IAppRepository _repo;

        #region Constructor  
        public Query(IAppRepository repo)
        {
            _repo = repo;
        }
        #endregion

        public IQueryable<Table1> Employees => _repo.Query<Table1>();
    }
}
