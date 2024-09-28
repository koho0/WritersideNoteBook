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