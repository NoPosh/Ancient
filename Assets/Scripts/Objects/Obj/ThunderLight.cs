using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ThunderLight : MonoBehaviour
{
    // ласс периодически мен€ет интенсивность света
    [SerializeField] private float _minInterval = 12f;
    [SerializeField] private float _maxInterval = 16f;
    private Animator _animator;
    private AudioSource _audioSource;

    [SerializeField]private float _pitchMin = 0.9f;
    [SerializeField]private float _pitchMax = 1.1f; 

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(TriggerLighting());
    }

    private IEnumerator TriggerLighting()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minInterval, _maxInterval));
            _animator.SetTrigger("Flash");

            _audioSource.pitch = Random.Range(_pitchMin, _pitchMax);
            _audioSource.Play();
        }
    }
}
