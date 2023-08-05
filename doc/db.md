# Database Design

## Table: Core
| Col      | Type       |
| ---      | ---        |
| CoreID   | int seq pk |
| Name     | char       |
| PathRoot | char       |

## Table: Emulator
| Col        | Type       |
| ---        | ---        |
| EmulatorID | int seq pk |
| CoreID     | int fk     |
| Name       | char       |
| PathRoot   | char       |
| Link       | char       |
| IsFavorite | bit        |

## Table: RomImage
| Col        | Type       |
| ---        | ---        |
| RomImageID | int seq pk |
| CoreID     | int fk     |
| Name       | char       |
| Path       | char       |
| IsFavorite | bit        |
