using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }
    // Start is called before the first frame update

    [SerializeField] private List<Sound> soundList;
    [SerializeField] private Dictionary<string, Sound> soundMap;
    public int index = 0;
    public AudioSource currentMusic = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        soundMap = new Dictionary<string, Sound>();

        foreach (Sound sound in soundList)
        {
            sound.source = this.gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.playOnAwake = sound.playOnAwake;

            soundMap.Add(sound.name, sound);
        }

        currentMusic = soundList[index].source;
        currentMusic.Play();
    }

    private void Update()
    {
        if (!currentMusic.isPlaying)
        {
            index++;
            currentMusic = soundList[(index % soundList.Count)].source;
            currentMusic.Play();
        }
    }

    public void Play(string name)
    {
        if (!soundMap.ContainsKey(name))
        {
            Debug.LogWarning("Sound " + name + " Not found");
            return;
        }

        Sound sound = soundMap[name];

        if (sound.source.isPlaying)
        {
            sound.source.Stop();
        }
        sound.source.Play();
    }

    public void Stop(string name)
    {
        if (!soundMap.ContainsKey(name))
        {
            Debug.LogWarning("Sound " + name + " Not found");
            return;
        }

        Sound sound = soundMap[name];
        sound.source.Stop();

    }
}
