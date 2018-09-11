using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNLamasAPI.Models
{
    public class Series : ISeries
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; internal set; }
        public string[] TitlesAlternative { get; internal set; }
        public Uri SeriesPageUri { get; internal set; }
        public Uri CoverImageUri { get; internal set; }
        public string Author { get; internal set; }
        public string Updated { get; internal set; }
        public string[] Tags { get; internal set; }
        public string[] Genres { get; internal set; }
        public Series(Uri seriesPageUri, string title)
        {
            SeriesPageUri = seriesPageUri;
            Title = title;
            Updated = string.Empty;
        }
    }
}
