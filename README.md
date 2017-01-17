# ember-asp-core-integration
A basic project that serves an Ember application with an ASP Core back-end.

# Description

The project can be used as scaffolding / inspiration on how to integrate a `ASP Core` back-end with an `EmberJS` front-end.

It is built in such a way that both the `front-end` and `back-end` projects can evolve in separate ways but can be deployed together.

The best way to continue development is to run the 2 projects separately, each with it's own runner. This way you can enjoy Ember's `auto-reload` (and maybe `dotnet watch` too).

## The `Ember` project

The Ember project can be run using the default `ember serve` command. Because we use the `back-end` as an API we need to proxy all of Ember Data calls to the right endpoint.
You can do this by running: 

> ember serve --proxy http://localhost:55555

Where `localhost:55555` is the location where the `back-end` server runs.

You can also modify the `package.json > scripts > start` script by editing the `back-end` endpoint then run:

> npm start

## The `ASP Core` project

The backend project is a *plain-MVC* project which serves `Razor` views. 
Apart from those, the project has an `App` controller, with a default `GET` action which serves the contents of `dist/index.html` from the Ember project.

You can run the project using `Visual Studio` build, or the `dotnet` command line interface.

The most important parts of the integration from a backend perspective are found inside these items:
 - `project.json`
 - `Startup.cs`

 ## Development environment

Inside the `project.json` file, both the `buildOptions` and  `publishOptions` sections copy the contents of the `frontend` project to the output folder.

```json
"buildOptions": {
  [...]
  "copyToOutput": {
    "mappings": {
      "dist/": {
        "include": [ "../ember-asp-test-front-end/dist/**/*", "wwwroot/**/*" ]
      }
    }
  }
}
```

Because in `development` environment we can only output items in the `bin/debug` folder (the standard build output) we need a way to have the rest of the
backend static files available at their default path as well. That's why we need to not only copy the `Ember/dist` folder to output but the contents of `wwwroot` as well.

Now, in order to actually serve the static files from the `bin/debug` folder we need to instruct the `StaticFiles` middleware to do so in `development`.
This is done inside the `Startup.cs > Configure()`:

```cs
if (env.IsDevelopment())
{
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, @"bin\Debug\netcoreapp1.0\dist"))
    });
}
```
## Production environment

When deploying the ASP project we use the `dotnet publish` CLI command. This builds the projects and all of it's dependencies in a distributable package.
The following instructs the `publish` process to copy the `Ember/dist` files inside the `wwwroot` folder, to be served as static assets.

```json
"publishOptions": {
  [...]
  "mappings": {
    "wwwroot/": "../ember-asp-test-front-end/dist/**/*"
  }
}
```

Note:
 - the ASP Core project reloads the Ember `dist` contents only on `Build`. This is why it's recommended to run/develop the Ember project separately.
 - the Ember's project `location` type is set to `hash` to avoid routing conflicts between frontend and backend
 - the `frontend` project must be alongside the `backend` project because we need to get to it in a relative manner. Make sure to rename the `../ember-asp-test-front-end`
 paths inside the `project.json` file if your `frontend` solution has a different name or path.