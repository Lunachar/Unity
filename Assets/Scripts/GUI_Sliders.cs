using UnityEngine;


public class GUI_Sliders : MonoBehaviour
{
    [SerializeField]
    [Header("Отладочная переменная")]
    [Range(0, 100)]
    [Tooltip("Значение в диапазоне от 0 до 100")]
    private float mySlider = 1.0f; //положение пользовательского слайдера
    [SerializeField][TextArea(5, 10)] private string my2Slider;
    [SerializeField] private int my3Slider = 1;

    public Color myColor;           // Градиент цвета
    public MeshRenderer GO;         // Ссылка на рендер объекта

    private void OnGUI()
    {
        mySlider = LabelSlider(new Rect(10, 10, 200, 20), mySlider, 5.0f, "My Slider"); // Отрисовка пользовательского слайдера
        myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor); // Отрисовка пользовательского набора слайдеров
        GO.material.color = myColor; // Покраска объекта
    }

    // Отрисовка пользовательского слайдера
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText) // Добавить MinValue
    {
        // Создаем прямоугольник с координатами в пространстве и заданой шириной и высотой
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);  // создаем Label на экране    
        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue); //Вырисовываем слайдер и считываем его положение
        return sliderValue; // Возвращаем значение слайдера
    }

    // Отрисовка тройной слайдер группы, каждый слайдер отвечает за свой цвет 
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // Используя пользовательский слайдер, создаем его
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");

        // Делаем промежуток
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "alpha");

        return rgb; //Возвращаем цвет

    }
}
