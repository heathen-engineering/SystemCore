namespace HeathenEngineering.Scriptable
{
    /// <summary>
    /// Base class for Variable References
    /// </summary>
    /// <remarks>
    /// This can be used to easily apply the drawer to any variable reference, the implamented reference will be assumed to have a ConstantValue and a Variable member
    /// </remarks>
    public class VariableReference<T> : VariableReference
    {
        public new virtual T Value { get; set; }
    }

    public class VariableReference
    {
        public VariableReferenceType Mode = VariableReferenceType.Constant;

        public virtual object Value { get; set; }
    }
}
