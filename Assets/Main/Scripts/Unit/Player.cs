using UnityEngine;

public class Player : Unit
{
    [Header("Player - 참조")]
    [SerializeField] private CameraMoving _cam;
    [SerializeField] private Player_Input _input;  

    [Header("Player - 플레이어 설정")]
    [SerializeField] private float splitSpeed; 
    [SerializeField] private int maxJumpCount;
    
    private int jumpCount;

    private float LastMoveDirectionX; // 마지막으로 이동한 방향
    private Vector2 cachedMoveDirection;
    private bool cachedIsSplit;
    private bool jumpQueued;

    // 게임 시작 때 첫번째로 실행되는 함수
    private void Awake()
    {
        LastMoveDirectionX = 1;
        jumpCount = maxJumpCount;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    // 컴퓨터의 매 프레임 마다 실행되는 함수
    private void Update()
    {
        InputCheck();
    }

    // 정해진 주기 마다 실행되는 함수 (20Ms)
    private void FixedUpdate()
    {
        Move(cachedMoveDirection, cachedIsSplit ? splitSpeed : moveSpeed);
        FovUpdate();
        JumpCheck();
    }

    private void InputCheck()
    {
        cachedMoveDirection = _input.moveDirection;
        DirectUpdate();
        
        cachedIsSplit = _input.isSplit;

        if (_input.isJump)
        {
            jumpQueued = true;
            _input.SetJumpInput(false);
        }
    }

    private void DirectUpdate()
    {
        if (cachedMoveDirection.x != 0)
        {
            LastMoveDirectionX = cachedMoveDirection.x;
        }

        if (cachedMoveDirection == Vector2.zero)
        {
            _cam.SetOffsetX(LastMoveDirectionX);
        }
        else
        {
            _cam.SetOffsetX(0);
        }
    }

    private void FovUpdate()
    {
        if (cachedMoveDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (cachedMoveDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void JumpCheck()
    {
        if (jumpQueued && jumpCount > 0)
        {
            Jump(jumpForce);
            jumpCount--;
        }

        jumpQueued = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = maxJumpCount;
        }
    }
}
