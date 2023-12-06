// ColorChanger.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public theNumberOfPeople objectCounter; // Unity �����Ϳ��� ������ ObjectCounter ������Ʈ
    public Image color1Image; // Unity �����Ϳ��� ������ Image ������Ʈ
    public Image color2Image;
    public Image color3Image;
    public Image color4Image;

    private void Update()
    {
        if (objectCounter == null)
        {
            Debug.LogWarning("ObjectCounter ������Ʈ�� �Ҵ���� �ʾҽ��ϴ�. Unity �����Ϳ��� ObjectCounter ������Ʈ�� �Ҵ����ּ���.");
            return;
        }

        int objectsOnPlane = objectCounter.GetObjectsOnPlaneCount();

        // ��� ���� ���� Canvas�� Image UI�� ���� ����
        if (objectsOnPlane >= 150)
        {
            ChangeColor(color1Image, Color.red); // ������ (Red)
            ChangeColor(color2Image, Color.red);
            ChangeColor(color3Image, Color.red);
            ChangeColor(color4Image, Color.red);
        }
        else if (objectsOnPlane >= 100)
        {
            ChangeColor(color1Image, new Color(1f, 0.5f, 0f)); // ��Ȳ�� (Orange)
            ChangeColor(color2Image, new Color(1f, 0.5f, 0f));
            ChangeColor(color3Image, new Color(1f, 0.5f, 0f));
            ChangeColor(color4Image, new Color(1f, 0.5f, 0f));
        }
        else if (objectsOnPlane >= 50)
        {
            ChangeColor(color1Image, Color.yellow); // ����� (Yellow)
            ChangeColor(color2Image, Color.yellow);
            ChangeColor(color3Image, Color.yellow);
            ChangeColor(color4Image, Color.yellow);
        }
        else
        {
            ChangeColor(color1Image, Color.green); // �ʷϻ� (Green)
            ChangeColor(color2Image, Color.green);
            ChangeColor(color3Image, Color.green);
            ChangeColor(color4Image, Color.green);
        }
    }

    // Image�� ������ �����ϴ� �Լ�
    private void ChangeColor(Image image, Color newColor)
    {
        if (image != null)
        {
            image.color = newColor;
        }
        else
        {
            Debug.LogWarning("Image ������Ʈ�� �Ҵ���� �ʾҽ��ϴ�. Unity �����Ϳ��� Image ������Ʈ�� �Ҵ����ּ���.");
        }
    }
}
