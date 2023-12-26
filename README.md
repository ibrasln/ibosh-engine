# ibosh-engine

# Custom Debugger
## Overview
 This toolset provides you with a range of features to simplify and improve your debugging process, making your Unity projects more efficient and maintainable.

## Features
**- Colorful Debug Messages:** Make your debug messages stand out by adding vibrant colors to them. Ibosh Custom Debugger offers a variety of colors to choose from, allowing you to visually differentiate your logs.

**- Custom Headers:** Organize your debug output effectively by using custom headers for your log messages. Clearly label and categorize your debug information to maintain clarity in your project.

**- Debug Validation:** Ensure your code runs smoothly with the built-in validation methods. Use these tools during Unity's OnValidate() phase to identify and fix common issues early in development.

**- Streamlined Debugging:** Simplify your debugging workflow with easy-to-use methods for logging messages, errors, and warnings. It helps you debug efficiently and effectively, speeding up your development process.

**- Conditional Debugging:** Control when your debug messages appear by leveraging Unity's isDebugBuild option. Messages are displayed only when needed, reducing clutter and distractions during development.


# Singleton
## Overview
 This is a versatile Unity component that simplifies the creation of singleton objects. Singletons are often used to manage resources or services that should have only one instance throughout the lifetime of your game. With this component, you can easily create singletons for various purposes in your Unity project.

## Features
**- Easy Singleton Creation:** It provides a straightforward way to create singletons for your MonoBehaviours. Simply inherit from IboshSingleton<T> and let the component handle the rest.

**- Singleton Enforcement:** It ensures that only one instance of the specified MonoBehaviour type exists at any given time. If multiple instances are detected, it logs an error message and destroys the extra instances, keeping your project clean and efficient.

## Example
<img src="https://github.com/ibrasln/ibosh-engine/assets/75907428/8898311c-90bd-417f-bfe4-ca6bf847e184" alt="image" width="75%" height="450">

# Object Pool
## Overview
 It is a utility class that simplifies the management and reuse of GameObjects, providing an efficient way to handle frequently created and destroyed objects. Object pooling helps reduce the performance overhead associated with instantiating and destroying objects, making it a valuable tool for optimizing your Unity projects.

## Features
**- Efficient Object Reuse:** It allows you to create a pool of GameObjects and efficiently reuse them as needed, eliminating the performance cost of frequent object instantiation and destruction.

**- Customizable Pool Size:** You can define the initial pool size and dynamically adjust it based on your project's requirements.

**- Automatic Pool Filling:** It automatically fills the pool with objects up to the specified initial size, ensuring that you always have a ready supply of objects to use.

**- Integration Flexibility:** It is designed to work with any GameObject-based components, offering flexibility in integrating it with various parts of your Unity project.

## Example
<img src="https://github.com/ibrasln/ibosh-engine/assets/75907428/fd2118d5-7884-47fa-9940-3b6c40a7300c" alt="image" width="75%" height="auto">
<img src="https://github.com/ibrasln/ibosh-engine/assets/75907428/ff3e40d0-34f6-41ab-af17-65067daffd51" alt="image" width="75%" height="auto">

# Validation Utilities
## Overview
 It is a collection of handy validation methods designed to help you perform common validation checks in your Unity projects. These utilities are especially useful during development to ensure your project's data and components meet the expected criteria.

## Features
**- Check for Empty Strings:** Validate if a given string is empty and log a warning if it is. Helps you avoid issues related to missing or invalid string data.

**- Check for Null Values:** Verify if an object reference is null and provide a warning message if it is. Useful for ensuring that critical references are properly assigned.

**- Validate Enumerable Values:** Ensure that an enumerable collection (e.g., lists, arrays) does not contain null values and is not empty. Detect issues early when working with collections.

**- Positive Value Validation:** Check if an integer or float value is positive (greater than zero) and log a warning if not. Optionally, allow zero values if needed.

**- Positive Range Validation:** Validate a range of float or integer values, ensuring that the minimum value is less than or equal to the maximum value. Log warnings for any inconsistencies.

## Example

### First Usage
 It can be used on OnValidate() method of Unity. Everytime you take an action on the inspector window of a script, OnValidate() executes. Consequently, our validation methods execute.
<img src="https://github.com/ibrasln/ibosh-engine/assets/75907428/1a75c0c6-fd42-43da-854a-15527b5920bb" alt="image" width="75%" height="auto">
<img src="https://github.com/ibrasln/ibosh-engine/assets/75907428/45e1337f-8b74-48f5-8810-2e4bc88fd3dc" alt="image" width="75%" height="auto">
<img src="https://github.com/ibrasln/ibosh-engine/assets/75907428/77dd9ee9-574b-431b-9370-b77b9f7eebe2" alt="image" width="75%" height="auto">

### Second usage
 It can be used on Start() method of Unity. If you forget the populate a variable, these methods execute on the Start() function, and populate the empty variables. **NOTE: The prefab should exist in the Resources folder.**
<img src="https://github.com/ibrasln/ibosh-engine/assets/75907428/5ee656ce-27bf-44b2-8a6c-1a746e6b516c" alt="image" width="75%" height="auto">
<img src="https://github.com/ibrasln/ibosh-engine/assets/75907428/4bfd45cb-e2b5-41a8-a1d1-8be181234d8e" alt="image" width="75%" height="auto">
<img src="https://github.com/ibrasln/ibosh-engine/assets/75907428/aa6bdaa0-9899-4193-8245-fbc80d2e001c" alt="image" width="75%" height="auto"> 
