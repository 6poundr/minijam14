using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Sprite[] images;
    public float timeBetweenImages = 5f;
    public Image imageComponent;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent= GetComponent<Image>();
        StartCoroutine("ShowImagesCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator ShowImagesCoroutine()
    {
        foreach (var sprite in images)
        {
            imageComponent.sprite = sprite;
            yield return new WaitForSeconds(timeBetweenImages);
        }

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
