using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoTriggerManager : MonoBehaviour
{
    public string videoFileName = "video.mp4"; // Nazwa pliku wideo
    public RawImage rawImage; // RawImage do wyœwietlania wideo na ekranie
    public VideoPlayer videoPlayer; // VideoPlayer
    public GameObject videoPanel; // Panel, który bêdzie wyœwietla³ wideo (bêdzie widoczny na pe³nym ekranie)

    private void Start()
    {
        // Upewnij siê, ¿e wideo jest pocz¹tkowo ukryte
        videoPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy obiekt, który wszed³ w trigger to gracz (mo¿esz zmieniæ tag)
        if (other.CompareTag("Player"))
        {
            PlayVideo();
        }
    }

    private void PlayVideo()
    {
        // Upewnij siê, ¿e panel z wideo jest widoczny
        videoPanel.SetActive(true);

        // Za³aduj plik wideo (œcie¿ka do pliku w folderze "StreamingAssets")
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);

        // Skonfiguruj VideoPlayer
        videoPlayer.url = path;
        videoPlayer.prepareCompleted += PlayOnPrepared; // Bêdziemy odtwarzaæ wideo, gdy bêdzie gotowe
        videoPlayer.Prepare(); // Przygotowanie wideo
    }

    private void PlayOnPrepared(VideoPlayer vp)
    {
        // Rozpoczynamy odtwarzanie wideo po przygotowaniu
        videoPlayer.Play();
    }

    private void Update()
    {
        // Jeœli wideo jest gotowe do zakoñczenia, sprawdzamy czy wideo jest odtwarzane
        if (videoPlayer.isPlaying && !videoPlayer.isLooping && videoPlayer.time >= videoPlayer.length)
        {
            // Po zakoñczeniu wideo zamykamy panel
            CloseVideo();
        }
    }

    private void CloseVideo()
    {
        // Ukrywamy panel z wideo
        videoPanel.SetActive(false);
    }
}
