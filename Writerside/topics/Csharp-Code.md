# C#程式码
<primary-label ref="csharp"/>
<secondary-label ref="2024.09.25"/>
<secondary-label ref="beta"/>
<secondary-label ref="experimental"/>

## 获取当周的7天并进行数据库参数化查询


```C#
        public List<ResultDto> GetPlansWeekNum()
        {
            using (var db = new WATDB_LEADANDONEntities())
            {
                var today = DateTime.Today;
                var startOfWeek = today.AddDays(-((int)today.DayOfWeek - (int)DayOfWeek.Monday) % 7);
                var weekDates = Enumerable.Range(0, 7).Select(i => startOfWeek.AddDays(i)).ToList();

                var dateParams = weekDates.Select((date, index) => new SqlParameter($"dateParam{index}", date.Date))
                    .ToList();

                var sql = @"
SELECT
    dateParam.Value AS DateOfWeek,
    (SELECT PlanNum FROM PlansNumberOfDays WHERE [DateTime] = dateParam.Value) AS TodayPlans,
    (SELECT COUNT(*) FROM AlarmReason_Log WHERE CONVERT(date, InsertTime) = dateParam.Value) AS TodayAlarmLogs
FROM (VALUES
    (@dateParam0), (@dateParam1), (@dateParam2), (@dateParam3), (@dateParam4), (@dateParam5), (@dateParam6)
) AS dateParam (Value)";

                var results = db.Database.SqlQuery<ResultDto>(sql, dateParams.ToArray()).ToList();

                return results;
            }
        }
```
{collapsible="true" collapsed-title="获取当周的7天并进行数据库参数化查询"}

## API寫法
```C#
 [HttpPost]
 [Route("api/ChargeRecord")]
 public HttpResponseMessage ChargeRecord(ChargeRecordRequestModel request)
 {
     var response = new ResponseModel<ChargeRecordModel>();
     var sqlStatement = new SqlStatement();
     var requestJsonString = JsonConvert.SerializeObject(request);
     var askTime = DateTime.Now;

     try
     {
         if (request == null)
         {
             response.Code = "1";
             response.Msg = "失败，失败原因：缺少必要的查询条件";
             response.Data = null;
             return GlobalData.GetResponse(response);
         }

         if (string.IsNullOrEmpty(request.StartTime))
         {
             response.Code = "1";
             response.Msg = "失败，失败原因：查询条件缺少时间";
             response.Data = null;
             return GlobalData.GetResponse(response);
         }

         var dateParts = request.StartTime.Split(',');
         string startTime;
         string endTime;
         if (dateParts.Length == 2)
         {
             startTime = dateParts[0].Trim();
             endTime = dateParts[1].Trim();
         }
         else
         {
             response.Code = "1";
             response.Msg = "失败，失败原因：输入的日期格式不正确";
             response.Data = null;
             return GlobalData.GetResponse(response);
         }

         var data = SqlStatement.GetChargeRecords(startTime, endTime, request.Pilecode, request.BatteryID);

         foreach (var item in data)
         {
             item.BatteryID = item.BatteryID.Replace("\0", "");
         }

         response.Code = "0";
         response.Msg = "成功";
         response.Data = data;
         return GlobalData.GetResponse(response);
     }
     catch (Exception e)
     {
         response.Code = "1";
         response.Msg = $"失败，失败原因：{e.Message}";
         response.Data = null;
         return GlobalData.GetResponse(response);
     }
 }
```
{collapsible="true" collapsed-title="API寫法"}

