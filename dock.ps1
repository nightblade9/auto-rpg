$ErrorActionPreference = "Stop"

docker build -t autorpg AutoRpg.Web
docker run -d -p 8001:80 -ti autorpg sh