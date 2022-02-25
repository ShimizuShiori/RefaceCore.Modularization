# About RefaceCore.Modularization


## Abstraction

This is a free , open source DotNetCore infrastucture that suppots **modularization** .

**Modularization** means you could split your WHOLE application into several **Little** , **Small** , **Lite** modules . And you need a StartModule as a entrance of the application . 

StartModule will depend on it's child modules .
Even the child modules have their own child modules .

It will scann all the modules when Application is starting .

**RefaceCore.Modularization** can not only ogranize modules , but also provide the following features :
* Scan components and register thier to IOC-Container
* Automaticlly map configurations to class Automaticlly
* Easily define AOP
* Easily define **DynamicImplementor**

**DynamicImplementor** means you can use a *interface* without any implementor , **DynamicImplementor** like a filter , dynamically execute the process when you invoke any method on this *interface* .

You could download this package from [Nuget](https://www.nuget.org/packages/RefaceCore.Modularization/) .

---

More informations please see [wiki](https://github.com/ShimizuShiori/RefaceCore.Modularization/wiki)