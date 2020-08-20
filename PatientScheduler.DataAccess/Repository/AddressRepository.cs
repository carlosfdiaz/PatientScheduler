﻿using PatientScheduler.DataAccess.Data;
using PatientScheduler.Models;

namespace PatientScheduler.DataAccess.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly ApplicationDbContext _db;

        public AddressRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;            
        }
    }
}
