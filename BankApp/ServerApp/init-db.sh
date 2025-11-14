#!/bin/bash
echo "Waiting for SQL Server to start..."

until /opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P 11223344Aa. -Q "SELECT 1" > /dev/null 2>&1
do
  echo "Waiting for SQL Server..."
  sleep 5
done

echo "SQL Server is up. Starting database restore..."

/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P 11223344Aa. -Q "
IF DB_ID('BankAppDB') IS NULL
BEGIN
    RESTORE DATABASE [BankAppDB]
    FROM DISK = '/var/opt/mssql/backup/BankAppDB.bak'
    WITH MOVE 'BankAppDB' TO '/var/opt/mssql/data/BankAppDB.mdf',
         MOVE 'BankAppDB_log' TO '/var/opt/mssql/data/BankAppDB_log.ldf',
         REPLACE;
END
"

echo "Database restore completed."
