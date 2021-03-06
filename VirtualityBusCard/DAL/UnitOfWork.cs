﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualityBusCard.Models;
using VirtualityBusCard.Repositories;

namespace VirtualityBusCard.DAL
{
    public class UnitOfWork:IDisposable
    {
        private AccountContext context = new AccountContext();


        private GenericRepository<VirtualityBusCardMessageUser> virtualityBusCardMessageUserRepository;
        private GenericRepository<VirtualityBusCardUser> virtualityBusCardUserRepository;
        private GenericRepository<WeChatAppletAppidAppSecret> weChatAppletAppidAppSecretRepository;
        private GenericRepository<WeChatUser> weChatUserRepository;
        public GenericRepository<VirtualityBusCardMessageUser> VirtualityBusCardMessageUserRepository
        {
            get
            {
                if (this.virtualityBusCardMessageUserRepository == null)
                {
                    this.virtualityBusCardMessageUserRepository = new GenericRepository<VirtualityBusCardMessageUser>(context);
                }
                return virtualityBusCardMessageUserRepository;
            }
        }
        public GenericRepository<VirtualityBusCardUser> VirtualityBusCardUserRepository
        {
            get
            {
                if (this.virtualityBusCardUserRepository == null)
                {
                    this.virtualityBusCardUserRepository = new GenericRepository<VirtualityBusCardUser>(context);
                }
                return virtualityBusCardUserRepository;
            }
        }
       public GenericRepository<WeChatAppletAppidAppSecret> WeChatAppletAppidAppSecretRepository
        {
            get
            {
                if(this.weChatAppletAppidAppSecretRepository==null)
                {
                    this.weChatAppletAppidAppSecretRepository = new GenericRepository<WeChatAppletAppidAppSecret>(context);
                }
                return weChatAppletAppidAppSecretRepository;
            }

        }
        public GenericRepository<WeChatUser> WeChatUserRepository
        {
            get
            {
                if (this.weChatUserRepository == null)
                {
                    this.weChatUserRepository = new GenericRepository<WeChatUser>(context);
                }
                return weChatUserRepository;
            }

        }

        public object SysUserRepository { get; internal set; }
        public object UserRleRepository { get; internal set; }
        #region Save & Dispose
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

}


    