using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamasAPI.Models;
using LNLamaScrape.Models;
using Chapter = LNLamasAPI.Models.Chapter;
using Page = LNLamasAPI.Models.Page;
using Series = LNLamasAPI.Models.Series;

namespace LNLamasAPI.Repository
{
    public interface IMongoRepository
    {
        Task<IEnumerable<ISeries>> GetSeriesAsync();
        Task PutSeriesAsync(List<Series> series);
        Task<IEnumerable<IChapter>> GetChaptersAsync();
        Task PutChaptersAsync(List<Chapter> chapters);
        Task<IEnumerable<IChapter>> GetChaptersBySeriesTitleAsync(string title);
        Task<IEnumerable<IPage>> GetPagesAsync();
        Task PutPagesAsync(List<Page> pages);
        Task<IEnumerable<IPage>> GetPagesByChapterUri(string chapterUri);
    }
}
