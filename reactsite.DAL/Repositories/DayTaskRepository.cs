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
    public class DayTaskRepository : IBaseRepository<DayTasks>
    {
        private readonly ApplicationDbContext appDbCon;
        public DayTaskRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(DayTasks entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(DayTasks entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<DayTasks> Get(int id)
        {
            return await appDbCon.DayTasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public  IQueryable<DayTasks> Select()
        {
            return appDbCon.DayTasks;
        }

        public async Task<DayTasks> Update(DayTasks entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
