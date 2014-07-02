echo "Dropping NGL Database..."
sqlcmd -Q "DROP DATABASE NGL;"

echo "Creating NGL Database..."
sqlcmd -Q "CREATE DATABASE NGL;"

PAUSE
