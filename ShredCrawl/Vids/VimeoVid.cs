namespace ShredCrawl
{
    public class VimeoVid 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UploadDate { get; set; }
        public string ThumbnailSmall { get; set; }
        public string ThumbnailMedium { get; set; }
        public string ThumbnailLarge { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserUrl { get; set; }
        public string UserPortraitSmall { get; set; }
        public string UserPortraitMedium { get; set; }
        public string UserPortraitLarge { get; set; }
        public string UserPortraitHuge { get; set; }
        public int StatsNumberOfLikes { get; set; }
        public int StatsNumberOfPlays { get; set; }
        public int StatsNumberOfComments { get; set; }
        public int Duration { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Tags { get; set; }
        public string EmbedPrivacy { get; set; }
    }

    
}