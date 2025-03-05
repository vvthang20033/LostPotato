using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Bắt đầu phát video khi Scene khởi tạo
        videoPlayer.Play();
    }


}
