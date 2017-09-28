using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    private List<Point> pointList = new List<Point>();

	void Awake () {
        //获取每个点上的 point组件
        Point[] points = GetComponentsInChildren<Point>();
        //加到pointlist里
        pointList.AddRange(points);
        //print(pointList.Count);

        for (int i = 0; i < points.Length; i++) {
            if (i == 0) {
                points[i].Previous = null;
                points[i].Next = points[i + 1];
            }
            else if (i == points.Length - 1) {
                points[i].Previous = points[i - 1];
                points[i].Next = null;
            }
            else
            {
                points[i].Previous = points[i - 1];
                points[i].Next = points[i + 1];
            }

        }
	}

    public Point GetFirstPoint() {
        return this.pointList[0];
    }

	void Update () {
		
	}
}
