/*
 * This file contains a MessageService class with a method that handles creating a record in the database.
*/

using Models;
using Models.DTO;
using MongoDB.Driver;
using Services.Interface;
using System;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly IMongoClient _mongoClient;
        public MessageService(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }
        public async Task<Tuple<bool, string>> SendMessage(MessageToAddDto model, string companyName)
        {
            //define the database using the company name as DBName
            var database = _mongoClient.GetDatabase(companyName);
            //Get the collection 
            var collection = database.GetCollection<Message>("formMessages");
            //If it is null, create new database
            if (collection == null) await database.CreateCollectionAsync("formMessages");

            //map the MessageToSendDto to Message Model
            var message = new Message
            {
                Name = model.customerName,
                Email = model.customerEmail,
                MessageText = model.customerMessage,
                FormName = model._formName,
                FormDomainName = model._formDomainName
            };
            try
            {
                //Insert the message to collection
                await collection.InsertOneAsync(message);
                return new Tuple<bool, string>(true, "Message Added Successfully");
            }
            catch (NullReferenceException e)
            {
                return new Tuple<bool, string>(false, "Failed to Add Message: " + e.Message.ToString());
            }
        }
    }
}
