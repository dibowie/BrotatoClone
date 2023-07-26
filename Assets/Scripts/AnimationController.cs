using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private InputController _input;
    private Animator _animator;
    
    private bool _isMoving;
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        SetMoveAnimation();
    }

    private void SetMoveAnimation()
    {
        if (_input.InputDirection.magnitude >0)
        {
            _isMoving = true;
            _animator.SetBool("idle",false);
            _animator.SetBool("move", true);
        }
        else
        {
            _isMoving = false;
            _animator.SetBool("move", false);
            _animator.SetBool("idle",true);
        }
    }

    public void SetAttackAnimation()
    {
        _animator.SetTrigger("attack");
        
    }
}
