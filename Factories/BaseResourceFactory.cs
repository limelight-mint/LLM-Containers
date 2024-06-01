using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using LLM.Containers.Data;

namespace LLM.Containers.Factories
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

        public virtual async UniTask<TContainer> CreateInstance<TContainer>() 
            where TContainer : MonoContainer
        {
            return (TContainer)await Get<TContainer>();
        }

        public virtual async UniTask<TContainer> CreateInstance<TContainer, YContainerData>(YContainerData data)
            where TContainer : MonoContainer
            where YContainerData : ContainerData
        {
            TContainer instance = (TContainer)await Get<TContainer>();
            instance.Data = data;

            return instance;
        }
        
        public virtual async UniTask<MonoContainer> Get<TContainer>(string implicitContainerName = "")
            where TContainer : MonoContainer
        {
            string containerName = typeof(TContainer).Name;
            containerName = System.Text.RegularExpressions.Regex.Replace(containerName, "((?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z]))", " $1").Trim();

            string prefabPath = implicitContainerName.Length <= 0
                ? $"{folder}/{containerName}"
                : $"{folder}/{implicitContainerName}";
            
            var prefab = await Resources.LoadAsync<MonoContainer>(prefabPath);
            if (prefab == null)
            {
                Debug.LogError($"Container {containerName} does not exist at Resources/{prefabPath}");
            }

            var container = (TContainer)GameObject.Instantiate(prefab, parent);
            return container;
        }
    }
}