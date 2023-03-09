# Description

A simple web app containing a form for users to submit their names. A backend service will save the name to a file in json format.

# Requirements

For windows machine:

- [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [Node.js v16+](https://nodejs.org/en/)
- [Angular CLI v15+](https://angular.io/cli#installing-angular-cli)

# Run projects locally

## webapi

1. Restore `dotnet restore`
2. Build `dotnet build`
3. Run `dotnet run --launch-profile https`

Application will be available on https://localhost:7294 and swagger is on https://localhost:7294/swagger

For tests, go to `webapi.tests` project and run `dotnet test`

## angularapp

1. Install `npm install`
2. Build `npm run build`
3. Run `npm run start`

Application will be available on https://localhost:4200

For tests, run `npm run test`

> The `/src/proxy.config.js` is targeting https://localhost:7294. If you changed your webapi port, then make sure to update the target in proxy.config.js
