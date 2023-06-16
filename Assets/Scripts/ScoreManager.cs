using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private FloatVariableSO carSpeed;
    private float distance;
    private float maxDistance;
    private bool newScore = false;

    private void Start()
    {
        newScore = false;
        maxDistance = PlayerPrefs.GetFloat("maxDistance");
    }
    void Update()
    {
        distance += carSpeed.Value * Time.deltaTime;
        if(distance > maxDistance)
        {
            maxDistance = distance;
            newScore = true;
            PlayerPrefs.SetFloat("maxDistance", maxDistance);
        }
    }
    public bool IsNewScore()
    {
        return newScore;
    }
    public float GetDistance()
    {
        return distance;
    }
    public float GetMaxDistance()
    {
        return maxDistance;
    }
}
