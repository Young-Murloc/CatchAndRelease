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
<h2>3match퍼즐</h2>

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

Retry 버튼 클릭시 화면 재시작 -> LoadScene으로 하면 제대로 작동을 안함   
점수 계산법 구현   

<hr>
