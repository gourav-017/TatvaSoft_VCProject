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
    public class DALMissionTheme
    {
        private readonly AppDbContext _cIDbContext;

        public DALMissionTheme(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public async Task<List<MissionTheme>> GetMissionThemeListAsync()
        {
            return await _cIDbContext.MissionTheme.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<MissionTheme> GetMissionThemeByIdAsync(int id)
        {
            return await _cIDbContext.MissionTheme.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<string> AddMissionThemeAsync(MissionTheme missionTheme)
        {
            try
            {
                _cIDbContext.MissionTheme.Add(missionTheme);
                await _cIDbContext.SaveChangesAsync();
                return "Save theme Successfully.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error in adding theme.", ex);
            }
        }

        public async Task<string> UpdateMissionThemeAsync(MissionTheme missionTheme)
        {
            try
            {
                var existingTheme = await _cIDbContext.MissionTheme.Where(x => !x.IsDeleted && x.Id == missionTheme.Id).FirstOrDefaultAsync();
                if (existingTheme != null)
                {
                    existingTheme.ThemeName = missionTheme.ThemeName;
                    existingTheme.Status = missionTheme.Status;
                    await _cIDbContext.SaveChangesAsync();
                    return "Update theme Successfully.";
                }
                else
                {
                    throw new Exception("Mission theme is not found.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error in updating theme.", ex);
            }
        }

        public async Task<string> DeleteMissionThemeAsync(int id)
        {
            try
            {
                var existingTheme = await _cIDbContext.MissionTheme.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
                if (existingTheme != null)
                {
                    existingTheme.IsDeleted = true;
                    await _cIDbContext.SaveChangesAsync();
                    return "Delete theme Successfully.";
                }
                else
                {
                    throw new Exception("Mission theme is not found.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting theme.", ex);
            }
        }
    }
}
