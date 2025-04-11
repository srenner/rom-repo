namespace RomRepo.api
{
    /// <summary>
    /// Enum status code for API key
    /// </summary>
    public enum ApiKeyStatus
    {
        Pending     = 1,
        Active      = 2,
        Inactive    = 3,
        Unknown     = 4
    }

    /// <summary>
    /// Enum
    /// </summary>
    public enum ChecksumType
    {
        CRC     = 1,
        MD5     = 2,
        SHA1    = 3,
        SHA256  = 4,
    }
}
