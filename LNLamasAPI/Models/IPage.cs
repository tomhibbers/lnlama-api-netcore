using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNLamasAPI.Models
{
    public interface IPage
    {
        IChapter ParentChapter { get; }
        Uri ImageUri { get; }
        int PageNo { get; }
        Uri PageUri { get; }
        string PageContent { get; }
    }
}
