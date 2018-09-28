run:
	docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=d12DSAd12312edsadASDada@!' -e 'MSSQL_PID=Express' -p 1433:1433 -d microsoft/mssql-server-linux:latest
