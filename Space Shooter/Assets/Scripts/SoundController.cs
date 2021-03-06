﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eBGMClips
{
    BG01
}

public enum eEffectClips
{
    ExpAsteroid, ExpEnemy, ExpPlayer, WeaponEnemy, WeaponPlayer
}

public class SoundController : MonoBehaviour {
    public static SoundController instance;

    public AudioSource BGM, Effect;
    public AudioClip[] BGMClip, EffectClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayeBGM(eBGMClips id)
    {
        BGM.clip = BGMClip[(int)id];
        BGM.volume = 1;
        BGM.Play();
    }

    public void PlayerEffectSound(eEffectClips id)
    {
        Effect.PlayOneShot(EffectClip[(int)id]);
    }

    public void SetBGMVolum(Slider slider)
    {
        BGM.volume = slider.value;
    }
    public void SetEffectVolum(Slider slider)
    {
        Effect.volume = slider.value;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
