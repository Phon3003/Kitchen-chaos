using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedVisual : MonoBehaviour
{
    private BaseCounter counter;

    private void Awake()
    {
        counter = GetComponentInParent<BaseCounter>();
        // Debug.Log("counter:" +counter);

    }

    void Start()
    {
        PlayerController.Instance.OnSelectedCounterChanged += PlayerSelectedCounterChanged;
        
        gameObject.SetActive(false);
    }

    private void PlayerSelectedCounterChanged(BaseCounter counter){
        if(counter == null){
            gameObject.SetActive(false);
        }
        else {
            if(counter == this.counter){
                gameObject.SetActive(true);
            }
            else {
                gameObject.SetActive(false);
            }
        }
    }
}
