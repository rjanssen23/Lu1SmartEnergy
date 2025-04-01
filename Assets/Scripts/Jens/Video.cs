using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ButtonDisableer : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer1;
    [SerializeField] private VideoPlayer videoPlayer2;
    [SerializeField] private VideoPlayer videoPlayer3;
    [SerializeField] private VideoPlayer videoPlayer4;
    [SerializeField] private VideoPlayer videoPlayer5;
    [SerializeField] private VideoPlayer videoPlayer6;
    [SerializeField] private VideoPlayer videoPlayer7;
    [SerializeField] private VideoPlayer videoPlayer8;
    [SerializeField] private VideoPlayer videoPlayer9;
    [SerializeField] private VideoPlayer videoPlayer10;
    [SerializeField] private VideoPlayer videoPlayer11;
    [SerializeField] private VideoPlayer videoPlayer12;
    [SerializeField] private VideoPlayer videoPlayer13;
    [SerializeField] private VideoPlayer videoPlayer14;
    [SerializeField] private VideoPlayer videoPlayer15;
    [SerializeField] private VideoPlayer videoPlayer16;
    [SerializeField] private VideoPlayer videoPlayer17;
    [SerializeField] private VideoPlayer videoPlayer18;
    [SerializeField] private VideoPlayer videoPlayer19;


    [SerializeField] private GameObject playButton1;
    [SerializeField] private GameObject playButton2;
    [SerializeField] private GameObject playButton3;
    [SerializeField] private GameObject playButton4;
    [SerializeField] private GameObject playButton5;
    [SerializeField] private GameObject playButton6;
    [SerializeField] private GameObject playButton7;
    [SerializeField] private GameObject playButton8;
    [SerializeField] private GameObject playButton9;
    [SerializeField] private GameObject playButton10;
    [SerializeField] private GameObject playButton11;
    [SerializeField] private GameObject playButton12;
    [SerializeField] private GameObject playButton13;
    [SerializeField] private GameObject playButton14;
    [SerializeField] private GameObject playButton15;
    [SerializeField] private GameObject playButton16;
    [SerializeField] private GameObject playButton17;
    [SerializeField] private GameObject playButton18;
    [SerializeField] private GameObject playButton19;


    [SerializeField] private GameObject pauseButton1;
    [SerializeField] private GameObject pauseButton2;
    [SerializeField] private GameObject pauseButton3;
    [SerializeField] private GameObject pauseButton4;
    [SerializeField] private GameObject pauseButton5;
    [SerializeField] private GameObject pauseButton6;
    [SerializeField] private GameObject pauseButton7;
    [SerializeField] private GameObject pauseButton8;
    [SerializeField] private GameObject pauseButton9;
    [SerializeField] private GameObject pauseButton10;
    [SerializeField] private GameObject pauseButton11;
    [SerializeField] private GameObject pauseButton12;
    [SerializeField] private GameObject pauseButton13;
    [SerializeField] private GameObject pauseButton14;
    [SerializeField] private GameObject pauseButton15;
    [SerializeField] private GameObject pauseButton16;
    [SerializeField] private GameObject pauseButton17;
    [SerializeField] private GameObject pauseButton18;
    [SerializeField] private GameObject pauseButton19;




    private void Start()
    {
        SetupButton(videoPlayer1, playButton1, pauseButton1);
        SetupButton(videoPlayer2, playButton2, pauseButton2);
        SetupButton(videoPlayer3, playButton3, pauseButton3);
        SetupButton(videoPlayer4, playButton4, pauseButton4);
        SetupButton(videoPlayer5, playButton5, pauseButton5);
        SetupButton(videoPlayer6, playButton6, pauseButton6);
        SetupButton(videoPlayer7, playButton7, pauseButton7);
        SetupButton(videoPlayer8, playButton8, pauseButton8);
        SetupButton(videoPlayer9, playButton9, pauseButton9);
        SetupButton(videoPlayer10, playButton10, pauseButton10);
        SetupButton(videoPlayer11, playButton11, pauseButton11);
        SetupButton(videoPlayer12, playButton12, pauseButton12);
        SetupButton(videoPlayer13, playButton13, pauseButton13);
        SetupButton(videoPlayer14, playButton14, pauseButton14);
        SetupButton(videoPlayer15, playButton15, pauseButton15);
        SetupButton(videoPlayer16, playButton16, pauseButton16);
        SetupButton(videoPlayer17, playButton17, pauseButton17);
        SetupButton(videoPlayer18, playButton18, pauseButton18);
        SetupButton(videoPlayer19, playButton19, pauseButton19);
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

    public void StopAllVideos()
    {
        VideoPlayer[] videoPlayers = {
            videoPlayer1, videoPlayer2, videoPlayer3, videoPlayer4, videoPlayer5,
            videoPlayer6, videoPlayer7, videoPlayer8, videoPlayer9, videoPlayer10,
            videoPlayer11, videoPlayer12, videoPlayer13, videoPlayer14, videoPlayer15,
            videoPlayer16, videoPlayer17, videoPlayer18, videoPlayer19
        };

        foreach (var videoPlayer in videoPlayers)
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Stop();
            }
        }
    }
}
