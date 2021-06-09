using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticBeziers : MonoBehaviour
{
    [Header("Positions")]
    public Transform posA;
    public Transform posB;
    public Transform posC;
    float t;
    [Header("Objects")]
    public Transform obj0;
    public Transform obj1;
    public Transform obj2;

    private void Update() {
        t += Time.deltaTime * 0.3f;
        Vector2 posE = Blend(posA.position.x, posB.position.x, posA.position.y, posB.position.y, t);
        Vector2 posF = Blend(posB.position.x, posC.position.x, posB.position.y, posC.position.y, t);
        Vector2 posP = Blend(posE.x, posF.x, posE.y, posF.y, t);

        //print("posE : " + posE + "/" + "posF : " + posF + "/" + "posP : " + posP);

        float distance0 = (posB.position - obj0.position).magnitude;
        float distance1 = (posC.position - obj1.position).magnitude;
        float distance2 = (posC.position - obj2.position).magnitude;

        print("distance0 : " + distance0 + "/" + "distance1  : " + distance1  + "/" + "distance2 : " + distance2);

        if(distance0 < 0.1f){
            return;
        }
        obj0.transform.position = posE;
        obj1.transform.position = posF;
        obj2.transform.position = posP;
    }

    private Vector2 Blend(float x1, float x2, float y1, float y2, float time)
    {
        float x = Blender(x1, x2, time);
        float y = Blender(y1, y2, time);

        Vector2 value = new Vector2(x, y);
        return value;
    }

    private float Blender(float A, float B, float time)
    {
        if(time == 0){
            return A;
        }

        if(time == 1){
            return B;
        }

        return ((1 - time) * A) + (time * B);
    }
}
