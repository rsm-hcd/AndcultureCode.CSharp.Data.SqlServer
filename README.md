# AndcultureCode.CSharp.Data.SqlServer
![build status](https://github.com/AndcultureCode/AndcultureCode.CSharp.Data.SqlServer/actions/workflows/build.yaml/badge.svg)
[![codecov](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Data.SqlServer/branch/main/graph/badge.svg)](https://codecov.io/gh/AndcultureCode/AndcultureCode.CSharp.Data.SqlServer)<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-2-orange.svg?style=flat-square)](#contributors-)
<!-- ALL-CONTRIBUTORS-BADGE:END -->
Infrastructure layer's SQL Server specific package.

## Getting Started
This package is installed via NuGet
```
dotnet add [<PROJECT>] package AndcultureCode.CSharp.Data.SqlServer
```

## Documentation

[Full API Documentation](src/AndcultureCode.CSharp.Data.SqlServer/AndcultureCode.CSharp.Data.SqlServer.md)


## Development Setup

* Install Dotnet Core 2.x
* Install the `and-cli` tooling found at [AndcultureCode.Cli](https://github.com/AndcultureCode/AndcultureCode.Cli)

Below are a few basics to get you started, but there are many more commands and options for managing this and other projects found in the `and-cli`.

### Building project
* Run the build command
    ```
    and-cli dotnet --build
    ```

### Running tests along with code coverage
* Run the test command
    ```
    and-cli dotnet-test
    ```
* Open the `coverage/index.htm` file in your browser

### Publishing a new version
* Run the publish command with the next version number ([See semver package versioning](https://docs.microsoft.com/en-us/nuget/concepts/package-versioning))
    ```
    and-cli nuget --publish <version>
    ```

Contributing
======

Information on contributing to this repo is in the [Contributing Guide](CONTRIBUTING.md)

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="https://github.com/Stefanie899"><img src="https://avatars.githubusercontent.com/u/37462028?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Stefanie Leitch</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Data.SqlServer/commits?author=Stefanie899" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Data.SqlServer/commits?author=Stefanie899" title="Documentation">📖</a></td>
    <td align="center"><a href="https://winton.me"><img src="https://avatars.githubusercontent.com/u/48424?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Winton DeShong</b></sub></a><br /><a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Data.SqlServer/commits?author=wintondeshong" title="Code">💻</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Data.SqlServer/commits?author=wintondeshong" title="Tests">⚠️</a> <a href="https://github.com/AndcultureCode/AndcultureCode.CSharp.Data.SqlServer/commits?author=wintondeshong" title="Documentation">📖</a></td>
  </tr>
</table>

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!
