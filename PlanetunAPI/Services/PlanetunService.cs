using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace PlanetunAPI.Services
{
    public class PlanetunService : IPlanetunService
    {

        private readonly IConfiguration _configuration;

        public PlanetunService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly int[] tabNum = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public async Task GenerateMultiplationTable(IEnumerable<int> numbers)
        {
            await Parallel.ForEachAsync(numbers, new ParallelOptions { MaxDegreeOfParallelism = 5 }, async (i, cancellationToken) =>
            {
                StringBuilder sb = new StringBuilder();

                foreach (var numero in tabNum)
                    sb.AppendLine($"{i} x {numero} = {i * numero}");

                await CreateAndSaveFileResult(sb, $"tabuada_de_{i}.txt");

            });

        }

        private async Task CreateAndSaveFileResult(StringBuilder sb, string fileName)
        {

            var path = _configuration.GetSection("Paths").GetValue<string>("Path");

            if (File.Exists($"{path}\\{fileName}"))
                File.Delete($"{path}\\{fileName}");


            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using (StreamWriter sw = File.CreateText($"{path}\\{fileName}"))
                sw.WriteLine(sb.ToString());

        }
    }

}
