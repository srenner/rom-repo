namespace RomRepo.api
{
    public enum ApiKeyStatus
    {
        Pending     = 1,
        Active      = 2,
        Inactive    = 3,
        Unknown     = 4


    }

    public enum ChecksumType
    {
        CRC     = 1,
        MD5     = 2,
        SHA1    = 3,
        SHA256  = 4,
    }
}
