using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FootballLeague.Data;
using FootballLeague.Data.Entities;
using FootballLeague.Domain.Abstractions.Services;
using FootballLeague.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Services
{
    public abstract class BaseService<TDto,TEntity> : IBaseService<TDto> 
        where TDto : BaseDto
        where TEntity : BaseEntity
    {
        protected readonly FootballLeagueContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> entities;
        protected BaseService(FootballLeagueContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            entities = dbContext.Set<TEntity>();
        }
        public async Task<TDto> CreateAsync(TDto dto)
        {
            dto.Id = Guid.NewGuid().ToString();
            TEntity entity = _mapper.Map<TEntity>(dto);

            await entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        public async Task DeleteAsync(string id)
        {
            TEntity entity = await entities
               .FirstOrDefaultAsync(e => e.Id == id);

            if (entity != null)
            {
               entity.IsDeleted = true;
              //TEntity deleted=(TEntity)Activator.CreateInstance(typeof(TEntity));  
              //  deleted.IsDeleted = true;
              //  deleted.Id = id;
              //  _dbContext.Set<TEntity>().Attach(deleted);
              //  _dbContext.Entry(deleted).Property(e=>e.IsDeleted).IsModified=true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            var notDeleted = entities.Where(e => !e.IsDeleted);
           return await _mapper.ProjectTo<TDto>(notDeleted).ToListAsync();
        }

        public async Task<TDto> GetByIdAsync(string id)
        {
            TEntity entity = await entities
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            var dto = _mapper.Map<TDto>(entity);

            return dto;
        }

        public async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }
    }
}
