using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���̺귯��
using UnityEngine.SceneManagement; // �� ���� ���̺귯��

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���ӿ����� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText; // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText; // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime; // ���� �ð�
    private bool isGameover; // ���ӿ��� ����
    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0f;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            //���� �ð� ����
            surviveTime += Time.deltaTime;
            //������ ���� �ð��� timeText �ؽ� ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            //���� ���� ���¿��� R Ű�� ���� ���
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene ���� �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    
    public void EndGame()
    {
        //���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        // ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        // BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviveTime > bestTime)
        {
            // �ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;
            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //  �ְ� ����� recordtext �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        recordText.text = "Best Time: " + (int)bestTime;
    }
}
