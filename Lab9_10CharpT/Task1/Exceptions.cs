public class MusicCdNotExists : Exception
{
    public MusicCdNotExists(string message = "") : base(message) { }
}

public class SoundNotExists : Exception
{
    public SoundNotExists(string message = "") : base(message) { }
}