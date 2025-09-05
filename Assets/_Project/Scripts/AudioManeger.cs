using System;
using UnityEngine;

	public enum SFX
	{
		Jump,
		Land,
		Run
	}
public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;
	[Header("AudioSource")]
	[SerializeField] AudioSource SFXSource;
	[SerializeField] AudioSource MusicSource;
    [Header("AudioClips")]
	[SerializeField] AudioClip jumpClip;
	[SerializeField] AudioClip landClip;
	[SerializeField] AudioClip runClip;
	
	public event Action<bool> OnSoundEnabledChanged;
	public event Action<bool> OnMusicEnabledChanged;
    public bool IsSoundEnabled { get; private set; } = true;
	public bool IsMusicEnabled { get; private set; } = true;


    void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
		IsSoundEnabled = PlayerPrefs.GetInt("IsSoundEnabled", 1) == 1;
		IsMusicEnabled = PlayerPrefs.GetInt("IsMusicEnabled", 1) == 1;
    }

	public void SetMusicEnabled(bool isEnabled)
	{
		IsMusicEnabled = isEnabled;
		MusicSource.mute = !isEnabled;
		PlayerPrefs.SetInt("IsMusicEnabled", isEnabled ? 1 : 0);
        OnMusicEnabledChanged?.Invoke(isEnabled);
    }
	public void SetSoundEnabled(bool isEnabled)
	{
		IsSoundEnabled = isEnabled;
		SFXSource.mute = !isEnabled;
		PlayerPrefs.SetInt("IsSoundEnabled", isEnabled ? 1 : 0);
        OnSoundEnabledChanged?.Invoke(isEnabled);
    }
	public void ApplySettings()
	{
		SFXSource.mute = !IsSoundEnabled;
		MusicSource.mute = !IsMusicEnabled;
    }
    public void PlaySFX(SFX sfx)
	{
		AudioClip audioClip;
		switch (sfx)
		{
			case SFX.Jump:
				audioClip = jumpClip;
				break;
			case SFX.Land:
				audioClip = landClip;
				break;
			case SFX.Run:
				audioClip = runClip;
				break;
			default:
				return;
		}
		SFXSource.PlayOneShot(audioClip);
	}
}
