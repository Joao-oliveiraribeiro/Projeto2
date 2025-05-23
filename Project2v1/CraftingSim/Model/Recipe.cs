using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftingSim.Model
{
    public class Recipe : IRecipe
    {

        private readonly Inventory inventory;
        private readonly Name name;

        private readonly List<IMaterial, int> requiredMaterials;

        private readonly SuccessRate successRate;

        public Recipe(Inventory inventory, string name, double successRate)
        {
            Name = name;
            requiredMaterials = new List<IMaterial, int>();
            SuccessRate = successRate
        }

        public IReadOnlyDictionary<IMaterial, int> RequiredMaterials => RequiredMaterials;
    }
}