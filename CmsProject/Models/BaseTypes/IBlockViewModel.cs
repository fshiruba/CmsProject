using EPiServer.Core;

namespace CmsProject.Models.BaseTypes
{
    public interface IBlockViewModel<out T> where T : BlockData
    {
        T CurrentBlock { get; }
    }
}