using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalKnowledge.Repository
{
    public abstract class AbstractRepository
    {
        protected readonly TechnicalKnowledgeDBEntities db;

        public AbstractRepository(TechnicalKnowledgeDBEntities db)
        {
            this.db = db;
        }
}
}