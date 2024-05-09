# RomRepo.api

Server hosted API.

### Dat-o-Matic endpoints
* Rom title and checksum info.
* Data is sourced with permission from the No-Intro DAT-o-Matic daily XML dump.

### Analytics endpoints
* Sends and receives opt-in analytics about how the software is being used.

#### Example docker run command

```
docker run --user=root --rm -it -p 80:8080 -p 443:8081 --env=ASPNETCORE_HTTPS_PORTS=8081 --env=ASPNETCORE_HTTP_PORTS=8080 -e ASPNETCORE_URLS="https://+:8081;http://+:8080" -e ASPNETCORE_Kestrel__Certificates__Default__Password="PASSWORD" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx --volume=C:\Users\USER\AppData\Roaming/ASP.NET/Https:/home/app/.aspnet/https:ro -v c:\users\USER\.aspnet\https:/https/ --mount source=vol_db_api,target=/db_api shawnrenner/romrepoapi:latest
```
