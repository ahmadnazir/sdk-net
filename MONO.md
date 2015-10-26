# COMPILE on Linux

## Docker container
```
docker run -it --rm -w '/shared' -v `pwd`:'/shared' penneo/mono /bin/bash
```

## Dependencies
```
nuget install Src/Penneo/packages.config -o Src/packages
nuget install Src/PenneoTests/packages.config -o Src/packages
```

## Compile
```
xbuild Src/Penneo.sln
```

## Running Unit Tests
```
mono /opt/NUnit-2.6.4/bin/nunit-console.exe Src/PenneoTests/bin/Debug/PenneoTests.dll 
```

## Other notes

There is a PostBuildEvent in the `Penneo.csproj` that contains a
windows specific shell command. I had to temporary change `rem copy
/Y` to `cp` for the target to pass successfully.
