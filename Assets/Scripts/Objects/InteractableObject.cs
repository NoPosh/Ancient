using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //������� ������ ��� ������������� ��������   
    [SerializeField] protected bool _isGlobal; //������ �� �������������� ���� ��������� ������ ��� ������ ����� � ����������
    public bool isGlobal { get { return _isGlobal; } }
    protected bool _isInteractable = false;
    public bool IsInteractive { get { return _isInteractable; } set {  _isInteractable = value; } }

    protected virtual void Start()
    {
        if (_isGlobal) _isInteractable = true;
    }

    protected virtual void OnMouseDown()
    {
        if (!_isInteractable) return;
        Interact();
    }

    public virtual void Interact()
    {
        //Debug.Log("��������������");
        //����� �������� ��������� �������, ������� ����� ������ ������ ������
    }

}
