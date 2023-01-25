using TribalWarsPlayerInfo.Helpers;
using Xunit;

namespace TribalWarsPlayerInfoTests.Helpers
{
  public class HtmlManipulatorTests
  {
    private readonly IHtmlManipulator _htmlManipulator;

    public HtmlManipulatorTests()
    {
      _htmlManipulator = new HtmlManipulator();
    }

    [Fact]
    public void OnCall_ShouldReturn_EmptyString()
    {
      var expectedResult = string.Empty;
      var initialString = "\\n\\n\\t\\n\\t \\t\\n";

      var result = _htmlManipulator.CleanHtmlTextContent(initialString);

      Assert.Equal(expectedResult, result);
    }
  }
}
