# About RefaceCore.Modularization


## Abstraction

This is a free , open source DotNetCore infrastucture that suppots **modularization** .

**Modularization** means you could split your WHOLE application into several **Litter** , **Small** , **Lite** modules . And you need a StartModule as a entrance of the application . 

StartModule will depend on it's child modules .
And more the child modules have their own child modules .

It will scann all the modules when Application is starting .

**RefaceCore.Modularization** can not only ogranize modules and scan components , but also provide the following features :
* Automaticlly map configurations to class Automaticlly
* Easily define AOP
* Easily define **DynamicImplementor**

**DynamicImplementor** means you can use a *interface* without any implementor , **DynamicImplementor** like a filter , dynamically execute the process when you invoke any method on this *interface* .

You could download this package from [Nuget](https://www.nuget.org/packages/RefaceCore.Modularization/) .

## Examples

* [QuickStart](https://github.com/ShimizuShiori/RefaceCore.Modularization/tree/main/Examples/01%20-%20QuickStarter) - This example show how to start a application by **RefaceCore.Modularization** and it can register component into IOC-Container automatically . 
