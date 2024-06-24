using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using System;
using System.Collections.Generic;

namespace KhumaloCraftReg_2.Pages.Products
{
	public class Index1Model : PageModel
	{
		private const string searchServiceEndpoint = "https://khumalocraftsearch2002.search.windows.net";
		private const string apiKey = "0Kcmvni8CmqKqJU9VAGzzDleYiJmjFUnDptHP2FZC4AzSeDfsUbN";
		private const string indexName = "azuresql-index";

		public List<string>? Products{ get; set; }

		public async Task OnGet()
		{
			Products = new List<string>();

			Uri endpoint = new Uri(searchServiceEndpoint);
			AzureKeyCredential credential = new AzureKeyCredential(apiKey);
			SearchClient searchClient = new SearchClient(endpoint, indexName, credential);
			SearchResults<SearchDocument> response = await searchClient.SearchAsync<SearchDocument>("*", new SearchOptions());

			foreach (SearchResult<SearchDocument> result in response.Value.GetResults(""))
			{
				if (result.Document.TryGetValue("Products", out object name))
				{
					Products.Add(item:Products.ToString());
				}
			}
		}
	}
}


