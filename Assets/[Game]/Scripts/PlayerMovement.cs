using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI _countText;
    public TextMeshProUGUI _winText;
    private Rigidbody rb ;
    private int _count;
    void SetCountText()
    {
        _countText.text = "Count: " + _count.ToString();
        if (_count >=3)
        {
            _winText.text = "KAZANDIN!";
        }
    }

    private void Start()
    {
        Debug.Log("Oyun Baþladý");
        rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText ();
        _winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1;
            SetCountText ();
            Debug.Log("+1 Altýn. Toplam Altýnýnýz: " + _count);
        }

    }
}