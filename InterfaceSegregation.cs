/// <summary>
/// Violate ISP
/// </summary>
public interface IMediaPlayer
{
    void PlayAudio();
    void PlayVideo();
    void DisplaySubtitles();
    void LoadMedia(string filePath);
}
public class AudioPlayer : IMediaPlayer
{
    public void PlayAudio()
    {
        Code to play audio
    }
    public void PlayVideo()
    {
        throw new NotImplementedException("Audio players cannot play videos.");
    }
    public void DisplaySubtitles()
    {
        throw new NotImplementedException("Audio players cannot display subtitles.");
    }
    public void LoadMedia(string filePath)
    {
        Code to load audio file
    }

}
public class VideoPlayer : IMediaPlayer
{
    public void PlayAudio()
    {
        throw new NotImplementedException("Video players cannot play audio without video.");
    }
    public void PlayVideo()
    {
        Code to play video
    }
    public void DisplaySubtitles()
    {
        Code to display subtitles
    }
    public void LoadMedia(string filePath)
    {
        Code to load video file
    }
}

/// <summary>
/// refactor
/// separate the interface 
/// </summary>
/// 

public interface IMediaAudioPlayer
{
    void PlayAudio();
}
public interface IMediaVideoPlayer
{
    void PlayVideo();
    void DisplaySubtitles();
}
public interface IMediaPlayer
{
    void LoadMedia(string filePath);
}

public interface IAudioPlayer : IMediaPlayer, IMediaAudioPlayer
{

}
public interface IVideoPlayer : IMediaPlayer, IMediaVideoPlayer
{

}
public class AudioPlayer : IVideoPlayer
{
    public void PlayAudio()
    {
        Code to play audio
    }
    public void LoadMedia(string filePath)
    {
        Code to load audio file
    }

}
public class VideoPlayer : IMediaPlayer
{
    void PlayVideo()
    {

    }
    public void DisplaySubtitles()
    {
        Code to display subtitles
    }
    public void LoadMedia(string filePath)
    {
        Code to load video file
    }
}


