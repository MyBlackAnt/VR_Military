using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //血量
    protected float HP ;
    //移动速度
    protected float Speed ;
    //防御值
    protected float defenseValue;
    //攻击力
    protected float attackValue;
    protected float attackValue2;
    //攻击距离
    protected float attackDistance;
    //侦查距离
    protected float detectionDistance ;
    //攻击间隔时间
    protected float attackTime;

    float time;
    protected bool isFind = false;
    protected Path path;
    protected string myTag;
    //获取路径的第一个点
    protected Point current;
	void Start ()
    {
        time = attackTime;
    }

    void Update()
    {
        FindEnemyAndAutoAttack();
        if (!isFind)
        {
            Move();
        }
    }
    public virtual void SetTag(string tag)
    {
        myTag = tag;

    }
    public virtual void SetPath(Path path)
    {
        this.path = path;
        current = path.GetFirstPoint();
       // print(current.Next.transform.name);

        transform.position = current.transform.position;
    }
    public virtual void FindEnemyAndAutoAttack()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag(myTag);
        List<GameObject> myEnemy = new List<GameObject>();
        myEnemy.AddRange(enemy);
        myEnemy.Remove(this.gameObject);

        if (myEnemy.Count>0)
        {
            for (int i = 0; i < myEnemy.Count; i++)
            {
                if (Vector3.Distance(myEnemy[i].transform.position, this.transform.position) < attackDistance)
                {

                    isFind = true;
                    time += Time.deltaTime;
                    if (time >= attackTime)
                    {
                        float a = Random.Range(attackValue,attackValue2);
                        enemy[i].GetComponent<player>().Attacked(a);
                        GetComponent<Animator>().SetTrigger("attack");
                        time = 0f;
                    }
                }
            }
        }
        else
        {
            isFind = false;
            GetComponent<Animator>().SetTrigger("run");
        }
        
        print(isFind);
    }

    public virtual void Move()
    {
        if (current.Next != null && current.Next != null)
        {
            Point next = current.Next;
            Vector2 playerXZ = new Vector2(transform.position.x, transform.position.z);
            Vector2 targetXZ = new Vector2(next.transform.position.x, next.transform.position.z);
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 10f))
            {
                Vector2 result = Vector2.MoveTowards(playerXZ, targetXZ, Speed*Time.deltaTime);
                transform.position = new Vector3(result.x, hit.point.y+0.01f, result.y);
                transform.rotation = Quaternion.LookRotation(next.transform.position - current.transform.position);
            }
            float distance = Vector2.Distance(playerXZ, targetXZ);
            if (distance < 0.01f)
            {
                current = current.Next;
            }
        }
    }

    public virtual bool Attacked(float  attackValue)
    {
        bool isDid = false;
        float damage = attackValue / defenseValue*20;
        if (HP - damage > 0)
            HP -= damage;
        else
        {
            isDid = true;
            HP = 0;
            Die();
        }
        return isDid;
    }


    public virtual void Die()
    {
        FindObjectOfType<Game>().RemovePlayer(this);
        GameObject.Destroy(this.gameObject);
    }

    
}
