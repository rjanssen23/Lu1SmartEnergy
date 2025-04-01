using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ButtonDisabler : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayerInfo;


    [SerializeField] private GameObject playButton;

    [SerializeField] private GameObject pauseButton;


    private void Start()
    {
        SetupButton(videoPlayerInfo, playButton, pauseButton);
    }

    private void SetupButton(VideoPlayer videoPlayer, GameObject playButton, GameObject pauseButton)
    {
        pauseButton.SetActive(false);

        AddListener(playButton, () =>
        {
            videoPlayer.Play();
            playButton.SetActive(false);
            pauseButton.SetActive(true);
        });

        AddListener(pauseButton, () =>
        {
            videoPlayer.Pause();
            pauseButton.SetActive(false);
            playButton.SetActive(true);
        });
    }

    private void AddListener(GameObject buttonObj, UnityEngine.Events.UnityAction action)
    {
        Button btn = buttonObj.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(action);
        }
    }

    public void StopVideo()
    {
        videoPlayerInfo.Stop();
    }
}
