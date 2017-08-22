using UnityEngine;

public class Bullet1 : MonoBehaviour {

    private Transform target;

    /* 공격 속도(AttackRrate)와 별개로 총알이 날아가는 속도 */
    public float speed = 70f;

    // Update is called once per frame
    void Update()
    {
        FindTarget();
    }

    /* 웨폰으로부터 타겟을 전송받음. */
    public void Seek(Transform _target)
    {
        target = _target;
    }
	
    /* 슛할지 판단한다. */
    private void FindTarget()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position; //나(불릿)로부터 타겟으로의 방향
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    /* target에 shoot한다.*/
    private void HitTarget()
    {
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
