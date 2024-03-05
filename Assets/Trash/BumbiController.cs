using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumbiController : MonoBehaviour
{

  // Update is called once per frame
  void Update()
  {

    if (Input.GetAxisRaw("Fire1") > 0)
    {
      // GetComponent<Animator>().SetTrigger("Jump");
      // GetComponent<Animator>().SetFloat("x", 3);

      GetComponent<Animator>().Play("Rotate");
    }

  }
}
