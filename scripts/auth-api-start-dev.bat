@echo off

echo Started

SET currentPath=%~dp0
SET authPath=%~dp0..\backend\HashtagAggregatorIdentity

setx ASPNETCORE_ENVIRONMENT dev

cd %authPath%

echo %authPath%

dotnet run --no-launch-profile

cd %currentPath%

echo Finished


