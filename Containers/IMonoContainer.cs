using System;
using LLM.Containers.Data;

namespace LLM.Containers
{

    public interface IMonoContainer
    {
        public ContainerData Data { get; }

        public event Action<MonoContainer> OnCreated;

        public void Created();
    }
}