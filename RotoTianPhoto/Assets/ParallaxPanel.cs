using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParallaxPanel : MonoBehaviour {

    public float y_maxRot, y_pos;
    public float x_maxRot, x_pos;
    public float speed;
    RectTransform rect;
    public RectTransform recToRotate;
    Vector2 targetEulerAngles = Vector3.zero;
    Vector2 targetPos = Vector2.zero;
    // Use this for initialization
    void Start () {
        rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 diff = (Vector2)transform.position - (Vector2)Input.mousePosition;
        if (Mathf.Abs(diff.x)<=(rect.sizeDelta.x*0.5f) && Mathf.Abs(diff.y)<=(rect.sizeDelta.y *0.5f))
        {
            float offset_x = -Mathf.Clamp(diff.x/(rect.sizeDelta.x*0.5f),-1,1);
            float offset_y = -Mathf.Clamp(diff.y / (rect.sizeDelta.y * 0.5f), -1, 1);
            targetEulerAngles = new Vector3(x_maxRot*offset_x, y_maxRot* offset_y,0);
            targetPos = new Vector3(x_pos*offset_x,y_pos*offset_y,0);
        }else
        {
            targetEulerAngles = Vector3.zero;
            targetPos = Vector3.zero;
        }
        recToRotate.eulerAngles = AngleLerp(recToRotate.eulerAngles, targetEulerAngles, speed * Time.deltaTime);
        recToRotate.anchoredPosition = Vector2.Lerp(recToRotate.anchoredPosition,targetPos,speed*Time.deltaTime);

    }

    public static Vector3 AngleLerp(Vector3 startAngle,Vector3 finshAngle,float t)
    {
        return new Vector3(
            Mathf.LerpAngle(startAngle.x,finshAngle.x,t),
            Mathf.LerpAngle(startAngle.y, finshAngle.y, t),
            Mathf.LerpAngle(startAngle.z, finshAngle.z, t)
            );
    }
}
