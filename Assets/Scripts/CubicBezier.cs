using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicBezier : MonoBehaviour
{
    [Header("Positions")]
    public Transform posA;
    public Transform posB;
    public Transform posC;
    public Transform posD;
    float t;

    [Header("Objects")]
    public Transform obj;

    public float time;


    private void Update() {
        t += Time.deltaTime;
        // Vector2 posE = Blend(posA.position.x, posB.position.x, posA.position.y, posB.position.y, t);
        // Vector2 posF = Blend(posB.position.x, posC.position.x, posB.position.y, posC.position.y, t);
        // Vector2 posG = Blend(posC.position.x, posD.position.x, posC.position.y, posD.position.y, t);
        // Vector2 posQ = Blend(posE.x, posF.x, posE.y, posF.y, t);
        // Vector2 posR = Blend(posF.x, posG.x, posF.y, posG.y, t);
        // Vector2 posP = Blend(posQ.x, posR.x, posQ.y, posR.y, t);

        // 아래와 같이 cubicBezier()를 이용해 그릴 수도 있다.
        float x = CubicBezierFunc(posA.position.x, posB.position.x, posC.position.x, posD.position.x, t);
        float y = CubicBezierFunc(posA.position.y, posB.position.y, posC.position.y, posD.position.y, t);
        Vector2 pos = new Vector2(x, y);

        float distance = (posD.position - obj.position).magnitude;

        if(distance < 0.1f){
            return;
        }
        obj.transform.position = pos;
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

    private float CubicBezierFunc(float A, float B, float C, float D, float time)
    {
        if (time == 0) {
            return A;
        }
        
        if( time == 1) {
            return C;
        }
        
        float s = 1 - t;
        
        // P = s³A + 3(s²t)B + 3(st²)C + t³D  
        float result = (Mathf.Pow(s, 3) * A + 
            3 * (Mathf.Pow(s, 2) * t) * B + 
            3 * (s * Mathf.Pow(t, 2)) * C + 
            Mathf.Pow(t, 3) * D);

        return result;
    }
}
