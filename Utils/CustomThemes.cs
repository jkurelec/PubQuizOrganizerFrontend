using MudBlazor;

namespace PubQuizOrganizerFrontend.Utils
{
    public static class CustomThemes
    {
        public static MudTheme PubQuizTheme = new MudTheme
        {
            PaletteLight = new PaletteLight
            {
                Primary = "#6E4C37",
                Secondary = "#C2A97E",
                Tertiary = "#4B382A",

                Background = "#FFFFFF",
                Surface = "#FFFFFF",

                AppbarBackground = "#3E2E23",
                AppbarText = "#FAFAFA",

                DrawerBackground = "#FFFFFF",
                DrawerText = "#3E2E23",

                TextPrimary = "#2D1E15",
                TextSecondary = "#6E4C37",

                ActionDefault = "#6E4C37",
                ActionDisabled = "#BDBDBD",

                Success = "#6A994E",
                Warning = "#D4A373",
                Error = "#9E2A2B",
                Info = "#588157",
            }
        };
    }
}
