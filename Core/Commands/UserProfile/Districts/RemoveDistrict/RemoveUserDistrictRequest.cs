using Core.Commands.Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.UserProfile.Districts.RemoveDistrict
{
    public class RemoveUserDistrictRequest : TelegramRequest
    {
        public string DistrictName { get; }

        public RemoveUserDistrictRequest(long chatId, UserState state, string districtName) 
            : base(chatId, state)
        {
            DistrictName = districtName;
        }
    }
}
