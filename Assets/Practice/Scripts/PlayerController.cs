using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("캐릭터 설정")]
    public string playerName = "또롱이";
    public float moveSpeed = 4.0f;
    public float SpeedMultiplier = 2.0f;

    // 속도 저장해두기
    private float baseSpeed;
    private float lastSpeed = 0f;
    
    // Animator 컴포넌트 참조 (private - Inspector에 안 보임)
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseSpeed = moveSpeed;

        Debug.Log("안녕하세요, " + playerName + "님!");
        Debug.Log("이동 속도: " + moveSpeed);
        
        // 디버그: 제대로 찾았는지 확인
        if (animator != null)
        {
            Debug.Log("Animator 컴포넌트를 찾았습니다!");
        }
        else
        {
            Debug.LogError("Animator 컴포넌트가 없습니다!");
        }
    }
    


void Update()
    {
        baseSpeed = moveSpeed;

        float currentMoveSpeed = baseSpeed;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentMoveSpeed *= SpeedMultiplier;
        }

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
            spriteRenderer.flipX = false;
        }

        if (movement != Vector3.zero)
        {
            transform.Translate(movement * currentMoveSpeed * Time.deltaTime);
        }

        float currentSpeed = movement != Vector3.zero ? currentMoveSpeed : 0f;
        animator.SetFloat("Speed", currentSpeed);

        // 속도 변화가 있을 때만 콘솔 출력
        if (currentSpeed != lastSpeed)
        {
            Debug.Log("현재 속도: " + currentSpeed);
            lastSpeed = currentSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            Debug.Log("점프!");
        }
    }





}