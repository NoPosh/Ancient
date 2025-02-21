using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour, IInitializable
{
    [SerializeField] Transform _characterTransform; //В дальнейшем лучше переделать
    [SerializeField] Transform _backgroundImage;

    private float lowerLevel = -6f;

    [SerializeField] float _smooth;
    private Vector3 _camOffset = new Vector3(0, 4, -10); //Улучшить
    private Vector3 _backgroundOffset = new Vector3(0, 0, 0);

    private bool _isInitialized = false;

    //Пока что просто следует за персонажем
    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _isInitialized = true;
        _backgroundOffset.y = _backgroundImage.position.y;
    }

    private void Update()
    {
        if (!_isInitialized) return;

        Vector3 pos = _characterTransform.position + _camOffset;
        if (pos.y < lowerLevel) pos.y = lowerLevel;
        transform.position = pos;

        Vector3 backPos = new Vector3(pos.x + _backgroundOffset.x, _backgroundOffset.y, 0);

        _backgroundImage.position = backPos;
        
    }
}
