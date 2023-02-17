﻿using Microsoft.EntityFrameworkCore;
using reactsite.DAL.Interfaces;
using reactsite.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.DAL.Repositories
{
    public class ActivityRepository : IBaseRepository<Activity>
    {
        private readonly ApplicationDbContext appDbCon;
        public ActivityRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }

        public async Task<bool> Create(Activity entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Activity entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Activity> Get(int id)
        {
            return await appDbCon.Activity.FirstOrDefaultAsync(x => x.Id == id);

        }

        public IQueryable<Activity> Select()
        {
            return appDbCon.Activity;
        }

        public async Task<Activity> Update(Activity entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
