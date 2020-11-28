using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    public static AudioManager audioinstance;

    public AudioAssets[] sounds;

    public AudioMixer MasterMixer;

    public string MasterMixerSounds = "Master";
    public string Music = "Music";
    public string SoundEffects = "Effect Sounds";


    // Start is called before the first frame update
    void Awake()
    {
        if(audioinstance == null)
        {
            audioinstance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        foreach (AudioAssets s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(MasterMixerSounds)[0];

           

        }

    }


    void Start()
    {
        PlayTheme("Theme");
    }
    public void Update()
    {



    }


    public void PlayC(string name)
    {
        AudioAssets s = Array.Find(sounds, sound => sound.name == name);
        s.source.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(SoundEffects)[0];
        s.source.pitch = Time.timeScale;
        s.source.Play();



    }
    public void Play (string name)
    {
        AudioAssets s = Array.Find(sounds, sound => sound.name == name);
        s.source.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(SoundEffects)[0];
        s.source.pitch = Time.timeScale;
        if (!s.source.isPlaying)
        {

            s.source.Play();
        }

        

    }
    public void PlayTheme(string name)
    {
        AudioAssets s = Array.Find(sounds, sound => sound.name == name);
        s.source.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(Music)[0];
        s.source.pitch = 1f;
        s.source.Play();
    }
    public void Stop(string name)
    {

        AudioAssets s = Array.Find(sounds, sound => sound.name == name);
        s.source.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(SoundEffects)[0];
        s.source.Stop();
        
    }


    /* Unsued Code
             if(TimeScript.timeinstance != null)
        {
            if (TimeScript.timeinstance.timefrozen)
            {
                s.source.pitch = .3f;
            }
            else
            {
                s.source.pitch = 1f;
            }
        }
        else
        {
            return;
        }*/
}
