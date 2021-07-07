using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMP_1005_Testing_2021.Utility
{
    public interface IInsightsJavaScriptSnippet
    {
        string FullScript { get; }

        string ScriptBody { get; }
    }
}
