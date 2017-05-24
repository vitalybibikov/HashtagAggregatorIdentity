@echo off

echo Started

SET currentPath=%~dp0
SET authPath=%~dp0..\backend\HashtagAggregatorIdentity

cd %authPath%

echo %authPath%

dotnet ef database update -e dev -c SqlIdentityDbContext
dotnet ef database update -e dev -c PersistedGrantDbContext
dotnet ef database update -e dev -c ConfigurationDbContext

cd %currentPath%

echo Finished

