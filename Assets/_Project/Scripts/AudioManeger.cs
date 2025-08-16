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
	[Header("AudioClips")]
	[SerializeField] AudioClip jumpClip;
	[SerializeField] AudioClip landClip;
	[SerializeField] AudioClip runClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
	}


	void Start()
	{

	}

	//Update is called once per frame
	void Update()
	{

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
