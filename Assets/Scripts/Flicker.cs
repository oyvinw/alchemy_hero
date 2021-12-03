using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Flicker : MonoBehaviour
{
    private Light2D[] _lights;
    private Color[] _lightColors;
    private float[] _intensitys;
    private float timerCurrent;

    [Range(0, 3)]
    public float flickerRate;

    [Range(0, 255)]
    public float colorFlicker;

    [Range(0, 100)]
    public float intensityFlicker;

    [Range(0, 1)]
    public float falloffFlicker;

    void Start()
    {
        _lights = GetComponentsInChildren<Light2D>();

        _lightColors = new Color[_lights.Length];
        _intensitys = new float[_lights.Length];

        for (int i = 0; i < _lights.Length; i++)
        {
            _lightColors[i] = _lights[i].color;
            _intensitys[i] = _lights[i].intensity;
        }
    }

    public void UpdateColor(Color color)
    {
        for (int i = 0; i < _lightColors.Length; i++)
        {
            _lightColors[i] = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerCurrent += Time.deltaTime;
        if (timerCurrent >= flickerRate)
        {
            float rChange = Random.Range(-colorFlicker, colorFlicker);
            float gChange = Random.Range(-colorFlicker, colorFlicker);
            float bChange = Random.Range(-colorFlicker, colorFlicker);

            float intensityChange = Random.Range(-intensityFlicker, intensityFlicker);

            for (int i = 0; i < _lights.Length; i++)
            {
                Color colorFlicker = new Color(
                    _lightColors[i].r + rChange,
                    _lightColors[i].g + gChange,
                    _lightColors[i].b + bChange
                    );

                _lights[i].color = colorFlicker;
                _lights[i].intensity = intensityChange + _intensitys[i];
            }

            timerCurrent = 0;
        }
    }
}
