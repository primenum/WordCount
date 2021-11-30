using Newtonsoft.Json;

namespace WordCount.WebApi.DTO
{
    public class AnalyzeInput
    {
        [JsonProperty("freeText")]
        public string FreeText { get; set; }
        [JsonProperty("filePath")]
        public string FilePath { get; set; }
        [JsonProperty("resourceUrl")]
        public string ResourceUrl { get; set; }
    }
}
