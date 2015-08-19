using System;

namespace Substitutor
{
    [Serializable]
    public class Snippet
    {
        public string Command { get; set; }
        public string SubtitutorTitle { get; set; }
        public string ExtraArgs { get; set; }
    }
}