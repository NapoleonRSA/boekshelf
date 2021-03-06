﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace grootboekrak.repository
{
    public class RepositoryBase : IDisposable
    {
        public IDbConnection _db;
        public RepositoryBase()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
            _db.Open();
        }
        public RepositoryBase(IDbConnection db)
        {
            _db = db;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Close();
            }
        }
        ~RepositoryBase()
        {
            Dispose(false);
        }
    }
}
