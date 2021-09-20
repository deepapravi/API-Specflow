using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace APTSpecFlowTestAutomationProject
{
   public static class RestAPIHelper
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string baseUrl = "https://dev.aspire.fft.local/api/assessmentservice-eyfs/api/v1/Student";
        public static RestClient SetUrl(string endpoint)

        {
            //var url = Path.Combine(baseUrl, endpoint);

            var url = baseUrl + endpoint;

            return client = new RestClient(url);


            //return client = new RestClient(baseUrl);
        }

        public static RestRequest CreateRequest()
        {

            restRequest = new RestRequest(Method.GET);

            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("authorization", "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjdCRTAzQjZCOUJCOTczNjcwREJFQ0ExOURBMzc0ODc5NzBDNzkwNkVSUzI1NiIsInR5cCI6IkpXVCIsIng1dCI6ImUtQTdhNXU1YzJjTnZzb1oyamRJZVhESGtHNCJ9.eyJuYmYiOjE2MzE4OTEyODIsImV4cCI6MTYzMTg5NDg4MiwiaXNzIjoiaHR0cHM6Ly9kZXYuc2lnbmluLmZmdC5sb2NhbCIsImF1ZCI6WyJGRlQuQXNwaXJlLkN1cnJpY3VsdW1UcmFja2VyLXYyLldlYkFwaSIsIkZGVC5Bc3BpcmUuSHViIiwiRkZULlN1YnNjcmlwdGlvbiIsImh0dHBzOi8vZGV2LnNpZ25pbi5mZnQubG9jYWwvcmVzb3VyY2VzIl0sImNsaWVudF9pZCI6IkZGVC5Bc3BpcmUuQ3VycmljdWx1bVRyYWNrZXItdjIiLCJzdWIiOiIwNzhmM2E1Ni03NDBmLTRjNzUtOTJlNi1mZjUxM2M5OGQ4YmUiLCJhdXRoX3RpbWUiOjE2MzE4OTEyODIsImlkcCI6ImxvY2FsIiwibWVtYmVyc2hpcCI6IjEiLCJtb2R1bGUiOiJGRlQuQXNwaXJlIiwib3JpZ2luIjoiRkZULkFzcGlyZSIsInJvbGUiOiJTdXBwb3J0Iiwic2lkIjoiNjVEMjM5QTlBMzJFNkRFMjU0QTU2QzJDREVEODJEOTIiLCJpYXQiOjE2MzE4OTEyODIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJlbWFpbCIsInBob25lIiwicm9sZSIsIm1lbWJlcnNoaXAiLCJtb2R1bGUiLCJvcmlnaW4iLCJwZXJtaXNzaW9uIiwic2VjdXJpdHkiLCJwZXJtaXNzaW9uLmFzcGlyZSIsInBlcm1pc3Npb24udHJhY2tpbmciLCJGRlQuQXNwaXJlLkN1cnJpY3VsdW1UcmFja2VyLXYyLldlYkFwaSIsIkZGVC5Bc3BpcmUuSHViIiwiRkZULlN1YnNjcmlwdGlvbiJdLCJhbXIiOlsicHdkIl19.ZIga9D3nPyhKAA30AsS23nVoOLC3U_cyzyfDEzbqunfRtdia_C-R52VZ5GsU6rQBXx7qbrGjzWqij7PoUJcNzm3g6yQ5dhgC1sizGWxAT3zPuxf-O1nPJF-kefCoSv_3zRS55n8QX9qeUnyadsPDJwwiic2MbKMmm64tSDZh0cT4zQlHUL2kNduiudWGq6P9NBL66k3FZHjK94Gq5P875bCHwYy1x1qmJtoWS17TRUu5aJi0fh_IKQBddrprcTIGJg64KwuGzdWGTFkKnj_b7Bzb4LTcie5UPBawF2Jw539kt9h6GmXGqXV2l3FWOnhQVVGPJHXYdJis-epxx2ObKQ");
            return restRequest;


        }

        //https://web.test.apt.fft.local/Home/orgid
        public static RestRequest CreateRequest(string orgId)
        {
            var resource = orgId;

            restRequest = new RestRequest(resource, Method.GET);

            restRequest.AddHeader("Accept", "application/json");
            return restRequest;


        }
        //https://aspiretest.fft.local/Admin/User/Org51765/UserDetail/?id=e136abf6-a0b1-4849-ad3f-786632dc489f&orgId=51765

        public static RestRequest CreateRequest(string userId, string orgId)
        {
            var resource = "/Org" + orgId + "/UserDetail/?id={userId}&orgId={orgId}";

            restRequest = new RestRequest(resource, Method.GET);

            restRequest.AddParameter("userId", userId, ParameterType.UrlSegment);
            restRequest.AddParameter("orgId", orgId, ParameterType.UrlSegment);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("authorization", "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjdCRTAzQjZCOUJCOTczNjcwREJFQ0ExOURBMzc0ODc5NzBDNzkwNkVSUzI1NiIsInR5cCI6IkpXVCIsIng1dCI6ImUtQTdhNXU1YzJjTnZzb1oyamRJZVhESGtHNCJ9.eyJuYmYiOjE2MDU2MjkyNTMsImV4cCI6MTYwNTYzMjg1MywiaXNzIjoiaHR0cHM6Ly90ZXN0LnNpZ25pbi5mZnQubG9jYWwiLCJhdWQiOlsiRkZULlN1YnNjcmlwdGlvbiIsIkZGVC5BUFQuV2ViQXBpIiwiaHR0cHM6Ly90ZXN0LnNpZ25pbi5mZnQubG9jYWwvcmVzb3VyY2VzIl0sImNsaWVudF9pZCI6IkZGVC5BUFQuV2ViIiwic3ViIjoiZTEzNmFiZjYtYTBiMS00ODQ5LWFkM2YtNzg2NjMyZGM0ODlmIiwiYXV0aF90aW1lIjoxNjA1NjI4NzUxLCJpZHAiOiJsb2NhbCIsIm1lbWJlcnNoaXAiOiI1MTc2NSIsIm1vZHVsZSI6WyJGRlQuQVBUIiwiRkZULkFzcGlyZSIsIkZGVC5TRkEiXSwib3JpZ2luIjoiRkZULkFzcGlyZSIsInJvbGUiOiJVc2VyIiwic2lkIjoiQzU1NkI2MUY1NEVBODg1REM4MzZGNTM2Nzk0M0EwQzQiLCJpYXQiOjE2MDU2MjkyNTMsInNjb3BlIjpbIm9wZW5pZCIsImVtYWlsIiwicGhvbmUiLCJwcm9maWxlIiwibWVtYmVyc2hpcCIsIkZGVC5BUFQuV2ViQXBpIiwibW9kdWxlIiwicm9sZSIsIm9yaWdpbiIsInNlY3VyaXR5Iiwic3Vic2NyaXB0aW9uIiwicHJlZmVyZW5jZXMiLCJwZXJtaXNzaW9uIiwicGVybWlzc2lvbi50cmFja2luZyIsInBlcm1pc3Npb24uYXNwaXJlIiwiRkZULlN1YnNjcmlwdGlvbiIsIm9mZmxpbmVfYWNjZXNzIl0sImFtciI6WyJwd2QiXX0.IZ3pLwzJsoyvxVmhWTOryM-J3Ax_Qr4aSf5XAb0Kgg00p1X-eKCueEeYYf202UD503ZsI8v61pBs7bStdTGxu6KKz508xmZs2j151KWk5uoysep5Buq_g3jBUBogaFL5w1Bw6x-LDoVttLuaZaV14hM5dFFz3NQG-fQkvYmdmCrLWMx3rAGp3XREzIyPvJ4uR74ONwycU50_fQyw5I5pJrMMiJ4lthv7Po1lsV96P4q3rS7i29TXMb-dc46qe0weAHk5Z0HIa72m5VxOfPi-LmnWGl0pDQJI2Sut98K9QuNoABZK30h7TJOEoOS-40lE9g4W4eWf09HlgSJwJYKzkw");
            return restRequest;


        }

        public static RestRequest CreatePostRequest(string userId, string orgId)

        {

            var resource = "/Org" + orgId + "CreateUser/" + userId + "?orgId={orgId}";

            restRequest = new RestRequest(resource, Method.POST);
            restRequest.AddParameter("UserId", userId, ParameterType.UrlSegment);
            restRequest.AddParameter("orgId", orgId, ParameterType.UrlSegment);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public static IRestResponse GetResponse()
        {

            return client.Execute(restRequest);
           
            //var content = client.Execute(restRequest).Content;
            //return content;



        }



    }
}
