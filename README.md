# cset-analytics

## Environment File

The local.env file has credentials for local development. Copy that file to a .env file and make any necessary changes.

## Visual Studio Debugging

To debug with visual studio, make sure that the docker containers are all stopped. Run the following command in order to bring up a postgres docker container for debugging purposes.

```bash
# Starting posgres container
docker run --name cset-analytics-vs-postgres -e POSTGRES_PASSWORD=LocalUserPassword123! -e POSTGRES_USER=local_user -p 5432:5432 -d postgres

# Stopping postgres container
docker stop cset-analytics-vs-postgres

# Remove postgres container
docker rm cset-analytics-vs-postgres
```

## Running Docker

```bash
# Build Docker Image
docker-compose build

# Create and Start Containers
docker-compose up

# Remove containers
docker-compose down

# Stop or Restart Containers
docker-compose stop
docker-compose restart

# Test docker container
curl https://localhost:44397/api/ping/GetPing --insecure --verbose

# Open CLI for API container
docker exec -it cset-analytics-api bash

# psql Postgres Container
docker exec -it cset-analytics-postgres psql -U inl_user -d CsetAnalytics

# Inspect Postgres Docker Volume
docker volume inspect cset-analytics_pgdata

# Remove Postgres Docker Volume (For resetting database)
docker volume rm cset-analytics_pgdata
```
