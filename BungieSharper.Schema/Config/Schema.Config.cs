namespace BungieSharper.Schema.Config
{
    public class UserTheme
    {
        public int userThemeId { get; set; }

        public string userThemeName { get; set; }

        public string userThemeDescription { get; set; }
    }

    public class GroupTheme
    {
        public string name { get; set; }

        public string folder { get; set; }

        public string description { get; set; }
    }
}