using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int pos = 0;
    [SerializeField]
    private float moveCarInTime = 0.8f;
    [SerializeField]
    private FloatVariableSO carSpeed;
    [SerializeField]
    private AudioSource audiocar;
    private float distancePos = 1.13f;
    private Vector3 initialPosition;
    
    void Start()
    {
        initialPosition = transform.position;
        audiocar = GetComponent<AudioSource>();
        carSpeed.onChange.AddListener(ChangePitch);
    }
    public void ChangePitch(float value)
    {
        audiocar.pitch = 0.22f + value / 10f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pos = Mathf.Clamp(pos - 1, -2, 2);
            StartCoroutine(MoveCar());
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            pos = Mathf.Clamp(pos + 1, -2, 2);
            StartCoroutine(MoveCar());
        }
        
    }
    IEnumerator MoveCar()
    {
        Vector3 fromPos = transform.position;
        Vector3 Endpos = (initialPosition + Vector3.right * (pos * distancePos));

        for (float t = 0f; t <= 1; t += Time.deltaTime / moveCarInTime)
        {

            transform.position = Vector3.Lerp(fromPos, Endpos, t);

            yield return null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
