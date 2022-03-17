using System.Collections.Generic;
using System.Linq;
using CmsProject.Models.BaseTypes;
using MoreLinq;

namespace CmsProject.Models.Blocks.EmployeeList
{
    public class EmployeeListViewModel : BlockViewModel<EmployeeList>
    {
        public EmployeeListViewModel(EmployeeList incomingPage) : base(incomingPage)
        {
        }
    }
}