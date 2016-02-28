using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackaton.DataAccess;
using Hackaton.DataAccess.Entities;
using Shared.Dtos;

namespace Services
{
    public class TreeService
    {
        // ReSharper disable once InconsistentNaming
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public async Task<TreeDto> GetTree(int treeId)
        {
            return AutoMapper.Instance.Map<Tree, TreeDto>(await context.Trees.FirstAsync(t => t.Id == treeId));
        }
    }
}
