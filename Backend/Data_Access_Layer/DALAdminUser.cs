using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class DALAdminUser
    {
        private readonly AppDbContext _cIDbContext;

        public DALAdminUser(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public async Task<List<UserDetail>> UserDetailsListAsync()
        {
            var userDetails = await (from u in _cIDbContext.User
                                     join ud in _cIDbContext.UserDetail on u.Id equals ud.UserId into userDeatilGroup
                                     from userDetail in userDeatilGroup.DefaultIfEmpty()
                                     where !u.IsDeleted && u.UserType == "user" && !userDetail.IsDeleted
                                     select new UserDetail
                                     {
                                         Id = u.Id,
                                         FirstName = u.FirstName,
                                         LastName = u.LastName,
                                         PhoneNumber = u.PhoneNumber,
                                         EmailAddress = u.EmailAddress,
                                         UserType = u.UserType,
                                         UserId = userDetail.Id,
                                         Name = userDetail.Name,
                                         Surname = userDetail.Surname,
                                         EmployeeId = userDetail.EmployeeId,
                                         Department = userDetail.Department,
                                         Title = userDetail.Title,
                                         Manager = userDetail.Manager,
                                         WhyIVolunteer = userDetail.WhyIVolunteer,
                                         CountryId = userDetail.CountryId,
                                         CityId = userDetail.CityId,
                                         Avilability = userDetail.Avilability,
                                         LinkdInUrl = userDetail.LinkdInUrl,
                                         MySkills = userDetail.MySkills,
                                         UserImage = userDetail.UserImage,
                                         Status = userDetail.Status,
                                     }).ToListAsync();
            return userDetails;
        }

        public async Task<string> DeleteUserAndUserDetailAsync(int userId)
        {
            try
            {
                string result = "";
                using (var transaction = await _cIDbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var userDetail = await _cIDbContext.UserDetail.FirstOrDefaultAsync(x => x.UserId == userId);
                        if (userDetail != null)
                        {
                            userDetail.IsDeleted = true;
                        }
                        var user = await _cIDbContext.User.FirstOrDefaultAsync(x => x.Id == userId);
                        if (user != null)
                        {
                            user.IsDeleted = true;
                        }

                        await _cIDbContext.SaveChangesAsync();

                        await transaction.CommitAsync();

                        result = "Delete User Successfully.";
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}

