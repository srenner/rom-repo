# rom-repo

Software for [retro video game ROM libraries](https://en.wikipedia.org/wiki/ROM_image)

* Browse your game collection in a web UI
* Manage your library through the web UI or directly in your local filesystem
* Organize your cheat codes, save files, screenshots, and manuals
* Easily find ports, alternate versions, and sequels across your systems
* Zip/unzip/convert files
* Turn on analytics to discover hidden gems you may be overlooking

## System Architecture
* Project runs in Docker
  * ASP.NET Blazor Wasm project
  * Console project
    * Runs as service
    * Monitors file system
    * Exchanges info with ASP.NET project via gRPC calls
  * Storage volume for SQLite database, backups, metadata and system files

---
### Analytics Disclaimer
If you choose to share analytics, we may periodically collect information from your SQLite database. We will never upload or inspect your rom files. We do not have the ability or inclination to determine the legal status of your files. Please obey all applicable copyright laws in your area.
