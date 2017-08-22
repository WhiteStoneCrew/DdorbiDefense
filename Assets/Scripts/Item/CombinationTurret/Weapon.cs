using UnityEngine;

public class Weapon : MonoBehaviour {

    public WeaponDTO WeaponDTO { get; set; }
    public float FinalAttackPower { get; set; }

    private Transform target; // 타겟(Enemy)
    private string enemyTag = "Enemy"; // 타켓(Enemy) 태그

    /* 스크립트 컴포넌트에서 설정 */
    public GameObject bulletPrefab; 
    public Transform shootinhPoint;

    private float range;
    private float turnSpeed;
    private float attackRate;
    private float fireCountdown;

    // Use this for initialization
    void Start () {
        range = WeaponDTO.AttackRange;
        turnSpeed = WeaponDTO.TurnSpeed;
        attackRate = WeaponDTO.AttackRate;
        fireCountdown = 0f;

        InvokeRepeating("UpdateTarget", 0f, 0.5f); //0.5f마다 반복??
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            return;

        /* 회전체(무기)의 회전을 담당한다.
         * 회전할 방향을 구하고,
         * 회전 시킨다.*/
        Vector3 dir = target.position - transform.position; //방향을 타겟으로 한다.
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; // Lert()를 통해 회전을 스무스하게 해준다.
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / attackRate;
        }

        fireCountdown -= Time.deltaTime; // Time.deltaTime을 이용해 프레임이 몇이 되든 같은 속도로 슛!!
    }

    /* Enemy를 배열로 가져와서 거리를 구한다.
     * 그리고 가장 가까운 거리에 있는 Enemy를 찾는다.
     */
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            /* Enemy-Turret간의 거리를 구한다.
             */
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            /* 가장 가까운 거리에 있는 Enemy를 nearestEnemy에 받는다.
             */
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

            /* if, 가장 가까운적으로 인식된게 null이 아니고,
             * shortestDistance가 공격 범위안에 있으면,
             * target을 nearestEnemy.transform으로 받는다.
             * else, 그렇지 않으면 target을 비운다.
             */
            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }

    /* Enemy에게 불릿을 날린다.
     * - Bullet 클래스를 생성한다.
     * - Bullet에서 Destroy를 통해*/
    private void Shoot()
    {
        Debug.Log("SHOOT!");
        GameObject bulletGO = Instantiate(bulletPrefab, shootinhPoint.position, shootinhPoint.rotation); // Bullet을 만드는 인스턴스화 작업
        Bullet1 bullet = bulletGO.GetComponent<Bullet1>();

        Debug.Log("bullet :" + bullet);
        if (bullet != null)
            bullet.Seek(target);
    }

    /* 공격범위 기즈모 생성 */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
