using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    public List<AudioClip> BGMList;         // BGMを格納するリスト
    public List<AudioClip> SEList;          // SEを格納するリスト
    public List<AudioClip> VoiceList;       // Voiceを格納するリスト
    public int MaxSE = 10;
    public int MaxVoice = 10;

    private AudioSource bgmSource = null;
    private List<AudioSource> seSources = null;
    private List<AudioSource> voiceSources = null;

    private Dictionary<string, AudioClip> bgmDict = null;
    private Dictionary<string, AudioClip> seDict = null;
    private Dictionary<string, AudioClip> voiceDict = null;

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        //create listener
        if (FindObjectsOfType(typeof(AudioListener)).All(o => !((AudioListener)o).enabled))
        {
            this.gameObject.AddComponent<AudioListener>();
        }
        //create audio sources
        this.bgmSource = this.gameObject.AddComponent<AudioSource>();
        this.seSources = new List<AudioSource>();
        this.voiceSources = new List<AudioSource>();

        //create clip dictionaries
        this.bgmDict = new Dictionary<string, AudioClip>();
        this.seDict = new Dictionary<string, AudioClip>();
        this.voiceDict = new Dictionary<string, AudioClip>();

        Action<Dictionary<string, AudioClip>, AudioClip> addClipDict = (dict, c) => 
        {
            if (!dict.ContainsKey(c.name))
            {
                dict.Add(c.name, c);
            }
        };

        this.BGMList.ForEach(bgm => addClipDict(this.bgmDict, bgm));
        this.SEList.ForEach(se => addClipDict(this.seDict, se));
        this.VoiceList.ForEach(voice => addClipDict(this.voiceDict, voice));
    }

    public void PlayBGM(string bgmName)
    {
        if (!this.bgmDict.ContainsKey(bgmName)) throw new ArgumentException(bgmName + " not found", "bgmName");
        if (this.bgmSource.clip == this.bgmDict[bgmName]) return;
        this.bgmSource.Stop();
        this.bgmSource.clip = this.bgmDict[bgmName];
        this.bgmSource.Play();
    }

    public void StopBGM()
    {
        this.bgmSource.Stop();
        this.bgmSource.clip = null;
    }

    public void PlaySE(string seName)
    {
        if (!this.seDict.ContainsKey(seName)) throw new ArgumentException(seName + " not found", "seName");

        AudioSource source = this.seSources.FirstOrDefault(s => !s.isPlaying);
        if (source == null)
        {
            if (this.seSources.Count >= this.MaxSE)
            {
                Debug.Log("SE AudioSource is full");
                return;
            }

            source = this.gameObject.AddComponent<AudioSource>();
            this.seSources.Add(source);
        }

        source.clip = this.seDict[seName];
        source.Play();
    }

    public void StopSE()
    {
        this.seSources.ForEach(s => s.Stop());
    }

    public void PlayVoice(string voiceName)
    {
        if (!this.voiceDict.ContainsKey(voiceName)) throw new ArgumentException(voiceName + " not found", "voiceName");

        AudioSource source = this.voiceSources.FirstOrDefault(s => !s.isPlaying);
        if (source == null)
        {
            if (this.voiceSources.Count >= this.MaxVoice)
            {
                Debug.Log("voice AudioSource is full");
                return;
            }

            source = this.gameObject.AddComponent<AudioSource>();
            this.voiceSources.Add(source);
        }

        source.clip = this.voiceDict[voiceName];
        source.Play();
    }

    public void StopVoice()
    {
        this.voiceSources.ForEach(s => s.Stop());
    }

}
