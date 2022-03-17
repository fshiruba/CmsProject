using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using SixLabors.ImageSharp;

namespace CmsProject.Models.Blocks.EmployeeList
{
    [TemplateDescriptor]
    public partial class EmployeeListComponent : AsyncBlockComponent<EmployeeList>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(EmployeeList currentContent)
        {
            EmployeeList writtableClone = currentContent.CreateWritableClone() as EmployeeList;

            if (writtableClone.EmployeeListItems == null)
            {
                writtableClone.EmployeeListItems = new List<EmployeeListItem>();
            }

            writtableClone.EmployeeListItems = writtableClone.EmployeeListItems.OrderBy(x => x.Order).ToList();

            return await Task.FromResult(View($"~/Models/Blocks/{nameof(EmployeeList)}/{nameof(EmployeeList)}.cshtml", new EmployeeListViewModel(writtableClone)));
        }
    }
}