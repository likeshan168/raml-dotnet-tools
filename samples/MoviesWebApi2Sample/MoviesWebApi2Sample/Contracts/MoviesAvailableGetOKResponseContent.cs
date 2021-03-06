// Template: Models (ApiModel.t4) version 3.0

// This code was generated by RAML Web Api 2 Scaffolder

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoviesWebApi2Sample.Movies.Models
{
    public partial class MoviesAvailableGetOKResponseContent
    {
        

		[JsonProperty("id")]
        public int? Id { get; set; }

		[JsonProperty("name")]
        public string Name { get; set; }

		[JsonProperty("director")]
        public string Director { get; set; }

		[JsonProperty("genre")]
        public string Genre { get; set; }

		[JsonProperty("cast")]
        public string Cast { get; set; }

		[JsonProperty("duration")]
        public decimal? Duration { get; set; }

		[JsonProperty("storyline")]
        public string Storyline { get; set; }

		[JsonProperty("language")]
        public string Language { get; set; }

		[JsonProperty("rented")]
        public bool? Rented { get; set; }
    } // end class

} // end Models namespace

