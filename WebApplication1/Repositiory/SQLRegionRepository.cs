using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Domain;

namespace WebApplication1.Repositiory
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly oneDbContext dbContext;

        public SQLRegionRepository(oneDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
             await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingregion=await dbContext.Regions.FirstOrDefaultAsync(x => x.Id==id);
            if (existingregion == null) { 
                return null;
            }
            dbContext.Regions.Remove(existingregion);
            await dbContext.SaveChangesAsync();
            return existingregion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIDAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingregion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingregion == null)
            {
                return null;
            }
            existingregion.Code = region.Code;
            existingregion.Name = region.Name;
            existingregion.RegionImageURL = region.RegionImageURL;

            await dbContext.SaveChangesAsync();
            return existingregion;
        }
    }
}
