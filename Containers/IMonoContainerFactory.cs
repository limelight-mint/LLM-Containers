using System;
using Cysharp.Threading.Tasks;
using LLM.Containers.Data;

namespace LLM.Containers
{
    public interface IMonoContainerFactory
    {
        public event Action<MonoContainer> OnInstanceCreated;

        public UniTask<TContainer> CreateInstance<TContainer>()
            where TContainer : MonoContainer;

        public UniTask<TContainer> CreateInstance<TContainer, YContainerData>(YContainerData data)
            where TContainer : MonoContainer
            where YContainerData : ContainerData;
    }
}