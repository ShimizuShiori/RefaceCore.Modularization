# About RefaceCore.Modularization


## Abstraction

This is a free , open source DotNetCore infrastucture that suppots **modularization** .

**Modularization** means you could split your WHOLE application into several **Litter** , **Small** , **Lite** modules . And you need a StartModule as the Enter of the application . 

StartModule will depend on it's child modules .
And more the child modules have their own child modules .

It will scann all the modules when Application is starting .



You could download this package from [Nuget](https://www.nuget.org/packages/RefaceCore.Modularization/) .

## Examples

* [QuickStart](https://github.com/ShimizuShiori/RefaceCore.Modularization/tree/main/Examples/01%20-%20QuickStarter) - This example show how to start a application by **RefaceCore.Modularization** and it can register component into IOC-Container automatically . 
