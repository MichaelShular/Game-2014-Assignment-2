//Michael Shular 101273089
//SFXController
//12/13/2021
//Summary: Controls SFX tracks and audio
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SFXID
{
    UIClick,
    PlayerJump,
    ProjectileHit,
    Death,
    Stun,
    RunnersHit,
    Throw
}
public class SFXController : MonoBehaviour
{
    private SFXController() { }

    private static SFXController instance = null;
    public static SFXController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SFXController>();
                DontDestroyOnLoad(instance.transform.root);
            }
            return instance;
        }
        private set { instance = value; }
    }

    [SerializeField] List<AudioClip> sfxTracks;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioMixer mixer;
    public void PlaySFX(SFXID id)
    {
        audioSource.PlayOneShot(sfxTracks[(int)id]);
    }
    void DestoryAllClones()
    {
        SFXController[] clones = FindObjectsOfType<SFXController>();
        foreach (SFXController clone in clones)
        {
            if (clone != Instance)
            {
                Destroy(clone.gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DestoryAllClones();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setVolume(float volumeDB)
    {
        mixer.SetFloat("VolumeMusic", volumeDB);
    }
}
