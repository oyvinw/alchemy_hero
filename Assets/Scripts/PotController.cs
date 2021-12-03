using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PotController : MonoBehaviour
{
    public Substance[] _ingredients;

    public Substance brew { get; private set; }

    private SpriteRenderer _brewRenderer;
    private Light2D[] _lights;
    private Flicker _flicker;
    private Color _brewColor;
    private AudioSource _audioSource;

    private int testCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        _brewRenderer = GetComponentInChildren<SpriteRenderer>();
        _lights = GetComponentsInChildren<Light2D>();
        _flicker = GetComponent<Flicker>();
        _audioSource = GetComponent<AudioSource>();
        _brewColor = _brewRenderer.color;
    }

    private void Awake()
    {
        brew = new Substance();
    }

    public void AddIngredient(Substance sub)
    {
        float poisonThreshold = -10;
        brew.Add(sub);
        if(brew.stats.toxic <= poisonThreshold && sub.stats.toxic <= 0)
		{
            float thresholdDiff = brew.stats.toxic + poisonThreshold;
            _audioSource.volume = -((thresholdDiff/10) * (float)0.1);
            _audioSource.Play();
		}
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        _brewRenderer.color = brew.stats.color;
        _flicker.UpdateColor(brew.stats.color);
        foreach (Light2D light in _lights)
        {
            light.color = brew.stats.color;
        }
    }

    public void EmptyPot()
    {
        brew = new Substance();
        brew.stats.color = _brewColor;
        UpdateVisuals();
    }
}
