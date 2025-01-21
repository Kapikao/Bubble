using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoTriggerManager : MonoBehaviour
{
    public string videoFileName = "video.mp4"; // Nazwa pliku wideo
    public RawImage rawImage; // RawImage do wy�wietlania wideo na ekranie
    public VideoPlayer videoPlayer; // VideoPlayer
    public GameObject videoPanel; // Panel, kt�ry b�dzie wy�wietla� wideo (b�dzie widoczny na pe�nym ekranie)

    private void Start()
    {
        // Upewnij si�, �e wideo jest pocz�tkowo ukryte
        videoPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy obiekt, kt�ry wszed� w trigger to gracz (mo�esz zmieni� tag)
        if (other.CompareTag("Player"))
        {
            PlayVideo();
        }
    }

    private void PlayVideo()
    {
        // Upewnij si�, �e panel z wideo jest widoczny
        videoPanel.SetActive(true);

        // Za�aduj plik wideo (�cie�ka do pliku w folderze "StreamingAssets")
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);

        // Skonfiguruj VideoPlayer
        videoPlayer.url = path;
        videoPlayer.prepareCompleted += PlayOnPrepared; // B�dziemy odtwarza� wideo, gdy b�dzie gotowe
        videoPlayer.Prepare(); // Przygotowanie wideo
    }

    private void PlayOnPrepared(VideoPlayer vp)
    {
        // Rozpoczynamy odtwarzanie wideo po przygotowaniu
        videoPlayer.Play();
    }

    private void Update()
    {
        // Je�li wideo jest gotowe do zako�czenia, sprawdzamy czy wideo jest odtwarzane
        if (videoPlayer.isPlaying && !videoPlayer.isLooping && videoPlayer.time >= videoPlayer.length)
        {
            // Po zako�czeniu wideo zamykamy panel
            CloseVideo();
        }
    }

    private void CloseVideo()
    {
        // Ukrywamy panel z wideo
        videoPanel.SetActive(false);
    }
}
