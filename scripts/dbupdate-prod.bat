@echo off

echo Started

SET currentPath=%~dp0
SET authPath=%~dp0..\backend\HashtagAggregatorIdentity

cd %authPath%

echo %authPath%

dotnet ef database update -e prod -c SqlIdentityDbContext
dotnet ef database update -e prod -c PersistedGrantDbContext
dotnet ef database update -e prod -c ConfigurationDbContext

cd %currentPath%

echo Finished

