using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : player {

	void Start () {
        this.HP = 100;
        this.Speed = 0.2f;
        //防御值
        this.defenseValue = 10f;
        //攻击值
        this.attackValue = 5f;
        this.attackValue2 = 6f;
        //攻击距离
        this.attackDistance = 0.3f;
        //侦查距离
        this.detectionDistance = 1f;
        //攻击间隔
        this.attackTime = 0.5f;
	}
    public override void SetPath(Path path)
    {
        this.path = path;
        print(this.path.name);
        current = path.GetFirstPoint();
        print(current.Next.transform.name);
        transform.position = current.transform.position;
       
    }
    //public override void Move()
    //{
    //    if (current.Next != null && current.Next != null)
    //    {
    //        Point next = current.Next;
    //        Vector2 playerXZ = new Vector2(transform.position.x, transform.position.z);
    //        Vector2 targetXZ = new Vector2(next.transform.position.x, next.transform.position.z);
    //        RaycastHit hit;
    //        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 10f))
    //        {
    //            Vector2 result = Vector2.MoveTowards(playerXZ, targetXZ, Speed * Time.deltaTime);
    //            transform.position = new Vector3(result.x, hit.point.y +0.01f, result.y);
    //            transform.rotation = Quaternion.LookRotation(next.transform.position - current.transform.position);
    //            //print(hit.point);
    //        }
    //       // print("budong");
    //        float distance = Vector2.Distance(playerXZ, targetXZ);
    //        if (distance < 0.01f)
    //        {
    //            current = current.Next;
    //        }
    //    }
    //}
   
}
