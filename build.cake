
Task("Run-Test").Does(() => {
    StartProcess("nunit-console", new ProcessSettings {
        Arguments = "DevRocks05.App.UnitTests/bin/Debug/DevRocks05.App.UnitTests.dll"
    });
});

var target = Argument("target", "Run-Test");
RunTarget(target);