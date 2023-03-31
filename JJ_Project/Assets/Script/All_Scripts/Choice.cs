using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;   //text UI사용을 위해 추가

public class Choice : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject MakePoint;
    List<GameObject> character = new List<GameObject>();
    GameObject tempPlayer;
    public GameObject CurrentCharacter; //캐릭터 선택 시 해당 변수 초기화하여 선택된 캐릭터로 플레이가능하게 해줌

    public static int selectedCharacter = 0;
    //public Text character;

    // Start is called before the first frame update
    private void Start()
    {
        characters = Resources.LoadAll<GameObject>("user");

        for (int i = 0; i < characters.Length; i++)
        {
            tempPlayer = Instantiate(characters[i].transform.gameObject, gameObject.transform);
            tempPlayer.transform.localScale = new Vector3(3, 3, 3);
            tempPlayer.transform.localPosition = MakePoint.transform.position;
            tempPlayer.SetActive(false);
            character.Add(tempPlayer);
        }

        character[selectedCharacter].SetActive(true);
        CurrentCharacter = character[selectedCharacter];
    }

    public void NextCharacter()
    {
        character[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter >= character.Count)
        {
            selectedCharacter = 0;
        }

        character[selectedCharacter].SetActive(true);
        CurrentCharacter = character[selectedCharacter];

    }


    public void PreviousCharacter()
    {
        character[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += character.Count;
        }

        character[selectedCharacter].SetActive(true);
        CurrentCharacter = character[selectedCharacter];
    }

   /*public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        character[selectedCharacter].SetActive(false);
    }*/
    
    public void Pick_Me()
    {
      CurrentCharacter.GetComponent<Animator>().SetTrigger("happy_dance");

    }
    
   
}