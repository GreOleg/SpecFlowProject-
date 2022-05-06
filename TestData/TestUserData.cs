namespace SpecFlowProject.TestData
{
    public class TestUserData
    {
        public static Dictionary<string, string> userData = new Dictionary<string, string>()
        {
            ["firstNameUser"] = Faker.Name.First(),
            ["lastNameUser"] = Faker.Name.Last(),
            ["passwordUser"] = Faker.RandomNumber.Next(100000, 999999999).ToString(),
            ["addressUser"] = Faker.Address.StreetAddress(),
            ["cityUser"] = Faker.Address.City(),
            ["stateUser"] = Faker.RandomNumber.Next(1, 50).ToString(),
            ["postCodeUser"] = Faker.RandomNumber.Next(10000, 99999).ToString(),
            ["mobilePhoneUser"] = Faker.RandomNumber.Next(100000000000, 999999999999).ToString(),
        };
    }
}
