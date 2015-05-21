using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PompeiiSquare.Data.Repositories;
using PompeiiSquare.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PompeiiSquare.Data.UnitOfWork
{
    public class PompeiiSquareData : IPompeiiSquareData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        private IUserStore<User> userStore;

        public PompeiiSquareData()
            : this(new PompeiiSquareDbContext())
        {
        }

        public PompeiiSquareData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        // TODO: Add the remaining repositories

        public IUserStore<User> UserStore
        {
            get
            {
                if (this.userStore == null)
                {
                    this.userStore = new UserStore<User>(this.dbContext);
                }

                return this.userStore;
            }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericEfRepository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}