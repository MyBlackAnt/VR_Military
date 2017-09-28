using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : player {

    void Start() {
        this.HP = 200;
    }

    //public override void Move() {
    //    if (current != null && current.Next != null)
    //    {
    //        Point next = current.Next;
    //        transform.position = Vector3.MoveTowards(transform.position, next.transform.position, Speed*Time.deltaTime);
    //        float distance = Vector3.Distance(transform.position, next.transform.position);
    //        if (distance < 0.01f)
    //        {
    //            current = current.Next;
    //        }
    //    }
    //}

    public override void Die()
    {
        base.Die();
        print("坦克英勇牺牲...");
    }
}
