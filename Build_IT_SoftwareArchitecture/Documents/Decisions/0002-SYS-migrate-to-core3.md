# ADR migrate to .net core 3.0

Due to the release of new version of .net core I decided to move to the newest version of it.

* **Issue**: Be up to date with the newest solutions.

* **Decision**: Migrate to the newest version of .net core.

* **Status**: Done.

* **Group**: Versioning.

* **Assumptions**: Could be done easily.

* **Constraints**: None.

* **Positions**: Stay at 2.2.

* **Argument**: It is better to have it as new as possible. In order to develop better skills at the newest technologies.

* **Implications**: Not everything work after migration.

* **Related decisions**: Rewrite Build_IT_Web project.

* **Related requirements**: Rewrite Build_IT_Web project.

* **Related artifacts**: None.

* **Related principles**: None.

* **Date**: 2019-09-26

* **Notes**: Project become fixed on some non existing NUnit tests (it was pointing to old folder for .netCore 2.2). 
Solution for that was to go back with the changes and after that remove old tests and go back to the newest .netCore 3.0.