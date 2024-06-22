using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class BALMission
    {
        private readonly DALMission _dalMission;

        public BALMission(DALMission dalMission)
        {
            _dalMission = dalMission;
        }

        public List<Mission> MissionList()
        {
            return _dalMission.MissionList();
        }
        public async Task<Mission> GetMissionDetailByIdAsync(int id)
        {
            return await _dalMission.GetMissionDetailByIdAsync(id);
        }
        public string AddMission(Mission mission)
        {
            return _dalMission.AddMission(mission);
        }
        public async Task<string> UpdateMissionAsync(Mission mission)
        {
            return await _dalMission.UpdateMissionAsync(mission);
        }
        public async Task<string> DeleteMissionAsync(int id)
        {
            return await _dalMission.DeleteMissionAsync(id);
        }
        public List<Mission> ClientSideMissionList(int userId)
        {
            return _dalMission.ClientSideMissionList(userId);
        }
        public string ApplyMission(MissionApplication missionApplication)
        {
            return _dalMission.ApplyMission(missionApplication);
        }
        public string MissionApplicationApprove(int id)
        {
            return _dalMission.MissionApplicationApprove(id);
        }
        public string MissionApplicationDelete(int id)
        {
            return _dalMission.MissionApplicationDelete(id);
        }
        public List<MissionApplication> GetMissionApplicationList()
        {
            return _dalMission.GetMissionApplicationList();
        }
    }
}
