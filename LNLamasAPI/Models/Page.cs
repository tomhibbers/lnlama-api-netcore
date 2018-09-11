using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNLamasAPI.Models
{
    public class Page : IPage
    {
        public Chapter ParentChapterInternal { get; private set; }
        public IChapter ParentChapter => ParentChapterInternal;
        public Uri PageUri { get; private set; }
        public int PageNo { get; private set; }
        public Uri ImageUri { get; internal set; }
        public string PageContent { get; internal set; }
        public Page(Chapter parent, Uri pageUri, int pageNo)
        {
            ParentChapterInternal = parent;
            PageUri = pageUri;
            PageNo = pageNo;
        }
    }
}
