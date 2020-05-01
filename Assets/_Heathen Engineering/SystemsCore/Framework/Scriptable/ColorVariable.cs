using HeathenEngineering.Events;
using HeathenEngineering.Serializable;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    /// <summary>
    /// <para>A data variable such as this represents this data type in your project folder as a scriptable object. The core benifit to doing this is that you can then reference this field on any script in any scene as a shared point of data without the need of singletons or other dependency breaking paradigms.</para>
    /// <para>In addition to the ease of reference even across scenes, scriptable object like these aka Scriptable Variables can be organized into data libraries and serialized as save files easily loaded at run time and always available with no initalization testing required.</para>
    /// <para>You can create custom 'Scriptable Variables' by creating a ScriptableObject that has a value of the data type you wish to define. alternativly you can create a 'Sriptable Variable' by deriving your new type from <see cref="DataVariable{T}"/> where T is the type of data you want to define ... note that if using this method T must be serailizable.</para>
    /// </summary>
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <para>The following is simply a copy of the <see cref="BoolVariable"/> code used in the package. To create your own of any other data type simply replace bool with your own data type.</para>
    /// </description>
    /// <code>
    /// public class BoolVariable : DataVariable<bool>
    /// {
    ///#if UNITY_EDITOR
    ///    [Multiline]
    ///    public string DeveloperDescription = "";
    ///#endif
    ///    public bool Value;
    ///    [HideInInspector]
    ///    public List<ChangeEventListener<bool>> Listeners = new List<ChangeEventListener<bool>>();
    ///
    ///    public override bool DataValue
    ///    {
    ///        get
    ///        {
    ///            return Value;
    ///        }
    ///
    ///        set
    ///        {
    ///            SetValue(value);
    ///        }
    ///    }
    ///
    ///    public override object ObjectValue
    ///    {
    ///        get
    ///        {
    ///            return Value;
    ///        }
    ///
    ///        set
    ///        {
    ///            if (value.GetType() == typeof(bool))
    ///                SetValue((bool)value);
    ///        }
    ///    }
    ///
    ///    public override void SetValue(bool value)
    ///    {
    ///        if (Value != value)
    ///        {
    ///            Value = value;
    ///            Raise();
    ///        }
    ///    }
    ///
    ///    public void SetValue(string value)
    ///    {
    ///        bool v;
    ///        if (bool.TryParse(value, out v))
    ///        {
    ///            if (Value != v)
    ///            {
    ///                Value = v;
    ///                Raise();
    ///            }
    ///        }
    ///    }
    ///
    ///    public override void SetValue(DataVariable<bool> value)
    ///    {
    ///        if (Value != value.DataValue)
    ///        {
    ///            Value = value.DataValue;
    ///            Raise();
    ///        }
    ///    }
    ///
    ///    public override void Raise()
    ///    {
    ///        for (int i = Listeners.Count - 1; i >= 0; i--)
    ///        {
    ///            if (Listeners[i] != null)
    ///                Listeners[i].OnEventRaised(Value);
    ///        }
    ///    }
    ///
    ///    public override void AddListener(ChangeEventListener<bool> listener)
    ///    {
    ///        Listeners.Add(listener);
    ///    }
    ///
    ///    public override void RemoveListener(ChangeEventListener<bool> listener)
    ///    {
    ///        Listeners.Remove(listener);
    ///    }
    ///
    ///    public void ToggleValue()
    ///    {
    ///        DataValue = !Value;
    ///    }
    /// }
    /// </code>
    /// </item>
    /// </list>
    /// </example>
    [CreateAssetMenu(menuName = "Variables/Color")]
    public class ColorVariable : DataVariable<SerializableColor>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        [SerializeField]
        private SerializableColor value;

        [HideInInspector]
        public List<ChangeEventListener<SerializableColor>> Listeners = new List<ChangeEventListener<SerializableColor>>();

        public override SerializableColor Value
        {
            get
            {
                return value;
            }

            set
            {
                SetValue(value);
            }
        }

        public override object ObjectValue
        {
            get
            {
                return Value;
            }

            set
            {
                if (value.GetType() == typeof(SerializableColor))
                    SetValue((SerializableColor)value);
                else if (value.GetType() == typeof(Color))
                    SetValue((Color)value);
            }
        }

        public override void SetValue(SerializableColor value)
        {
            if (value.r != Value.r
                || value.g != Value.g
                || value.b != Value.b
                || value.a != Value.a)
            {
                this.value = value;
                Raise();
            }
        }

        public override void SetValue(DataVariable<SerializableColor> value)
        {
            if (value.Value.r != Value.r
                || value.Value.g != Value.g
                || value.Value.b != Value.b
                || value.Value.a != Value.a)
            {
                Value = value.Value;
                Raise();
            }
        }

        public override void Raise()
        {
            for (int i = Listeners.Count - 1; i >= 0; i--)
            {
                if (Listeners[i] != null)
                    Listeners[i].OnEventRaised(Value);
            }
        }

        public override void AddListener(ChangeEventListener<SerializableColor> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<SerializableColor> listener)
        {
            Listeners.Remove(listener);
        }
    }
}
