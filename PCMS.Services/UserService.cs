using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCMS.Repositories;
using PCMS.Entities;
using PCMS.Utility;

namespace PCMS.Services
{
    public class UserService : EntityService<PortalUser>
    {
        public UserService(UnitOfWork uow)
            : base(uow)
        {

        }

        public override PortalUser Add(PortalUser entity)
        {
            PortalUser user = new PortalUser()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                DateLastLogin = DateTime.Now,
                FailLoginAttempt = 0,
                IsActive = true,
                LoginCount = 0,
                Password = BCrypt.Encrypt(entity.Password),
                Username = entity.Username
            };

            this.repository.Insert(user);
            this.uow.Save();
            return user;
        }

        public override PortalUser GetById(object Id)
        {
            return this.repository.GetById(Id);
        }

        public override IEnumerable<PortalUser> GetAll()
        {
            return this.repository.All();
        }

        private string GetPassword(Guid id)
        {
            return GetById(id).Password;
        }

        public override void Update(PortalUser entity)
        {
            PortalUser pu = new PortalUser()
            {
                Id = entity.Id,
                DateCreated = entity.DateCreated,
                DateLastLogin = entity.DateLastLogin,
                FailLoginAttempt = entity.FailLoginAttempt,
                IsActive = entity.IsActive,
                LoginCount = entity.LoginCount,
                Password = entity.Password,
                Username = entity.Username
            };

            this.repository.Update(entity);
            this.uow.Save();
        }

        public override void Delete(object Id)
        {
            this.repository.Delete(Id);
            this.uow.Save();
        }

        public PortalUser GetUserByUsername(string username)
        {
            return this.repository.SingleOrDefault(p => p.Username == username);
        }

        public bool IsUserExist(string username)
        {
            return GetUserByUsername(username) != null;
        }

        public PortalUser Login(string username, string password)
        {
            PortalUser user = GetUserByUsername(username);
            if (user != null)
            {
                bool passwordsMatching = BCrypt.Compare(password, user.Password);
                return passwordsMatching ? user : null;
            }
            else
            {
                return null;
            }
        }

        public override IEnumerable<PortalUser> GetAllWithPaging(int start, int pageSize, string orderBy = null)
        {
            return repository.GetAllWithPaging(start, pageSize,orderBy);
        }

        public override int GetCount()
        {
            return repository.GetCount();
        }
    }
}
