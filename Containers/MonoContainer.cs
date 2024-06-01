using System;
using UnityEngine;
using LLM.Containers.Data;

namespace LLM.Containers
{

    public class MonoContainer : MonoBehaviour, IMonoContainer
    {
        public ContainerData Data { get; set; }

        public event Action<MonoContainer> OnCreated;

        public virtual void Created() => OnCreated?.Invoke(this);
    }
}