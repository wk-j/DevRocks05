
Task("Run-Test")
    .IsDependentOn("Build")
    .Does(() => {
        StartProcess("nunit-console", new ProcessSettings {
            Arguments = "DevRocks05.App.UnitTests/bin/Debug/DevRocks05.App.UnitTests.dll"
        });
    });

Task("Build").Does(() => {
    XBuild("DevRocks05.sln");
});

var target = Argument("target", "Run-Test");
RunTarget(target);