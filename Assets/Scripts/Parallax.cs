using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    [SerializeField]
    private float velocity = 1f;
    [SerializeField]
    private FloatVariableSO carSpeed;
    private Material mat;
    
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    void Update()
    {
        mat.mainTextureOffset = new Vector2(mat.mainTextureOffset.x, mat.mainTextureOffset.y + carSpeed.Value * velocity * Time.deltaTime);
    }
}
