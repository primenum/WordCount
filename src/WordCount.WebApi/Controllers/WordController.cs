using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordCount.Application.Services.Data;
using WordCount.Application.Services.Query;

namespace WordCount.Exercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordController : ControllerBase
    {
        private readonly IDataAnalize _dataAnalize;
        private readonly IStatistics _statistsics;

        public WordController(IDataAnalize dataAnalize, IStatistics statistsics)
        {
            _dataAnalize = dataAnalize;
            _statistsics = statistsics;
        }


        [HttpPost("analyze")]
        public async Task<IActionResult> AnalyzeData([FromBody] WordCount.WebApi.DTO.AnalyzeInput input)
        {
            var t1 = Stopwatch.StartNew();
            if (string.IsNullOrEmpty(input.FreeText) &&
                string.IsNullOrEmpty(input.FilePath)
                && string.IsNullOrEmpty(input.ResourceUrl))
                return BadRequest("User input invalid");


            List<Task> tasks = new List<Task>();


            //if exception occurs in any of this tasks all request will have an error

            ///run all task in parallel
            tasks.Add(Task.Run(() =>
            {
                _dataAnalize.AnalyzeFreeText(input.FreeText);
            }));

            tasks.Add(Task.Run(() =>
            {
                _dataAnalize.AnalyzeFreeText(input.FilePath);
                
            }));

            tasks.Add(Task.Run(() =>
            {
                _dataAnalize.AnalyzeWebResource(input.ResourceUrl);

            }));

            Task.WaitAll(tasks.ToArray());

            return Ok(new { status = "ok", timeTaken = $"{t1.ElapsedMilliseconds} (ms)" });
        }


        [HttpGet("statistics/{word}")]
        public async Task<IActionResult> GetWordStatistics(string word)
        {
            if (string.IsNullOrEmpty(word))
                return BadRequest("The input is incorrect");

            var count = _statistsics.GetWordCount(word);
            return Ok(new {word= word, count= count });
        }
    }
}
