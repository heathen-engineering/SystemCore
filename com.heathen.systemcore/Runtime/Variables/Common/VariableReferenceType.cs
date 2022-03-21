#if HE_SYSCORE
namespace HeathenEngineering
{
    public enum VariableReferenceType
    {
        /// <summary>
        /// Displays in editor like a primative type and does not link to a scriptable object
        /// </summary>
        Constant,
        /// <summary>
        /// Displays in editor like a primative type and does not link to a scriptable object ... will ignore runtime updates to Value
        /// </summary>
        Static,
        /// <summary>
        /// Displays in editor like a reference look up, passes updates to Value into the linked scriptable object
        /// </summary>
        Referenced
    }
}
#endif