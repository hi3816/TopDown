using UnityEngine;

public class TopDownShooting : MonoBehaviour 
{
    private TopDownController controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    public GameObject testPrefab;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }

    void Start()
    {
        controller.OnAttackEvent += OnShoot;
        // OnLookEvent에 이제 두개가 등록되는 것(하나는 지난 시간에 등록했었죠? TopDownAimRotation.OnAim(Vec2)
        // 한 개의 델리게이트에 여러 개의 함수가 등록되어있는 것을 multicast delegate라고 함.
        // Action이나 Func도 델리게이트의 일종인 것 기억하시죠..?
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        aimDirection = newAimDirection;
    }

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        // 화살을 생성합니다.
        // TODO : 화살이 실제로 날라가게 구현 / 오브젝트 풀을 통한 구조 개선
        Instantiate(testPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }
}