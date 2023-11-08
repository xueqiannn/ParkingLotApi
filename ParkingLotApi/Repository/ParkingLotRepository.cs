﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ParkingLotApi.Repository
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly IMongoCollection<ParkingLot> parkingLotCollection;

        public ParkingLotRepository(IOptions<ParkingLotDatabaseSetting> parkingLotDatabaseSetting)
        {
            parkingLotCollection = new MongoClient(parkingLotDatabaseSetting.Value.ConnectionString)
                .GetDatabase(parkingLotDatabaseSetting.Value.DatabaseName)
                .GetCollection<ParkingLot>(parkingLotDatabaseSetting.Value.CollectionName);
        }
        public async Task<ParkingLot> AddParkingLot(ParkingLot parkingLot)
        {
            await parkingLotCollection.InsertOneAsync(parkingLot);
            return await parkingLotCollection.Find(_=>_.Id == parkingLot.Id).FirstOrDefaultAsync();
        }

        public async Task DeleteParkingLot(string parkingLotId)
        {
            await parkingLotCollection.DeleteOneAsync(parkingLotId);
        }
    }
}
