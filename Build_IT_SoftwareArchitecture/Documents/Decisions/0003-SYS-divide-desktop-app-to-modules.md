# ADR divide desktop app to modules

Build into Prism library possibility to divide views into a different modules is worth to consider

* **Issue**: Hard to maintain one big module of an application.

* **Decision**: Keep small modules as a containers for functionalities.

* **Status**: Done.

* **Group**: Versioning.

* **Assumptions**: Could be done easily.

* **Constraints**: None.

* **Positions**: Keep one big module.

* **Argument**: It is better to have it as several smaller modules in terms of readability and future work.

* **Implications**: .Net Core 3.0 not allows to create Class libraries for WPF stuff.

* **Related decisions**: Create libraries as WPF apps and then change their types.

* **Related requirements**: None.

* **Related artifacts**: None.

* **Related principles**: None.

* **Date**: 2019-10-08

* **Notes**: None.