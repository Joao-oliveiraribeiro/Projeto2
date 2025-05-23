using System.Collections.Generic;

namespace CraftingSim.Model
{
    /// <summary>
    /// Inventory of materials and quantities the user has
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Dictionary that contains all the materials the user has
        /// and the respective amount
        /// </summary>
        private readonly Dictionary<IMaterial, int> materials;

        public Inventory()
        {
            materials = new Dictionary<IMaterial, int>();
        }

        /// <summary>
        /// Provides all materials in the inventory.
        /// </summary>
        public IEnumerable<IMaterial> Materials => materials.Keys;

        // <summary>
        /// provides the amount of the specified material in the inventory.
        /// </summary>
        /// <param name="material">The material to view corresponding amount.</param>
        /// <returns>The quantity in inventory, or 0 if not contained</returns>
        public int GetQuantity(IMaterial material) => materials.ContainsKey(material) ? materials[material] : 0;


        /// <summary>
        /// Adds or replaces the quantity for a specific material
        /// </summary>
        /// <param name="material">The material to add</param>
        /// <param name="quantity">The new amount to set</param>
        public void AddMaterial(IMaterial material, int quantity)
        {
            //TODO Implement Me
        }

        /// <summary>
        /// Removes a given amount of a material from inventory
        /// If theres not enough material it is not removed.
        /// </summary>
        /// <param name="material">The material we want to remove from</param>
        /// <param name="quantity">The amount to remove</param>
        /// <returns>True if removed successfuly, false if not enough material</returns>
        public bool RemoveMaterial(IMaterial material, int quantity)
        {
            // TODO Implement Me
            return false;
        }

        /// <summary>
        /// Get all the materials the user has in the inventory.
        /// </summary>
        /// <returns>A read only dictionary of materials</returns>
        public IReadOnlyDictionary<IMaterial, int> GetAllMaterials()
        {
            return materials;
        }

        /// <summary>
        /// Search and return a material by the Id.
        /// </summary>
        /// <param name="id">The material id</param>
        /// <returns>The material if it's in the inventory, if not returns null
        /// </returns>
        public IMaterial GetMaterial(int id)
        {
            foreach (IMaterial m in materials.Keys)
                if (m.Id == id)
                    return m;

            return null;
        }

        /// <summary>
        /// Loads the materials and their quantities from the text file.
        /// </summary>
        /// <param name="file">Path to the materials file</param>
        public void LoadMaterialsFromFile(string file)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("O caminho do ficheiro não pode ser vazio.", nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Ficheiro de materiais não encontrado.", filePath);

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    int lineNumber = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;
                        
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        
                        string[] parts = line.Split(',');
                        if (parts.Length != 3)
                        {
                            Console.WriteLine($"Linha {lineNumber}: formato inválido. Deve ser 'id,nome,quantidade'.");
                            continue;
                        }

                        
                        if (!int.TryParse(parts[0].Trim(), out int id))
                        {
                            Console.WriteLine($"Linha {lineNumber}: id inválido ('{parts[0]}'). Deve ser um número inteiro.");
                            continue;
                        }

                        string name = parts[1].Trim();
                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine($"Linha {lineNumber}: nome vazio ou inválido.");
                            continue;
                        }

                        if (!int.TryParse(parts[2].Trim(), out int quantity))
                        {
                            Console.WriteLine($"Linha {lineNumber}: quantidade inválida ('{parts[2]}'). Deve ser um número inteiro.");
                            continue;
                        }

                        if (quantity < 0)
                        {
                            Console.WriteLine($"Linha {lineNumber}: quantidade negativa (\"{quantity}\"). Ignorando linha.");
                            continue;
                        }

                        
                        IMaterial material = new Material(id, name);
                        AddMaterial(material, quantity);
        }
    }
}
