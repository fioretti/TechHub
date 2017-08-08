﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Data.SqlClient;
using TechHub.Lib.Model;
using TechHub.Lib.Core;

namespace TechHub.Lib.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// The context object for the database
        /// </summary>
        protected ObjectContext _context;

        /// <summary>
        /// The IObjectSet that represents the current entity.
        /// </summary>
        protected IObjectSet<T> _objectSet;

        /// <summary>
        /// Initializes a new instance of the BaseRepository class
        /// </summary>
        public BaseRepository()
            : this(new TechHubContainer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the BaseRepository class
        /// </summary>
        /// <param name="context">The Entity Framework ObjectContext</param>
        public BaseRepository(ObjectContext context)
        {
            _context = context;
            _context.CommandTimeout = 1800;
            _context.ContextOptions.LazyLoadingEnabled = true;
            _objectSet = _context.CreateObjectSet<T>();
        }

        /// <summary>
        /// Gets all records as an IQueryable
        /// </summary>
        /// <returns>An IQueryable object containing the results of the query</returns>
        public IQueryable<T> GetQuery()
        {
            return _objectSet;
        }

        /// <summary>
        /// Gets all records as an IEnumberable
        /// </summary>
        /// <returns>An IEnumberable object containing the results of the query</returns>
        public IEnumerable<T> GetAll()
        {
            return GetQuery().AsEnumerable();
        }

        /// <summary>
        /// Finds a record with the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A collection containing the results of the query</returns>
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            try
            {
                return _objectSet.Where(predicate);
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public T Single(Func<T, bool> predicate)
        {
            try
            {
                return _objectSet.Single<T>(predicate);
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public T First(Func<T, bool> predicate)
        {
            return _objectSet.First<T>(predicate);
        }

        /// <summary>
        /// Deletes the specified entitiy
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _objectSet.DeleteObject(entity);
        }

        /// <summary>
        /// Deletes records matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        public void Delete(Func<T, bool> predicate)
        {
            //      IEnumerable<T> records = from x in _objectSet.Where<T>(predicate) select x;
            var records = _objectSet.Where(predicate).ToList();

            foreach (T record in records)
            {
                _objectSet.DeleteObject(record);
            }
        }

        /// <summary>
        /// Adds the specified entity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _objectSet.AddObject(entity);
        }

        /// <summary>
        /// Attaches the specified entity
        /// </summary>
        /// <param name="entity">Entity to attach</param>
        public void Attach(T entity)
        {

            _objectSet.Attach(entity);
        }


        /// <summary>
        /// Saves all context changes
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Saves all context changes with the specified SaveOptions
        /// </summary>
        /// <param name="options">Options for saving the context</param>
        public void SaveChanges(SaveOptions options)
        {
            _context.SaveChanges(options);
        }


        // gets the entity set
        public EntitySetBase GetEntitySet(Object entityType)
        {
            var container = _context.MetadataWorkspace.GetEntityContainer(_context.DefaultContainerName, DataSpace.CSpace);

            if (entityType.GetType().Namespace == "System.Data.Entity.DynamicProxies")
                return container.BaseEntitySets.Single(es => es.ElementType.Name == entityType.GetType().BaseType.Name);
            else
                return container.BaseEntitySets.Single(es => es.ElementType.Name == entityType.GetType().Name);
        }


        public void Update(T entity)
        {
            // use our method to get the entity set name
            var entityES = GetEntitySet(entity);

            // create the entity key
            var key = _context.CreateEntityKey(entityES.Name, entity);

            // retrieve and update the item
            _context.GetObjectByKey(key);
            _context.ApplyCurrentValues(entityES.Name, entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        /// <param name="disposing">A boolean value indicating whether or not to dispose managed resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

    }
}
