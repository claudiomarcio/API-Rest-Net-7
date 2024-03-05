namespace PlanetunAPI.Services
{
    public interface IPlanetunService
    {
        Task GenerateMultiplationTable(IEnumerable<int> numbers);
    }
}
