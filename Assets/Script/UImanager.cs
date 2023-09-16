using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject increaseHealth;
    public GameObject increaseDamage;
    public GameObject increaseCritical;
    public GameObject damageText;
    public GameObject critText;
    public GameObject monsterDamageText;
    public Canvas gameCanvas;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void takeHealthPowerUp(GameObject character)
    {
        Debug.Log(character.transform.position);
        Vector3 spawnposition = Camera.main.WorldToScreenPoint(character.transform.position);

        Instantiate(increaseHealth, spawnposition, Quaternion.identity, gameCanvas.transform);

    }

    public void takeDamagePowerUp(GameObject character)
    {
        Debug.Log(character.transform.position);
        Vector3 spawnposition = Camera.main.WorldToScreenPoint(character.transform.position);

        Instantiate(increaseDamage, spawnposition, Quaternion.identity, gameCanvas.transform);

    }

    public void takeCriticalPowerUp(GameObject character)
    {
        Debug.Log(character.transform.position);
        Vector3 spawnposition = Camera.main.WorldToScreenPoint(character.transform.position);

        Instantiate(increaseCritical, spawnposition, Quaternion.identity, gameCanvas.transform);

    }

    public void DamageEnemy(GameObject character,float attack)
    {
        Debug.Log(character.transform.position);
        Vector3 spawnposition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText= Instantiate(damageText, spawnposition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        tmpText.text = attack.ToString();
    }

    public void CriticalDamageEnemy(GameObject character, float attack)
    {
        Debug.Log(character.transform.position);
        Vector3 spawnposition = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText = Instantiate(critText, spawnposition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        tmpText.text = attack.ToString();
    }

    public void MonsterDamage(GameObject character, float attack)
    {
        Debug.Log(character.transform.position);
        Vector3 spawnposition = Camera.main.WorldToScreenPoint(character.transform.position);
        spawnposition.y += 100;
        TMP_Text tmpText = Instantiate(monsterDamageText, spawnposition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        tmpText.text = attack.ToString();
    }

    public void heal(GameObject character,float heal)
    {
        Debug.Log(character.transform.position);
        Vector3 spawnposition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText= Instantiate(increaseHealth, spawnposition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        tmpText.text ="+"+ heal.ToString();
        tmpText.fontSize += 30;
    }

}
