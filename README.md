# Description

A simple web app `i.e., angularapp` containing a form for users to enter their names. When the user submits the form, the form data will be sent to a backend service `i.e., webapi` to save to a file in json format.

# Requirements

For windows machine:

- [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [Node.js v16+](https://nodejs.org/en/)
- [Angular CLI v15+](https://angular.io/cli#installing-angular-cli)

# Run projects locally

## webapi

On terminal 1:
 
 1. Restore `dotnet restore`
 2. Build `dotnet build`
 3. Run `dotnet run --launch-profile https`

Application will be available on https://localhost:7294 and swagger on https://localhost:7294/swagger

For tests, go to `webapi.tests` project and run `dotnet test`

## angularapp

On terminal 2:

 1. Install `npm install`
 2. Build `npm run build`
 3. Run `npm run start`

Application will be available on https://localhost:4200

For tests, run `npm run test`

> The `/src/proxy.config.js` is targeting https://localhost:7294. If you changed your webapi port, then make sure to update the target in proxy.config.js
