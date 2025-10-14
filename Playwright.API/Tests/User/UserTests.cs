using Playwright.API.Models.User;
using Playwright.API.Utils;

namespace Playwright.API.Tests.User
{
   internal class UserTests : BaseTest
   {
      private readonly ReportManager.LogLevel _info = ReportManager.LogLevel.Info;

      [Test]
      public async Task User_GetAllUsers_ShouldSucceed()
      {
         ReportManager.Log(_info, "Retrieving all users.");

         var response = await _userService.GetUsersAsync();
         var body = await response.TextAsync();

         ReportManager.Log(_info, "Verifying that all users are retrieved.");
         ReportManager.Log(_info, $"<pre>{body}</pre>");

         Assert.That(response.Status, Is.EqualTo(200));
      }

      [Test]
      public async Task User_GetSingleUser_ShouldSucced()
      {
         ReportManager.Log(_info, "Retrieving a single user record.");

         var response = await _userService.GetUserAsync(2);
         var body = await response.TextAsync();

         ReportManager.Log(_info, "Verifying that a single user record is retrieved.");
         ReportManager.Log(_info, $"<pre>{body}</pre>");

         Assert.That(response.Status, Is.EqualTo(200));
      }

      [Test]
      public async Task User_CreateUserRecord_ShouldSucceed()
      {
         ReportManager.Log(_info, "Creating a user record");

         var sendBody = new UserModel
         {
            Name = "Mandy Moore",
            UserName = "MandyM",
            Email = "Mandy@email.com",
            Address = new Address
            {
               Street = "Scret",
               Suite = "ssss",
               City = "California",
               Zipcode = "2222",
               Geo = new Geo
               {
                  Lat = "111111",
                  Lng = "222222"
               }
            },
            Phone = "122 333 4444",
            Website = "mandy.com",
            Company = new Company
            {
               Name = "Dilemma",
               CatchPhrase = "No matter what I do",
               Bs = "I'm thinking over you"
            }
         };

         var response = await _userService.CreateUserAsync(sendBody);
         var responseBody = await response.TextAsync();

         ReportManager.Log(_info, "Verifying that a user record was created.");
         ReportManager.Log(_info, $"<pre>{responseBody}</pre>");

         Assert.That(response.Status, Is.EqualTo(201));
      }

      [Test]
      public async Task User_UpdateUserRecord_ShouldSucceed()
      {
         ReportManager.Log(_info, "Retrieving single post");

         var sendBody = new UserModel
         {
            Name = "Nelly  Kelly",
            UserName = "Kelly",
            Email = "Mandy@email.com",
            Address = new Address
            {
               Street = "Scret",
               Suite = "ssss",
               City = "California",
               Zipcode = "2222",
               Geo = new Geo
               {
                  Lat = "111111",
                  Lng = "222222"
               }
            },
            Phone = "122 333 4444",
            Website = "mandy.com",
            Company = new Company
            {
               Name = "Dilemma",
               CatchPhrase = "No matter what I do",
               Bs = "I'm thinking over you"
            }
         };

         var response = await _userService.UpdateUserAsync(sendBody, 2);
         var responseBody = await response.TextAsync();

         ReportManager.Log(_info, "Verifying that a user record was updated.");
         ReportManager.Log(_info, $"<pre>{responseBody}</pre>");

         Assert.That(response.Status, Is.EqualTo(200));
      }

      [Test]
      public async Task User_DeleteUser_ShouldSucceed()
      {
         ReportManager.Log(_info, "Deleting a user record.");

         var response = await _userService.DeleteUserAsync(2);

         ReportManager.Log(_info, "Verifying that a user record was deleted/removed.");
         ReportManager.Log(_info, "JsonPlaceholder doesn't actually delete anything, so for the mean time, I am going to use 200 instead of 204.");

         Assert.That(response.Status, Is.EqualTo(200));
      }
   }
}
