using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPausable
{
    [SerializeField] private float m_MoveSpeed = default;
    public float MoveSpeed { get => m_MoveSpeed; }

    private Vector2 m_Direction;
    public Vector2 Direction { get => m_Direction; }

    private Rigidbody2D _rigidbody;
    private Vector2 _nextPosition;

    private bool _isPaused;

    private bool _isMoving;
    private bool m_HasFreeMovement;
    public bool HasFreeMovement { get => m_HasFreeMovement; set => m_HasFreeMovement = value; }

    private bool _beforeIsMoving;
    private Vector3 _beforeDirection;

    private LayerMask _groundMask;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _nextPosition = _rigidbody.position;
        m_HasFreeMovement = false;
        _isPaused = false;

        _groundMask = 1 << LayerMask.NameToLayer("Ground");
    }

    void Update()
    {
        if (_isPaused) return;
        if (!m_HasFreeMovement && _isMoving) return;
        int horizontalMovement = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        int verticalMovement = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        if (horizontalMovement != 0)
        {
            _isMoving = true;
            m_Direction.x = horizontalMovement;
            m_Direction.y = 0f;
        }
        else if (verticalMovement != 0)
        {
            _isMoving = true;
            m_Direction.x = 0f;
            m_Direction.y = verticalMovement;
        }

#if DEVELOPMENT_BUILD || UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_HasFreeMovement = true;
            if (_groundMask == 0) _groundMask = 1 << LayerMask.NameToLayer("Ground");
            else _groundMask = 0;
        }
#endif
    }

    public void ForceMovement(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        m_Direction = direction;
        _isMoving = true;
    }

    void FixedUpdate()
    {
        if (_isPaused) return;
        if (!_isMoving) return;

        if (_rigidbody.position == _nextPosition)
        {
            bool foundNextPosition = FindNextPosition();
            if (!foundNextPosition)
            {
                _isMoving = false;
                m_Direction = Vector2.zero;
                return;
            }
        }
        
        Vector2 movePosition = Vector2.MoveTowards(_rigidbody.position, _nextPosition, m_MoveSpeed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(movePosition);

    }

    bool FindNextPosition()
    {
        Vector2 nextPosition = _rigidbody.position + m_Direction;

        nextPosition = new Vector2(
            Mathf.FloorToInt(nextPosition.x) + .5f,
            Mathf.FloorToInt(nextPosition.y) + .5f
        );

        Collider2D coll = Physics2D.OverlapBox(_rigidbody.position + m_Direction, Vector2.one * .9f, 0f, _groundMask);
        if (coll == null)
        {
            _nextPosition = nextPosition;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnPause()
    {
        _isPaused = true;
        _beforeIsMoving = _isMoving;
        _beforeDirection = m_Direction;

        _isMoving = false;
        m_Direction = Vector2.zero;
    }

    public void OnResume()
    {
        _isPaused = false;
        _isMoving = _beforeIsMoving;
        m_Direction = _beforeDirection;
    }

}
