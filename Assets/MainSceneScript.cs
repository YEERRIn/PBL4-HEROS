using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneScript : MonoBehaviour
{
    public TMP_InputField policeInputField;
    public Toggle subwayToggle;

    public void StartSimulation()
    {
        // 'Simulation Option' �˾�â���� �Է��� ���� �����ͼ� ������ ����
        int policeCount = int.Parse(policeInputField.text);
        bool subwayNoStopping = subwayToggle.isOn;

        // 'SimulationScene'�� ������ ���� PlayerPrefs�� ����
        PlayerPrefs.SetInt("PoliceCount", policeCount);
        PlayerPrefs.SetInt("SubwayNoStopping", subwayNoStopping ? 1 : 0); //������ �ɼ� ���ý� 0

        // 'SimulationScene'���� �̵�
        SceneManager.LoadScene("SimulationScene");
    }
}
