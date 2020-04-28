using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace UnitTestProject2
{
    [Binding]
    public class BookingUtils
    {
        public static HttpResponseMessage response;
        private BookingDetails details;

        internal BookingDetails Details { get => details; set => details = value; }

        [BeforeScenario]
         public static void before()
        {
            CommonUtils.Initialise();
        }
       
        [Given(@"'(.*)'")]
        public void Given(string p0)
        {
            CommonUtils.createUri(p0);
        }

        [Given(@"'(.*)'")]
        public void Given(string p0,string p1)
        {
            CommonUtils.createUri(p0);
        }


        [When(@"the request is made to fetch all booking ids")]
        public void WhenTheRequestIsMadeToFetchAllBookingIds()
        {
            response = CommonUtils.getRequest();
        }

        [Then(@"we get all booking ids with '(.*)' status")]
        public void ThenWeGetAllBookingIdsWithStatus(string p0)
        {
            List<BookingResponse> bookingIdList = JsonConvert.DeserializeObject<List<BookingResponse>>(response.Content.ReadAsStringAsync().Result);
            Assert.IsTrue(bookingIdList.Capacity >= 1);
            Assert.AreEqual(response.StatusCode.ToString(), p0);
        }

        [Given(@"the booking id '(.*)'")]
        public void GivenTheBookingId(int p0)
        {
            
            CommonUtils.createUri("/booking/"+p0.ToString());
        }

        [Given(@"the booking id in hand")]
        public void GivenTheBookingIdInHand()
        {
            Given("/booking");
            GivenTheBookingDetailsInHand();
            WhenTheRequestIsMadeToCreateABooking();
            ThenWeGetSuccessfulBookingWithStatus("OK");
            CommonUtils.createUri("/booking/" + ScenarioContext.Current.Get<int>("Id").ToString());
        }


        [When(@"the request is made to fetch details of specific book id")]
        public void WhenTheRequestIsMadeToFetchDetailsOfSpecificBookId()
        {
            response=CommonUtils.getRequest();
        }

        [Then(@"we get the details of specific book with '(.*)' status")]
        public void ThenWeGetTheDetailsOfSpecificBookWithStatus(string p0)
        {
            string reponseAsString = response.Content.ReadAsStringAsync().Result;
            details = JsonConvert.DeserializeObject<BookingDetails>(reponseAsString);
            Assert.IsNotNull(details.firstname);
            Assert.IsNotNull(details.lastname);
            Assert.AreEqual(response.StatusCode.ToString(), p0);
        }

        [Given(@"the booking details in hand")]
        public void GivenTheBookingDetailsInHand()
        {
            details= new BookingDetails();
            details.SetFirstname("Mary");
            details.SetLastname("White");
            details.SetTotalPrice(20000);
            details.SetDepositPaid(true);
            details.SetAdditionalNeeds("None");
            BookingDates bookingDate = new BookingDates(new DateTime(2020, 10, 2), new DateTime(2020, 10, 4));
            details.SetBookingDates(bookingDate) ;
            ScenarioContext.Current.Set<BookingDetails>(details,"BookingObject");
        }

        [When(@"the request is made to create a booking")]
        public void WhenTheRequestIsMadeToCreateABooking()
        {
            response=CommonUtils.postRequest(JsonConvert.SerializeObject(ScenarioContext.Current.Get<BookingDetails>("BookingObject")));
;
        }

        [Then(@"we get successful booking with '(.*)' status")]
        public void ThenWeGetSuccessfulBookingWithStatus(string p0)
        {  
            BookingDetailsResponse bookingDetailsResponse = JsonConvert.DeserializeObject<BookingDetailsResponse>(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(bookingDetailsResponse.booking.firstname, ScenarioContext.Current.Get<BookingDetails>("BookingObject").firstname);
            Assert.AreEqual(bookingDetailsResponse.booking.lastname, ScenarioContext.Current.Get<BookingDetails>("BookingObject").lastname);
            ScenarioContext.Current.Set<int>(bookingDetailsResponse.bookingid, "Id");
            Assert.AreEqual(response.StatusCode.ToString(), p0);
  
        }

        [When(@"the request is made to delete a booking")]
        public void WhenTheRequestIsMadeToDeleteABooking()
        {
            response =CommonUtils.deleteRequest();
            
        }

        [Then(@"we get all existing booking ids with '(.*)' status")]
        public void ThenWeGetAllExistingBookingIdsWithStatus(string p0)
        {
            Assert.AreEqual(response.StatusCode.ToString(), p0);
        }

    }
}
