﻿using GC_PlanMyMeal.Models;
using GC_PlanMyMeal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_PlanMyMeal.Repository
{
    public interface IRepositoryClient
    {
        Task<bool> SaveRecipe(int? recipeId, string userId);
        Task<bool> FindSavedRecipe(int recipeId, string userId);
        Task<List<SavedRecipe>> RetrieveRecipeList(string userId);
        Task<bool> DeleteRecipe(string userId, int? recipeId, int? customId);
        Task<bool> AddCustomRecipe(CustomRecipe customRecipe);
        Task<List<CustomRecipe>> RetrieveCustomRecipeList(string userId);
        Task<CustomRecipe> RetrieveCustomRecipe(string userId, int? customRecipeId);
        Task<bool> UpdateRecipe(CustomRecipe customRecipe);
        Task <bool> SaveMealPlan(RecipeCalendar recipe);
        Task<List<RecipeCalendar>> GetMealPlan(string userId);
        Task<bool> DeleteCustomRecipeFromMealPlan(int customRecipeId, string userId, int numDaysFromToday);
        Task<bool> DeleteAPIRecipeFromMealPlan(int recipeId, string userId, int numDaysFromToday);
        Task<bool> VerifyMealPlanStatus(RecipeCalendar recipe);
        Task<bool> DeleteParticularRecipeFromMealPlans(int? customRecipeId, string userId);
    }
}
