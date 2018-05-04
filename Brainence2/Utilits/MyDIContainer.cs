using Brainence2.Models;
using Brainence2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brainence2.Utilits
{
    public static class MyDIContainer
    {
        static IRepository<Entity> savedRepository;
        public static void BindDependency(Type @interface ,object createdRepo)
        {
            if (createdRepo is IRepository<Entity>)
                savedRepository = (IRepository<Entity>)createdRepo;
        }
        public static IRepository<Entity> GetRepository()
        {
            return savedRepository;
        }
    }
}