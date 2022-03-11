using EPiServer.Core;

namespace CmsProject.Models.BaseTypes
{
    public interface IBaseViewModel<out TContent> where TContent : IContent
    {
        TContent CurrentPage { get; }
    }
}