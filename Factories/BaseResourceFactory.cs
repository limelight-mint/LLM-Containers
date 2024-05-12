using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using LLM.Services.Containers;

namespace LLM.Data.Factories
{

    public class BaseResourceFactory : IMonoContainerFactory
    {
        private string folder;
        private Transform parent;

        public event Action<MonoContainer> OnInstanceCreated;

        public BaseResourceFactory(string folderPath, Transform parent) 
        {
            folder = folderPath;
            this.parent = parent;
        }

        public virtual async UniTask<T> CreateInstance<T>() 
            where T : MonoContainer
        {
            return (T)await Get<T>();
        }

        public virtual async UniTask<T> CreateInstance<T, Y>(Y data)
            where T : MonoContainer
            where Y : ContainerData
        {
            T instance = (T)await Get<T>();
            instance.Data = data;

            return instance;
        }

        public virtual async UniTask<MonoContainer> Get<T>()
            where T : MonoContainer
        {
            string containerName = typeof(T).Name;
            containerName = System.Text.RegularExpressions.Regex.Replace(containerName, "((?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z]))", " $1").Trim();

            string prefabPath = $"{folder}/{containerName}";
            var prefab = await Resources.LoadAsync<MonoContainer>(prefabPath);
            if (prefab == null)
            {
                Debug.LogError($"Container {containerName} does not exist at Resources/{prefabPath}");
            }

            var container = (T)GameObject.Instantiate(prefab, parent);
            return container;
        }
    }
}