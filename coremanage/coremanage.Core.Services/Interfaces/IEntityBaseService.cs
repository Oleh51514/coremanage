﻿using System.Collections.Generic;
using System.Threading.Tasks;
using coremanage.Core.Models.Interfaces;

namespace coremanage.Core.Services.Interfaces
{
    public interface IBaseService<TDto, in TKey> where TDto : IBaseDto<TKey>
    {
        IEnumerable<TDto> GetAll();
        Task<IEnumerable<TDto>> GetAllAsync();

        //IEnumerable<TDto> GetPage();
        //Task<IEnumerable<TDto>> GetPageAsync();

        TDto Get(TKey id);

        Task<TDto> GetAsync(TKey id);

        void Add(TDto entity);

        TDto Update(TDto entity);

        void Remove(TDto entity);
        void Remove(TKey id);
        
        //bool Any();
        //Task<bool> AnyAsync();

        //int Count();
        //Task<int> CountAsync();

        //void SetUnchanged(TDto entitieit);

    }
}
