using System;
using Cysharp.Threading.Tasks;

namespace LLM.Services.Containers
{
    public interface IMonoContainerFactory
    {
        public event Action<MonoContainer> OnInstanceCreated;

        public UniTask<T> CreateInstance<T>()
            where T : MonoContainer;

        public UniTask<T> CreateInstance<T, Y>(Y data)
            where T : MonoContainer
            where Y : ContainerData;
    }
}