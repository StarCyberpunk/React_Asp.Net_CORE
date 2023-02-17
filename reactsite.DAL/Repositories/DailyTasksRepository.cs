using Microsoft.EntityFrameworkCore;
using reactsite.DAL.Interfaces;
using reactsite.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.DAL.Repositories
{
    public class DailyTasksRepository:IBaseRepository<DailyTasks>
    {
        private readonly ApplicationDbContext appDbCon;
        public DailyTasksRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }

        public async Task<bool> Create(DailyTasks entity)
        {
           await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(DailyTasks entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<DailyTasks> Get(int id)
        {
           return await appDbCon.DailyTasks.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public  IQueryable<DailyTasks> Select()
        {
            return appDbCon.DailyTasks;
        }

        public async Task<DailyTasks> Update(DailyTasks entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
