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

        public IRepository<Gender> Genders
        {
            get { return this.GetRepository<Gender>(); }
        }

        public IRepository<Venue> Venues
        {
            get { return this.GetRepository<Venue>(); }
        }

        public IRepository<VenueGroup> VenueGroups
        {
            get { return this.GetRepository<VenueGroup>(); }

        }

        public IRepository<OpenHours> OpenHours
        {
            get { return this.GetRepository<OpenHours>(); }
        }

        public IRepository<Tag> Tags
        {
            get { return this.GetRepository<Tag>(); }
        }

        public IRepository<Photo> Photos
        {
            get { return this.GetRepository<Photo>(); }
        }

        public IRepository<Tip> Tips
        {
            get { return this.GetRepository<Tip>(); }
        }

        public IRepository<Checkin> Checkins
        {
            get { return this.GetRepository<Checkin>(); }
        }

        public IRepository<Notification> Notifications
        {
            get { return this.GetRepository<Notification>(); }
        }

        public IRepository<Event> Events
        {
            get { return this.GetRepository<Event>(); }
        }

        public IRepository<EventCategory> EventCategories
        {
            get { return this.GetRepository<EventCategory>(); }
        }

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