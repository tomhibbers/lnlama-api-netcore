using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNLamasAPI.Models
{
    public interface ISeries
    {
        int Id { get; }
        string Title { get; }
        string Description { get; }
        string[] TitlesAlternative { get; }
        Uri SeriesPageUri { get; }
        Uri CoverImageUri { get; }
        string Author { get; }
        string Updated { get; }
        string[] Tags { get; }
    }
}
