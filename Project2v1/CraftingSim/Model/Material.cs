using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CraftingSim.Model
{
    public class Material : IMaterial
    {
        public int Id { get; }
        public string Name { get; }

        public Material(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public bool Equals(IMaterial other)
        {
            if (other == null)
                return false;

            return this.Id == other.Id || this.Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as IMaterial);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Name.ToLowerInvariant().GetHashCode();
        }

    }
}