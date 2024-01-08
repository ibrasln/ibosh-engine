using System.Collections;
using UnityEngine;

namespace IboshEngine.Runtime.Utilities
{
    using Debugger;

    /// <summary>
    /// Utility class for performing various validation checks with debug logging.
    /// </summary>
    public static class ValidationUtilities
    {
        /// <summary>
        /// Checks if a string is empty and logs a warning if true.
        /// </summary>
        /// <param name="thisObject">The object being validated.</param>
        /// <param name="fieldName">The name of the field being checked.</param>
        /// <param name="stringToCheck">The string to check for emptiness.</param>
        /// <returns>True if the string is empty, otherwise false.</returns>
        public static bool ValidateCheckEmptyString(Object thisObject, string fieldName, string stringToCheck)
        {
            if (stringToCheck == "")
            {
                IboshDebugger.LogWarning($"{fieldName} is empty and must contain a value in object {thisObject.name}", thisObject.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Yellow);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if an object reference is null and logs a warning if true.
        /// </summary>
        /// <param name="thisObject">The object being validated.</param>
        /// <param name="fieldName">The name of the field being checked.</param>
        /// <param name="objectToCheck">The object reference to check for null.</param>
        /// <returns>True if the object reference is null, otherwise false.</returns>
        public static bool ValidateCheckNullValue(Object thisObject, string fieldName, Object objectToCheck)
        {
            if (objectToCheck == null)
            {
                IboshDebugger.LogWarning($"{fieldName} is null and must contain a value in object {thisObject.name}", thisObject.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Yellow);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if an enumerable collection is empty or contains null values and logs a warning if true.
        /// </summary>
        /// <param name="thisObject">The object being validated.</param>
        /// <param name="fieldName">The name of the field being checked.</param>
        /// <param name="enumerableObjectToCheck">The enumerable collection to check.</param>
        /// <returns>True if the enumerable collection is empty or contains null values, otherwise false.</returns>
        public static bool ValidateCheckEnumerableValues(Object thisObject, string fieldName, IEnumerable enumerableObjectToCheck)
        {
            bool error = false;
            int count = 0;

            if (enumerableObjectToCheck == null)
            {
                IboshDebugger.LogWarning($"{fieldName} is null in object {thisObject.name}", thisObject.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Yellow);
                return true;
            }


            foreach (var item in enumerableObjectToCheck)
            {

                if (item == null)
                {
                    IboshDebugger.LogWarning($"{fieldName} has null values in object {thisObject.name}", thisObject.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Yellow);
                    error = true;
                }
                else
                {
                    count++;
                }
            }

            if (count == 0)
            {
                IboshDebugger.LogWarning($"{fieldName} has no values in object {thisObject.name}", thisObject.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Yellow);
                error = true;
            }

            return error;
        }

        /// <summary>
        /// Checks if an integer value is positive and logs a warning if false.
        /// </summary>
        /// <param name="thisObject">The object being validated.</param>
        /// <param name="fieldName">The name of the field being checked.</param>
        /// <param name="valueToCheck">The integer value to check for positivity.</param>
        /// <param name="isZeroAllowed">True if zero is an allowed value, otherwise false.</param>
        /// <returns>True if the integer value is not positive, otherwise false.</returns>
        public static bool ValidateCheckPositiveValue(Object thisObject, string fieldName, int valueToCheck, bool isZeroAllowed)
        {
            bool error = false;

            if (isZeroAllowed)
            {
                if (valueToCheck < 0)
                {
                    IboshDebugger.LogWarning($"{fieldName} must contain a positive value or zero in object {thisObject.name}", thisObject.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Yellow);
                    error = true;
                }
            }
            else
            {
                if (valueToCheck <= 0)
                {
                    IboshDebugger.LogWarning($"{fieldName} must contain a positive value in object {thisObject.name}", thisObject.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Yellow);
                    error = true;
                }
            }
            return error;
        }


        /// <summary>
        /// Checks if a float value is positive and logs a warning if false.
        /// </summary>
        /// <param name="thisObject">The object being validated.</param>
        /// <param name="fieldName">The name of the field being checked.</param>
        /// <param name="valueToCheck">The float value to check for positivity.</param>
        /// <param name="isZeroAllowed">True if zero is an allowed value, otherwise false.</param>
        /// <returns>True if the float value is not positive, otherwise false.</returns>
        public static bool ValidateCheckPositiveValue(Object thisObject, string fieldName, float valueToCheck, bool isZeroAllowed)
        {
            bool error = false;

            if (isZeroAllowed)
            {
                if (valueToCheck < 0)
                {
                    IboshDebugger.LogWarning($"{fieldName} must contain a positive value or zero in object {thisObject.name}", thisObject.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Yellow);
                    error = true;
                }
            }
            else
            {
                if (valueToCheck <= 0)
                {
                    IboshDebugger.LogWarning($"{fieldName} must contain a positive value in object {thisObject.name}", thisObject.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Yellow);
                    error = true;
                }
            }
            return error;
        }

        /// <summary>
        /// Checks if a range of values is positive and logs a warning if false.
        /// </summary>
        /// <param name="thisObject">The object being validated.</param>
        /// <param name="fieldNameMinimum">The name of the minimum field being checked.</param>
        /// <param name="valueToCheckMinimum">The minimum value to check for positivity.</param>
        /// <param name="fieldNameMaximum">The name of the maximum field being checked.</param>
        /// <param name="valueToCheckMaximum">The maximum value to check for positivity.</param>
        /// <param name="isZeroAllowed">True if zero is an allowed value, otherwise false.</param>
        /// <returns>True if the range is not positive, otherwise false.</returns>
        public static bool ValidateCheckPositiveRange(Object thisObject, string fieldNameMinimum, float valueToCheckMinimum, string fieldNameMaximum, float valueToCheckMaximum, bool isZeroAllowed)
        {
            bool error = false;

            if (valueToCheckMinimum > valueToCheckMaximum)
            {
                IboshDebugger.LogWarning($"{fieldNameMinimum} must be less than or equal to {fieldNameMaximum} in object {thisObject.name}", thisObject.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Yellow);
                error = true;
            }

            if (ValidateCheckPositiveValue(thisObject, fieldNameMinimum, valueToCheckMinimum, isZeroAllowed)) error = true;
            if (ValidateCheckPositiveValue(thisObject, fieldNameMaximum, valueToCheckMaximum, isZeroAllowed)) error = true;

            return error;
        }

        /// <summary>
        /// Checks if a range of values is positive and logs a warning if false.
        /// </summary>
        /// <param name="thisObject">The object being validated.</param>
        /// <param name="fieldNameMinimum">The name of the minimum field being checked.</param>
        /// <param name="valueToCheckMinimum">The minimum value to check for positivity.</param>
        /// <param name="fieldNameMaximum">The name of the maximum field being checked.</param>
        /// <param name="valueToCheckMaximum">The maximum value to check for positivity.</param>
        /// <param name="isZeroAllowed">True if zero is an allowed value, otherwise false.</param>
        /// <returns>True if the range is not positive, otherwise false.</returns>
        public static bool ValidateCheckPositiveRange(Object thisObject, string fieldNameMinimum, int valueToCheckMinimum, string fieldNameMaximum, int valueToCheckMaximum, bool isZeroAllowed)
        {
            bool error = false;

            if (valueToCheckMinimum > valueToCheckMaximum)
            {
                IboshDebugger.LogWarning($"{fieldNameMinimum} must be less than or equal to {fieldNameMaximum} in object {thisObject.name}", thisObject.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Yellow);
                error = true;
            }

            if (ValidateCheckPositiveValue(thisObject, fieldNameMinimum, valueToCheckMinimum, isZeroAllowed)) error = true;
            if (ValidateCheckPositiveValue(thisObject, fieldNameMaximum, valueToCheckMaximum, isZeroAllowed)) error = true;

            return error;
        }
    }
}
