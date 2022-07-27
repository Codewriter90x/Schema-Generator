using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Runtime.Serialization;

namespace Schema_Generator
{
    #region functions for Article schema
    internal class MainEntityOfPage
    {
        [JsonPropertyName("@type")]
        [JsonPropertyOrder(0)]
        [JsonInclude]
        public virtual string Type { get; internal set; } = "WebPage";

        [JsonPropertyName("@id")]
        [JsonPropertyOrder(1)]
        [JsonInclude]
        public virtual string ID { get; internal set; } = "https://google.com/article";
    }
    public class Publisher
    {
        [JsonPropertyName("@type")]
        [JsonPropertyOrder(0)]
        [JsonInclude]
        public string Type { get; private set; } = "Organization";

        [JsonPropertyName("name")]
        [JsonPropertyOrder(1)]
        [JsonInclude]
        public string Name { get; set; } = "";

        [JsonPropertyName("logo")]
        [JsonPropertyOrder(2)]
        [JsonInclude]
        public Logo Logo { get; set; } = new Logo();
    }
    public class Logo
    {
        [JsonPropertyName("@type")]
        [JsonPropertyOrder(0)]
        [JsonInclude]
        public string Type { get; private set; } = "ImageObject";

        [JsonPropertyName("url")]
        [JsonPropertyOrder(1)]
        [JsonInclude]
        public string Url { get; set; } = "";
    }
    public class Author
    {
        [JsonPropertyName("@type")]
        [JsonPropertyOrder(0)]
        [JsonInclude]
        public string Type { get; private set; } = "Person";

        [JsonPropertyName("name")]
        [JsonPropertyOrder(1)]
        [JsonInclude]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        [JsonPropertyOrder(2)]
        [JsonInclude]
        public string Url { get; set; }
    }
    #endregion

    internal class ArticleSchema
    {
        [JsonPropertyName("@context")]
        [JsonPropertyOrder(0)]
        [JsonInclude]
        public virtual string Context { get; internal set; } = "https://schema.org";

        [JsonPropertyName("@type")]
        [JsonPropertyOrder(1)]
        [JsonInclude]
        public virtual string Type { get; internal set; } = "NewsArticle";

        [JsonPropertyName("MainEntityOfPage")]
        [JsonPropertyOrder(2)]
        [JsonInclude]
        public MainEntityOfPage mainEntityOfPage = new MainEntityOfPage();

        [JsonPropertyName("headline")]
        [JsonInclude]
        [JsonPropertyOrder(3)]
        public string Headline { get; set; }

        [JsonPropertyName("image")]
        [JsonInclude]
        [JsonPropertyOrder(4)]
        public List<string> Image { get; set; }

        [JsonPropertyName("datePublished")]
        [JsonInclude]
        [JsonPropertyOrder(5)]
        public string DatePublished { get; set; }

        [JsonPropertyName("dateModified")]
        [JsonInclude]
        [JsonPropertyOrder(6)]
        public string DateModified { get; set; }

        [JsonPropertyName("author")]
        [JsonInclude]
        [JsonPropertyOrder(7)]
        public List<Author> Author { get; set; }

        [JsonPropertyName("publisher")]
        [JsonPropertyOrder(7)]
        [DataMember(Name = "publisher", EmitDefaultValue = false)]
        public Publisher Publisher { get; set; }
    }



    public class Article_SD
    {
        private string ArticleSchema;
        public Article_SD(string Headline, List<string> Images, DateTime datePublished, DateTime dateModified, List<Author> authors, Publisher publisher = null)
        {
            ArticleSchema Schema = new ArticleSchema
            {
                Headline = Headline,
                Image = Images,
                DatePublished = datePublished.ToString("yyyy-MM-dd'T'HH:mm:ss"),
                DateModified = dateModified.ToString("yyyy-MM-dd'T'HH:mm:ss"),
                Author = authors,
                Publisher = publisher is null ? new Publisher() : publisher

            };
            ArticleSchema = JsonSerializer.Serialize(Schema);
        }

        public override string ToString()
        {
            return ArticleSchema;

        }
    }
}

/*
 * 
 * <script type="application/ld+json">
      {
      "@context": "https://schema.org",
      "@type": "NewsArticle",
      "mainEntityOfPage": {
        "@type": "WebPage",
        "@id": "https://google.com/article"
      },
      "headline": "Article headline",
      "image": [
        "https://example.com/photos/1x1/photo.jpg",
        "https://example.com/photos/4x3/photo.jpg",
        "https://example.com/photos/16x9/photo.jpg"
      ],
      "datePublished": "2015-02-05T08:00:00+08:00",
      "dateModified": "2015-02-05T09:20:00+08:00",
      "author": {
        "@type": "Person",
        "name": "John Doe",
        "url": "http://example.com/profile/johndoe123"
      },
      "publisher": {
        "@type": "Organization",
        "name": "Google",
        "logo": {
          "@type": "ImageObject",
          "url": "https://google.com/logo.jpg"
        }
      }
    }
    </script>
*/