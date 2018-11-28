using Sitecore.Diagnostics;
using Sitecore.ItemWebApi.Pipelines.Request;
using System.Linq;

namespace Sitecore.Support.ItemWebApi.Pipelines.Request
{
  internal class FilterScope : RequestProcessor
    {
        public override void Process(RequestArgs arguments)
        {
            Assert.ArgumentNotNull(arguments, "arguments");

            var itemsScopeList = arguments.Scope.ToList();
            itemsScopeList.RemoveAll(item => !item.Versions.GetVersionNumbers().Contains(item.Version));
            arguments.Scope = itemsScopeList.ToArray();
        }
    }
}