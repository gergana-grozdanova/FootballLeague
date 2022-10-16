using FootballLeague.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Domain.Abstractions.Services
{
    public interface IBaseService<TDto>
        where TDto : BaseDto
    {
        public Task<TDto> CreateAsync(TDto dto);
        public Task<TDto> UpdateAsync(TDto dto);
        public Task DeleteAsync(string id);
        public Task<TDto> GetByIdAsync(string id);
        public Task<List<TDto>> GetAllAsync();
    }
}
