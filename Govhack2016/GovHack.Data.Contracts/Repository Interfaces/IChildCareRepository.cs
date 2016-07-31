using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovHack.Data.Contracts.DTOs;
using GovHack.Data.Entities;

namespace GovHack.Data.Contracts.Repository_Interfaces
{
    public interface IChildCareRepository:IBaseRepository<Locations>
    {
        IEnumerable<ChildCareDto> GetChildCareBySuburb(string suburb);

        IEnumerable<Locations> GetChildCareByFilters(string suburb, decimal maxPrice, bool isTransportation, bool isLift,
            bool isWheelChairAccess,bool isBus, bool isHospital, bool isPark, bool isSpeialNeeds,bool isNonProfit, bool isNotReligeousAffiliate);

        IEnumerable<SuburbsDTO> GetAllSuburbs();
    }
}
