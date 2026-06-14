using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class SoundMap
{
    public string StateName;
    public AudioClip[] Sound;
}

public class AudioComponent : MonoBehaviour
{
    [SerializeField] public AudioSource myAudioSource;
    [SerializeField] public List<SoundMap> AudioInfo = new List<SoundMap>();

    protected AudioClip[] GetSoundFromState(string StateToFind)
    {
        foreach (var i in AudioInfo)
        {
            if (i.StateName == StateToFind)
            {
                return i.Sound;
            }

        }
        return null;
    }

    protected List<AudioClip> GetAllSounds()
    {
        List<AudioClip> AllSounds = new List<AudioClip>();

        foreach(var i in AudioInfo)
        {
            if(i.Sound != null)
            {
                AllSounds.AddRange(i.Sound);
            }
        }
        return AllSounds;
    }

    public void PlaySoundByState(string StateToPlay)
    {
        //Debug.Log("PlaySoundByState");
        var SoundClipsToPlay = GetSoundFromState(StateToPlay);

        if (SoundClipsToPlay == null || SoundClipsToPlay.Length == 0) return;

        /* Choice random sound */
        var SoundToPlay = SoundClipsToPlay[Random.Range(0, SoundClipsToPlay.Length)];
        /* Play */
        myAudioSource.PlayOneShot(SoundToPlay);       
    }
}
