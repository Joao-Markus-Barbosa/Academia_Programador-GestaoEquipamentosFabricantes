using System.Text.Json;

namespace GestaoEquipamentosWeb.Data
{
    public static class JsonStorage
    {
        public static void SalvarEmArquivo<T>(string caminho, List<T> dados)
        {
            var json = JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminho, json);
        }

        public static List<T> CarregarDeArquivo<T>(string caminho)
        {
            if (!File.Exists(caminho))
                return new List<T>();

            var json = File.ReadAllText(caminho);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }
}

