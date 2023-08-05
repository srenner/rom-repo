# rom-repo
Storage Assistant and organizer for video game ROM libraries. 

## Purpose

Many people play video games by loading ROM files into an emulator, flashcart, or FPGA chip. One way to manage all the different ROM images for all the different systems is to configure a shared network folder and divide ROMs for each system into subfolders. This software is a minimalist, optional application layer between the end user and the network folder. Features will include a web UI for batch file transfers, automatic zipping and unzipping, search, and library statistics. 

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
