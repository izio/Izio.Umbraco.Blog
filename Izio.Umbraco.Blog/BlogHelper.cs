using System.Linq;
using System.Text;
using System.Web;
using Umbraco.Core;
using Umbraco.Web;

namespace Izio.Umbraco.Blog
{
    /// <summary>
    /// 
    /// </summary>
    public static class BlogHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static IHtmlString GetTags(dynamic article)
        {
            var builder = new StringBuilder();

            if (article.Tags != null && string.IsNullOrEmpty(article.Tags) == false)
            {
                string[] tags = article.Tags.ToString().Split(',');

                if (tags.Any())
                {
                    builder.Append("<ul class=\"tags\">");
                    foreach (var tag in tags)
                    {
                        builder.AppendFormat("<li><a href=\"{0}?tag={1}\" title=\"View articles tagged {1}\">{1}</a></li>", @article.Parent().Url, tag);
                    }
                    builder.Append("</ul>");
                }
            }

            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="thumbnailSize"></param>
        /// <param name="imageSize"></param>
        /// <returns></returns>
        public static IHtmlString BuildGallery(string folder, int thumbnailSize, int imageSize)
        {
            var builder = new StringBuilder();

            if (folder != null)
            {
                var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
                var media = umbracoHelper.Media(folder);
                var images = media.Children;

                if (thumbnailSize == 0)
                {
                    thumbnailSize = 200;
                }

                if (imageSize == 0)
                {
                    imageSize = 600;
                }

                if (images.Any())
                {
                    builder.Append("<ul class=\"gallery\">");

                    foreach (var image in images)
                    {
                        builder.AppendFormat("<li><span><a href=\"#\" data-featherlight=\"{0}?width={1}\" style=\"background-image: url('{0}?width={2}')\"></a></span></li>", image.Url, imageSize, thumbnailSize);
                    }

                    builder.Append("</ul>");
                }
            }

            return new HtmlString(builder.ToString());
        }
    }
}