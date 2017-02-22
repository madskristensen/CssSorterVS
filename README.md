# CSS Sorter

[![Build status](https://ci.appveyor.com/api/projects/status/qpgnlho3cps0f7qs?svg=true)](https://ci.appveyor.com/project/madskristensen/csssortervs)

Download this extension from the [Marketplace](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.CSSSorter)
or get the [CI build](http://vsixgallery.com/extension/87534672-5a41-4ea1-a145-17f1a8f5502a/).

---------------------------------------

Sort CSS properties easily for better readibility and GZIP compression

See the [change log](CHANGELOG.md) for changes and road map.

## Features

- Sorts CSS properties
- Uses [CSS Declaration Sorter](https://github.com/ben-eb/css-declaration-sorter) node module under the hood

### Sort properties
This extension calls the [CSS Declaration Sorter](https://github.com/ben-eb/css-declaration-sorter) node module behind the scenes to perform the property sorting.


Invoke the command from the context menu in the CSS editor.

![Context Menu](art/context-menu.png)

## Contribute
Check out the [contribution guidelines](.github/CONTRIBUTING.md)
if you want to contribute to this project.

For cloning and building this project yourself, make sure
to install the
[Extensibility Tools 2015](https://visualstudiogallery.msdn.microsoft.com/ab39a092-1343-46e2-b0f1-6a3f91155aa6)
extension for Visual Studio which enables some features
used by this project.

## License
[Apache 2.0](LICENSE)