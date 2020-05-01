using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] public Transform _target;
    [SerializeField] public float _dampTime = 10f;
    [SerializeField] public Vector3 _offset; 

    private float margin = 0.1f;

    void LateUpdate() {
        if(_target) {
			float targetX = _target.position.x + _offset.x;
			float targetY = _target.position.y + _offset.y;

			if (Mathf.Abs(transform.position.x - targetX) > margin)
				targetX = Mathf.Lerp(transform.position.x, targetX, 1/_dampTime * Time.deltaTime);

			if (Mathf.Abs(transform.position.y - targetY) > margin)
				targetY = Mathf.Lerp(transform.position.y, targetY, _dampTime * Time.deltaTime);
            
			transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}
