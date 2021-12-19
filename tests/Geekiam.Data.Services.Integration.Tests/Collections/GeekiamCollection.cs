using Geekiam.Data.Services.Integration.Tests.TestFixtures;
using Xunit;

namespace Geekiam.Data.Services.Integration.Tests.Collections;

[CollectionDefinition(GlobalTestStrings.TestFixtureName)]
public class GeekiamCollection : ICollectionFixture<SqlLiteTestFixture>
{
    
}