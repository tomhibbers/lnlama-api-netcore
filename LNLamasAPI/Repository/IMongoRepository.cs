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
        Task<ISeries> GetSeriesAsync(string title);
        Task PutSeriesAsync(List<Series> series);
        Task DeleteSeriesAsync(string title);

        Task<IEnumerable<IChapter>> GetChaptersAsync();
        Task<IChapter> GetChaptersAsync(string chapterRef);
        Task PutChaptersAsync(List<Chapter> chapters);
        Task<IEnumerable<IChapter>> GetChaptersBySeriesAsync(string title);
        Task DeleteChapterAsync(string chapterRef);

        Task<IEnumerable<IPage>> GetPagesAsync();
        Task<IPage> GetPagesAsync(string pageRef);
        Task PutPagesAsync(List<Page> pages);
        Task<IEnumerable<IPage>> GetPagesByChapterUri(string chapterUri);
        Task DeletePageAsync(string pageRef);
    }
}
