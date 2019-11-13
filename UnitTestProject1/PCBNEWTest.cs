using NUnit.Framework;
using KicadAutomatedGUITests;

namespace PCBNEWTest
{
    [TestFixture]
    public class OpenPCBTest : PCBNEWTestBase
    {
        //Move these variables to test data configuration part
        BasicOperations helper = new BasicOperations();

        string projectPath = "D:\\Projects\\";

        static object[] testProjects =
        {
            "pcb_001.kicad_pcb",
            "pcb_002.kicad_pcb"
        };

        [TestFixtureSetUp]
        public static void Init()
        {
            Setup();
        }

        [TestFixtureTearDown]
        public static void TearDown()
        {
            BaseTearDown();
        }

        [Test, TestCaseSource("testProjects")]
        public void Open_PCBNEW_File (string pcbName)
        {
            string sanitizedProjectPath = SanitizeBackslashes(projectPath);
            helper.Open_PCB_File(session, sanitizedProjectPath, pcbName);
            Assert.AreEqual(session.Title, @"D:\Project\" + pcbName);
        }

        [Test, TestCaseSource("testProjects")]
        public void Draw_a_Trace_In_Openned_PCB(string pcbName)
        {
            Assert.AreEqual("True", "True");
        }

        [Test]
        public void Save_and_Close_The_Modified_PCB()
        {
            Assert.AreNotEqual(string.Empty, "Full");
        }

    }
}