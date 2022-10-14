using UnityEngine;
using UnityEditor;

public class Window : EditorWindow
{

    public Color myColor;           // Градиент цвета
    public MeshRenderer GO;         // Ссылка на рендер объекта

    public Material newMat;
    private Transform MainCam;

    [MenuItem("Инструменты /Окна /Генератор префабов")]
    public static void ShowMyWindow()
    {
        GetWindow(typeof(Window), false, "Генератор префабов");
    }

    private void OnGUI()
    {
        GO = EditorGUILayout.ObjectField("Мэш объекта", GO, typeof(MeshRenderer), true) as MeshRenderer;
        newMat = EditorGUILayout.ObjectField("Материал объекта", newMat, typeof(Material), true) as Material;

        if (GO)
        {
            myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor); // Отрисовка пользовательского набора слайдеров
            GO.sharedMaterial.color = myColor; // Покраска объекта
        }
        else
        {

        }
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
        screenRect.y += 20;
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
