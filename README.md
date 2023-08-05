# rom-repo
Storage Assistant and organizer for video game ROM libraries. 

## Technical Overview
* Intended to be self-hosted on each user's local network
* Written in modern C# .NET
* Backend storage either SQLite or MongoDB
* Bootstrap for UI
* Blazor on the frontend with Vue.js as needed
* No built-in security

## Feature List
* Option for password protected or open folders
* Filesystem as source of truth -- add ROMs to folders and the app will find them
* Define preferred and alternate file formats for usage
* Define preferred emulation software for each folder
* Can convert .7z to .zip, unzip after upload, etc.
* Metadata storage (passwords, cheats, etc.)

## Usage Overview
* 
