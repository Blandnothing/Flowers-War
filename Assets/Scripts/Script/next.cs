using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform targetPosition; // 指定目标位置
    public float rotationAngle = 45f; // 旋转 45 度
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    public void OnButtonClick()
    {
        StartCoroutine(MoveCameraAndLoadScene());
    }

    IEnumerator MoveCameraAndLoadScene()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = cameraTransform.position;
        Quaternion startRotation = cameraTransform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotationAngle);

        while (elapsedTime < 1f) // 移动时间为1秒
        {
            cameraTransform.position = Vector3.Lerp(startPosition, targetPosition.position, elapsedTime / 1f);
            cameraTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 确保最终位置和旋转准确到达目标
        cameraTransform.position = targetPosition.position;
        cameraTransform.rotation = targetRotation;

        // 加载下一个场景
        SceneManager.LoadScene("dating");
    }
}