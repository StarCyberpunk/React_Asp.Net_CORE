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
    public class ProfileRepository : IBaseRepository<Profile>
    {
        private readonly ApplicationDbContext appDbCon;
        public ProfileRepository(ApplicationDbContext a)
        {
            appDbCon = a;
        }
        public async Task<bool> Create(Profile entity)
        {
            await appDbCon.Profiles.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Profile entity)
        {
            appDbCon.Profiles.Remove(entity);
            appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<Profile> Get(int id)
        {
            return await appDbCon.Profiles.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public IQueryable<Profile> Select()
        {
            throw new NotImplementedException();
        }

        public async Task<Profile> Update(Profile entity)
        {
            appDbCon.Update(entity);
            appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
