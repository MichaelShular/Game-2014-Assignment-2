using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public enum TrackID
{
    StartMenu,
    GameMenu,
    Level1
}
public class BGMController : MonoBehaviour
{
    private BGMController() { }

    private static BGMController instance = null;
    public static BGMController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BGMController>();
                DontDestroyOnLoad(instance.transform.root);
            }
            return instance;
        }
        private set { instance = value; }
    }

    [SerializeField] List<AudioClip> musicTracks;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioMixer mixer;
    public void PlayTrack(TrackID id)
    {
        audioSource.clip = musicTracks[(int)id];
        audioSource.Play();
    }
    void DestoryAllClones()
    {
        BGMController[] clones = FindObjectsOfType<BGMController>();
        foreach (BGMController clone in clones)
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
        Instance.PlayTrack(TrackID.StartMenu);
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
