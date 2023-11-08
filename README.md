```
 _____                 _____                  
|  __ \               |  __ \                 
| |__) |___  _ __ ___ | |__) |___ _ __   ___  
|  _  // _ \| '_ ` _ \|  _  // _ \ '_ \ / _ \ 
| | \ \ (_) | | | | | | | \ \  __/ |_) | (_) |
|_|  \_\___/|_| |_| |_|_|  \_\___| .__/ \___/ 
                                 | |          
          repo for roms          |_|          
----------------------------------------------
```

Software for retro video game [ROM](https://en.wikipedia.org/wiki/ROM_image) libraries

* Manage your game library through a web UI or directly in your local filesystem
* Organize your cheat codes, save files, screenshots, and manuals
* Easily find ports, alternate versions, and sequels across your systems
* Zip/unzip/convert files
* Turn on analytics to discover hidden gems you may be overlooking
* Validate checksums and titles against the No-Intro DAT-o-Matic database

## System Architecture
* Items to install by user:
  * RomRepo.service
    * Background service that keeps an eye on the filesystem
    * API endpoints for the UI
    * SQLite database
  * RomRepo.web
    * Standard UI for RomRepo.service
* Items hosted on RomRepo.com:
  * RomRepo.com
    * Project home page
    * API key request form
  * RomRepo.api
    * Optional API endpoints for the DAT-o-Matic database
    * Optional API endpoints for (opt-in) analytics

---
### Analytics Disclaimer
If you choose to share analytics, we may periodically collect information from your SQLite database. We will never upload or inspect your rom files. We do not have the ability or inclination to determine the legal status of your files. Please obey all applicable copyright laws in your area.
