# CatchAndRelease

<h1>완료한 화면</h1>
<h2>메인화면</h2> 메인게임, 도감, 종료
출현하는 몬스터가 오른쪽에서 왼쪽으로 움직임  
<h2>도감화면</h2> 몬스터 리스트(스크롤뷰), 종료

몬스터DB를 통해 사용자가 만난적이 있는 몬스터인지 확인 후 그에 관련된 정보를 표시  
만난적이 있다면 몬스터와 설명 / 없다면 미싱 이미지와 ???설명  
<h2>로딩화면</h2> 진행바, 몬스터
씬 전환을 비동기 방식으로 구현   
<h2>게임리스트화면</h2> 게임선택, 종료, 해당 게임에 대한 설명 및 실행 팝업
<hr>
<h1>게임 종류</h1>
<h2>카드뒤집기</h2>
<h2>Gwent:ThroneBraker Puzzle</h2>

<hr>
0412 

monsterList: scrollView 안에 들어갈 몬스터 넣어두기(게임 내에서 몬스터를 수집 할 경우 해금)   
메인 화면과 연결 마무리

<hr>

0413

실제 게임 화면 구상

<hr>

0414
   
게임 스테이지 버튼으로 제작 -> 선택된 스테이지의 간략한 정보를 팝업창으로 소개

<hr>

0415

같은 그림 찾기를 위한 버튼을 눌렀을때 이미지가 뒤집어 지면서 몬스터 이미지가 나오는 모션 + 다시 되돌아가는 모션 구현

<hr>

0416

Retry 버튼 클릭시 화면 재시작 -> LoadScene으로 하면 제대로 작동을 안함 -> timescale값 조정   
점수 계산법 구현   

<hr>

0419   

궨트 보드 구성 / 턴 알려주는 토큰 -> 버튼 컴포넌트를 통해 Y로테이션, RGB 값 조정   
사용할 소스 파일들 구하기   
카드 local position -92.5/0/92.5

<hr>

0420   
   
BtnCtrl -> 버튼 꾹 누르는지 확인   
PanelManager -> 버튼 꾹 눌렀을때 설명 패널 팝업   
BackBtnManager -> 설명 패널에 뒤로가기 눌렀을때 생성된 패널 및 버튼 삭제   
   
CardManager -> 카드 능력 구현   
PlaceManager -> 카드 배치 구현   
    
<hr>

0421   
   
토큰 이동시 게롤트 방어구 증가 구현   
게롤트 클릭시 방어구 만큼 데미지 구현   
트리스 배치시 명령 재사용 가능 구현   
게롤트 방어구 얻을시 카드에 표시 구현
배치능력 재사용 구현

<hr>

0422   

게롤트 클릭시 방어구 만큼 데미지 구현   
게임 종료시 성공 및 실패 표시 패널 구현   
재시작 및 게임 종료 구현   

<hr>

0423   

궨트 마무리

<h1>처음부터 필요한 함수와 변수 등을 설계</h1>

0426   
   
미리 만들 스크립트 정하기   
   
1.DefenseBtnCtrl           -> 모든 오브젝트들이 가지는 스크립트 / 배치, 스킬사용, 퇴각, 해당 유닛 정보 표시   
2.DefenseFieldManager      -> DefenseTimeManager에서 시간 정보를 받아서 DefenseEnemyDB를 통해 적을 field에 출현시키고 적의 움직임을 관리   
3.DefenseSituationManager  -> DefenseFriendlyDB에서 아군의 공격 범위 정보를 받아서 적의 위치랑 비교 후 공격하는 과정을 관리   
4.DefenseTimeManager       -> 적이 출현하는 시간 및 코스트 계산하여 UiManager에 전달   
5.DefenseCostManager       -> 코스트 관리   
6.DefenseLifeCountManager  -> 목숨 관리   
7.DefenseEnemyDB           -> 이름, 공격력, 방어력, 이동 속도, 체력   
8.DefenseFriendlyDB        -> 이름, 공격력, 방어력, 체력, 배치 코스트   

<hr>
   
0427   

기본 UI 구현   
DefenseTimeManager 구현   
DefenseCostManager 구현   
DefenseLifeCountManager 구현   
Unit prefab & 배치 대기 패널 구현

<hr>

0428 & 0429   

적이 지나가는 길 설정   
라이프 카운트 구현   
코스트 구현   
유닛 배치 구현   
유닛 임시 DB 구현   
버튼 가볍게 누르기(배치) / 꾹 누르기 구분(설명 팝업)   

내일 작업할 일   
유닛 배치시 필드에 상호 작용 구현   
설명 팝업창 구현   
