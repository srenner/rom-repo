Related Architecture
---
* Service is running in Docker container with API exposed
  * Initial settings accessible from service command line or web
* Website is running in Docker container

User Workflow
---
* Ping Service API on page load, prompt user if fail
* Website loads to Core view
  * Card view
	* List favorites first
	* Card basic view
	  * Core name
	  * Wallpaper?
	  * Rom count
	  * Disk usage
	* Card actions
	  * Discover (find folders the FileSystemWatcher missed)
	  * Edit name
	  * Set ZipAsRom
	  * Set SevenZipAsRom
	  * Favorite star
	  * Archive

* Click core to view roms
  * Do patched roms list separate or under parent rom?
* Click to select rom - open modal
  * Zip, unzip, download, upload(replace), view checksum and title verification
  * View related files (manual?)
  * View related roms in other cores
  * View patched versions
