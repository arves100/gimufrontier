namespace gimufrontier.Models
{
    public record MSTVersion
    {
        public string Name = "";

        public string Description = "";

        public uint Version;

        public uint Unknown;

        public uint SubVersion;
    }

    public record MSTVersionCfg
    {
        public MSTVersion[]? MSTs;
    }
}
