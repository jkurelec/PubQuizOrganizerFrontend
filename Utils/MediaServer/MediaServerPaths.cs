using PubQuizOrganizerFrontend.Enums;

namespace PubQuizOrganizerFrontend.Utils.MediaServer
{
    public static class MediaServerPaths
    {
        private static readonly string BasePath = "https://localhost:7246/media";

        private static class Public
        {
            public static string Question => $"{BasePath}/question";
            public static string QuestionImage => $"{Question}/image/";
            public static string QuestionVideo => $"{Question}/video/";
            public static string QuestionAudio => $"{Question}/audio/";

            public static string Edition => $"{BasePath}/edition/";
            public static string Location => $"{BasePath}/location/";
            public static string Organization => $"{BasePath}/organization/";
            public static string Quiz => $"{BasePath}/quiz/";
            public static string Team => $"{BasePath}/team/";
            public static string User => $"{BasePath}/user/";
        }

        public static string GetPublicPath(MediaServerResource path) =>
            path switch
            {
                MediaServerResource.Edition => Public.Edition,
                MediaServerResource.Location => Public.Location,
                MediaServerResource.Organization => Public.Organization,
                MediaServerResource.Question => Public.Question,
                MediaServerResource.Quiz => Public.Quiz,
                MediaServerResource.Team => Public.Team,
                MediaServerResource.User => Public.User,
                _ => throw new ArgumentOutOfRangeException(nameof(path), path, null)
            };
    }
}
