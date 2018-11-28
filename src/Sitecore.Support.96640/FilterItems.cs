using Sitecore.Diagnostics;
using Sitecore.ItemWebApi.Pipelines.Request;
using System.Linq;

namespace Sitecore.Support.ItemWebApi.Pipelines.Request
{
  internal class FilterItems : RequestProcessor
    {
        public override void Process(RequestArgs arguments)
        {
            Assert.ArgumentNotNull(arguments, "arguments");

            var itemsList = arguments.Items.ToList();
            itemsList.RemoveAll(item => !item.Versions.GetVersionNumbers().Contains(item.Version));
            arguments.Items = itemsList.ToArray();
        }
    }
}