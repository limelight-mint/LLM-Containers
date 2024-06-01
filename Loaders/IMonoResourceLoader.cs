using Cysharp.Threading.Tasks;
using LLM.Containers.Data;

namespace LLM.Containers.Loaders
{
    public interface IMonoResourceLoader
    {
        public IMonoContainerFactory Factory { get; }

        public UniTask<T> LoadContainer<T>()
            where T : MonoContainer;

        public UniTask<T> LoadContainer<T,Y>(Y data)
            where T : MonoContainer
            where Y : ContainerData;
    }
}