using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    /*
     * 충돌했을때 물체를 회전시키기위한 Script.
     * 이 Script는 Unity 2020.1.11f1 에서 정상 작동했음.
     * 조건 - Script를 Object에 컴포넌트로 붙여야 하며
     * https://docs.unity3d.com/kr/2018.4/Manual/CollidersOverview.html
     * 해당 문서의 충돌 조건에 부합해야 함.
     *     
     * OnTriggerEnter -> 해당 Script 컴포넌트를 붙인 Object가 상대 Trigger로 진입했을때 1회 실행.
     * OnTriggerStay -> 해당 Script 컴포넌트를 붙인 Object가 상대 Trigger에 머물러 있을동안 반복 실행.
     * OnTriggerExit -> 해당 Script 컴포넌트를 붙인 Object가 상대 Trigger로부터 존재하지 않을 경우 1회 실행.
     * (메서드 인자값 Collider obj는 Script를 붙인 Object가 아닌 부딪혀온 상대의 Object를 말함.)
     */

    Quaternion TempRotate;              // 충돌물체의 Transform Rotation Value 임시 저장.
    Vector3 TempVector;                 // 충돌물체의 Transform Vector3 Value 임시 저장.
    private float speed = 100.0f;       // Test를 위한 Rotate Speed Value.

    private void OnTriggerEnter(Collider obj)
    {
        TempRotate = obj.transform.rotation; // 해당 Object의 Transform Value를 저장.
        TempVector = obj.transform.position;
        Debug.Log("Enter Triggered!");
    }

    private void OnTriggerStay(Collider obj)
    {
        obj.transform.Rotate(Vector3.up * speed * Time.deltaTime); // Vector로 방향성을 주어 Speed Value * deltaTime 만큼 회전.
        Debug.Log("Running....");
    }

    private void OnTriggerExit(Collider obj)
    {
        obj.transform.rotation = TempRotate; // Enter당시에 저장했던 초기 TempRotate와 TempVector를 참조하여
        obj.transform.position = TempVector; // 원래 위치와 회전 값으로 복원함.
        Debug.Log("Exit Triggered!");
    }
}
