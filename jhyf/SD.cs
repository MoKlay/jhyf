using jhyf.Data.Identity;

namespace jhyf
{
    public static class SD
    {
        public static List<AddNews> news = new List<AddNews>();

        public static void AddNews(AddNews model)
        {
            news.Add(model);
        }
    }
}
