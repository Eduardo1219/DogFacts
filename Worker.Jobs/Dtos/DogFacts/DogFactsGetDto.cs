using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Worker.Jobs.Dtos.DogFacts
{
    public record DogFactsGetDto(
    [JsonProperty("data")] List<FactData> Data
    );

    public record FactData(
        [JsonProperty("id")] Guid Id,
        [JsonProperty("type")] string Type,
        [JsonProperty("attributes")] FactAttributes Attributes
    );

    public record FactAttributes(
        [JsonProperty("body")] string Body
    );
}
