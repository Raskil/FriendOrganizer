﻿using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class MeetingRepository : GenericRepository<Meeting, FriendOrganizerDbContext>, IMeetingRepository
    {
        public MeetingRepository(FriendOrganizerDbContext context) : base(context)
        {

        }

        public async override Task<Meeting> GetByIdAsync(int id)
        {
            return await Context.Meetings
                .Include(m => m.Friends)
                .SingleAsync(m => m.Id == id);
        }

        public async Task<List<Friend>> GetAllFriendsAsync()
        {
            return await Context.Set<Friend>().ToListAsync();
        }

        public void ReloadFriend(int friendId)
        {
            var dbEntitiyEntry = Context.ChangeTracker.Entries<Friend>()
                .Single(db => db.Entity.Id == friendId);

            if (dbEntitiyEntry!=null)
            {
                dbEntitiyEntry.Reload();
            }
        }
    }
}
