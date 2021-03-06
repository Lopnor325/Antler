﻿using SmartElk.Antler.Core.Common.CodeContracts;
using SmartElk.Antler.Core.Domain;
using SmartElk.Antler.Core.Domain.Configuration;

namespace SmartElk.Antler.Linq2Db.Configuration
{
    public class Linq2DbStorage : AbstractRelationalStorage<Linq2DbStorage>
    {
        private readonly string _connectionString;

        private Linq2DbStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static Linq2DbStorage Use(string connectionString)
        {
            Requires.NotNullOrEmpty(connectionString, "connectionString");
            return new Linq2DbStorage(connectionString);
        }

        protected override ISessionScopeFactory ConfigureInternal(IDomainConfigurator configurator)
        {
            Requires.NotNull(configurator, "configurator");
            return new Linq2DbSessionScopeFactory(_connectionString);           
        }
    }
}
