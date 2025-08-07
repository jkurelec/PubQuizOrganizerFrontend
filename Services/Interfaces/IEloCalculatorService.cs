namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface IEloCalculatorService
    {
        Task<bool> CalculateEditionElo(int editionId);
        Task<bool> IsEditionRated(int editionId);
    }
}
