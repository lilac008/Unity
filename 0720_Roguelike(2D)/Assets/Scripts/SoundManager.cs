using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;
    public float lowPitchRange = .95f; //사운드는 1이 기본값
    public float hightPitchRange = 1.05f; //사운드는 1이 기본값

    public static SoundManager instance = null;


    private void Awake()
    {
        if(instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip) 
    { 
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips) //파라미터
    {
        int randomIdx = Random.Range(0, clips.Length);

        float randomPitch = Random.Range(lowPitchRange, hightPitchRange);

        efxSource.pitch = randomPitch;

        efxSource.clip = clips[randomIdx];

        efxSource.Play();

    }
}
