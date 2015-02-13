﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Formatting;


namespace Raml.Client.Common
{
	public class ApiRequest
	{
		public ApiRequest()
        {
            RawHeaders = new HttpHeaders();
        }

		/// <summary>
		/// Additional Custom Headers - Use to add any header not specified in RAML
		/// </summary>
		public HttpHeaders RawHeaders { get; set; }
	}

	public class HttpHeaders : System.Net.Http.Headers.HttpHeaders
	{
		public HttpHeaders()
			: base()
		{
		
		}
	}
}