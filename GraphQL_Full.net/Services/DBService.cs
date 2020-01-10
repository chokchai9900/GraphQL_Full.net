using GraphQL_Full.net.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Full.net.Services
{
    public class DBService
    {
        private readonly IMongoCollection<userModel> _user;
        private readonly IMongoCollection<companyModel> _company;

        public DBService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<userModel>(settings.UserCollectionName);
            _company = database.GetCollection<companyModel>(settings.CompanyCollectionName);
        }
        public List<userModel> GetAllUser() =>
            _user.Find(user => true).ToList();
        public userModel GetUserByID(string id) =>
            _user.Find(user => user._id == id).FirstOrDefault();

        public List<companyModel> GetAllCompany() =>
            _company.Find(company => true).ToList();
        public companyModel GetCompanyByID(string id) =>
            _company.Find(company => company._id == id).FirstOrDefault();

        public userModel CreateCompany(userModel data)
        {
            const string charT = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var randomPrefix = Enumerable.Repeat(charT, 16).Select(it => it[random.Next(36)]).ToList();
            const string headerID = "5de76602";
            var result = String.Join("", randomPrefix);
            data._id = $"{headerID}{result}";
            _user.InsertOne(data);
            return data;
        }
        public void UpdateUserByID(userModel baseUser, userModel UserInput)
        {
            UserInput._id = baseUser._id;
            _user.ReplaceOne(it => it._id == baseUser._id, UserInput);
        }

        public void RemoveUser(string id)
        {
            _user.DeleteOne(it => it._id == id);
        }
    }
}
