using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DALMissionSkill
    {
        private readonly AppDbContext _cIDbContext;

        public DALMissionSkill(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public async Task<List<MissionSkill>> GetMissionSkillListAsync()
        {
            return await _cIDbContext.MissionSkill.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<MissionSkill> GetMissionSkillByIdAsync(int id)
        {
            return await _cIDbContext.MissionSkill.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<string> AddMissionSkillAsync(MissionSkill missionSkill)
        {
            try
            {
                _cIDbContext.MissionSkill.Add(missionSkill);
                await _cIDbContext.SaveChangesAsync();
                return "Save Skill Successfully.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error in adding skill.", ex);
            }
        }

        public async Task<string> UpdateMissionSkillAsync(MissionSkill missionSkill)
        {
            try
            {
                var existingSkill = await _cIDbContext.MissionSkill.Where(x => !x.IsDeleted && x.Id == missionSkill.Id).FirstOrDefaultAsync();
                if (existingSkill != null)
                {
                    existingSkill.SkillName = missionSkill.SkillName;
                    existingSkill.Status = missionSkill.Status;
                    await _cIDbContext.SaveChangesAsync();
                    return "Update Skill Successfully.";
                }
                else
                {
                    throw new Exception("Mission Skill is not found.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error in updating skill.", ex);
            }
        }

        public async Task<string> DeleteMissionSkillAsync(int id)
        {
            try
            {
                var existingSkill = await _cIDbContext.MissionSkill.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
                if (existingSkill != null)
                {
                    existingSkill.IsDeleted = true;
                    await _cIDbContext.SaveChangesAsync();
                    return "Delete Skill Successfully.";
                }
                else
                {
                    throw new Exception("Mission Skill is not found.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting skill.", ex);
            }
        }
    }
}
