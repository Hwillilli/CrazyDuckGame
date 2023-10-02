using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 cameraStartPos;
    public GameObject image; // 이미지 오브젝트를 연결합니다.
    public float smoothness = 0.1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cameraStartPos = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 touchCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = touchCurrentPos - touchStartPos;

            float imageWidth = image.GetComponent<Renderer>().bounds.size.x;
            float cameraWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
            float minX = image.transform.position.x - imageWidth / 2 + cameraWidth / 2;
            float maxX = image.transform.position.x + imageWidth / 2 - cameraWidth / 2;

            Vector3 newPosition = new Vector3(
                Mathf.Clamp(cameraStartPos.x - offset.x, minX, maxX),
                transform.position.y,
                transform.position.z
            );

            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothness);
        }
    }
}
