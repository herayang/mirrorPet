using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mirrorPet.Models;

namespace mirrorPet.Services
{
    public class MockGoalDataStore : IGoalDataStore
    {
        private static readonly List<Goal> mockGoals;
        private static int nextGoalId;

        static MockGoalDataStore()
        {
            
            mockGoals = new List<Goal>
            {
                new Goal { GoalId="0", GoalName="Eat Less", GoalSum=0, GoalTarget=2000, PetId="1",
                   PetName="Holdkun", PetImageUrl="1.ok.png"  },
                
            };

            nextGoalId = mockGoals.Count;
        }

        // constructor not used currently
        public MockGoalDataStore()
        {
        }

        public async Task<string> AddGoalAsync(Goal goal)
        {
            lock (this)
            {
                goal.GoalId = nextGoalId.ToString();
                mockGoals.Add(goal);
                nextGoalId++;
            }
            return await Task.FromResult(goal.GoalId);
        }

        public async Task<Goal> GetGoalAsync(string id)
        {
            var _goal = mockGoals.FirstOrDefault(goal => goal.GoalId == id);

            // Make a copy of the goals to simulate reading from an external datastore
            var returnGoal= CopyGoal(_goal);
            return await Task.FromResult(returnGoal);
        }

        public async Task<IList<Goal>> GetGoalsAsync()
        {
            // Make a copy of the goals to simulate reading from an external datastore
            var returnGoals = new List<Goal>();
            foreach (var goal in mockGoals)
                returnGoals.Add(CopyGoal(goal));
            return await Task.FromResult(returnGoals);
        }

        public async Task<bool> UpdateGoalAsync(Goal goal)
        {
            var goalIndex = mockGoals.FindIndex((Goal arg) => arg.GoalId == goal.GoalId);
            var goalFound = goalIndex != -1;
            if (goalFound)
            {
                mockGoals[goalIndex].GoalName = goal.GoalName;
                mockGoals[goalIndex].GoalSum = goal.GoalSum;
                mockGoals[goalIndex].GoalTarget = goal.GoalTarget;
                mockGoals[goalIndex].PetId = goal.PetId;
                mockGoals[goalIndex].PetName = goal.PetName;
                mockGoals[goalIndex].PetImageUrl = goal.PetImageUrl;
               
            }
            return await Task.FromResult(goalFound);
        }

        private static Goal CopyGoal(Goal goal)
        {
            return new Goal { GoalId = goal.GoalId, GoalName = goal.GoalName, GoalSum = goal.GoalSum, GoalTarget = goal.GoalTarget,
            PetId = goal.PetId, PetImageUrl = goal.PetImageUrl, PetName = goal.PetName };
        }
    }
}
