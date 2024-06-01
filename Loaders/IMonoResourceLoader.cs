using Cysharp.Threading.Tasks;
using LLM.Containers.Data;

namespace LLM.Containers.Loaders
{
    public interface IMonoResourceLoader
    {
        public IMonoContainerFactory Factory { get; }

        public UniTask<TContainer> LoadContainer<TContainer>()
            where TContainer : MonoContainer;

        public UniTask<TContainer> LoadContainer<TContainer,YContainerData>(YContainerData data)
            where TContainer : MonoContainer
            where YContainerData : ContainerData;
    }
}