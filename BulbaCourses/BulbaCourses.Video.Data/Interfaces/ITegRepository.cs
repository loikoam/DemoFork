﻿using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Interfaces
{
    public interface ITegRepository : IDisposable
    {
        TagDb GetById(string tagId);
        IEnumerable<TagDb> GetAll();
        void Add(TagDb tag);
        void Update(TagDb tag);
        void Remove(TagDb tag);

        Task<TagDb> GetByIdAsync(string tagId);
        Task<IEnumerable<TagDb>> GetAllAsync();
        Task<int> AddAsync(TagDb tagDb);
        Task<int> UpdateAsync(TagDb tagDb);
        Task<int> RemoveAsync(TagDb tag);
    }
}
