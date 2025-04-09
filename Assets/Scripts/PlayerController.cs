using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { get; private set; }

        [SerializeField] float moveSpeed = 10f;
        [SerializeField] float rotationSpeed = 10f;
        [SerializeField] Animator animator;
        [SerializeField] float heightCast = 1.8f;
        [SerializeField] float radiusCast = 0.6f;
        [SerializeField] float distanceCast = 0.5f;
        [SerializeField] float selectDistance = 0.5f;
        
        public event Action<ClearCounter> OnSelectedCounterChanged;

        BaseCounter selectedCounter;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Tồn tại 1 playerController khác trong scene. Vui lòng xóa nó đi.");
            Destroy(gameObject);
            return;
        }

        Instance = this;

        OnSelectedCounterChanged += CounterChanged;
    }


    Vector2 HandleInput()
        {           
            Vector2 inputVector = new Vector2(0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                inputVector.y = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputVector.y = -1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputVector.x = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputVector.x = 1;
            }
            return inputVector;
        }
    void HandleSelect() {
        // Nếu không dùng interface - abstract class
        // ClearCounter clearCounter = hit.collider.GetComponent<ClearCounter>();
        // if (clearCounter != null) {
        //     clearCounter.Interact();
        // }

        // CuttingCounter cuttingCounter = hit.collider.GetComponent<CuttingCounter>();
        // if (cuttingCounter != null) {
        //     cuttingCounter.Interact();
        // }
        
        bool isHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, selectDistance);
        if (isHit == false)
        {
            // Debug.Log("No hit");
           SetSelectedCounter(null);
        }
        else
        {
           //Raycast ban trung vat the co collider 
           //Kiem tra xem collider ban trung co phai la counter khong
           ClearCounter counter = hit.collider.GetComponent<ClearCounter>();
           if (counter == null)
           {
                //Vat the ban trung khong phai la counter
                // Debug.Log("ban trung nhung khong phai la couter");
                SetSelectedCounter(null);
           } 
           else
           {
                //vat the ban trung chinh la couter
                // Debug.Log("ban trurng couter");
                SetSelectedCounter(counter);
           }
        }
    }

    private void SetSelectedCounter(ClearCounter counter){
        if(selectedCounter != counter) 
        {
            selectedCounter = counter;
            OnSelectedCounterChanged?.Invoke(counter);
        }
    }

    private void CounterChanged(ClearCounter counter){
        Debug.Log("Counter thay doi thanh: " + counter);
    } 

    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(selectedCounter != null)
                {
                    selectedCounter.Interact();
                }
            }

        HandleSelect();
        
        Vector2 inputVector = HandleInput();

        bool isWalking = inputVector != Vector2.zero;

        if (isWalking)
        {
            inputVector = inputVector.normalized;

            Vector3 moveVecter = new Vector3(inputVector.x, 0, inputVector.y);
            //check tuong 
            
            bool isBlocked = Physics.CapsuleCast(transform.position, transform.position + Vector3.up * heightCast, radiusCast, moveVecter, distanceCast);
            if (isBlocked)
            {
                // Debug.Log("Blocker");
                return;
            }
            transform.position +=  moveSpeed * Time.deltaTime * moveVecter;

            //xu ly huong
            // Debug.Log("forward: " + transform.forward + " moveVecter: " + moveVecter);
            transform.forward = Vector3.Slerp(transform.forward, moveVecter, Time.deltaTime * rotationSpeed);

        }

        // Animation
        animator.SetBool("IsWalking", isWalking);




    

        
    }
}
