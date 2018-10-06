REM - This file assumes that you have access to the application and that you have docker installed
REM : Setup your applications name below
SET APP_NAME="perpetualshred"

dotnet clean --configuration Release
dotnet publish -c Release
copy Dockerfile .\bin\Release\netcoreapp2.0\publish\
cd .\bin\Release\netcoreapp2.0\publish\
heroku container:push web -a %APP_NAME%
heroku container:release web -a %APP_NAME%