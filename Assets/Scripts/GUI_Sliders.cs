using UnityEngine;


public class GUI_Sliders : MonoBehaviour
{
    [SerializeField]
    [Header("���������� ����������")]
    [Range(0, 100)]
    [Tooltip("�������� � ��������� �� 0 �� 100")]
    private float mySlider = 1.0f; //��������� ����������������� ��������
    [SerializeField][TextArea(5, 10)] private string my2Slider;
    [SerializeField] private int my3Slider = 1;

    public Color myColor;           // �������� �����
    public MeshRenderer GO;         // ������ �� ������ �������

    private void OnGUI()
    {
        mySlider = LabelSlider(new Rect(10, 10, 200, 20), mySlider, 5.0f, "My Slider"); // ��������� ����������������� ��������
        myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor); // ��������� ����������������� ������ ���������
        GO.material.color = myColor; // �������� �������
    }

    // ��������� ����������������� ��������
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText) // �������� MinValue
    {
        // ������� ������������� � ������������ � ������������ � ������� ������� � �������
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);  // ������� Label �� ������    
        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue); //������������ ������� � ��������� ��� ���������
        return sliderValue; // ���������� �������� ��������
    }

    // ��������� ������� ������� ������, ������ ������� �������� �� ���� ���� 
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // ��������� ���������������� �������, ������� ���
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");

        // ������ ����������
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "alpha");

        return rgb; //���������� ����

    }
}
