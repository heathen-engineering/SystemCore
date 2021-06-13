namespace HeathenEngineering.Tools
{
    public abstract class ValueSensor<T> : ValueSensor, IValueSensor<T>
    {
        public new virtual T Value
        {
            get
            {
                return default(T);
            }
        }

        object IValueSensor.Value { get { return Value; } }
    }

    public abstract class ValueSensor : HeathenBehaviour, IValueSensor
    {
        public virtual object Value
        {
            get
            {
                return null;
            }
        }

        public virtual void Refresh()
        {
        }
    }
}
