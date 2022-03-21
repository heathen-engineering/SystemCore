#if HE_SYSCORE
using System;
using System.Collections.Generic;

namespace HeathenEngineering
{
    /// <summary>
    /// Base class for Variable References
    /// </summary>
    /// <remarks>
    /// This can be used to easily apply the drawer to any variable reference, the implamented reference will be assumed to have a ConstantValue and a Variable member
    /// </remarks>
    public abstract class VariableReference<T> : VariableReference, IEquatable<T>, IEquatable<VariableReference<T>>
    {
        public T m_constantValue;

        public abstract IDataVariable<T> m_variable { get; }

        public T Value
        {
            get 
            { 
                if(Mode == VariableReferenceType.Referenced)
                {
                    if (m_variable != null)
                        return m_variable.Value;
                    else
                    {
                        throw new NullReferenceException("Failed to get variable reference, mode Referenced requires a valid DataVariable be available, no variable found.");
                    }
                }
                else
                {
                    return m_constantValue;
                }
            }
            set
            {
                if (Mode != VariableReferenceType.Static)
                {
                    if (Mode == VariableReferenceType.Referenced)
                    {
                        if (m_variable != null)
                            m_variable.SetValue(value);
                        else
                            throw new NullReferenceException("Failed to set variable reference, mode Referenced requires a valid DataVariable be available, no variable found.");
                    }
                    else
                        m_constantValue = value;
                }
            }
        }

        public VariableReference(T value)
        {
            Mode = VariableReferenceType.Constant;
            m_constantValue = value;
        }

        public static implicit operator T (VariableReference<T> reference)
        {
            return reference.Value;
        }

        public static bool operator ==(VariableReference<T> a, VariableReference<T> b)
        {
            return EqualityComparer<T>.Default.Equals(a.Value, b.Value);
        }

        public static bool operator ==(VariableReference<T> a, T b)
        {
            return EqualityComparer<T>.Default.Equals(a.Value, b);
        }

        public static bool operator ==(T a, VariableReference<T> b)
        {
            return EqualityComparer<T>.Default.Equals(a, b.Value);
        }

        public static bool operator !=(VariableReference<T> a, VariableReference<T> b)
        {
            return !EqualityComparer<T>.Default.Equals(a.Value, b.Value);
        }

        public static bool operator !=(VariableReference<T> a, T b)
        {
            return !EqualityComparer<T>.Default.Equals(a.Value, b);
        }

        public static bool operator !=(T a, VariableReference<T> b)
        {
            return !EqualityComparer<T>.Default.Equals(a, b.Value);
        }

        public bool Equals(T other)
        {
            return this == other;
        }

        public bool Equals(VariableReference<T> other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public abstract class VariableReference
    {
        public VariableReferenceType Mode = VariableReferenceType.Constant;
    }
}
#endif