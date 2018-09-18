using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamasAPI.Models;
using LNLamaScrape.Models;

namespace LNLamasAPI.Repository
{
    public interface IMongoRepository
    {
        Task<IEnumerable<ISeries>> GetSeriesAsync();
        Task<ISeries> GetSeriesAsync(string id);
        Task PutSeriesAsync(List<SeriesDto> series);
        Task DeleteSeriesAsync(string title);

        Task<IEnumerable<IChapter>> GetChaptersAsync();
        Task<IChapter> GetChaptersAsync(string id);
        Task PutChaptersAsync(List<ChapterDto> chapters);
        Task<IEnumerable<IChapter>> GetChaptersBySeriesAsync(string id);
        Task DeleteChapterAsync(string id);

        Task<IEnumerable<IPage>> GetPagesAsync();
        Task<IPage> GetPagesAsync(string id);
        Task PutPagesAsync(List<PageDto> pages);
        Task<IEnumerable<IPage>> GetPagesByChapter(string id);
        Task DeletePageAsync(string id);
    }
}
