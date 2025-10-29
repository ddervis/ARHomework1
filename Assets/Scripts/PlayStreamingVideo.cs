using UnityEngine;
using UnityEngine.Video;
using System.IO;
using Debug = UnityEngine.Debug;
using Application = UnityEngine.Application;

[RequireComponent(typeof(VideoPlayer))]
public class PlayStreamingVideo : MonoBehaviour
{
    public string videoFileName = "default.mp4";
    [HideInInspector] public VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        string videoPath = GetVideoPath(videoFileName);
        if (string.IsNullOrEmpty(videoPath))
        {
            Debug.LogError($"[{name}] Video not found!");
            return;
        }

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = videoPath;
        videoPlayer.isLooping = true;
        videoPlayer.playOnAwake = false;
        videoPlayer.waitForFirstFrame = false;
        videoPlayer.Prepare();
    }

    private string GetVideoPath(string fileName)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // Android için özel path: StreamingAssets erişimi WWW gerektirir
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        return filePath;
#else
        // Editor ve iOS için
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(filePath))
            return filePath;
        return null;
#endif
    }
}
