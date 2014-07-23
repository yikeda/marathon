using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {
		
	readonly Hashtable audioResorces = new Hashtable
		{
			{"button", "Sound/button"},			
			{"start", "Sound/start"},
			{"finish", "Sound/finish"},
			{"lap", "Sound/lap"},
			{"damage", "Sound/damage"},
			{"countdown", "Sound/countdown"},
			{"no_star", "Sound/no_star"},
			{"1_star", "Sound/1_star"},
			{"2_star", "Sound/2_star"},
			{"3_star", "Sound/3_star"},
			{"explosion", "Sound/explosion"},
		};

	static AudioManager sInstance;
	
	private AudioSource mAudioSource;
	private AudioSource mAudioSourceBGM;
	private Hashtable mRsources;
	
	public AudioSource AudioSourceBGM
	{
		get
		{
			return mAudioSourceBGM;
		}
	}
		
	private AudioManager(){}
		
	public static AudioManager SharedInstance()
	{
		if (sInstance == null) {
			GameObject gameObject = GameObject.Find("Camera");
			sInstance = gameObject.GetComponent<AudioManager>();
			DontDestroyOnLoad(gameObject);
		}
		return sInstance;
	}
		
	void Awake () {
		mRsources = new Hashtable();
		mAudioSourceBGM = gameObject.GetComponent<AudioSource>();
		mAudioSource = gameObject.AddComponent<AudioSource>();

		load();
	}

	void load()
	{
		foreach(DictionaryEntry audioResource in audioResorces)
		{
			AudioClip audioClip = Resources.Load((string)audioResource.Value) as AudioClip;
			mRsources.Add(audioResource.Key, audioClip);
		}
	}
		
	public void Play(string seid)
	{
		if (mRsources.ContainsKey(seid))
		{
			AudioClip audioClip = (AudioClip)mRsources[seid];
			mAudioSource.PlayOneShot(audioClip);
		}
	}

	public void PlayBGM()
	{
		if (mAudioSourceBGM != null)
		{
			mAudioSourceBGM.Play();
		}
	}

	public void StopBGM()
	{
		if (mAudioSourceBGM != null)
		{
			mAudioSourceBGM.Stop();
		}
	}

}
