# cset-analytics

## Environment File

When deploying to another environment, credentials other than the default local credentials should be used. Alter the values in .env for the desired environment.

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
