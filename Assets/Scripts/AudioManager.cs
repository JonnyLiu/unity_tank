using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
     
	public static AudioManager Instance; 
    //音乐播放器
    public AudioSource MusicPlayer;
    //音效播放器
    public AudioSource SoundPlayer;
	// Use this for initialization
	void Start () {
		Instance = this;
	}
	//播放音乐
    public void PlayMusic(string name)
	{

		if (MusicPlayer.isPlaying==false)
		{
		//加载音乐
		AudioClip clip = Resources.Load<AudioClip>(name);
		MusicPlayer.clip=clip;
		MusicPlayer.Play();
		}
	}
	//停止播放
	public void StopMusic()
	{
		MusicPlayer.Stop();
	}
    //播放音效
	public void PlaySound(string name)
	{
		//加载音乐片段
		AudioClip clip = Resources.Load<AudioClip>(name);
		SoundPlayer.PlayOneShot(clip);
	}
}
