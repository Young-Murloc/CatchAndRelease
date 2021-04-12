/*
 * 몬스터와 만난적이 있다면 도감에 등록
 * 서버DB에 데이터를 저장 -> 첫 실행시 DB에서 데이터를 불러와서 isContact 변수 값 수정
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDB : MonoBehaviour
{
    private string[] monstersName = new string[10];      // 몬스터 이름
    private bool[] isContact = new bool[10];             // 만난적이 있는지 확인
    private string[] monstersDescribe = new string[10];   // 몬스터 설명

    private void Start()
    {
        // 서버에서 필요한 정보를 불러오기
        setContactBat();
        setDescribeBat("Bat");

        setContactBrain();
        setDescribeBrain("Brain");

        setContactDwarf();
        setDescribeDwarf("Dwarf");

        setContactMushroom();
        setDescribeMushroom("Mushroom");
    }


    //박쥐
    public void setContactBat()
    {
        isContact[0] = true;
    }

    public bool getContactBat()
    {
        return isContact[0];
    }

    public void setDescribeBat(string describe)
    {
        monstersDescribe[0] = describe;
    }

    public string getDescribeBat()
    {
        return monstersDescribe[0];
    }


    //뇌
    public void setContactBrain()
    {
        isContact[1] = true;
    }

    public bool getContactBrain()
    {
        return isContact[1];
    }

    public void setDescribeBrain(string describe)
    {
        monstersDescribe[1] = describe;
    }

    public string getDescribeBrain()
    {
        return monstersDescribe[1];
    }


    //드워프
    public void setContactDwarf()
    {
        isContact[2] = true;
    }

    public bool getContactDwarf()
    {
        return isContact[2];
    }

    public void setDescribeDwarf(string describe)
    {
        monstersDescribe[2] = describe;
    }

    public string getDescribeDwarf()
    {
        return monstersDescribe[2];
    }


    //눈알
    public void setContactEyeball()
    {
        isContact[3] = true;
    }

    public bool getContactEyeball()
    {
        return isContact[3];
    }

    public void setDescribeEyeball(string describe)
    {
        monstersDescribe[3] = describe;
    }

    public string getDescribeEyeball()
    {
        return monstersDescribe[3];
    }


    //가스트
    public void setContactGhast()
    {
        isContact[4] = true;
    }

    public bool getContactGhast()
    {
        return isContact[4];
    }

    public void setDescribeGhast(string describe)
    {
        monstersDescribe[4] = describe;
    }

    public string getDescribeGhast()
    {
        return monstersDescribe[4];
    }


    //모노리스
    public void setContactMonolith()
    {
        isContact[5] = true;
    }

    public bool getContactMonolith()
    {
        return isContact[5];
    }

    public void setDescribeMonolith(string describe)
    {
        monstersDescribe[5] = describe;
    }

    public string getDescribeMonolith()
    {
        return monstersDescribe[5];
    }

    
    //버섯
    public void setContactMushroom()
    {
        isContact[6] = true;
    }

    public bool getContactMushroom()
    {
        return isContact[6];
    }

    public void setDescribeMushroom(string describe)
    {
        monstersDescribe[6] = describe;
    }

    public string getDescribeMushroom()
    {
        return monstersDescribe[6];
    }


    //슬라임
    public void setContactSlime()
    {
        isContact[7] = true;
    }

    public bool getContactSlime()
    {
        return isContact[7];
    }

    public void setDescribeSlime(string describe)
    {
        monstersDescribe[7] = describe;
    }

    public string getDescribeSlime()
    {
        return monstersDescribe[7];
    }


    //뱀
    public void setContactSnake()
    {
        isContact[8] = true;
    }

    public bool getContactSnake()
    {
        return isContact[8];
    }

    public void setDescribeSnake(string describe)
    {
        monstersDescribe[8] = describe;
    }

    public string getDescribeSnake()
    {
        return monstersDescribe[8];
    }


    //좀비
    public void setContactZombie()
    {
        isContact[9] = true;
    }

    public bool getContactZombie()
    {
        return isContact[9];
    }

    public void setDescribeZombie(string describe)
    {
        monstersDescribe[9] = describe;
    }

    public string getDescribeZombie()
    {
        return monstersDescribe[9];
    }


    // 몬스터 만난적 있는지 참조
    public bool[] GetContactInfo()
    {
        return isContact;
    }

    public string[] GetDescribeInfo()
    {
        return monstersDescribe;
    }
}
