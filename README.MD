.NET 8 function app with AOT publishing enabled.

### To run AOT published version:

1. Use the worker packages from this branch: https://github.com/Azure/azure-functions-dotnet-worker/tree/shkr/aot_for-net8. 
[This build](https://azfunc.visualstudio.com/Azure%20Functions/_build/results?buildId=120803&view=results) was using that build and you may use those artifacts. 

2. Set up a local nuget source and drop the packages from above step.

3. Open this function app in VS, go to manage nuget packages and select the local nuget source and update to the packages from above step.

4. To publish AOT output, open a cmd prompt in the function app root (where you will see the .csproj file) and run `dotnet publish -r win-x64 -c release`. This will generate the publish output in "Net8AOTFunctionApp\bin\release\net8.0\win-x64\publish" directory.

5. Open `workerconfig.json` from the publish directory and update the value of `defaultWorkerPath` property from `Net8AOTFunctionApp.dll` to `Net8AOTFunctionApp.exe`

Now this payload is good to be deployed.