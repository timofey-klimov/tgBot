using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.UserProfile.Districts.AddDistrict
{
    public class AddUserDistrictRequest : TelegramRequest
    {
        public string DistrictName { get; }

        public AddUserDistrictRequest(long chatId, UserState state, string districtName) 
            : base(chatId, state)
        {
            DistrictName = districtName;
        }
    }
}
