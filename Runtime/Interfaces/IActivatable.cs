namespace IboshEngine.Runtime.Interfaces
{
    /// <summary>
    /// Interface for objects that can be activated and deactivated.
    /// </summary>
    public interface IActivatable
    {
        /// <summary>
        /// Activates the object.
        /// </summary>
        void Activate();

        /// <summary>
        /// Deactivates the object.
        /// </summary>
        void Deactivate();
    }

}