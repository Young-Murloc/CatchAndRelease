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
<h2>3MatchPuzzle with RPG</h2>
<h2>Pricone</h2>

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

<hr>   

0430

monolith 광역 공격 완료

<hr>

0507  
   
3 match 퍼즐게임 만들기 위한 스크립트 설계

1. CreateTileScript     - 타일 생성
2. TileManagerScript    - 타일 관리 
3. MoveTileScript       - 타일 움직임
4. SpawnEnemyScript     - 적 생성
5. AllyScript           - 아군 능력 관리
6. EnemyScript          - 적 능력 관리
7. EffectScript?        - 게임 이펙트 관리
8. DmgCtrlScript        - 터진 타일 배열 관리

<hr>

0510

3 match puzzle   
   
1. BoardManageScript - 보드관리 및 퍼즐 요소 생성
2. Tile - 각 타일에 저장되어 각각의 스프라이트를 가지고 있으며 타일 자리 변경, 인접 타일 확인...   
   
해결해야할 문제 - 타일을 드래그를 통해 스왑하기
   
<방법1>
터치된곳 - 변수1 저장   
드래그 후 터치가 끝나는 곳 - 변수2 저장   
변수1, 변수2 스왑   
   
<방법2>
터치된곳 - 변수1 저장   
드래그 후 터치가 끝나는 곳 - 방향 저장   
방향 계산후 변수1 타일에서 방향으로 인접한 타일과 교환   
   
해결: 레이캐스트를 이용하여 시작 오브젝트, 종료 오브젝트 저장 -> 인접한 타일 검사 -> 위치 변경

내일 할 일: 매칭 알고리즘 및 타일 사라진곳 다시 채우는 알고리즘 구현   

<hr>

0511   

1. match3Script: 터질 타일들 계산   
기존의 레이캐스트를 이용하여 중심이 되는 타일 기준으로 위,아래 / 오른쪽,왼쪽 나눠서 killList 생성 후 타일 삭제   
삭제(스프라이트 교체)

해결해야할 문제 - killTile 후 새로운 타일 생성 후 다시 isMatch 함수 반복시 전달되는 변수   
   
<방법1>   
clearAllMatch 함수 제작 후 모든 타일을 검사하면서 터질 타일들을 killList 전달 후 killTile 실행   
   
해결: checkAllMatch 함수를 만들어서 모든 타일을 IsMatch로 전달하여 계산 (3단 터짐 확인)

내일 할 일: 4개 이상 터질 경우 폭탄으로 변경, 터지는 세로 타일들 수 계산하여 해당 라인 적 공격 구현   

<hr>

0512
   
폭탄 구현 완료   
몬스터와 hp바 구현 완료   
   
내일 할 일: 터지는 세로 타일 수 계산 및 공격 구현

<hr>

0513   
   
터지는 세로 타일수 계산 및 공격 구현 완료    
현재 클래스 다이어그램 vs 새로 제작한 클래스 다이어그램 비교

<hr>

0517

https://user-images.githubusercontent.com/78486158/118498954-79e9ac80-b761-11eb-9fbd-e6115bd6803f.mp4
   
<구현한점>
1. 3match퍼즐 적용
2. 아군과 적군 -> 타일이 터지는 수에 따라 스킬 충전, 피해 구현
3. 4개 이상 타일 터질경우 폭탄으로 변경
   
<보완할점>
1. 불완전한 함수 보수 (cross check, spawn tile...)
2. 타일 터지는 이펙트 추가
3. 체계적인 클래스 설계

<hr>

0520   
   
프리코네 전투 화면 구현   
   
1. AllyManager - 아군 생성 및 관리   
2. EnemyManager - 적군 생성 및 관리   
3. MoveManager - 아군 움직임 관리   
4. AtkManager - 아군 공격 관리   
5. ColliderManager - 적군 접촉 관리   

<hr>

0524

1. 아군 생성 - AllyManager   
2. 적군 생성 - EnemyManager
3. 아군 개인 스크립트 - BatManager   
4. 적군 개인 스크립트 - GhastManager   
5. 전투 스크립트 - CombatManager   
   
<할 일>   
1. 아군 스크립트 공격 부분 구현(시간에 따라 공격, CM으로 공격하는 오브젝트/피해 전달)   
2. 적군 스크립트 공격 부분 구현(시간에 따라 공격, CM으로 공격하는 오브젝트/피해 전달, 첫 공격 받을 시 상대 를 향해 이동)   
3. CM에 공격 명령을 받아서 전달하는 함수 구현(GameObject targetObj, float Dmg)   

<hr>
