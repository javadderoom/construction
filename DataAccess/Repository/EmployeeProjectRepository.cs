﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DataAccess.Repository
{
    public class EmployeeProjectRepository
    {
        private ConstructionCompanyEntities database;

        public EmployeeProjectRepository()
        {
            database = new ConstructionCompanyEntities();
        }



        public void SaveEmployeeProject(EmployeeProject ep)
        {

            if (ep.EmployeeProjectID > 0)
            {
                //==== UPDATE ====
                database.EmployeeProjects.Attach(ep);
                database.Entry(ep).State = EntityState.Modified;
            }
            else
            {
                //==== INSERT ====
                database.EmployeeProjects.Add(ep);
            }

            database.SaveChanges();

        }




    }
}