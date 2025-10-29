using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    public PlayStreamingVideo morocco;
    public PlayStreamingVideo neths;
    public PlayStreamingVideo arabia;

    public Button moroccoBtn;
    public Button nethsBtn;
    public Button arabiaBtn;

    void Start()
    {
        moroccoBtn.onClick.AddListener(() => TogglePlay(morocco.videoPlayer));
        nethsBtn.onClick.AddListener(() => TogglePlay(neths.videoPlayer));
        arabiaBtn.onClick.AddListener(() => TogglePlay(arabia.videoPlayer));
    }

    void TogglePlay(VideoPlayer player)
    {
        if (player == null) return;

        if (player.isPlaying)
            player.Pause();
        else
        {
            if (!player.isPrepared)
                player.Prepare();

            player.Play();
        }
    }
}
