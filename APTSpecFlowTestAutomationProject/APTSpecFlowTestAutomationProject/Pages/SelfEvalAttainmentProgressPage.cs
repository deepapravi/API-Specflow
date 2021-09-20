using APTSpecFlowTestAutomationProject.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

namespace APTSpecFlowTestAutomationProject.Pages
{


    class SelfEvalAttainmentProgressPage
    {
        public static double OrgValueRounded=0;
        public SelfEvalAttainmentProgressPage()
        {
            PageFactory.InitElements(DriverHelper.Driver, this);


        }

        [FindsBy(How = How.XPath, Using = "//body/div[@id='wrapper']/div[2]/div[2]/section[1]/div[1]/div[8]/div[2]/div[1]/div[1]/h3[1]")]
        public IWebElement AttainmentLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//body/div[@id='wrapper']/div[2]/div[2]/section[1]/div[1]/div[8]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/h5[1]/span[1]")]
        public IWebElement AttainmentValue { get; set; }

        public bool IsAttainmentAndProgressReportOPens()
        {
            if (SeleniumGetMethods.IsElementDisplayed(AttainmentLabel).Equals(true))
                return true;
            return false;


        }

        public void ConnectODSAndExecuteQuery(string orgId,string indicatorID)

        {

            string con = ConfigurationManager.AppSettings["ApplicationDb"];

            string Con = "Data Source=Saturn;Initial Catalog=ODSDev;Integrated Security=True";
            string query = "select *from[Organisation].[OrganisationAttainmentDFEKS2] a inner join odsdev.ods.indicator b on a.indicatorid = b.indicatorid where AcademicYear = 2020 and PupilGroupingID = 58 and a.OrganisationID = "+orgId+"  and a.IndicatorID = "+ indicatorID+"";


            SqlConnection sq = DataHelperExtensions.DBConnect(Con);
           DataTable DT= DataHelperExtensions.ExecuteQuery(sq, query);

           float OrgValue = DT.Rows[0].Field<float>(6);
             OrgValueRounded = Math.Round(OrgValue, 1, MidpointRounding.AwayFromZero);
           
        }

        public bool CompareAttainmentData()
        {

           string FrontEndValue= SeleniumGetMethods.GetText(AttainmentValue);

            if (FrontEndValue.Equals(OrgValueRounded.ToString()))

                return true;
                    return false;

        }

    }
}
