﻿using Infrastructure.DataAccess.Implementations.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccess.EF.Contexts;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.EF.Repositories
{
    public class JobLabelRepository : BaseRepository<JobLabel, ToDoContext>, IJobLabelRepository
    {
        public async Task<JobLabel> GetByIdAsync(int Id, params string[] includeList)
        {
            return await GetAsync(k => k.Id == Id, includeList);
        }
    }
}
