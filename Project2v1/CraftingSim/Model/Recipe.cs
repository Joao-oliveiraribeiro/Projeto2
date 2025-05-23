using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CraftingSim.Model
{
    /// <summary>
    /// Concrete implementation of IRecipe
    /// </summary>
    public class Recipe : IRecipe
    {
        public string Name { get; }
        public IReadOnlyDictionary<IMaterial, int> RequiredMaterials { get; }
        public double SuccessRate { get; }

        public Recipe(string name, Dictionary<IMaterial, int> requiredMaterials, double successRate)
        {
            Name = name;
            RequiredMaterials = new Dictionary<IMaterial, int>(requiredMaterials);
            SuccessRate = successRate;
        }

        public int CompareTo(IRecipe other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

    }
}
