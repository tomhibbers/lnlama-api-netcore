using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNLamasAPI.Models
{
    public class Chapter : IChapter
    {
        public Series ParentSeriesInternal { get; private set; }
        public ISeries ParentSeries => ParentSeriesInternal;
        public Uri FirstPageUri { get; private set; }
        public string Title { get; private set; }
        public string Updated { get; private set; }
        public Chapter(Series parent, Uri firstPageUri, string title)
        {
            ParentSeriesInternal = parent;
            FirstPageUri = firstPageUri;
            Title = title;
            Updated = string.Empty;
        }
    }
}
