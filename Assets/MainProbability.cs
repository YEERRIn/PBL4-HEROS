using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainProbability : MonoBehaviour
{
    public theNumberOfPeople objectCounter; // Unity �����Ϳ��� ������ ObjectCounter ������Ʈ
    public Text accidentProbabilityText;

    void Update()
    {
        if (objectCounter == null)
        {
            Debug.LogWarning("ObjectCounter ������Ʈ�� �Ҵ���� �ʾҽ��ϴ�. Unity �����Ϳ��� ObjectCounter ������Ʈ�� �Ҵ����ּ���.");
            return;
        }

        int objectsOnPlane = objectCounter.GetObjectsOnPlaneCount();

        // ��� �߻� Ȯ�� ���
        float accidentProbability = (float)objectsOnPlane / 960f * 100f;

        // ��� �߻� Ȯ���� Text UI�� ǥ��
        accidentProbabilityText.text = accidentProbability.ToString("F2");

    }
}