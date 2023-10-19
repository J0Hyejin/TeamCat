using UnityEngine;

public class SoulManager : MonoBehaviour
{
    [SerializeField]
    int soulNum = 0;
    int[] soulPoz = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    [SerializeField]
    AudioSource sound;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Soul"))
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            string a = PlayerPrefs.GetString("Soul");
            Debug.Log(a);
            string[] temp = PlayerPrefs.GetString("Soul").Split(',');
            for(int i = 0; i < 9; i++)
                soulPoz[i] = int.Parse(temp[i]);
            if (soulPoz[soulNum] == 1)  //�̹� �ҿ��� ȹ���� ���
                this.gameObject.SetActive(false);
            else  //���� �� ���� ���
                this.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("soul get");
            this.gameObject.SetActive(false);
            soulPoz[soulNum] = 1;
            string temp = "";
            for (int i = 0; i < 8; i++)
                temp += soulPoz[i] + ",";
            temp += soulPoz[8];
            PlayerPrefs.SetString("Soul", temp);
            if (!sound)
                Debug.Log("sound is missing");
            else
                sound.Play();

        }
    }
}
