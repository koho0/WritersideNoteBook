# Flex彈性容器

## 彈性容器屬性
![image.png](image.png)
![image_1.png](image_1.png)
![image_2.png](image_2.png)

01. flex-wrap 屬性  
    flex-wrap屬性允許彈性子元素換到新的一行或多行顯示。它可以設置爲nowrap（初始
    值）、wrap或者wrap-reverse。啓用換行後，子元素不再根據flex-shrink值收
    縮，任何超過彈性容器的子元素都會換行顯示。
    如果彈性方向是column或column-reverse，那麼flex-wrap會允許彈性子元素換到
    新的一列顯示，不過這隻在限制了容器高度的情況下才會發生，否則容器會擴展高度以包
    含全部彈性子元素。
02. flex-flow 屬性  
    flex-flow屬性是flex-direction和flex-wrap的簡寫。例如，flex-grow:
    column wrap指定彈性子元素按照從上到下的方式排列，必要時換到新的一列。
03. justify-content 屬性  
    當子元素未填滿容器時，justify-content屬性控制子元素沿主軸方向的間距。它的值
    包括幾個關鍵字：flex-start、flex-end、center、space-between以及space
    around。默認值flex-start讓子元素從主軸的開始位置順序排列，比如主軸方向爲從
    左到右的話，開始位置就是左邊。如果不設置外邊距，那麼子元素之間不會產生間距。如
    果值爲flex-end，子元素就從主軸的結束位置開始排列，center的話則讓子元素居
    中。 
    值space-between將第一個彈性子元素放在主軸開始的地方，最後一個子元素放在主軸
    結束的地方，剩下的子元素間隔均勻地放在這兩者之間的區域。值space-around類
    似，只不過給第一個子元素的前面和最後一個子元素的後面也加上了相同的間距。
    間距是在元素的外邊距之後進行計算的，而且flex-grow的值要考慮進來。也就是說，
    如果任意子元素的flex-grow的值不爲0，或者任意子元素在主軸方向的外邊距值爲
    auto，justify-content就失效了。
04. align-items 屬性    
    justify-content控制子元素在主軸方向的對齊方式，align-items則控制子元素在
    副軸方向的對齊方式。align-items的初始值爲stretch，在水平排列的情況下讓所有
    子元素填充容器的高度，在垂直排列的情況下讓子元素填充容器的寬度，因此它能實現等
    高列。
    其他的值讓彈性子元素可以保留自身的大小，而不是填充容器的大小。（類似的概念有
    vertical-align屬性。）
    flex-start和flex-end讓子元素與副軸的開始或結束位置對齊。（如果是水平布
    局的話，則與容器的頂部或者底部分別對齊。）
    center讓元素居中。
    baseline讓元素根據每個彈性子元素的第一行文字的基線對齊。
    當你想要一個彈性子元素裏大字號標題的基線與其他彈性子元素裏較小文字的基線對齊
    時，baseline就能派上用場。
    提示 justify-content和align-items屬性的名稱很容易弄混。我是參考文字
    樣式來記的：我們可以“調整”（justify）文字，讓其在水平方向的兩端之間均勻分
    布；而align-items更像vertical-align，讓行內元素在垂直方向“對
    齊”（align）。
05. align-content 屬性  
    如果開啓了換行（用flex-wrap），align-content屬性就可以控制彈性容器內沿副
    軸方向每行之間的間距。它支持的值有flex-start、flex-end、center、
    stretch（初始值）、space-between以及space-around。這些值對間距的處理類
    似上面的justify-content。


## 彈性子元素屬性
![image_3.png](image_3.png)
![image_4.png](image_4.png)

01. align-self 屬性  
    該屬性控制彈性子元素沿着容器副軸方向的對齊方式。它跟彈性容器的align-items屬
    性效果相同，但是它能單獨給彈性子元素設定不同的對齊方式。auto爲初始值，會以容
    器的align-items值爲準。其他值會覆蓋容器的設置。align-self屬性支持的關鍵字
    與align-items一樣：flex-start、flex-end、center、stretch以及 baseline。
02. order 屬性  
    正常情況下，彈性子元素按照在HTML源碼中出現的順序排列。它們沿着主軸方向，從主
    軸的起點開始排列。使用order屬性能改變子元素排列的順序。還可以將其指定爲任意正
    負整數。如果多個彈性子元素有一樣的值，它們就會按照源碼順序出現。
    初始狀態下，所有的彈性子元素的order都爲0。指定一個元素的值爲-1，它會移動到列
    表的最前面；指定爲1，則會移動到最後。可以按照需要給每個子元素指定order以便重
    新編排它們。這些值不一定要連續。
    警告 謹慎使用order。讓屏幕上的視覺佈局順序和源碼順序差別太大會影響網站的
    可訪問性。在大多數瀏覽器裏使用Tab鍵瀏覽元素的順序與源碼保持一致，如果視覺
    上差別太大就會令人困惑。視力受損的用戶使用的大部分屏幕閱讀器也是根據源碼的
    順序來的。