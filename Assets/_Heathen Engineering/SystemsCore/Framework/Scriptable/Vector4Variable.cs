﻿using HeathenEngineering.Events;
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
    [CreateAssetMenu(menuName = "Variables/Vector4")]
    public class Vector4Variable : DataVariable<SerializableVector4>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        [SerializeField]
        private SerializableVector4 value;
        [HideInInspector]
        public List<ChangeEventListener<SerializableVector4>> Listeners = new List<ChangeEventListener<SerializableVector4>>();

        public override SerializableVector4 Value
        {
            get
            {
                return this.value;
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
                return this.value;
            }

            set
            {
                if (value.GetType() == typeof(SerializableVector4))
                    SetValue((SerializableVector4)value);
                else if (value.GetType() == typeof(Vector4))
                    SetValue((Vector4)value);
            }
        }

        public override void SetValue(SerializableVector4 value)
        {
            if (this.value.x != value.x
                || this.value.y != value.y
                || this.value.z != value.z
                || this.value.w != value.w)
            {
                this.value = value;
                Raise();
            }
        }

        public override void SetValue(DataVariable<SerializableVector4> value)
        {
            if (this.value.x != value.Value.x
                || this.value.y != value.Value.y
                || this.value.z != value.Value.z
                || this.value.w != value.Value.w)
            {
                this.value = value.Value;
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

        public override void AddListener(ChangeEventListener<SerializableVector4> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<SerializableVector4> listener)
        {
            Listeners.Remove(listener);
        }
    }
}
