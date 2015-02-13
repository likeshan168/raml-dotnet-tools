﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Raml.Tools.ClientGenerator
{
	[Serializable]
	public class ClientGeneratorModel
	{
		public ClientGeneratorModel()
		{
			Warnings = new Dictionary<string, string>();
		}

		private string baseUri;
		public string Namespace { get; set; }
		public IDictionary<string, ApiObject> ResponseObjects { get; set; }
		public IDictionary<string, ApiObject> RequestObjects { get; set; }
		public IDictionary<string, ApiObject> QueryObjects { get; set; }
        public IDictionary<string, ApiObject> HeaderObjects { get; set; }
        public IDictionary<string, ApiObject> ResponseHeaderObjects { get; set; }
		public IEnumerable<ApiObject> ApiResponseObjects { get; set; }
		public IEnumerable<ApiObject> ApiRequestObjects { get; set; }
		public IDictionary<string, ApiObject> UriParameterObjects { get; set; }
		public IEnumerable<ClassObject> Classes { get; set; }

		public ClassObject Root { get; set; }

		public IDictionary<string, string> Warnings { get; set; }
		public IDictionary<string, ApiObject> Objects
		{
			get
			{
				var objects = RequestObjects.ToDictionary(requestObject => requestObject.Key, requestObject => requestObject.Value);
				foreach (var responseObject in ResponseObjects.Where(responseObject => !objects.ContainsKey(responseObject.Key)))
				{
					objects.Add(responseObject.Key, responseObject.Value);
				}
				foreach (var queryObject in QueryObjects.Where(keyValuePair => !objects.ContainsKey(keyValuePair.Key)))
				{
					objects.Add(queryObject.Key, queryObject.Value);
				}
				foreach (var uriParamObject in UriParameterObjects)
				{
					objects.Add(uriParamObject.Key, uriParamObject.Value);
				}
				return objects;
			}
		}

		public IEnumerable<GeneratorParameter> BaseUriParameters { get; set; }

		public string BaseUri
		{
			get { return !string.IsNullOrWhiteSpace(baseUri) && !baseUri.EndsWith("/") ? baseUri + "/" : baseUri; }
			set { baseUri = value; }
		}

		public Security Security { get; set; }

		public string BaseUriParametersString
		{
			get
			{
				if (BaseUriParameters == null || !BaseUriParameters.Any())
					return string.Empty;

				var baseUriParametersString = string.Join(",", BaseUriParameters
					.Where(p => p.Name.ToLower() != "version")
					.Select(p => p.Type + " " + p.Name)
					.ToArray());

				if (BaseUriParameters.Any(p => p.Name.ToLower() == "version"))
				{
					var versionParam = BaseUriParameters.First(p => p.Name.ToLower() == "version");
					if (!string.IsNullOrWhiteSpace(Version))
						baseUriParametersString += ", " + versionParam.Type + " " + versionParam.Name + " = \"" + Version + "\"";
					else
						baseUriParametersString += ", " + versionParam.Type + " " + versionParam.Name;
				}
				
				return baseUriParametersString;
			}
		}

		public string Version { get; set; }

		public string ConstructorParametersString
		{
			get
			{
				var res = "string baseUrl";
				if (string.IsNullOrWhiteSpace(BaseUriParametersString))
					res += ", " + BaseUriParametersString;

				return res + ", HttpClient httpClient = null";
			}
		}

	}
}