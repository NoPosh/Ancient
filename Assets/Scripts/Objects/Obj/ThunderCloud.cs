using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ThunderCloud : InteractableObject
{
    [SerializeField] private float _cooldown = 10f;
    [SerializeField] private float _intensivity;
    [SerializeField] private float _duration = 5f;

    [SerializeField] private GameObject _thunderSprite;

    private float _currentCooldown = 0f;
    private float _baseIntensivity;
    
    [SerializeField]private Animator _animator;

    private AudioSource _audioSource;
    [SerializeField] private float _pitchMin = 0.9f;
    [SerializeField] private float _pitchMax = 1.1f;

    protected override void Start()
    {
        base.Start();
        if (_isGlobal) _isInteractable = true;
        _audioSource = GetComponent<AudioSource>();
    }
    public override void Interact()
    {
        base.Interact();
        if (_currentCooldown > 0) return;
        ShowThunder();

        _currentCooldown = _cooldown;
    }

    private void Update()
    {
        if (_currentCooldown > 0) _currentCooldown -= Time.deltaTime;
    }

    public void ShowThunder()
    {        
        _animator.SetTrigger("Flash");
        _audioSource.pitch = Random.Range(_pitchMin, _pitchMax);
        _audioSource.Play();
        if (_thunderSprite == null) return;
        _thunderSprite.SetActive(true);
        StartCoroutine(HideThunder());
    }

    private IEnumerator HideThunder()
    {
        yield return new WaitForSeconds(2f);
        _thunderSprite.SetActive(false);
    }


}
