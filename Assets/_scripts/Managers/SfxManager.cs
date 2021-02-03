using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SfxManager : MonoBehaviour, ISceneLoad
{
    [SerializeField] private AudioSource musicOne, musicTwo, sfx;
    public static SfxManager SingleInstance;
    [SerializeReference] private List<AudioClip> levelsLoop = new List<AudioClip>();
    private AudioSource _currentAudioSource;
    private int _lastScene;

    private void Awake()
    {
        OnSceneLoadEvent.AddNotifier(this);
        if (SingleInstance == null)
        {
            SingleInstance = this;
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        musicOne.clip = levelsLoop[0];
        musicOne.volume = 1;
        musicTwo.volume = 0;
        musicOne.Play();
        _currentAudioSource = musicOne;
    }

    /// <summary>
    /// Mute sound/Music
    /// </summary>
    /// <param name="mode">1:Sound 2:Music 3:All</param>
    public void Mute(int mode)
    {
        switch (mode)
        {
            case 1:
                sfx.volume = 0;
                break;
            case 2:
                musicOne.volume = 0;
                musicTwo.volume = 0;
                break;
            case 3:
                musicOne.volume = 0;
                musicTwo.volume = 0;
                sfx.volume = 0;
                break;
            default:
                Debug.Log("Option not exists");
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mode">1: Enable sfx ,2:enable music ,another number: Bug bitch </param>
    /// <param name="volume">AudioSourceVolume 0-1</param>
    public void EnableSound(int mode, float volume = 1)
    {
        switch (mode)
        {
            case 1:
                sfx.volume = volume;
                break;
            case 2:
                musicOne.volume = volume;
                musicTwo.volume = volume;
                break;
            default:
                Debug.Log("Option does not exist");
                break;
        }
    }


    public void PlaySound(AudioClip clip)
    {
        sfx.clip = clip;
        sfx.PlayOneShot(sfx.clip);
    }


    [SerializeField] private AudioClip bounceSound;


    public void PlayMusicLevel(int id)
    {
        StopAllCoroutines();
        _currentAudioSource.volume = 1;
        var next = _currentAudioSource == musicOne ? musicTwo : musicOne;
        next.volume = 0;
        switch (id)
        {
            case 0:
                if (_lastScene == 0)
                {
                    break;
                }

                StartCoroutine(FadeMusic(_currentAudioSource, next));
                next.clip = levelsLoop[0];
                break;

            case 1:
            case 2:
            case 3:
            {
                var randomTrack = Random.Range(1, 4);
                next.clip = levelsLoop[randomTrack];
                StartCoroutine(FadeMusic(_currentAudioSource, next));
                break;
            }
            case 4:
                next.clip = levelsLoop[4];
                StartCoroutine(FadeMusic(_currentAudioSource, next));
                break;
        }
    }


    private IEnumerator FadeMusic(AudioSource current, AudioSource next)
    {
        while (current.volume > 0)
        {
            if (!next.isPlaying)
            {
                next.Play();
            }

            current.volume -= 0.1f;
            next.volume += 0.1f;
            yield return new WaitForSeconds(0.2f);
        }

        current.Stop();
        next.volume = 1;
        current.volume = 0;
        _currentAudioSource = next;
    }

    public void NotifySceneLoad()
    {
        _lastScene = SceneManager.GetActiveScene().buildIndex;
    }


    public void PlayBounceSound()
    {
        sfx.clip = bounceSound;

        sfx.PlayOneShot(sfx.clip);
    }
}