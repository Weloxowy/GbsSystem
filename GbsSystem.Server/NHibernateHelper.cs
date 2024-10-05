using GbsSystem.Server.Controllers.Planets;
using GbsSystem.Server.Models.AspNetUsers;
using Planets = GbsSystem.Server.Models.Planets.Planets;

namespace GbsSystem.Server;

﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

public class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;

    public static NHibernate.ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }

    private static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = Fluently.Configure()
                    .Database(
                        MsSqlConfiguration.MsSql2012.ConnectionString(
                            "Server=localhost\\TEW_SQLEXPRESS;Database=Hackaton;Integrated Security=SSPI;Application Name=Hackaton;TrustServerCertificate=true;")
                    ) 
                    .Mappings(m =>
                         m.FluentMappings.AddFromAssemblyOf<AspNetUsers>()
                     )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Planets>())
                    
                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                    .BuildSessionFactory();
            }
            return _sessionFactory;
        }
    }
}