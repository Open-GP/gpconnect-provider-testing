﻿namespace GPConnect.Provider.AcceptanceTests.Steps
{
    using System.Collections.Generic;
    using System.Linq;
    using Context;
    using Hl7.Fhir.Model;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Constants;

    [Binding]
    public class LocationSteps : BaseSteps
    {
        private readonly HttpContext _httpContext;
        private List<Location> Locations => _httpContext.FhirResponse.Locations;

        public LocationSteps(HttpContext httpContext, HttpSteps httpSteps) 
            : base(httpSteps)
        {
            _httpContext = httpContext;
        }

        [Then(@"the Response Resource should be a Location")]
        public void TheResponseResourceShouldBeALocation()
        {
            _httpContext.FhirResponse.Resource.ResourceType.ShouldBe(ResourceType.Location);
        }

        [Then(@"the Location Id should be valid")]
        public void TheLocationIdShouldBeValid()
        {
            Locations.ForEach(location =>
            {
                location.Id.ShouldNotBeNullOrEmpty($"The Location Id should not be null or empty but was {location.Id}.");
            });
        }

        [Then(@"the Location Id should equal the Request Id")]
        public void TheLocationIdShouldEqualTheRequestId()
        {
            Locations.ForEach(location =>
            {
                location.Id.ShouldBe(_httpContext.HttpRequestConfiguration.GetRequestId, $"The Location Id should be equal to {_httpContext.HttpRequestConfiguration.GetRequestId} but was {location.Id}.");
            });
        }

        [Then(@"the Location Type should be valid")]
        public void TheLocationTypeShouldBeValid()
        {
            Locations.ForEach(location =>
            {
                var locationType = location.Type;

                if (locationType != null)
                {
                    // locationType codeable concept binding is extensible
                    // ideally I would check if it was of FhirConst.ValueSetSystems.kServDelLocationRoleType
                    // and if so check the code
                    // as extensible is does not need to be of FhirConst.ValueSetSystems.kServDelLocationRoleType

                    //var serviceDeliveryLocationRoleTypes = GlobalContext.GetFhirGpcValueSet(FhirConst.ValueSetSystems.kServDelLocationRoleType).WithComposeImports();

                    foreach (var coding in locationType.Coding)
                    {
                        coding.System.ShouldNotBeNullOrEmpty("The Location Type Coding should contain a System Value.");

                        //if (coding.System.Equals(FhirConst.ValueSetSystems.kServDelLocationRoleType) && serviceDeliveryLocationRoleTypes != null)
                        //{
                        //        coding.Code.ShouldBeOneOf(serviceDeliveryLocationRoleTypes.ToArray(), "The Location Type Coding should contain a Code.");
                        //}

                        coding.Code.ShouldNotBeNullOrEmpty("The Location Type Coding should contain a Code.");
                        coding.Display.ShouldNotBeNullOrEmpty("The Location Type Coding should contain a Display.");
                    }
                }
            });
        }

        [Then(@"the Location Physical Type should be valid")]
        public void TheLocationPhysicalTypeShouldBeValid()
        {
            Locations.ForEach(location =>
            {
                if (location.PhysicalType?.Coding != null)
                {
                    foreach (var coding in location.PhysicalType.Coding)
                    {
                        coding.System.ShouldNotBeNullOrEmpty("The Location PhysicalType Coding System should not be null or empty.");
                        coding.Code.ShouldNotBeNullOrEmpty("The Location Physical Type Coding should contain a Code.");
                        coding.Display.ShouldNotBeNullOrEmpty("The Location Physical Type Coding should contain a Display.");
                    }
                }
            });
        }

        [Then(@"the Location PartOf Location should be valid")]
        public void TheLocationPartOfLocationShouldBeValid()
        {
            Locations.ForEach(location =>
            {
                location.PartOf?.Reference?.ShouldStartWith("Location/", "The reference element within the PartOf element of the Location resource should contain a relative Location reference.");
            });
        }

        [Then(@"the Location Managing Organization should be valid")]
        public void TheLocationManagingOrganizationShouldBeValid()
        {
            Locations.ForEach(location =>
            {
                location.ManagingOrganization?.Reference?.ShouldStartWith("Organization/", "The ManagingOrganization reference should be a relative url for an Organization.");
            });
        }

        [Then(@"the Location should be valid")]
        public void TheLocationShouldBeValid()
        {
            TheLocationMetadataShouldBeValid();
            TheLocationIdentifierShouldBeValid();
            TheLocationTypeShouldBeValid();
            TheLocationPhysicalTypeShouldBeValid();
            TheLocationPartOfLocationShouldBeValid();
            TheLocationManagingOrganizationShouldBeValid();
        }

        [Then(@"the Location Metadata should be valid")]
        public void TheLocationMetadataShouldBeValid()
        {
            Locations.ForEach(location =>
            {
                CheckForValidMetaDataInResource(location, FhirConst.StructureDefinitionSystems.kLocation);
            });
        }

        [Then(@"the Location Telecom should be valid")]
        public void TheLocationTelecomShouldBeValid()
        {

            Locations.ForEach(location =>
            {
                ValidateTelecom(location.Telecom, "Location Telecom");
            });
        }

        [Then(@"the Location Status should be valid")]
        public void TheLocationStatusShouldBeValid()
        {

            Locations.ForEach(location =>
            {
                location.Status?.ShouldBeOfType<Location.LocationStatus>($"If a Location Status is supplied it must be one of {System.Enum.GetNames(typeof(Location.LocationStatus))}");
            });
        }

        [Then(@"the Location Id should match the GET request Id")]
        public void TheLocationIdShouldMarchTheGetRequestId()
        {
            var location = Locations.FirstOrDefault();

            location.ShouldNotBeNull();
            location.Id.ShouldBe(_httpContext.HttpRequestConfiguration.GetRequestId);
        }

        [Then(@"the Location Identifier should be valid")]
        public void TheLocationIdentifierShouldBeValid()
        {
            TheLocationIdentifierShouldBeValidForValue(null);
        }

        [Then(@"the Location Identifier should be valid for Value ""([^""]*)""")]
        public void TheLocationIdentifierShouldBeValidForValue(string locationName)
        {
            Locations.ForEach(location =>
            {
                var siteCodeIdentifiers = location.Identifier
                    .Where(identifier => identifier.System.Equals(FhirConst.IdentifierSystems.kOdsSiteCode))
                    .ToList();

                siteCodeIdentifiers.Count.ShouldBeLessThanOrEqualTo(1, "There should be a maximum of one ods site code in the location resource");

                siteCodeIdentifiers.ForEach(si =>
                {
                    si.System.ShouldNotBeNullOrEmpty("Location Identifier System must have a value.");
                    si.Value.ShouldNotBeNullOrEmpty("Location Identifier Value must have a value.");
                });

                if (!string.IsNullOrEmpty(locationName))
                {
                     siteCodeIdentifiers.ForEach(siteCodeIdentifier =>
                    {
                        siteCodeIdentifier.Value.ShouldBe(GlobalContext.OdsCodeMap[locationName], "Location business identifier does not match the expected business identifier.");
                    });
                }

            });
        }
    }
}
