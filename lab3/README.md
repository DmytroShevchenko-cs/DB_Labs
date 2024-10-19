# Before run a docker compose you must:

-edit `docker-compose.yml` (Change a props for connecting to postgres)
-edit `appsettings.json` (Change a connection string to db using props from docker-compose file)

# Run
1. Open project in terminal and use `docker-compose build` command for build the project
2. Use `docker-compose up -d` command for startting up a docker containers
3. Use `docker-compose run --rm app` or `docker-compose exec app /bin/sh -c "dotnet lab3.dll"` to run an only .net console app with posibility of input request

# Commands
```
docker-compose build
```
```
docker-compose up -d
```
```
docker-compose run --rm app

docker-compose exec app /bin/sh -c "dotnet lab3.dll"
```
