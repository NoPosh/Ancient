using UnityEngine;
using System.Collections.Generic;

public class FallingTree : InteractableObject
{
    //Дерево падает, когда рядом персонаж (Нужно нажать мышкой)
    [SerializeField] private int _timesBeforeFall = 3;
    [SerializeField] private float _shakeCooldown = 2f;
    [SerializeField] private List<GameObject> _fireSprite;

    [SerializeField]private ThunderCloud _thunderCloud;

    float _currentCooldown = 0f;
    Animator animator;

    private bool _wasFalling = false;
    private bool _isMoved = false;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_currentCooldown > 0) _currentCooldown -= Time.deltaTime;
    }

    public override void Interact()
    {
        if (_currentCooldown > 0) return;
        if (_isMoved)
        {
            _thunderCloud.ShowThunder();
            StartFire();
        }
        if (_wasFalling)
        {
            animator.SetTrigger("Move");
            _isMoved = true;
        }

        if (_timesBeforeFall-- > 0)
        {
            animator.SetTrigger("Shake");
            _currentCooldown = _shakeCooldown;
            
        }
        if (_timesBeforeFall <= 0)
        { 
            animator.SetTrigger("Fall");
            _wasFalling = true;
        }
    }

    public void StartFire()
    {
        foreach (var item in _fireSprite)
        {
            item.gameObject.SetActive(true);
        }
    }
}
