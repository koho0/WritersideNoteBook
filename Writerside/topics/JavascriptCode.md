# Javascript程式码

<primary-label ref="javascript"/>
<secondary-label ref="2024.09.25"/>
<secondary-label ref="beta"/>
<secondary-label ref="experimental"/>


## meta标签中定义网页自动刷新
```html
<html>
<head><meta http-equiv="refresh" content="60"></head>
<frameset>
<frame src="https://www.kejixiaobai.top" name="iframe">
</frameset></frameset>
</html>
```
{collapsible="true" collapsed-title="meta标签中定义网页自动刷新(HTML)"}


## 透过定时器刷新
```Javascript
setInterval(location.reload(), 60000);
```

## 网页大小发生改变时自动刷新
```Javascript
window.onresize = () => {
    const currentWidth = window.innerWidth;
    const currentHeight = window.innerHeight;

    if (
        Math.abs(currentWidth - previousWidth) > resizeThreshold ||
        Math.abs(currentHeight - previousHeight) > resizeThreshold
    ) {
        location.reload();
    }

    previousWidth = currentWidth;
    previousHeight = currentHeight;
};
```
{collapsible="true" collapsed-title="网页大小发生改变时自动刷新(JS)"}

## 获取当前时间
```html
<div class="clock" id="nowtime">
    <p id="timeDisplay">00:00<span style="padding-left:0.6rem">星期X</span></p>
    <p style="font-size:0.9rem" id="dateDisplay">0000/00/00</p>
</div>
```
{collapsible="true" collapsed-title="获取当前时间(HTML)"}
```Javascript
        function updateClock() {
            const now = new Date();
            let hours = now.getHours();
            let minutes = now.getMinutes();
            let dayOfWeek = now.getDay();
            let days = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"];
            let date = now.getFullYear() + '/' + (now.getMonth() + 1).toString().padStart(2, '0') + '/' + now.getDate().toString().padStart(2, '0');

            hours = hours.toString().padStart(2, '0');
            minutes = minutes.toString().padStart(2, '0');

            document.getElementById('timeDisplay').innerHTML = hours + ':' + minutes + '<span style="padding-left:0.6rem">' + days[dayOfWeek] + '</span>';
            document.getElementById('dateDisplay').innerHTML = date;
        }
```
{collapsible="true" collapsed-title="获取当前时间(JS)"}

## 表格数据自动翻页
```html
 <table id="mytable" lay-filter="mytable"
        style="position:absolute;">
     <thead>
         <tr style="line-height: 5vh;">
             <th>列名</th>
             ............
         </tr>
     </thead>
     <tbody>
     </tbody>
 </table>
```
{collapsible="true" collapsed-title="表格数据自动翻页(HTML)"}
```Javascript
 function autoPageUpdate() {
     const startIndex = pageIndex * pageSize;

     // 如果起始索引已经超出了数据长度，重置 pageIndex
     if (startIndex >= totalData.length) {
         pageIndex = 0;
         return; // 返回以避免展示空白页
     }

     const endIndex = Math.min(startIndex + pageSize, totalData.length); // 结束索引不要超过数据长度
     const pagedData = totalData.slice(startIndex, endIndex); // 获取当前页的数据

     // 清空表格
     $('#demo2 tbody').empty();

     // 插入当前页的数据
     for (let i = 0; i < 5; i++) {
         const item = pagedData[i];
         const row = `
     <tr>
         <td>${startIndex + i + 1}</td>
         <td>${item ? item.列名 : ''}</td>
         ...........
         </tr>
 `;
         $('#mytable tbody').append(row);
     }

     // 增加 pageIndex，准备显示下一页
     pageIndex++;
 }
```
{collapsible="true" collapsed-title="表格数据自动翻页(JS)"}

## 自適應字體大小
```Javascript
        var setFont = function () {
            var html = document.documentElement;
            var width = html.clientWidth;
            var mul = Math.floor(window.innerWidth / window.innerHeight * 10) / 10;
            fontSizes = width / ((mul - 1.7) * 10 * 5 + 80);
            html.style.fontSize = fontSizes + 'px';
            autopx = fontSizes * 0.04;
        }
```
{collapsible="true" collapsed-title="自適應字體大小(JS)"}

