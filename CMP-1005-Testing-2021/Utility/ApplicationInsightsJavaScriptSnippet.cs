using Microsoft.ApplicationInsights.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMP_1005_Testing_2021.Utility
{
    public class ApplicationInsightsJavaScriptSnippet
        : IInsightsJavaScriptSnippet
    {
        private readonly JavaScriptSnippet _snippet;

        public ApplicationInsightsJavaScriptSnippet(JavaScriptSnippet snippet)
        {
            _snippet = snippet;
        }

        public string FullScript => _snippet.FullScript;

        public string ScriptBody => _snippet.ScriptBody;
    }
}
