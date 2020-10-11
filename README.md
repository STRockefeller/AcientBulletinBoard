# AncientBulletinBoard

## Abstract

ASP.net core mvc 練習之作，一邊學習一邊實作的產物

![](https://i.imgur.com/QmSVqbW.png)

[TOC]

## Introduction



### 概觀

因為把學習的重點放在MVC架構，以及功能面上，外觀畫面的部分沒有花太多心思，基本上就是bootstrap套一套完事。

### 身分驗證系統

#### 登入

![](https://i.imgur.com/7FD2VaS.png)

過去在非MVC架構的專案下有寫過的功能，本來想說在MVC的架構下可以寫得有些不一樣，但最後結果還是大同小異。

post送出表單資訊，再用middleware攔截然後比對資料庫內容。

#### 註冊

![](https://i.imgur.com/zXLln7O.png)

下方Camp的選項算是留言版功能的小構思，後面會解釋。(三國陣營用英文表示實在看不習慣就乾脆用中文寫了)

![](https://i.imgur.com/LQ1UGCR.png)

這個頁面有做一些基礎的表單內容查錯功能(email確認的作法是從MSDN查到的)

#### Navigator

上方的Navigator會隨著登入狀態以及帳號的身分(權限等級)而不同

一般帳號登入後如下圖

![](https://i.imgur.com/tOaJEE2.png)

遊客如下圖(登出按鍵變為註冊按鍵，另外Bulletin Board展開內容少了Camp Bulletin Board 雖然從截圖看不出來)

![](https://i.imgur.com/egIsmgU.png)

管理員權限的帳號如下圖

![](https://i.imgur.com/0Z4JkUu.png)



#### 管理員權限功能

![](https://i.imgur.com/B6HBCG1.png)

目前有兩項，分別是帳號管理以及留言板管理



##### 帳號管理

這個頁面也是使用SignalR製作的，搜尋結果會及時顯示在畫面中



![](https://i.imgur.com/wB7bhfK.png)

目前只有搜尋功能，原本打算加入刪除帳號功能，但想想覺得這個權力好像太大了點，禁止發言功能可能好一點(具體怎麼實現還在構思中)

![](https://i.imgur.com/QNJePZe.png)

![](https://i.imgur.com/OBpJdz4.png)

![](https://i.imgur.com/qqNqyR1.png)

搜尋條件是聯立的，全部都空白就是顯示所有帳號，會顯示除了密碼以及權限等級之外的所有資訊



##### 留言板管理

![](https://i.imgur.com/gIb2mp1.png)

目前只有刪除留言功能



### 留言板

#### 關於顯示名稱

進入任意留言板後預設的名稱是來自登入帳號的Display Name (Browse as a guest 的話是 guest)

![](https://i.imgur.com/vixjygx.png)

留言顯示名稱是可以修改的

#### 關於留言

![](https://i.imgur.com/ecWZFyC.png)

留言包含發言人(因為可以修改，所以不一定是該帳號的顯示名稱)、留言內容以及時間，顏色會根據陣營(Camp)而有所不同

以特定名稱進行留言會有預設的陣營表示，如下圖

![](https://i.imgur.com/WjQRTAI.png)

管理者權限的帳號會多一個清空留言版的按鍵

![](https://i.imgur.com/Bwba98l.png)

全部留言的內容都會存在資料庫中



#### 留言板的種類

中立陣營及訪客身分的使用者以外，展開Navigator中的Bulletin Boards可以看到除了上面的Public Bulletin Board(公共留言板)之外，還有一個Camp Bulletin Board(陣營留言板)

![](https://i.imgur.com/qrHY0Sl.png)

顧名思義是只有同陣營的人才能看到的留言板，進入這個頁面時就會根據帳號所處的陣營連結到對應的資料庫，畫面上方會顯示你現在所處的陣營名稱，功能大致與公共留言板大同小異。



### 即時聊天室

以SignalR實現的功能(主要參考MSDN的範例)

不同於留言板，聊天室裡面的名稱只能是Display Name不能更改，資料也不會存入資料庫。

![](https://i.imgur.com/F77uXrs.png)

![](https://i.imgur.com/2oX6XFK.png)



![](https://i.imgur.com/NkcgVch.png)



![](https://i.imgur.com/qTZX4Ym.png)



![](https://i.imgur.com/TIimD3s.png)

