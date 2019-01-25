using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {
    [SerializeField]
    private EffectPool pool;
	// Use this for initialization
	void Start () {
		
	}
#if UNITY_EDITOR
    // 에디터 전용 파트
#elif UNITY_ANDROID || UNITY_IOS
    // 안드로이드 디바이스 전용파트
#endif
    private Ray GenerateRay(Vector3 ScreenPoint)
    {
        Vector3 near = Camera.main.ScreenToWorldPoint(
                            new Vector3(ScreenPoint.x, ScreenPoint.y, Camera.main.nearClipPlane));
        Vector3 far = Camera.main.ScreenToWorldPoint(
                            new Vector3(ScreenPoint.x, ScreenPoint.y, Camera.main.farClipPlane));
        return new Ray(near, far - near);
    }

    private bool Touch()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = GenerateRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        GameObject effect = pool.GetFromPool((int)eEffectType.touch);
                        effect.transform.position = hit.point;
                        return true;
                    }
                }
            }
        }        
        return false;
    }

	
    // Update is called once per frame
	void Update () {

        if (Touch())
        {
            GameController.instance.Touch();
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GenerateRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    GameObject effect = pool.GetFromPool((int)eEffectType.touch);
                    effect.transform.position = hit.point;

                    GameController.instance.Touch();
                }
            }
        }
#endif
    }
}
