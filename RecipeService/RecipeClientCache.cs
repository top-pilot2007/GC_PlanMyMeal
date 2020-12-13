﻿using GC_PlanMyMeal.Configuration;
using GC_PlanMyMeal.RecipeService.Models;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;

namespace GC_PlanMyMeal.RecipeService
{
    public class RecipeClientCache : RecipeClient
    {
        private static ConcurrentDictionary<int, Recipe> _recipeCache;

        public RecipeClientCache(HttpClient httpClient, SpoonacularConfiguration config) : base(httpClient, config)
        {
            _recipeCache = new ConcurrentDictionary<int, Recipe>();
        }

        public override async Task<Recipe> SearchForRecipeById(int? id)
        {
            if (id == null)
            {
                return await base.SearchForRecipeById(id);
            }

            if(_recipeCache.TryGetValue(id.Value, out var recipe))
            {
                return recipe;
            }

            recipe = await base.SearchForRecipeById(id);
            _recipeCache.TryAdd(id.Value, recipe);
            return recipe;
        }

    }
}