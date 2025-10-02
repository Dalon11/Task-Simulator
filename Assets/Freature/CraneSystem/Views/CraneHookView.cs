using UnityEngine;

public class CraneHookView : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void Awake() => SetupAudio();

    public void PlaySoundMove() => _audioSource.Play();

    public void StopSoundMove() => _audioSource.Stop();

    private void SetupAudio()
    {
        _audioSource.clip = _audioClip;
        _audioSource.loop = true;
        _audioSource.playOnAwake = false;
    }
}