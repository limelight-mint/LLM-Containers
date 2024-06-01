using System;
using Cysharp.Threading.Tasks;
using LLM.Containers.Data;

namespace LLM.Containers
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