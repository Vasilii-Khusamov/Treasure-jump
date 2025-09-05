using UnityEngine;
using UnityEngine.UI;

public class OptionsView : MonoBehaviour
{
	[SerializeField] private GameObject optionsMenu;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle soundToggle;
    void Start()
	{
		soundToggle.isOn = AudioManager.Instance.IsSoundEnabled;
        musicToggle.isOn = AudioManager.Instance.IsMusicEnabled;

        soundToggle.onValueChanged.AddListener((isSoundEnabled) => AudioManager.Instance.SetSoundEnabled(isSoundEnabled));
        musicToggle.onValueChanged.AddListener((isMusicEnabled) => AudioManager.Instance.SetMusicEnabled(isMusicEnabled));

        AudioManager.Instance.OnSoundEnabledChanged += (isSoundEnabled) => soundToggle.isOn = isSoundEnabled;
        AudioManager.Instance.OnMusicEnabledChanged += (isMusicEnabled) => musicToggle.isOn = isMusicEnabled;
    }

    private void OnDestroy()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.OnSoundEnabledChanged -= (isSoundEnabled) => soundToggle.isOn = isSoundEnabled;
            AudioManager.Instance.OnMusicEnabledChanged -= (isMusicEnabled) => musicToggle.isOn = isMusicEnabled;
        }
    }
}
