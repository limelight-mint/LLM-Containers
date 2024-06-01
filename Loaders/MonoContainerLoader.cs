using UnityEngine;
using Cysharp.Threading.Tasks;
using LLM.Containers.Data;
using LLM.Containers.Factories;

namespace LLM.Containers.Loaders
{

    public class MonoContainerLoader : IMonoResourceLoader
    {
        public MonoContainerLoader(string subfolder, Transform parent = null)
        {
            Factory = new BaseResourceFactory(subfolder, parent);
        }

        public IMonoContainerFactory Factory { get; }

        public virtual async UniTask<TContainer> LoadContainer<TContainer>()
            where TContainer : MonoContainer
        {
            return await Factory.CreateInstance<TContainer>();
        }

        public virtual async UniTask<TContainer> LoadContainer<TContainer,YContainerData>(YContainerData data)
            where TContainer : MonoContainer
            where YContainerData : ContainerData
        {
            return await Factory.CreateInstance<TContainer, YContainerData>(data);
        }
    }
}