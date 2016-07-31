using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovHack.Data.Contracts.DTOs;
using GovHack.Data.Contracts.Repository_Interfaces;
using GovHack.Data.Entities;

namespace GovHack.Data.Repositories.Data_Repositories
{
    public class ChildRepository : IChildCareRepository
    {
        public void Remove(Locations enitity)
        {
            using (aayaDbEntities context = new aayaDbEntities())
            {
                context.Locations.Remove(enitity);
            }
        }

        public void Remove(string id)
        {
            using (aayaDbEntities context = new aayaDbEntities())
            {
                var locationId = Convert.ToDouble(id);
                var location = context.Locations.FirstOrDefault(e => Math.Abs(e.LOCATION_ID - locationId) < 1);
                context.Locations.Remove(location);
            }

        }

        public Locations Update(Locations entity)
        {
            using (aayaDbEntities context = new aayaDbEntities())
            {
                context.Locations.AddOrUpdate(entity);
                return entity;
            }
        }

        public bool UpdateAll(IEnumerable<Locations> entities)
        {
            using (aayaDbEntities context = new aayaDbEntities())
            {
                foreach (var location in entities)
                {
                    context.Locations.AddOrUpdate(location);
                }

                return true;
            }
        }

        public IEnumerable<Locations> Get()
        {
            using (aayaDbEntities context = new aayaDbEntities())
            {
                var results = context.Locations;
                return results;
            }
        }

        public Locations Get(string id)
        {
            using (aayaDbEntities context = new aayaDbEntities())
            {
                var locationId = Convert.ToDouble(id);
                var location = context.Locations.FirstOrDefault(e => Math.Abs(e.LOCATION_ID - locationId) < 1);
                return location;
            }
        }

        public IEnumerable<ChildCareDto> GetChildCareBySuburb(string suburb)
        {
            using (aayaDbEntities context = new aayaDbEntities())
            {
                suburb = suburb.ToLower();
                var sampleSet = context.Locations.Where(e => e.SUBURB.ToLower() == suburb).Select(e => new ChildCareDto
                {
                    Name = e.PROVIDER_NAME,
                    Address = e.ADDRESS,
                    PhoneNumber = "0423494591",

                });
                var results = sampleSet.ToList();

                results.ForEach((item) =>
                {
                    item.Availability = GetDummyVacancies();
                });

                return results;
            }
        }

        public IEnumerable<Locations> GetChildCareByFilters(string suburb, decimal maxPrice, bool isTransportation, bool isLift,
            bool isWheelChairAccess, bool isBus, bool isHospital, bool isPark, bool isSpeialNeeds, bool isNonProfit,
            bool isNotReligeousAffiliate)
        {
            //TBD CALCULATE DISTANCE BETWEEN TRANSPORT LOCATIONS AND CHILD CARE CENTERS IN ORDER TO GET ACCURATE RESULTS
            //THIS IS JUST A MOCK UP OF WHAT THE ACTUAL THING WOULD LOOK LIKE - ASHISH CHETTRI
            using (aayaDbEntities context = new aayaDbEntities())
            {
                suburb = suburb.ToLower();
                var result = context.Locations.Where(e => e.SUBURB.ToLower() == suburb);

                if (maxPrice > 0)
                {
                    var childCareCenters = context.ChildCareOperations.Where(e => e.HourlyPrice <= maxPrice);
                    result = (from e1 in result
                              join e2 in childCareCenters
                                  on e1.LOCATION_ID equals e2.LocationId
                              select e1);
                }

                if (isBus)
                {
                    var busLocales = context.transport.Where(e => e.Bus == true);
                    result = (from e1 in result
                              join e2 in busLocales
                                  on e1.SUBURB equals e2.LOCATION_NAME
                              select e1);
                }
                if (isTransportation)
                {
                    var transportLocales = context.transport.Where(e => e.Bus == true || e.IsTrain == true);
                    result = (from e1 in result
                              join e2 in transportLocales
                                  on e1.SUBURB equals e2.LOCATION_NAME
                              select e1);
                }
                if (isLift)
                {
                    var liftLocales = context.transport.Where(e => e.Lift == true);
                    result = (from e1 in result
                              join e2 in liftLocales
                                  on e1.SUBURB equals e2.LOCATION_NAME
                              select e1);
                }
                if (isWheelChairAccess)
                {
                    var wheelChairLocales = context.transport.Where(e => e.Wheelchairaccessible == true);
                    result = (from e1 in result
                              join e2 in wheelChairLocales
                                  on e1.SUBURB equals e2.LOCATION_NAME
                              select e1);
                }

                //TBD IMPLEMENT FILTERS FOR HOSPITAL + CHECKLIST
                return result.ToList();
            }
        }

        public IEnumerable<Vacancies> GetDummyVacancies()
        {
            List<Vacancies> result = new List<Vacancies>();
            Vacancies vacancy = new Vacancies
            {
                Key = Guid.NewGuid().ToString(),
                Category = "1 - 2 years",
                Count = 2
            };
            result.Add(vacancy);
            vacancy = new Vacancies
            {
                Key = Guid.NewGuid().ToString(),
                Category = "2 - 4 years",
                Count = 4
            };
            result.Add(vacancy);
            vacancy = new Vacancies
            {
                Key = Guid.NewGuid().ToString(),
                Category = "4 - 6 years",
                Count = 2
            };
            result.Add(vacancy);
            return result;
        }

        public IEnumerable<SuburbsDTO> GetAllSuburbs()
        {
            using (aayaDbEntities context = new aayaDbEntities())
            {
                var result = context.Locations.Take(100).Select(e => new SuburbsDTO
                {
                    Name = e.SUBURB
                });
                return result.ToList();
            }
        }
    }
}
