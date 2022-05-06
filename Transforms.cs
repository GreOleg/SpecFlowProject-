using SpecFlowProject.TestData;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class Transforms
    {
        [StepArgumentTransformation(@"(.*) email")]
        public string EmailTransforms(string expression)
        {
            return Faker.Internet.Email();
        }
        [StepArgumentTransformation(@"(.*) data")]
        public Dictionary<string, string> UserDataTransforms(string expression)
        {
            return TestUserData.userData;
        }
    }
}
