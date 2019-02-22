﻿namespace GPConnect.Provider.AcceptanceTests.Steps
{
    using System.Collections.Generic;
    using System.Linq;
    using Context;
    using Hl7.Fhir.Model;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Constants;
    using Enum;
    using Http;


    [Binding]
    public class AmendAppointmentSteps : Steps
    {
        private readonly HttpContext _httpContext;
        private List<Appointment> Appointments => _httpContext.FhirResponse.Appointments;

        public AmendAppointmentSteps(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }
        
        [Then(@"the Appointment Description should be valid for ""(.*)""")]
        public void TheAppointmentDescriptionShouldBeValidFor(string value)
        {
            Appointments.ForEach(appointment =>
            {
                appointment.Description.ShouldNotBeNull("Appointment description cannot be null");
                appointment.Description.ShouldContain(value, $@"The Appointment Description should be ""{value}"" but was ""{appointment.Description}"".");
            });
        }

        [Then(@"the Appointment Comment should be valid for ""(.*)""")]
        public void TheAppointmentCommentShouldBeValidFor(string value)
        {
            Appointments.ForEach(appointment =>
            {
                appointment.Comment.ShouldBe(value, $@"The Appointment Description should be ""{value}"" but was ""{appointment.Comment}"".");
            });
        }

        // git hub ref 190 (demonstrator)
        // RMB 6/2/19
        [Then(@"the Appointment Comment should be null")]
        public void TheAppointmentCommentShouldBeNull()
        {
            Appointments.ForEach(appointment =>
            {
                appointment.Comment.ShouldBeNull("Appointment Comment should be Null");
            });
        }
    }
}
