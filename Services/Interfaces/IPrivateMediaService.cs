namespace PubQuizOrganizerFrontend.Services.Interfaces
{
    public interface IPrivateMediaService
    {
        Task<byte[]?> GetMediaFile(string mediaType, int editionId, string fileName);
    }
}
