using UnityEngine;

public class CraneHookView : AbstractCraneHookView
{
    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void Awake() => SetupAudio();

    public override void PlaySoundMove() => _audioSource.Play();

    public override void StopSoundMove() => _audioSource.Stop();

    private void SetupAudio()
    {
        _audioSource.clip = _audioClip;
        _audioSource.loop = true;
        _audioSource.playOnAwake = false;
    }
}