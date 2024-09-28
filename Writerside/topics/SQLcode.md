# SQL程式码
<primary-label ref="sqlserver"/>
<secondary-label ref="2024.09.25"/>
<secondary-label ref="beta"/>
<secondary-label ref="experimental"/>

## 運算子
```SQL
1. 比較運算子
   =: 等於
<>: 不等於
>: 大於
<: 小於
>=: 大於等於
<=: 小於等於
2. 邏輯運算子
AND: 且（同時滿足兩個條件）
OR: 或（滿足其中一個條件即可）
NOT: 非（取反）
3. 通配符
%: 匹配任意長度的字符序列
_: 匹配任意单个字符
4. NULL 值處理
IS NULL: 判斷是否為 NULL 值
IS NOT NULL: 判斷是否不為 NULL 值
5. 集合運算子
UNION: 合併兩個結果集，去除重複行
UNION ALL: 合併兩個結果集，保留重複行
INTERSECT: 求兩個結果集的交集
EXCEPT: 求兩個結果集的差集
6. 其他常用語法
LIKE: 模糊匹配
IN: 判斷值是否在一個列表中
BETWEEN: 判斷值是否在一個範圍內
EXISTS: 判斷子查詢是否存在結果
7. 聚合函數
COUNT: 計算行數
SUM: 求和
AVG: 求平均值
MAX: 求最大值
MIN: 求最小值
```
{collapsible="true" collapsed-title="SQL运算符"}





## Sql Server中查询今天、昨天、本周、上周、本月、上月数据

```SQL
在做Sql Server开发的时候有时需要获取表中今天、昨天、本周、上周、本月、上月等数据，这时候就需要使用DATEDIFF()函数及GetDate()函数了。
DATEDIFF ( datepart , startdate , enddate )
释义：计算时间差
datepare值：year | quarter | month | week | day | hour | minute | second | millisecond
startdate：开始日期
enddate ：结束日期
GetDate()
释义：获取当前的系统日期

下面例子中表名为tablename,条件字段名为inputdate

查询今天

SELECT * FROM tablename where DATEDIFF(day,inputdate,GETDATE())=0

查询昨天

SELECT * FROM tablename where DATEDIFF(day,inputdate,GETDATE())=1

查询本周

SELECT * FROM tablename where datediff(week,inputdate,getdate())=0

查询上周

SELECT * FROM tablename where datediff(week,inputdate,getdate())=1

查询本月

SELECT * FROM tablename where DATEDIFF(month,inputdate,GETDATE())=0

查询上月

SELECT * FROM tablename where DATEDIFF(month,inputdate,GETDATE())=1

查询本季度的

select * from T_InterViewInfo where datediff(QQ,inputdate,getdate())=0

```
{collapsible="true" collapsed-title="Sql Server中查询今天、昨天、本周、上周、本月、上月数据"}

## Sql Server日期推算(年,季度,月,星期推算) {id="sql-server_1"}

```SQL
DECLARE @dt datetime
SET @dt=GETDATE()

DECLARE @number int
SET @number=3


--1．指定日期该年的第一天或最后一天
--第一天为1月1日、最后一天为12月31日都是固定的

--A. 年的第一天
SELECT CONVERT(char(5),@dt,120)+'1-1'

--B. 年的最后一天
SELECT CONVERT(char(5),@dt,120)+'12-31'


--2．指定日期所在季度的第一天或最后一天
--A. 季度的第一天
SELECT CONVERT(datetime,
 CONVERT(char(8),
  DATEADD(Month,
   DATEPART(Quarter,@dt)*3-Month(@dt)-2,
   @dt),
  120)+'1')

--B. 季度的最后一天（CASE判断法）
SELECT CONVERT(datetime,
 CONVERT(char(8),
  DATEADD(Month,
   DATEPART(Quarter,@dt)*3-Month(@dt),
   @dt),
  120)
 +CASE WHEN DATEPART(Quarter,@dt) in(1,4)
  THEN '31'ELSE '30' END)

--C. 季度的最后一天（直接推算法）
SELECT DATEADD(Day,-1,
 CONVERT(char(8),
  DATEADD(Month,
   1+DATEPART(Quarter,@dt)*3-Month(@dt),
   @dt),
  120)+'1')


--3．指定日期所在月份的第一天或最后一天
--A. 月的第一天
SELECT CONVERT(datetime,CONVERT(char(8),@dt,120)+'1')

--B. 月的最后一天
SELECT DATEADD(Day,-1,CONVERT(char(8),DATEADD(Month,1,@dt),120)+'1')


--4．指定日期所在周的任意一天
SELECT DATEADD(Day,@number-DATEPART(Weekday,@dt),@dt)


--5．指定日期所在周的任意星期几
--A.  星期天做为一周的第1天
SELECT DATEADD(Day,@number-(DATEPART(Weekday,@dt)+@@DATEFIRST-1)%7,@dt)

--B.  星期一做为一周的第1天
SELECT DATEADD(Day,@number-(DATEPART(Weekday,@dt)+@@DATEFIRST-2)%7-1,@dt)
```

{collapsible="true" collapsed-title="Sql Server日期推算(年,季度,月,星期推算)"}