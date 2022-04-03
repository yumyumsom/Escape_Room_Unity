using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements. public class Example : MonoBehaviour { public InputField mainInputField; // Checks if there is anything entered into the input field. void LockInput(InputField input) { if (input.text.Length > 0) { Debug.Log("Text has been entered"); } else if (input.text.Length == 0) { Debug.Log("Main Input Empty"); } } public void Start() { //Use onEndEdit mainInputField.onEndEdit.AddListener(delegate{LockInput(mainInputField);}); //Use onSubmit mainInputField.onSubmit.AddListener(delegate{LockInput(mainInputField);}); } }
public class Submit : MonoBehaviour
{
    public static int key = 0;
    public GameObject pass; // 게임오브젝트로 받기



    public void check1(InputField f) //InputField를 f로 선언
    {
        //  while (ture)
        {
            if (f.text == "clock") //InputField에 text를 검사하여 @일때 실행
            {

                print("지금 우리학교는 ");
                pass.SetActive(false); // 입력받고 Ui창이 꺼짐

                //break;
            }
            else print("틀린답");
            //pass.SetActive(false);

        }

    }
}

