using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ZoEazy.Api.Model;
using ZoEazy.Api.Model.Subscriber;

namespace ZoEazy.Api.Data
{
    public class DisconnectedData
    {
        private ZoeazyDbContext _context;

        public DisconnectedData(ZoeazyDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior
              = QueryTrackingBehavior.NoTracking;
        }

        public List<KeyValuePair<Guid, string>> GetUsersReferenceList()
        {
            return _context.Users.OrderBy(s => s.Name.FullLastFirst)
              .Select(s => new { s.Id, s.Name.FullLastFirst})
              .ToDictionary(t => t.Id, t => t.FullLastFirst).ToList();
        }


        public Subscriber LoadUserGraph(Guid id)
        {
            return
              _context.Users
              .Include(s => s.Franchises)
              .Include(s => s.Address)
              .FirstOrDefault(s => s.Id == id);
            
        }


        public void SaveUserGraph(Subscriber subscriber)
        {
            _context.ChangeTracker.TrackGraph
              (subscriber, e => ApplyStateUsingIsKeySet(e.Entry));
            _context.SaveChanges();
        }

        private static void ApplyStateUsingIsKeySet(EntityEntry entry)
        {
            if (entry.IsKeySet)
            {
                if (((ClientChangeTracker)entry.Entity).IsDirty)
                {
                    entry.State = EntityState.Modified;
                }
                else
                {
                    entry.State = EntityState.Unchanged;
                }
            }
            else
            {
                entry.State = EntityState.Added;
            }
        }

        public void DeleteUserGraph(string id)
        {
           
            //EF Core supports Cascade delete by convention
            //Even if full graph is not in memory, db is defined to delete
            //But always double check!
            var user = _context.Users.Find(id); //NOT TRACKING !!
            _context.Entry(user).State = EntityState.Deleted; //TRACKING
            _context.SaveChanges();



        }
    }
}
