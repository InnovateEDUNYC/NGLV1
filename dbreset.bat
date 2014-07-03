@echo off

echo Kill IIS EXPRESS
taskkill /IM IISEXPRESS*

echo "Dropping NGL Database..."
SqlCmd -Q "ALTER DATABASE [NGL] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE"

sqlcmd -Q "DROP DATABASE NGL;"

echo "Creating NGL Database..."
sqlcmd -Q "CREATE DATABASE NGL;"

PAUSE
