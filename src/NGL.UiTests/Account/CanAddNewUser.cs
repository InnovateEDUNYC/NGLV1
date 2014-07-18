using System;
using TestStack.BDDfy;
using Xunit;

namespace NGL.UiTests.Account
{
    [Story(
        AsA = "Master Admin",
        IWant = "to add new user",
        SoThat = "school staff can login to the website")]
    public class CanAddNewUser
    {
        void GivenIHaveLoggedInAsAMasterAdmin()
        {
            throw new NotImplementedException();
        }

        void WhenINavigateToUsersManagerPage()
        {
            throw new NotImplementedException();            
        }

        void AndWhenICreateANewUser()
        {
            throw new NotImplementedException();            
        }

        void ThenTheUserIsCreated()
        {
            throw new NotImplementedException();            
        }

        void AndItAppearsOnTheUserLists()
        {
            throw new NotImplementedException();            
        }

        void AndTheUserCanLogin()
        {
            throw new NotImplementedException();            
        }

        [Fact]
        public void Verify()
        {
            this.BDDfy();
        }
    }
}
