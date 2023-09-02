using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 cameraStartPos;
    public GameObject image; // 이미지 오브젝트를 연결합니다.

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

            // 드래그 영역을 이미지 크기로 제한합니다.
            float imageWidth = image.GetComponent<Renderer>().bounds.size.x;
            float cameraWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
            float minX = image.transform.position.x - imageWidth / 2 + cameraWidth / 2;
            float maxX = image.transform.position.x + imageWidth / 2 - cameraWidth / 2;

            // 카메라의 X 위치를 조절합니다.
            Vector3 newPosition = new Vector3(
                Mathf.Clamp(cameraStartPos.x - offset.x, minX, maxX),
                transform.position.y,
                transform.position.z
            );

            transform.position = newPosition;
        }
    }
}