## Ajax寫法
```Javascript
$("#button1").on('click',function(){
        $.ajax({
            url: "/greet",
            // url: '@Url.Action("method", "Controller")',//(C#中可以写成这样)
            data: {name: 'jenny'},
            type: "POST",
            dataType: "json",
            async = false;　
            success: function(data) {
                console.log(data);
                data = jQuery.parseJSON(data); 
                console.log(data);
                $("#ret").text(data.result);
            }
        });
    });
```
{collapsible="true" collapsed-title="Ajax寫法(JS)"}
> async = false：flase 表示同步处理，即等待回调函数执行完毕之后，再执行ajax代码块下面的JS代码，而不是同时执行
>
> dataType: "json"：data = jQuery.parseJSON(data);  // 如果没有选择dataType为Json，则要转换为JSON对象

## foreach循环
```Javascript
var xsl=[];
var xszzl=[];
larmlogs.forEach(data => {
	if (!isNaN(Number(data.plan))) {
		xsl.push(Number(alarmlog.TodayPlans));
		const ratio = (logs / plans) * 100;
		const ratio1 = ratio.toFixed(1);
		if (!isNaN(ratio1)) {
			xszzl.push(ratio1);
		} else {
			xszzl.push(0);
		}
	}
});
```
{collapsible="true" collapsed-title="foreach循环(JS)"}

## 自定义前后翻页按钮
```Javascript
        function renderPagination(currentPage, totalItems, alarmlog) {
            var paginationContainer = document.querySelector('.pagination');
            paginationContainer.innerHTML = "";

            const totalPages = Math.ceil(totalItems / rowsPerPage);

            // 上一页按钮
            if (currentPage > 1) {
                var prevButton = document.createElement('button');
                prevButton.className = 'layui-btn layui-btn-primary custom';
                prevButton.textContent = '上一页';
                prevButton.onclick = function () {
                    currentPage--;
                    alarmTable(currentPage, alarmlog); // 调用 alarmTable 更新表格和分页
                };
                paginationContainer.appendChild(prevButton);
            }

            // 下一页按钮
            if (currentPage < totalPages) {
                var nextButton = document.createElement('button');
                nextButton.className = 'layui-btn layui-btn-primary custom';
                nextButton.textContent = '下一页';
                nextButton.onclick = function () {
                    currentPage++;
                    alarmTable(currentPage, alarmlog); // 调用 alarmTable 更新表格和分页
                };
                paginationContainer.appendChild(nextButton);
            }
        }
```
{collapsible="true" collapsed-title="foreach循环(JS)"}

## 根据数据动态生成按钮
```Javascript
  function alarmButton(alarmlog,linecode) {

      var alarm = document.getElementById('alarm');
      alarm.innerHTML = '';

      var paginationContainer = document.querySelector('.pagination');
      paginationContainer.innerHTML = "";

      if (!alarm) {
          return;
      }

      // 创建 HTML 结构
      var html = `
          <input type="text" id="alarmInput" placeholder="请扫描条码">
          <div id="buttonsContainer" style="margin-top:30px;"></div>
      `;

      // 将 HTML 结构插入到 alarm 元素中
      alarm.innerHTML = html;

      // 生成按钮
      var buttonsContainer = document.getElementById('buttonsContainer');
      if (!buttonsContainer) {
          return;
      }

      buttonsContainer.innerHTML = '';

      alarmlog.forEach(function (item) {
          var button = document.createElement('button');
          button.className = 'layui-btn layui-btn-lg';
          button.innerText = item.AlarmType;
          button.onclick = function () {
              if ($('#alarmInput').val().trim() === '') {
                   showPopup('请先扫描车身条码!');
              } else {
                  $.ajax({
                      type: 'post',
                      url: '@Url.Action("InsertAlarmReasonLog", "DevAlarmLogs")',
                      datatype: 'json',
                      data: {
                          reasonID:item.AlarmCode,
                          userid: '',
                          barCode: $('#alarmInput').val().trim()
                      },
                      async: false,
                      success: function (data) {
                          if (data.code === 0) {
                              showPopup('上报不良信息成功!');
                              $("#alarmInput").val("");
                              $("#alarmInput").focus();
                              toggleNode(`[L]${linecode}`);
                              showTable(linecode);
                          }
                      }
                  });
              }
          };
          buttonsContainer.appendChild(button);
      });

      $('#alarmInput').focus();
  }
```
{collapsible="true" collapsed-title="foreach循环(JS)"}