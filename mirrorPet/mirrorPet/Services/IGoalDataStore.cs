using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mirrorPet.Models;

namespace mirrorPet.Services
{
    public interface IGoalDataStore
    {
        Task<String> AddGoalAsync(Goal goal);
        Task<bool> UpdateGoalAsync(Goal goal);
        Task<Goal> GetGoalAsync(string id);
        Task<IList<Goal>> GetGoalsAsync();
        
    }
}
