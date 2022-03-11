using EPiServer.Core;

namespace CmsProject.Models.BaseTypes
{
    public class BaseViewModel<TContent> : IBaseViewModel<TContent> where TContent : IContent
    {
        public BaseViewModel() : this(default)
        {
        }

        public BaseViewModel(TContent incomingPage)
        {
            CurrentPage = incomingPage;
        }

        public TContent CurrentPage { get; set; }
    }
}