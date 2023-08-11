# rom-repo
Storage Assistant and organizer for video game ROM libraries. 

## Purpose

Many people play video games by loading ROM files into an emulator, flashcart, or FPGA chip. One way to manage all the different ROM images for all the different systems is to configure a shared network folder and divide ROMs for each system into subfolders. This software is a minimalist, optional application layer between the end user and the network folder. Features will include a web UI for batch file transfers, automatic zipping and unzipping, search, and library statistics. 

## System Architecture
* Single Docker image - ASP.NET Core provided by Microsoft
* Storage volume for SQLite database, backups, metadata and system files
* .NET sln 
    * Asp.net project
        * Primary UI
        * Bootstrap css
        * Blazor wasm
        * Vue.js or Arrow.js as needed
        * Upload/download functionality
    * Console project
        * Hosted as service
        * Monitors file system
        * Builds queue of file changes to process in worker thread
    * Class library
        * All db access via EF
        * Process file queue
        * Calculate stats
        * Search engine processing


---
### Analytics Disclaimer
If you choose to share analytics, we may periodically collect information from your SQLite database. We will never upload or inspect your rom files. We do not have the ability or inclination to determine the legal status of your files. Please obey all applicable copyright laws in your area.