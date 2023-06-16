using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]
public class FloatVariableSO : ScriptableObject
{
    private float value;
    public UnityEvent<float> onChange;
    public UnityEvent onMaxValue;
    public float maxValue = 17.88f;
    public float MaxValue { get => maxValue; set => maxValue = value; }
    public float Value
    {
        get => value;
        set
        {
            if (this.value != value)
            {
                this.value = value;
                onChange?.Invoke(this.value);
                if (this.value == maxValue)
                {
                    onMaxValue?.Invoke();
                }
            }
        }
    }
}
