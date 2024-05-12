using UnityEngine;
using Cysharp.Threading.Tasks;
using LLM.Data.Loaders;
using LLM.Data.Factories;

namespace LLM.Services.Containers
{

    public class MonoContainerLoader : IMonoResourceLoader
    {
        public MonoContainerLoader(string subfolder, Transform parent = null)
        {
            Factory = new BaseResourceFactory(subfolder, parent);
        }

        public IMonoContainerFactory Factory { get; }

        public virtual async UniTask<T> LoadContainer<T>()
            where T : MonoContainer
        {
            return await Factory.CreateInstance<T>();
        }

        public virtual async UniTask<T> LoadContainer<T,Y>(Y data)
            where T : MonoContainer
            where Y : ContainerData
        {
            return await Factory.CreateInstance<T, Y>(data);
        }
    }
}