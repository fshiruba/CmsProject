using CmsProject.Models.BaseTypes;
using EPiServer.Core;

namespace CmsProject.Models.BaseTypes
{
    public class BlockViewModel<T> : IBlockViewModel<T> where T : BlockData
    {
        public BlockViewModel(T currentBlock) => CurrentBlock = currentBlock;

        public T CurrentBlock { get; }
    }
}