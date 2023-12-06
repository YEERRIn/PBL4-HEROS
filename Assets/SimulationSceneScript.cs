using UnityEngine;
using UnityEngine.UI;

public class SimulationSceneScript : MonoBehaviour
{
    public Text policeCountText;
    public Text subwayNoStoppingText;

    void Start()
    {
        // 'SimulationScene'���� PlayerPrefs���� ���� �����ͼ� Text UI�� ǥ��
        int policeCount = PlayerPrefs.GetInt("PoliceCount", 0);
        bool subwayNoStopping = PlayerPrefs.GetInt("SubwayNoStopping", 0) == 1;

        policeCountText.text = policeCount.ToString();
        subwayNoStoppingText.text = subwayNoStopping ? "������" : "����";
    }
}