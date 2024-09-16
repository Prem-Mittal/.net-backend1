using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Domain;

namespace WebApplication1.Repositiory
{
    public class SQLWalkRepo : IWalkRepository
    {
        private readonly oneDbContext dbcontext;

        public SQLWalkRepo(oneDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbcontext.walks.AddAsync(walk);
            await dbcontext.SaveChangesAsync();
            return walk;
        }

        public async  Task<Walk?> DeleteAsync(Guid id)
        {
            var existingwalk= await dbcontext.walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingwalk == null) { 
                return null;
            }
            dbcontext.walks.Remove(existingwalk);
            await dbcontext.SaveChangesAsync();
            return existingwalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,  string? sortBy = null, bool isAscending = true, int pageNumber=1,int pageSize=1000)
        {
            //return await dbcontext.walks.Include("Difficulty").Include("Region").ToListAsync();
            var walks= dbcontext.walks.Include("Difficulty").Include("Region").AsQueryable();
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false) 
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks=walks.Where(x=>x.Name.Contains(filterQuery));
                }
            }
            if (string.IsNullOrWhiteSpace(sortBy)==false){
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks=isAscending? walks.OrderBy(x=>x.Name) : walks.OrderByDescending(x=>x.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }
            var skipresult = (pageNumber - 1) * pageSize;
            return await walks.Skip(skipresult).Take(pageSize).ToListAsync();

        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbcontext.walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingwalk = await dbcontext.walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingwalk == null)
            {
                return null;
            }
            existingwalk.Name = walk.Name;
            existingwalk.Description = walk.Description;
            existingwalk.LengthInKm = walk.LengthInKm;
            existingwalk.WalkImageurl = walk.WalkImageurl;
            existingwalk.DifficultyId = walk.DifficultyId;
            existingwalk.RegionId = walk.RegionId;

            await dbcontext.SaveChangesAsync();
            return existingwalk;
        }
    }
}
