using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using RestSharp.Serialization.Json;
using RestSharp;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APTSpecFlowTestAutomationProject.StepDefinition
{
    [Binding]
    public class APISteps
    {

      
        [Given(@"I have a endpoint (.*)")]
        public void GivenIHaveAEndpointEndpoint(string endpoint)
        {
            RestAPIHelper.SetUrl(endpoint);
        }

    



        [When(@"I call get method of api")]
        public void WhenICallGetMethodOfApi()
        {

            RestAPIHelper.CreateRequest();
        }




        [Then(@"I get API response in json format")]
        public void ThenIGetAPIResponseInJsonFormat()
        {
            var expected = "something";
            var apiResponse = RestAPIHelper.GetResponse();

            var content = apiResponse.Content;

            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)

            {
                Assert.That(apiResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));



            }



        }


        [When(@"I call get method to get user information using (.*)")]
        public void WhenICallGetMethodToGetUserInformationUsing(string orgId)
        {

            RestAPIHelper.CreateRequest(orgId);

        }







        [Then(@"I will get org information")]
        public void ThenIWillGetOrgInformation()
        {
            var expected = "something";
            var apiResponse = RestAPIHelper.GetResponse();
            
            var deserialize = new JsonDeserializer();

            JArray jarr = JArray.Parse(apiResponse.Content);



            // JObject obs = JObject.Parse(apiResponse.Content);

            // string Status = obs["forename"].ToString();


            //dynamic stuff = JsonConvert.DeserializeObject(content);

            // var output = deserialize.Deserialize<Dictionary<string, string>>(apiResponse);

            // Dictionary<string, object> values = deserialize.Deserialize<Dictionary<string, object>>(apiResponse);

            foreach (JObject content in jarr.Children<JObject>())
            {
                foreach (JProperty prop in content.Properties())
                {
                    string tempValue = prop.Value.ToString(); // This is not allowed 
                                                            //here more code in order to save in a database
                }
            }
        


            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
              //  NUnit.Framework.Assert.That(apiResponse.Content, Is.EqualTo(expected), "Error");
               // NUnit.Framework.Assert.That(Status, Is.EqualTo("50"), "Error");

            }


        }

        [When(@"I call get method for user information using (.*) and (.*)")]
        public void WhenICallGetMethodForUserInformationUsingUserAnd(string userId, string orgId)
        {

            RestAPIHelper.CreateRequest(userId, orgId);
        }

        [Then(@"I will get user information")]
        public void ThenIWillGetUserInformation()
        {
            var expected = "OK";
            var response = RestAPIHelper.GetResponse();

            var content = response.Content;
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, object>>(response);
            var description = response.StatusDescription;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                NUnit.Framework.Assert.That(description, Is.EqualTo(expected), "Error");

            }



        }

        [When(@"I call post method to create a user with (.*) and (.*)")]
        public void WhenICallPostMethodToCreateAUserWithUserIdAndOrgId(string userId, string orgId)
        {


            RestAPIHelper.CreatePostRequest(userId, orgId);
        }


        [Then(@"I will create user successfully")]
        public void ThenIWillCreateUserSuccessfully()
        {
            var expected = "something";
            var response = RestAPIHelper.GetResponse();

            var content = response.Content;
            //  var deserialize = new JsonDeserializer();
            //var output=  deserialize.Deserialize<Dictionary<string, string>>(response);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                NUnit.Framework.Assert.That(response.StatusCode, Is.EqualTo(201), "User is not created");

            }

        }


    

}
}
