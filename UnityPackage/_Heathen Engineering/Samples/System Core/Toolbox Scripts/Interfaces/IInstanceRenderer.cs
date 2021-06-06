namespace HeathenEngineering.Tools
{
    public interface IInstanceRenderer<T> where T : IMatrixTransformData, new()
    {
        T Spawn();

        void Spawn(T data);

        void Remove(T data);

        void Render();
    }
}

