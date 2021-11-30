using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordCount.Application.Services.DataProcess;
using WordCount.Application.Services.Query;

namespace WordCount.Exercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordController : ControllerBase
    {
        private readonly IDataProcessFactory _dataProcessFactory;
        private readonly IStatistics _statistsics;

        public WordController(IDataProcessFactory dataProcessFactory, IStatistics statistsics)
        {
            _dataProcessFactory = dataProcessFactory;
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


            Task[] tasks = new Task[2];


            //if exception occurs in any of this tasks all request will have an error

            tasks[0] = Task.Run(() =>
            {
                var dp = _dataProcessFactory.GetService<ITextDataProcess>();
                dp.DataProcess(input.FreeText);
            });

            tasks[1] = Task.Run(() =>
            {
                var dp = _dataProcessFactory.GetService<IFileDataProcess>();
                
                dp.DataProcess(input.FilePath);
            });


            Task.WaitAll(tasks);

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
