using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class VirtualButtonManager : MonoBehaviour, IVirtualButtonEventHandler
{
    [SerializeField] private UnityEngine.UI.Image imagePanel;
    [SerializeField] private VideoPlayer videoPlayer;

    void Start()
    {
        imagePanel.color = Color.green;
        GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) // Sobre botão virtual
    {
        WhenIsPress();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) // Retira botão virtual
    {
        WhenIsReleased();
    }

    private void WhenIsPress()
    {
        imagePanel.color = Color.blue;
        PlayOrPauseVideo();
        print("WhenIsPress");
    }

    private void WhenIsReleased()
    {
        imagePanel.color = Color.green;
        print("WhenIsReleased");
    }

    private void PlayOrPauseVideo()
    {
        if (!videoPlayer.isPlaying)
            videoPlayer.Play();
        else
            videoPlayer.Pause();
    }
}