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

RomRepo is a software package that provides tools for your retro video game rom library. It installs on your home network as a Docker container. 

# Features

Automatic Checksum Validation
---
  |  Benefit | Example |
  | ---      | ---     |
  | Alerts user if they are using non-genuine, altered, or corrupted roms. | The user adds a legally obtained rom to their rom library. If there was a subtle error in the cartridge ripping or file downloading process, the checksum mismatch will alert the user to a potential problem.

Automatic Filename Validation 
---
  |  Benefit | Example |
  | ---      | ---     |
  | Helps the user stay organized by suggesting filename updates based on community standards. | The user adds a legally obtained Super Mario World rom named `smw.sfc`. Using checksum validation, the system will suggest a rename to `Super Mario World (USA).sfc` to match established community standards.

Rom Unpacker
---
  |  Benefit | Example |
  | ---      | ---     |
  | Unzips a collection of zipped roms in a single command. | Most SNES rom libraries are stored as a collection of zip files. This approach optimizes for storage space, but some devices such as the Analogue Pocket require unzipped roms. Use the rom unpacker to download an unzipped collection to transfer to your device.

---
**Features coming soon:**
- Game manual uploader/viewer
- Cheat code manager
- Game save manager
- Library statistics


---
### Analytics Disclaimer
If you choose to share analytics, we may periodically collect information from your SQLite database. We will never upload or inspect your rom files. We do not have the ability or inclination to determine the legal status of your files. Please obey all applicable copyright laws in your area.
