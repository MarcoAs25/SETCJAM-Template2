using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager Instance { get; private set; }
    [SerializeField]
    private FloatVariableSO carSpeed;
    [SerializeField]
    private AnimationCurve animationCurveSpeed;
    [SerializeField]
    private float maxSpeedIn = 5f;
    private float timeElapsed = 0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        timeElapsed = 0f;
        carSpeed.Value = 0f;
    }
    private void Update()
    {
       
        timeElapsed += Time.deltaTime;
        carSpeed.Value = animationCurveSpeed.Evaluate(timeElapsed / maxSpeedIn) * carSpeed.MaxValue;
    }
}
