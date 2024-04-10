using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    public float timeRemaining = 60;
    public Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
        
    }
    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdownText.text = "Time: " + timeRemaining.ToString();
        }
        countdownText.text = "Time's up!";
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.Translate(movement * 5f * Time.deltaTime);
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {
            Debug.Log("Lose");
            Vector2 fistPosition = new Vector2(-8, 1);
            transform.position = fistPosition;
        }
        if (collision.gameObject.name.Equals("Box"))
        {
            Debug.Log("Win");
            LoadNextScene();
        }
        if (collision.gameObject.name.Equals("Pinwheel"))
        {
            Vector2 fistPosition = new Vector2(-8, 0);
            transform.position = fistPosition;
        }
        if (collision.gameObject.tag.Equals("RangCua"))
        {
            Debug.Log("Lose");
            Vector2 fistPosition = new Vector2(-5, 3);
            transform.position = fistPosition;
        }
        if (collision.gameObject.tag.Equals("CircleScenes3"))
        {
            Debug.Log("Lose");
            Vector2 fistPosition = new Vector2(-5, 3);
            transform.position = fistPosition;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("MapEdge"))
    {
        Debug.Log("xxxx");
        Vector2 fistPosition = new Vector2(-9, 0);
        transform.position = fistPosition;

    }
}
}
