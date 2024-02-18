using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioClip[] musicTracks; 
    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        
        if (musicTracks != null && musicTracks.Length > 0)
        {
            
            PlayNextTrack();
        }
        else
        {
            Debug.LogWarning("No music tracks assigned to the GameMusic script.");
        }
    }

    void Update()
    {
        
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    void PlayNextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;

        audioSource.clip = musicTracks[currentTrackIndex];
        audioSource.Play();
    }
}
