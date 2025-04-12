namespace RomRepo.api.Models.NotMapped
{
    /// <summary>Non-mapped object to hold API Key and Key Status</summary>
    public class ApiKeyValueStatus
    {
        /// <summary>API Key</summary>
        public string Key {  get; set; }

        /// <summary>
        /// Status code for the API Key; see <see cref="ApiKeyStatus"/>
        /// </summary>
        public int Status { get; set; }
    }
}
