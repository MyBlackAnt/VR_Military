using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPath : MonoBehaviour
{
    private List<Point> pointList = new List<Point>();

    void Awake()
    {
        //获取每个点上的 point组件
        Point[] points = GetComponentsInChildren<Point>();

        Point[] AIPoints=new Point[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            AIPoints[i] = points[points.Length - i - 1];
        }
        for (int i = 0; i < AIPoints.Length; i++)
        {
            print(AIPoints[i].transform.name);
        }
        //加到pointlist里
        pointList.AddRange(AIPoints);
        //print(pointList.Count);

        for (int i = 0; i < AIPoints.Length; i++)
        {
            if (i == 0)
            {
                AIPoints[i].Previous = null;
                AIPoints[i].Next = AIPoints[i + 1];
            }
            else if (i == AIPoints.Length - 1)
            {
                AIPoints[i].Previous = AIPoints[i - 1];
                AIPoints[i].Next = null;
            }
            else
            {
                AIPoints[i].Previous = AIPoints[i - 1];
                AIPoints[i].Next = AIPoints[i + 1];
            }

        }
    }
    public Point GetFirstPoint()
    {
        return this.pointList[0];
        
    }

}
