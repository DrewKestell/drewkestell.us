using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrewKestellSite.Models
{
    public class Article
    {
        public Article()
        {
            ArticleChapters = new HashSet<ArticleChapter>();
        }

        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string Slug { get; set; }

        [Required, MaxLength(128)]
        public string Title { get; set; }

        [Required, MaxLength(512)]
        public string Description { get; set; }

        [Required, MaxLength(256)]
        public string ThumbnailUrl { get; set; }

        public virtual ICollection<ArticleChapter> ArticleChapters { get; set; }
    }
}
