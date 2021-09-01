using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlipDir : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePos = Input.mousePosition.x - mainCamera.WorldToScreenPoint(transform.position).x;
        if (gameObject.tag == "Player" && SceneManager.GetActiveScene().name == "MainMenu"){
            if (mousePos > gameObject.transform.position.x && transform.localScale.x < 0){
                Flip();
            }
            else if (mousePos < gameObject.transform.position.x && transform.localScale.x > 0){
                Flip();
            }
        }
    }


    void Flip(){
        transform.localScale = new Vector3(-(Mathf.Sign(transform.localScale.x)) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
