namespace IboshEngine.Runtime.Interfaces
{
    /// <summary>
    /// Interface for objects that can take damage.
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// Takes damage.
        /// </summary>
        void TakeDamage(int amount);
    }

}