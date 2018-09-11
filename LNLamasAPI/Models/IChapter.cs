using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNLamasAPI.Models
{
    public interface IChapter
    {
        ISeries ParentSeries { get; }
        string Title { get; }
        string Updated { get; }
        Uri FirstPageUri { get; }
    }
}
