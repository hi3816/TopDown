using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 "Wall" 태그를 가지고 있는지 확인
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);  // 화살 오브젝트를 파괴
        }
    }
}